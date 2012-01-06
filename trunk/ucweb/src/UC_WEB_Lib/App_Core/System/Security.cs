using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Configuration;
using System.Web.Configuration;

using UCENTRIK.DATASETS;
using UCENTRIK.BLL;



namespace UCENTRIK.Membership
{
    public class UserAccount
    {
        private Int32 _userId;
        private string _username;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _passwordSalt;
        private Int32 _userRoleId;
        private string _timeZone;
        private Int32 _loginAttempts;
        private bool _isLockedOut;
        private bool _isNew;

        public Int32 UserId
        {
            get { return  _userId; }
            set { _userId = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string FirstName
        {
            get { return  _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return  _lastName; }
            set { _lastName = value; }
        }
        public string Password
        {
            get { return  _password; }
            set { _password = value; }
        }
        public string PasswordSalt
        {
            get { return  _passwordSalt; }
            set { _passwordSalt = value; }
        }
        public Int32 UserRoleId
        {
            get { return  _userRoleId; }
            set { _userRoleId = value; }
        }
        public string TimeZone
        {
            get { return _timeZone; }
            set { _timeZone = value; }
        }
        public Int32 LoginAttempts
        {
            get { return  _loginAttempts; }
            set { _loginAttempts = value; }
        }
        public bool IsLockedOut
        {
            get { return  _isLockedOut; }
            set { _isLockedOut = value; }
        }
        public bool IsNew
        {
            get { return _isNew; }
        }
        public bool IsExpired
        {
            get
            {
                AuthenticationSection authSection = ConfigurationManager.GetSection("system.web/authentication") as AuthenticationSection;
                TimeSpan _ttl = authSection.Forms.Timeout;
                if (this._accessed.Add(_ttl) < DateTime.Now)
                    return true;
                else
                    return false;
            }
            
        }

        private DateTime _created;
        private DateTime _accessed;

        public UserAccount(string userName)
        {
            _username = userName;

            RefreshAccountInfo();

            this._created = DateTime.Now;
            this._accessed = DateTime.Now;
        }

        public void RefreshAccountInfo()
        {
            UserDS.UserDSDataTable dt = BllUser.GetUser(_username);
            if (dt.Rows.Count > 0)
            {
                _isNew = false;

                _userId = dt[0].user_id;
                
                _firstName = dt[0].first_name;
                _lastName = dt[0].last_name;

                _password = dt[0].password;
                _passwordSalt = dt[0].password_salt;

                _userRoleId = dt[0].user_role_id;
                _timeZone = dt[0].time_zone;

                _loginAttempts = dt[0].login_attempts;
                _isLockedOut = dt[0].is_locked_out;
            }
            else
            {
                _userId = 0;

                _firstName = null;
                _lastName = null;

                _password = null;
                _passwordSalt = null;

                _userRoleId = 0;
                _timeZone = null;

                _loginAttempts = 0;
                _isLockedOut = false;

                _isNew = true;
            }
        }

        public bool IsValid(string userName, string password)
        {
            if ((_username == userName) && (_password == password))
            {
                this._accessed = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool IsExpired(string userName)
        //{
        //    return false;
        //}

        public void Refresh()
        {
            this._accessed = DateTime.Now;
        }

        public void Update()
        {
            UserDS.UserDSDataTable dt = BllUser.GetUser(this._username);
            if (dt.Rows.Count != 0)
            {
                _firstName = dt[0].first_name;
                _lastName = dt[0].last_name;

                _password = dt[0].password;
                _passwordSalt = dt[0].password_salt;

                _userRoleId = dt[0].user_role_id;
                _timeZone = dt[0].time_zone;

                _loginAttempts = dt[0].login_attempts;
                _isLockedOut = dt[0].is_locked_out;
            }


            this._accessed = DateTime.Now;
        }
    }

    public class UserPool
    {
        private Hashtable table;

        public Hashtable Table
        {
            get
            {
                return (Hashtable)table.Clone();
            }
        }

        public UserPool()
        {
            table = new Hashtable();
        }

        public bool IfUserExists(string userName)
        {
            bool result = false;

            //if (!String.IsNullOrEmpty(userName))
            //{
            //    UserAccount userAccount = (UserAccount)table[userName];
            //    if (userAccount != null)
            //        if (!userAccount.IsExpired)     //if (!userAccount.IsExpired(userName))
            //            result = true;

            //}

            return result;
        }

        public bool RegisterUser(string userName, string password)
        {
            bool result = false;
            UserAccount userAccount;
            if (table.Contains(userName))
            {
                userAccount = (UserAccount)table[userName];
                userAccount.RefreshAccountInfo();
                if (userAccount.IsValid(userName, password))
                {
                    result = true;
                }
            }
            else
            {
                userAccount = new UserAccount(userName);
                if (!userAccount.IsNew)
                {
                    if (userAccount.IsValid(userName, password))
                    {
                        table.Add(userName, userAccount);
                        result = true;
                    }
                }
            }

            //if (result)
            //  BllUser.Login(userName);

            BllUser.Login(userName, result);

            return result;
        }

        public void RemoveUser(string username)
        {
            if (table.Contains(username))
            {
                table.Remove(username);
            }
        }

        public bool ValidateUser(string userName)
        {
            bool result = false;

            if (!String.IsNullOrEmpty(userName))
            {
                UserAccount userAccount = (UserAccount)table[userName];
                if (userAccount != null)
                    if (!userAccount.IsExpired)     //if (!userAccount.IsExpired(userName))
                        result = true;

            }
            //this.test(userName);

            return result;
        }

        public Int32 GetUserRoleId(string username)
        {
            Int32 roleId = 0;
            UserAccount userAccount = (UserAccount)table[username];
            if (userAccount != null)
            {
                userAccount.Refresh();
                roleId = userAccount.UserRoleId;
            }
            return roleId;
        }

        public string GetUserTimeZone(string username)
        {
            string timeZone = "";
            UserAccount userAccount = (UserAccount)table[username];
            if (userAccount != null)
            {
                userAccount.Refresh();
                timeZone = userAccount.TimeZone;
            }
            return timeZone;
        }
        //public void SetUserTimeZone(string username, string timeZone)
        //{
        //    UserAccount userAccount = (UserAccount)table[username];
        //    if (userAccount != null)
        //    {
        //        userAccount.TimeZone = timeZone;
        //        userAccount.Refresh();
        //    }
        //}




        public void ReloadUserData(string username)
        {
            UserAccount userAccount = (UserAccount)table[username];
            if (userAccount != null)
                userAccount.Update();
        }





        public void CleanUp()
        {
            Hashtable tableToClear = new Hashtable();

            foreach (UserAccount user in table.Values)
            {
                if (user.IsExpired)
                {
                    tableToClear.Add(user.Username, null);
                }
            }


            foreach (string username in tableToClear.Keys)
            {
                table.Remove(username);
            }
        }


        public Int32 Count
        {
            get
            {
                return table.Count;
            }
        }


        //------------------------------------------------


        public Int32 GetUserId(string userName)
        {
            Int32 userId = 0;
            UserAccount userAccount;
            if (table.Contains(userName))
            {
                userAccount = (UserAccount)table[userName];
                    
                userId = userAccount.UserId;
            }

            return userId;
        }




    }




}
