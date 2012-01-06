using System;
using System.Collections.Generic;
using System.Web;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyChat
    {



        public static ChatDS.ChatDSDataTable GetChatMessagesBySession(string session, Int32 chat_rows)
        {
            return BllChat.GetChatMessagesBySession(session, chat_rows);
        }







        public static ChatDS.ChatDSDataTable SelectChatMessage(Int32 chat_id)
        {
            return BllChat.SelectChatMessage(chat_id);
        }

        public static void InsertChatMessage(string session, string sender, string message)
        {
            BllChat.InsertChatMessage(session, sender, message);
        }

        public static void UpdateChatMessage(Int32 chatId, string session, string sender, string message)
        {
            BllChat.UpdateChatMessage(chatId, session, sender, message);
        }

        public static void DeleteChatMessage(Int32 chatId)
        {
            BllChat.DeleteChatMessage(chatId);
        }


    }
}
