using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.ContactDSTableAdapters;


namespace UCENTRIK.DAL
{
    public class DalContact
    {
        
        public static ContactDS.ContactDSDataTable GetAllContacts()
        {
            ContactDSTableAdapter ta = new ContactDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAllContacts();
        }


        public static ContactDS.ContactDSDataTable GetContactsByPhoneNumber(string phoneNumber)
        {
            ContactDSTableAdapter ta = new ContactDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetContactsByPhoneNumber(phoneNumber);
        }


        public static ContactDS.ContactDSDataTable SelectContact(Int32 contactId)
        {
            ContactDSTableAdapter ta = new ContactDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(contactId);
        }

        public static ContactDS.ContactDSDataTable GetContactByGuid(Guid contactGuid)
        {
            ContactDSTableAdapter ta = new ContactDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetContactByGuid(contactGuid);
        }



        public static ContactDS.ContactDSDataTable GetUserContactId(Int32 userId)
        {
            ContactDSTableAdapter ta = new ContactDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetUserContactId(userId);
        }



        public static ContactDS.ContactDSDataTable SearchContact(string firstName, string lastName, string email, string phone)
        {
            ContactDSTableAdapter ta = new ContactDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.SearchContact(firstName, lastName, email, phone);
        }








        public static Int32 InsertContact(Int32 userId, string first_name, string last_name, string email, string phone, string memo)
        {
            ContactDSTableAdapter ta = new ContactDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            

            System.Nullable<Int32> user_id = Helper.ResolveEmptyInt(userId);

            if (memo == "")
                memo = null;

            int id = Convert.ToInt32(ta.InsertContact(user_id, first_name, last_name, email, phone, memo));
            return id;
        }

        public static Int32 UpdateContact(Int32 contactId, Int32 userId, string firstName, string lastName, string email, string phone, string memo)
        {
            ContactDSTableAdapter ta = new ContactDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;


            System.Nullable<Int32> user_id = Helper.ResolveEmptyInt(userId);

            if (memo == "")
                memo = null;

            return ta.Update(contactId, user_id, firstName, lastName, email, phone, memo);
        }


        public static Int32 DeleteContact(Int32 contactId)
        {
            ContactDSTableAdapter ta = new ContactDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(contactId);
        }



    }



    public class DalContactState
    {
        public static ContactDS.ContactStateDSDataTable GetAllContactStates()
        {
            ContactStateDSTableAdapter ta = new ContactStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAllContactStates();
        }


        //-----------------------------------------------------------------------------

        public static ContactDS.ContactStateDSDataTable SelectContactState(Int32 contactId)
        {
            ContactStateDSTableAdapter ta = new ContactStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(contactId);
        }

        public static void InsertContactState(Int32 contactId, bool isActive, string state)
        {
            ContactStateDSTableAdapter ta = new ContactStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            ta.Insert(contactId, isActive, state);
        }

        public static Int32 UpdateContactState(Int32 contactId, bool isAvailable, string state, Int32 callId)
        {
            ContactStateDSTableAdapter ta = new ContactStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;


            System.Nullable<Int32> call_id = Helper.ResolveEmptyInt(callId);

            return ta.Update(contactId, isAvailable, state, call_id);
        }

        public static Int32 DeleteContactState(Int32 contactId)
        {
            ContactStateDSTableAdapter ta = new ContactStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(contactId);
        }







        public static void SetBusy(Int32 contactId, bool isBusy, Int32 callId)
        {
            ContactStateDSTableAdapter ta = new ContactStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;


            System.Nullable<Int32> call_id = Helper.ResolveEmptyInt(callId);

            ta.SetBusy(contactId, isBusy, call_id);
        }

    }




    public class DalContactListing
    {
        //-----------------------------------------------------------------------------

        public static ContactDS.ContactListingDSDataTable GetContactListing(Int32 contactId)
        {
            ContactListingDSTableAdapter ta = new ContactListingDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            return ta.GetContactListing(contactId);
        }
        
        public static ContactDS.ContactListingDSDataTable FindContactListing(Int32 contactId, string searchWords)
        {
            ContactListingDSTableAdapter ta = new ContactListingDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            return ta.FindContacts(contactId, searchWords);
        }

        public static ContactDS.ContactListingDSDataTable GetIncomingListing(Int32 contactId)
        {
            ContactListingDSTableAdapter ta = new ContactListingDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            return ta.GetIncomingListing(contactId);
        }

        public static ContactDS.ContactListingDSDataTable GetOutgoingListing(Int32 contactId)
        {
            ContactListingDSTableAdapter ta = new ContactListingDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            return ta.GetOutgoingListing(contactId);
        }










        public static ContactDS.ContactListingDSDataTable SelectContactListing(Int32 contactId, Int32 contactListngId)
        {
            ContactListingDSTableAdapter ta = new ContactListingDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            return ta.GetData(contactId, contactListngId);
        }


        public static void InsertContactToListing(Int32 contactId, Int32 contactListingId, string nickname)
        {
            ContactListingDSTableAdapter ta = new ContactListingDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            ta.Insert(contactId, contactListingId, nickname);
        }

        public static Int32 DeleteContactFromListing(Int32 contactId, Int32 contactListingId)
        {
            ContactListingDSTableAdapter ta = new ContactListingDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            
            return ta.Delete(contactId, contactListingId);
        }
    }



}
