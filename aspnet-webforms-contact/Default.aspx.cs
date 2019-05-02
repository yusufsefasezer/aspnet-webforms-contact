using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace aspnet_webforms_contact
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Contact> contactList = null;
        public string xmlFile = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlFile = Server.MapPath("contact-list.xml");
            
            contactList= (List<Contact>)Session["Contact"] ?? new List<Contact>();
            
            if (!IsPostBack)
            {
                LoadData(xmlFile);
                Session["Contact"] = contactList;
            }
        }

        private void LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(contactList.GetType(), new XmlRootAttribute
                    {
                        ElementName = "Contacts"
                    });
                    contactList = (List<Contact>)xmlSerializer.Deserialize(fileStream);
                }
            }
            FillContactList();
        }

        protected void SaveData(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(contactList.GetType(), new XmlRootAttribute
                {
                    ElementName = "Contacts"
                });
                xmlSerializer.Serialize(fileStream, contactList);
            }
        }

        protected void FillContactList()
        {
            foreach (Contact currentContact in contactList)
            {
                string FullName = currentContact.FirstName + " " + currentContact.LastName;
                ListBoxContactList.Items.Add(FullName);
            }
        }

        protected void AddContact(object sender, EventArgs e)
        {
            contactList.Add(new Contact
            {
                FirstName = TextBoxFirstName.Text,
                LastName = TextBoxLastName.Text,
                Email = TextBoxEmail.Text,
                PhoneNumber = TextBoxPhoneNumber.Text,
                Address = TextBoxAddress.Text,
                WebAddress = TextBoxWebAddress.Text,
                Notes = TextBoxNotes.Text
            });
            string FullName = TextBoxFirstName.Text + " " + TextBoxLastName.Text;
            ListBoxContactList.Items.Add(FullName);
            SaveData(xmlFile);
            Session["Contact"] = contactList;
            Response.Redirect("Default.aspx");
        }
        private void ResetInput()
        {
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxEmail.Text = "";
            TextBoxPhoneNumber.Text = "";
            TextBoxWebAddress.Text = "";
            TextBoxAddress.Text = "";
            TextBoxNotes.Text = "";
        }

        protected void UpdateContact(object sender, EventArgs e)
        {
            if (ListBoxContactList.Items.Cast<ListItem>().Where(item => item.Selected).Count() == 0) return;
            int selectedIndex = ListBoxContactList.SelectedIndex;
            Contact selectedContact = contactList[selectedIndex];
            selectedContact.FirstName = TextBoxFirstName.Text;
            selectedContact.LastName = TextBoxLastName.Text;
            selectedContact.Email = TextBoxEmail.Text;
            selectedContact.PhoneNumber = TextBoxPhoneNumber.Text;
            selectedContact.WebAddress = TextBoxWebAddress.Text;
            selectedContact.Address = TextBoxAddress.Text;
            selectedContact.Notes = TextBoxNotes.Text;
            string FullName = TextBoxFirstName.Text + " " + TextBoxLastName.Text;
            ListBoxContactList.Items[selectedIndex].Text = FullName;
            SaveData(xmlFile);
            Session["Contact"] = contactList;
            Response.Redirect("Default.aspx");
        }

        protected void RemoveContact(object sender, EventArgs e)
        {
            if (ListBoxContactList.Items.Cast<ListItem>().Where(item => item.Selected).Count() == 0) return;
            int selectedIndex = ListBoxContactList.SelectedIndex;
            ListBoxContactList.Items.RemoveAt(selectedIndex);
            contactList.RemoveAt(selectedIndex);
            SaveData(xmlFile);
            Session["Contact"] = contactList;
            Response.Redirect("Default.aspx");
        }

        protected void ChangeContact(object sender, EventArgs e)
        {
            if (ListBoxContactList.Items.Cast<ListItem>().Where(item => item.Selected).Count() == 0) return;
            Contact selectedContact = contactList[ListBoxContactList.SelectedIndex];
            TextBoxFirstName.Text = selectedContact.FirstName;
            TextBoxLastName.Text = selectedContact.LastName;
            TextBoxEmail.Text = selectedContact.Email;
            TextBoxPhoneNumber.Text = selectedContact.PhoneNumber;
            TextBoxWebAddress.Text = selectedContact.WebAddress;
            TextBoxAddress.Text = selectedContact.Address;
            TextBoxNotes.Text = selectedContact.Notes;
        }
    }
}