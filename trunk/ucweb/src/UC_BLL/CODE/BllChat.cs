using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;


namespace UCENTRIK.BLL
{
    public class BllChat
    {


        private static ChatDS.ChatDSDataTable processData(ChatDS.ChatDSDataTable dt)
        {
            return dt;
        }






        public static ChatDS.ChatDSDataTable GetChatMessagesBySession(string session, Int32 maxRows)
        {
            ChatDS.ChatDSDataTable dt = DalChat.GetChatMessagesBySession(session, maxRows);
            return processData(dt);
        }







        public static ChatDS.ChatDSDataTable SelectChatMessage(Int32 chatMessageId)
        {
            ChatDS.ChatDSDataTable dt = DalChat.SelectChatMessage(chatMessageId);
            return processData(dt);
        }

        public static void InsertChatMessage(string session, string sender, string message)
        {
            DalChat.InsertChatMessage(session, sender, message);
        }

        public static void UpdateChatMessage(Int32 chatId, string session, string sender, string message)
        {
            DalChat.UpdateChatMessage(chatId, session, sender, message);
        }

        public static void DeleteChatMessage(Int32 chatId)
        {
            DalChat.DeleteChatMessage(chatId);
        }


    }
}
