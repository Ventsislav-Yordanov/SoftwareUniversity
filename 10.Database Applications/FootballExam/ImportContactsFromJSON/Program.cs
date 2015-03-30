using Phonebook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ImportContactsFromJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"..\..\contacts.json");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var contacts = serializer.Deserialize<ContactDTO[]>(json);
            foreach (var contactDTO in contacts)
            {
                try
                {
                    AddContactToDB(contactDTO);
                    Console.WriteLine("Contact {0} imported.", contactDTO.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static void AddContactToDB(ContactDTO contactDTO)
        {
            var context = new PhonebookContext();
            if (contactDTO.Name == null)
            {
                throw new Exception("Contact name is required");
            }

            var c = new Contact() 
            { 
                Name = contactDTO.Name,
                Company = contactDTO.Company,
                Position = contactDTO .Position,
                Url = contactDTO.Site,
                Notes = contactDTO.Notes
            };

            if (contactDTO.Phones.Count() > 0)
            {
                foreach (var phoneDTO in contactDTO.Phones)
                {
                    var p = new Phone() { Number = phoneDTO };
                    c.Phones.Add(p);
                }
            }

            if (contactDTO.Emails.Count() > 0)
            {
                foreach (var emailDTO in contactDTO.Emails)
                {
                    var e = new Email() { Address = emailDTO };
                    c.Emails.Add(e);
                }
            }

            

            context.Contacts.Add(c);
            context.SaveChanges();
        }
    }
}
