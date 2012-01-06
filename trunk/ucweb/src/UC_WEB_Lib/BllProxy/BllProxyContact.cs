using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyContact
    {
        public static ContactDS.ContactDSDataTable GetAllContacts()
        {
            return BllContact.GetAllContacts();
        }
        public static ContactDS.ContactDSDataTable GetContactsByPhoneNumber(string phoneNumber)
        {
            return BllContact.GetContactsByPhoneNumber(phoneNumber);
        }

        public static ContactDS.ContactDSDataTable SelectContact(Int32 contact_id)
        {
            return BllContact.SelectContact(contact_id);
        }

        public static ContactDS.ContactDSDataTable GetContactByGuid(Guid contact_guid)
        {
            return BllContact.GetContactByGuid(contact_guid);
        }








        public static ContactDS.ContactDSDataTable GetUserContactId(Int32 user_id)
        {
            return BllContact.GetUserContactId(user_id);
        }



        //public static ContactDS.ContactDSDataTable AddContact(string first_name, string last_name, string email, string phone)
        //{
        //    return BllContact.AddContact(first_name, last_name, email, phone);
        //}


        public static ContactDS.ContactDSDataTable SearchContact(string first_name, string last_name, string email, string phone)
        {
            return BllContact.SearchContact(first_name, last_name, email, phone);
        }




        public static Int32 InsertContact(Int32 user_id, string first_name, string last_name, string email, string phone, string memo)
        {
            return BllContact.InsertContact(user_id, first_name, last_name, email, phone, memo);
        }

        public static Int32 UpdateContact(Int32 contact_id, Int32 user_id, string first_name, string last_name, string email, string phone, string memo)
        {
            return BllContact.UpdateContact(contact_id, user_id, first_name, last_name, email, phone, memo);
        }

        public static Int32 DeleteContact(Int32 contact_id)
        {
            return BllContact.DeleteContact(contact_id);
        }




    }



    public class BllProxyContactState
    {



        public static ContactDS.ContactStateDSDataTable GetAllContactStates()
        {
            return BllContactState.GetAllContactStates();
        }

        //-----------------------------------------------------------------------------

        public static ContactDS.ContactStateDSDataTable SelectContactState(Int32 contact_id)
        {
            return BllContactState.SelectContactState(contact_id);
        }

        public static void InsertContactState(Int32 contact_id, bool is_available, string state)
        {
            BllContactState.InsertContactState(contact_id, is_available, state);
        }

        public static Int32 UpdateContactState(Int32 contact_id, bool is_available, string state, Int32 call_id)
        {
            return BllContactState.UpdateContactState(contact_id, is_available, state, call_id);
        }

        public static Int32 DeleteContactState(Int32 contact_id)
        {
            return BllContactState.DeleteContactState(contact_id);
        }





        

        public static void SetBusy(Int32 contact_id, bool is_busy, Int32 call_id)
        {
            BllContactState.SetBusy(contact_id, is_busy, call_id);
        }

    }





    public class BllProxyContactListing
    {
        //-----------------------------------------------------------------------------

        public static ContactDS.ContactListingDSDataTable GetContactListing(Int32 contact_id)
        {
            return BllContactListing.GetContactListing(contact_id);
        }

        public static ContactDS.ContactListingDSDataTable FindContactListing(Int32 contact_id, string search_words)
        {
            return BllContactListing.FindContactListing(contact_id, search_words);
        }
        public static ContactDS.ContactListingDSDataTable GetIncomingListing(Int32 contact_id)
        {
            return BllContactListing.GetIncomingListing(contact_id);
        }
        public static ContactDS.ContactListingDSDataTable GetOutgoingListing(Int32 contact_id)
        {
            return BllContactListing.GetOutgoingListing(contact_id);
        }

        






        public static ContactDS.ContactListingDSDataTable SelectContactListing(Int32 contact_id, Int32 lst_contact_id)
        {
            return BllContactListing.SelectContactListing(contact_id, lst_contact_id);
        }

        public static void InsertContactToListing(Int32 contact_id, Int32 lst_contact_id, string lst_nickname)
        {
            BllContactListing.InsertContactToListing(contact_id, lst_contact_id, lst_nickname);
        }

        public static void DeleteContactFromListing(Int32 contact_id, Int32 contact_listing_id)
        {
            BllContactListing.DeleteContactFromListing(contact_id, contact_listing_id);
        }
    }



}
