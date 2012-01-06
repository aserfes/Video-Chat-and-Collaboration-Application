using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;



namespace UCENTRIK.BLL
{
    public class BllContact
    {


        private static ContactDS.ContactDSDataTable processData(ContactDS.ContactDSDataTable dt)
        {
            foreach (ContactDS.ContactDSRow row in dt.Rows)
            {
                row.full_name = Helper.GetFullName(row.first_name, row.last_name);
            }

            return dt;
        }

        //=========================================================================================



        public static ContactDS.ContactDSDataTable GetAllContacts()
        {
            ContactDS.ContactDSDataTable dt = DalContact.GetAllContacts();
            return processData(dt);
        }

        public static ContactDS.ContactDSDataTable GetContactsByPhoneNumber(string phoneNumber)
        {
            ContactDS.ContactDSDataTable dt = DalContact.GetContactsByPhoneNumber(phoneNumber);
            return processData(dt);
        }


        public static ContactDS.ContactDSDataTable SelectContact(Int32 contactId)
        {
            ContactDS.ContactDSDataTable dt = DalContact.SelectContact(contactId);
            return processData(dt);

        }

        public static ContactDS.ContactDSDataTable GetContactByGuid(Guid contactGuid)
        {
            ContactDS.ContactDSDataTable dt = DalContact.GetContactByGuid(contactGuid);
            return processData(dt);
        }





        public static ContactDS.ContactDSDataTable GetUserContactId(Int32 userId)
        {
            ContactDS.ContactDSDataTable dt = DalContact.GetUserContactId(userId);
            return processData(dt);
        }




        public static ContactDS.ContactDSDataTable SearchContact(string firstName, string lastName, string email, string phone)
        {
            ContactDS.ContactDSDataTable dt = DalContact.SearchContact(firstName, lastName, email, phone);
            return processData(dt);
        }










        public static Int32 InsertContact(Int32 userId, string firstName, string lastName, string email, string phone, string memo)
        {
            return DalContact.InsertContact(userId, firstName, lastName, email, phone, memo);
        }

        public static Int32 UpdateContact(Int32 contactId, Int32 userId, string firstName, string lastName, string email, string phone, string memo)
        {
            return DalContact.UpdateContact(contactId, userId, firstName, lastName, email, phone, memo);
        }


        public static Int32 DeleteContact(Int32 contactId)
        {
            return DalContact.DeleteContact(contactId);
        }



    }


    public class BllContactState
    {


        private static ContactDS.ContactStateDSDataTable processData(ContactDS.ContactStateDSDataTable dt)
        {
            return dt;
        }

        //-----------------------------------------------------------------------------



        public static ContactDS.ContactStateDSDataTable GetAllContactStates()
        {
            ContactDS.ContactStateDSDataTable dt = DalContactState.GetAllContactStates();
            return processData(dt);
        }



        public static ContactDS.ContactStateDSDataTable SelectContactState(Int32 contactId)
        {
            ContactDS.ContactStateDSDataTable dt = DalContactState.SelectContactState(contactId);
            return processData(dt);
        }

        public static void InsertContactState(Int32 contactId, bool isAvailable, string state)
        {
            if(contactId != 0)
                DalContactState.InsertContactState(contactId, isAvailable, state);
        }

        public static Int32 UpdateContactState(Int32 contactId, bool isAvailable, string state, Int32 callId)
        {
            return DalContactState.UpdateContactState(contactId, isAvailable, state, callId);
        }

        public static Int32 DeleteContactState(Int32 contactId)
        {
            return DalContactState.DeleteContactState(contactId);
        }







        public static void SetBusy(Int32 contactId, bool isBusy, Int32 callId)
        {
            DalContactState.SetBusy(contactId, isBusy, callId);
        }
    }


    public class BllContactListing
    {

        private static ContactDS.ContactListingDSDataTable processData(ContactDS.ContactListingDSDataTable dt)
        {
            foreach (ContactDS.ContactListingDSRow row in dt.Rows)
            {
                row.full_name = Helper.GetFullName(row.first_name, row.last_name);
            }

            return dt;
        }


        
        
        
        //=========================================================================================

        public static ContactDS.ContactListingDSDataTable GetContactListing(Int32 contactId)
        {
            ContactDS.ContactListingDSDataTable dt = DalContactListing.GetContactListing(contactId);
            return processData(dt);
        }

        public static ContactDS.ContactListingDSDataTable FindContactListing(Int32 contactId, string searchWords)
        {
            ContactDS.ContactListingDSDataTable dt = DalContactListing.FindContactListing(contactId, searchWords);
            return processData(dt);
        }
        public static ContactDS.ContactListingDSDataTable GetIncomingListing(Int32 contactId)
        {
            ContactDS.ContactListingDSDataTable dt = DalContactListing.GetIncomingListing(contactId);
            return processData(dt);
        }
        public static ContactDS.ContactListingDSDataTable GetOutgoingListing(Int32 contactId)
        {
            ContactDS.ContactListingDSDataTable dt = DalContactListing.GetOutgoingListing(contactId);
            return processData(dt);
        }






        public static ContactDS.ContactListingDSDataTable SelectContactListing(Int32 contactId, Int32 contactListngId)
        {
            ContactDS.ContactListingDSDataTable dt = DalContactListing.SelectContactListing(contactId, contactListngId);
            return processData(dt);
        }

        public static void InsertContactToListing(Int32 contactId, Int32 contactListingId, string nickname)
        {
            DalContactListing.InsertContactToListing(contactId, contactListingId, nickname);
        }

        public static void DeleteContactFromListing(Int32 contactId, Int32 contactListingId)
        {
            DalContactListing.DeleteContactFromListing(contactId, contactListingId);
        }
    }

}

