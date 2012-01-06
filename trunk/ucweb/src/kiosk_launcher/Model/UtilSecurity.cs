using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Security;
using System.Diagnostics;
using System.Security.Principal;
using System.Text;
using System.Collections;

namespace KioskLauncher.Model
{
	class UtilSecurity
	{
		static readonly log4net.ILog ___log =
			log4net.LogManager.GetLogger( typeof( UtilSecurity ).ToString() );

		[StructLayout( LayoutKind.Sequential )]
		struct STARTUPINFO
		{
			public Int32 cb;
			public string lpReserved;
			public string lpDesktop;
			public string lpTitle;
			public Int32 dwX;
			public Int32 dwY;
			public Int32 dwXSize;
			public Int32 dwXCountChars;
			public Int32 dwYCountChars;
			public Int32 dwFillAttribute;
			public Int32 dwFlags;
			public Int16 wShowWindow;
			public Int16 cbReserved2;
			public IntPtr lpReserved2;
			public IntPtr hStdInput;
			public IntPtr hStdOutput;
			public IntPtr hStdError;
		}

		[StructLayout( LayoutKind.Sequential )]
		struct PROCESS_INFORMATION
		{
			public IntPtr hProcess;
			public IntPtr hThread;
			public Int32 dwProcessID;
			public Int32 dwThreadID;
		}

		[StructLayout( LayoutKind.Sequential )]
		struct SECURITY_ATTRIBUTES
		{
			public Int32 Length;
			public IntPtr lpSecurityDescriptor;
			public bool bInheritHandle;
		}

		enum SECURITY_IMPERSONATION_LEVEL
		{
			SecurityAnonymous,
			SecurityIdentification,
			SecurityImpersonation,
			SecurityDelegation
		}

		enum TOKEN_TYPE
		{
			TokenPrimary = 1,
			TokenImpersonation
		} 

		[DllImport( "user32.dll" )]
		extern static uint GetWindowThreadProcessId( IntPtr hWnd, out uint lpdwProcessId );
		//[DllImport( "user32.dll" )]
		//extern static IntPtr GetDesktopWindow();
		[DllImport( "user32.dll" )]
		extern static IntPtr GetShellWindow();

		[DllImport( "kernel32", SetLastError = true ), SuppressUnmanagedCodeSecurityAttribute]
		extern static bool CloseHandle( IntPtr handle );

