using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp10.Models;

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ContactList contactList = new ContactList();
        private int viewId { get; set; }
        private int editId { get; set; }
      
        public MainWindow()
        {
            InitializeComponent();

            Contacts.DataContext = contactList.GetAll();

            btnSave.IsEnabled = false;
        }

        // Видалити контакт
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).DataContext);

            if(editId == id)
            {
                ClearEditForm();
            }

            if (viewId == id)
            {
                ClearViewContact();
            }

            contactList.Delete(id);
        }

        // Редагувати контакт
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            editId = Convert.ToInt32(((Button)sender).DataContext);

            Contact contact = (Contact)contactList.GetContactById(editId).Clone();

            ContactEdit.DataContext = contact;
           
            btnCreate.IsEnabled = false;
            btnSave.IsEnabled = true;
        }

        // Редагування контакту
        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = UserName.Text,
                Surname = UserSurname.Text,
                Email = UserEmail.Text,
                Phone = UserPhone.Text
            };
            contactList.Edit(editId, contact);
            
            ClearEditForm();
        }

        // Скасувати редагування
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ClearEditForm();
        }

        // Очистити форму редагування
        private void ClearEditForm()
        {
            foreach (var item in ContactEdit.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = null;
                }
            }

            btnSave.IsEnabled = false;
            btnCreate.IsEnabled = true;
        }

        // Очистити контакт, що переглядається
        private void ClearViewContact()
        {
            ViewContact.DataContext = null;
        }

        // Додати контакт
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {  
                Name = UserName.Text,
                Surname = UserSurname.Text,
                Email = UserEmail.Text,
                Phone = UserPhone.Text
            };

            contactList.Add(contact);
            ClearEditForm();
        }

        // Перегляд контакту
        private void Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Contacts.SelectedItem != null)
            {
                viewId = ((Contact)Contacts.SelectedItem).Id;

                ViewContact.DataContext = contactList.GetContactById(viewId);
            }
        }
    }
}
