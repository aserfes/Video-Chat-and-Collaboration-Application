using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Threading;



using UCENTRIK.DATASETS;
using UCENTRIK.BLL;
using UCENTRIK.LIB.CoreSystem;
using UCENTRIK.LIB.BllProxy;


namespace UCENTRIK.Conference
{


    /// <summary>
    /// -------------------------------------------------------------------------------------
    /// UcTextChatSession
    /// </summary>
    internal class UcTextChatSession
    {

        protected Guid id;
        protected DateTime timeStamp;
        protected ArrayList list;




        public Guid Id
        {
            get
            {
                return id;
            }
        }
        public DateTime TimeStamp
        {
            get
            {
                return timeStamp;
            }
        }




        public UcTextChatSession()
        {
            this.id = Guid.NewGuid();
            this.timeStamp = DateTime.Now.ToUniversalTime();
            this.list = new ArrayList();
        }


        public void AddMessage(UcTextChatMessage message)
        {
            list.Add(message);
            this.timeStamp = DateTime.Now.ToUniversalTime();
        }

        public UcTextChatMessage[] GetAllMessages()
        {
            return (UcTextChatMessage[])this.list.ToArray(typeof(UcTextChatMessage));
        }

        public UcTextChatMessage[] GetMessages(Int32 num)
        {
            ArrayList listOutput = (ArrayList)this.list.Clone();
            Int32 count = listOutput.Count;
            if (count > num)
            {
                num = count - num;
                listOutput.RemoveRange(0, num);
            }
            return (UcTextChatMessage[])listOutput.ToArray(typeof(UcTextChatMessage));

            //return (UcTextChatMessage[])this.list.ToArray(typeof(UcTextChatMessage));
        }




    }

    /// <summary>
    /// -------------------------------------------------------------------------------------
    /// UcTextChatMessage
    /// </summary>
    public class UcTextChatMessage
    {
        protected Guid id;
        protected DateTime timeStamp;
        protected string senderName;
        protected string messageText;

        public Guid Id
        {
            get
            {
                return id;
            }
        }
        public DateTime TimeStamp
        {
            get
            {
                return timeStamp;
            }
        }
        public string SenderName
        {
            set
            {
                senderName = value;
            }
            get
            {
                return senderName;
            }
        }
        public string MessageText
        {
            set
            {
                messageText = value;
            }
            get
            {
                return messageText;
            }
        }




        //public UcTextChatMessage()
        //{
        //    this.id = Guid.NewGuid();
        //    this.timeStamp = DateTime.Now.ToUniversalTime();
        //}

        public UcTextChatMessage(string senderName, string messageText)
        {
            this.id = Guid.NewGuid();
            this.timeStamp = DateTime.Now.ToUniversalTime();

            this.senderName = senderName;
            this.messageText = messageText;
        }


    }

    
    
    
    
    /// <summary>
    /// -------------------------------------------------------------------------------------
    /// UcTextChatController
    /// </summary>
    public class UcTextChatController
    {
        public UcTextChatController()
        {
        }

        public void SendMessage(string sessionId, UcTextChatMessage message)
        {
            BllProxyChat.InsertChatMessage(sessionId, message.SenderName, message.MessageText);
        }
      
        public ChatDS.ChatDSDataTable GetMessages(string sessionId, Int32 num)
        {
            ChatDS.ChatDSDataTable dt = BllProxyChat.GetChatMessagesBySession(sessionId, num);
            return dt;
        }
    }
}
