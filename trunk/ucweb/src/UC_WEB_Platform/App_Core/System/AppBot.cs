using System;
using System.Threading;

using UCENTRIK.ROUTING;
using UCENTRIK.LIB.CoreSystem;



namespace UCENTRIK.GLOBAL
{
    public class UcAppBot
    {
        private AgentPool _agentPool;

        public UcAppBot(AgentPool agentPool)
        {
            _agentPool = agentPool;

            Thread threadBot = new Thread(this._doRoutine);
            threadBot.Start();
        }

        private void _doRoutine()
        {
            Thread.Sleep(15000);        // delay 15 sec

            try
            {
                while (true)
                {
                    _agentPool.DoRoutine();
                    Thread.Sleep(1000);     // repeat every 1 sec
                }
            }
            catch (ThreadAbortException)
            {
                //Warning: ASP.NET aborts current thread
            }
            catch (Exception ex)
            {
                UcSystem.HandleException(ex, "[_UcAppBot_]", "");
            }
        }
    }
}
