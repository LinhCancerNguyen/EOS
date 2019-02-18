using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public interface IContactService
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(int Id);
        void CreateContact(Contact contact);
        void SaveContact();
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }

    public class ContactService : IContactService
    {
        public void CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContacts()
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveContact()
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
