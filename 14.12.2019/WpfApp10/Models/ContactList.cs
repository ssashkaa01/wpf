using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp10.Models
{
    public class ContactList
    {
        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

        public void Add(Contact contact)
        {
            if(contacts.Count < 1)
            {
                contact.Id = 1;
            }
            else
            {
                contact.Id = contacts.Max(item => item.Id) + 1;
            }

            contacts.Add(contact);
        }

        public bool Delete(int id)
        {
            Contact contact = GetContactById(id);

            if(contact != null)
            {
                int index = contacts.IndexOf(contact);

                contacts.RemoveAt(index);

                return true;
            }
            else
            {
                return false;
            }
        }

        public ObservableCollection<Contact> GetAll()
        {
            return contacts;
        }

        public Contact GetContactById(int id)
        {
            return contacts.FirstOrDefault(item => item.Id == id);
        }

        public void Edit(int id, Contact contact)
        {
            int index = contacts.IndexOf(GetContactById(id));

            contact.Id = id;

            if(Delete(id))
            {
                contacts.Insert(index, contact);
            }        
        }
    }
}
