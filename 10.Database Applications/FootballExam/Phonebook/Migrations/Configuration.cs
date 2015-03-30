namespace Phonebook.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhonebookContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhonebookContext context)
        {
            if (! context.Contacts.Any())
            {
                var peter = new Contact()
                {
                    Name = "Peter Ivanov",
                    Position = "CTO",
                    Emails = { new Email { Address = "peter_ivanov@yahoo.com" }, new Email { Address = "peter@gmail.com" } },
                    Phones = { new Phone { Number = "+359 2 22 22 22" }, new Phone { Number = "+359 88 77 88 99" } },
                    Url = "http://blog.peter.com",
                    Notes = "Friend from school"
                };
                context.Contacts.Add(peter);

                var maria = new Contact()
                {
                    Name = "Maria",
                    Phones = { new Phone { Number = "+359 22 33 44 55" } }
                };
                context.Contacts.Add(maria);

                var angie = new Contact()
                {
                    Name = "Angie Stanton",
                    Emails = { new Email { Address = "info@angiestanton.com" } },
                    Url = "http://angiestanton.com"
                };
                context.Contacts.Add(angie);
            }
        }
    }
}
