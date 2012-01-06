using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.ChatDSTableAdapters;


namespace UCENTRIK.DAL
{
    public class DalChat
    {

        public static ChatDS.ChatDSDataTable GetChatMessagesBySession(string session, Int32 maxRows)
        {
            ChatDSTableAdapter ta = new ChatDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetChatMessagesBySession(session, maxRows);
        }







        public static ChatDS.ChatDSDataTable SelectChatMessage(Int32 chatMessageId)
        {
            ChatDSTableAdapter ta = new ChatDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(chatMessageId);
        }

        public static void InsertChatMessage(string session, string sender, string message)
        {
            ChatDSTableAdapter ta = new ChatDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.Insert(session, sender, message);
        }

        public static void UpdateChatMessage(Int32 chatId, string session, string sender, string message)
        {
            ChatDSTableAdapter ta = new ChatDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.Update(chatId, session, sender, message);
        }

        public static void DeleteChatMessage(Int32 chatId)
        {
            ChatDSTableAdapter ta = new ChatDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.Delete(chatId);
        }


    }
}
