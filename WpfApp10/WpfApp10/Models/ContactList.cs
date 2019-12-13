using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp10.Models
{
    public class ContactList
    {
        private List<Contact> contacts = new List<Contact>();

        public void Add(Contact contact)
        {
            contact.Id = contacts.Max(item => item.Id) + 1;
            contacts.Add(contact);
        }

        public void Delete(int id)
        {
            Contact forDelete = GetContactById(id);

            if(forDelete != null)
            {
                contacts.Remove(forDelete);
            }
        }

        public IEnumerable<Contact> GetAll()
        {
            return contacts;
        }

        public Contact GetContactById(int id)
        {
            return contacts.FirstOrDefault(item => item.Id == id);
        }

        public void Edit(int id, Contact contact)
        {
            Contact forEdit = GetContactById(id);

            if(forEdit != null)
            {
                forEdit = contact;
                forEdit.Id = id;
            }
        }
    }
}
