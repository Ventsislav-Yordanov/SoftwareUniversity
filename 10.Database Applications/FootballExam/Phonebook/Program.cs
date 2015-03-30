using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhonebookContext();
            var contacts = context.Contacts
                    .Select(c => new
                    {
                        c.Name,
                        Phones = c.Phones
                            .Select(p => p.Number),
                        Emails = c.Emails
                            .Select(e => e.Address)
                    });

            foreach (var contact in contacts)
            {
                Console.WriteLine("Contact: {0}, Phones: {1}, Emails: {2}",
                    contact.Name,
                     string.Join(", ", contact.Phones),
                     string.Join(", ", contact.Emails));
            }
        }
    }
}
