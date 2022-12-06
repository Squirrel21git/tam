using Android.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace essentialXamarin
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Contact> contactsCollect = new ObservableCollection<Contact>();
        public MainPage()
        {
            InitializeComponent();
            GetAllContacts();
            ContactList.ItemsSource = contactsCollect;
            //ContactList.ItemSelected += ContactList_ItemSelected;
        }

        public async void GetAllContacts()
        {
            

            try
            {
                // cancellationToken parameter is optional
                var cancellationToken = default(CancellationToken);
                var contacts = await Contacts.GetAllAsync(cancellationToken);

                if (contacts == null)
                    return;

                foreach (var contact in contacts)
                    contactsCollect.Add(contact);
            }
            catch (Exception ex)
            {
                // Handle exception here.
            }
        }

        private async void ContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = e.SelectedItem as Contact;
            var contactInfo = new ContactInfo();

            contactInfo.BindingContext = selected;

            await Navigation.PushAsync(contactInfo);
            
        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            //ContentResolver.Update();
            // https://learn.microsoft.com/pl-pl/xamarin/android/user-interface/user-profile
        }
    }
}