		[DllImport( "advapi32", SetLastError = true ), SuppressUnmanagedCodeSecurityAttribute]
		extern static int OpenProcessToken
			( IntPtr ProcessHandle // handle to process
			, uint DesiredAccess // desired access to process
			, ref IntPtr TokenHandle // handle to open access token
			);
		//[DllImport( "advapi32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		//extern static bool DuplicateToken
		//    ( IntPtr ExistingTokenHandle
		//    , int SECURITY_IMPERSONATION_LEVEL
		//    , ref IntPtr DuplicateTokenHandle
		//    );
		[DllImport( "advapi32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		extern static bool DuplicateTokenEx
			( IntPtr hExistingToken
			, uint dwDesiredAccess
			, ref SECURITY_ATTRIBUTES lpTokenAttributes
			, SECURITY_IMPERSONATION_LEVEL ImpersonationLevel
			, TOKEN_TYPE TokenType
			, out IntPtr phNewToken
			);
		//[DllImport( "advapi32.dll", SetLastError = true, CharSet = CharSet.Auto )]
		//extern static bool CreateProcessAsUser
		//    ( IntPtr hToken
		//    , string lpApplicationName
		//    , string lpCommandLine
		//    , ref SECURITY_ATTRIBUTES lpProcessAttributes
		//    , ref SECURITY_ATTRIBUTES lpThreadAttributes
		//    , bool bInheritHandles
		//    , uint dwCreationFlags
		//    , IntPtr lpEnvironment
		//    , string lpCurrentDirectory
		//    , ref STARTUPINFO lpStartupInfo
		//    , out PROCESS_INFORMATION lpProcessInformation
		//    );
		[DllImport( "advapi32", SetLastError = true, CharSet = CharSet.Unicode )]
		extern static bool CreateProcessWithTokenW
			( IntPtr hToken
			, uint dwLogonFlags
			, string lpApplicationName
			, string lpCommandLine
			, uint dwCreationFlags
			, IntPtr lpEnvironment
			, string lpCurrentDirectory
			, [In] ref STARTUPINFO lpStartupInfo
			, out PROCESS_INFORMATION lpProcessInformation
			);

		const uint TOKEN_ASSIGN_PRIMARY = 0x1;
		const uint TOKEN_DUPLICATE = 0x2;
		const uint TOKEN_IMPERSONATE = 0x4;
		const uint TOKEN_QUERY = 0x8;
		const uint TOKEN_QUERY_SOURCE = 0x10;
		const uint TOKEN_ADJUST_PRIVILEGES = 0x20;
		const uint TOKEN_ADJUST_GROUPS = 0x40;
		const uint TOKEN_ADJUST_DEFAULT = 0x80;
		const uint TOKEN_ADJUST_SESSIONID = 0x100;
		const uint READ_CONTROL = 0x00020000;

		//internal static IntPtr GetExplorerProcessHandle()
		//{
		//    IntPtr hwnd = GetShellWindow();
		//    uint id_process;
		//    uint id_thread = GetWindowThreadProcessId( hwnd, out id_process );

		//    ___log.Debug( string.Format( "thread={0} process={1} hwnd={2}", id_thread, id_process, hwnd.ToString() ) );

		//    return Process.GetProcessById( (int) id_process ).Handle;
		//}

		internal static void AddVariable( StringBuilder sb, string key, string value )
		{
			___log.Debug( string.Format( "AddVariable: {0}={1}", key, value ) );

			sb.Append( key );
			sb.Append( '=' );
			sb.Append( value );
			sb.Append( '\0' );
		}

		internal static void RunAsExplorerUser( string path, string args, string folder, string[] vars )
		{
			IntPtr hwnd = GetShellWindow();
			uint id_process;
			uint id_thread = GetWindowThreadProcessId( hwnd, out id_process );

			Process process = Process.GetProcessById( (int) id_process );

			___log.Debug( string.Format( "Shell: thread={0} process={1} hwnd={2}", id_thread, id_process, hwnd.ToString() ) );

			uint access
				= TOKEN_ASSIGN_PRIMARY
				| TOKEN_DUPLICATE
				| TOKEN_QUERY
				| TOKEN_ADJUST_DEFAULT
				//| TOKEN_ADJUST_PRIVILEGES
				| TOKEN_ADJUST_SESSIONID
				| READ_CONTROL
				;

			IntPtr token = IntPtr.Zero;
			IntPtr token_dup = IntPtr.Zero;
			GCHandle gchandle = new GCHandle();

			for( ; ; )
			{
				if( OpenProcessToken( process.Handle, access, ref token ) == 0 )
				{
					___log.Error( "OpenProcessToken " + Marshal.GetLastWin32Error() );
					return;
				}

				SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
				sa.Length = Marshal.SizeOf( sa );

				if( !DuplicateTokenEx
					( token
					, access
					, ref sa
					, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation
					, TOKEN_TYPE.TokenPrimary
					, out token_dup
					) )
				{
					___log.Error( "DuplicateTokenEx " + Marshal.GetLastWin32Error() );
					return;
				}

				STARTUPINFO startupInfo = new STARTUPINFO();
				startupInfo.cb = Marshal.SizeOf( startupInfo );
				//startupInfo.lpDesktop = "";

				PROCESS_INFORMATION processInfo = new PROCESS_INFORMATION();

				IntPtr env = IntPtr.Zero;
				if( vars != null )
				{
					SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
					foreach( DictionaryEntry de in Environment.GetEnvironmentVariables() )
						dic.Add( de.Key as string, de.Value as string );
					for( int i = 0; i < vars.Length; i += 2 )
						dic.Add( vars[ i ], vars[ i + 1 ] );

					StringBuilder sb = new StringBuilder();
					foreach( string key in dic.Keys )
					{
						___log.Debug( string.Format( "Env: {0}={1}", key, dic[ key ] ) );

						sb.Append( key );
						sb.Append( '=' );
						sb.Append( dic[ key ] );
						sb.Append( '\0' );
					}
					sb.Append( '\0' );

					byte[] buf = Encoding.Unicode.GetBytes( sb.ToString() );
					___log.Debug( "Env: " + buf.Length );

					gchandle = GCHandle.Alloc( buf, GCHandleType.Pinned );
					env = gchandle.AddrOfPinnedObject();
				}

				if( !CreateProcessWithTokenW
					( token_dup
					, 0
					, path
					, "\"" + path + "\" " + args
					, 0x400 //CREATE_UNICODE_ENVIRONMENT
					, env
					, folder
					, ref startupInfo
					, out processInfo
					) )
				{
					___log.Error( "CreateProcessWithTokenW " + Marshal.GetLastWin32Error() );
				}
				else
				{
					CloseHandle( processInfo.hProcess );
					CloseHandle( processInfo.hThread );
				}

				break;
			}

			if( gchandle.IsAllocated )
				gchandle.Free();
			if( token != IntPtr.Zero )
				CloseHandle( token );
			if( token_dup != IntPtr.Zero )
				CloseHandle( token_dup );
		}
	}
}
