namespace Customer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class TestCustomer
    {
        static void Main()
        {
            Payment keyboard = new Payment("Keyboard MODECOM", 35m);
            Payment monitor = new Payment("Monitor Sony", 149.99m);
            Payment glasses = new Payment("Glasses Alpina", 79.80m);
            Payment shoes = new Payment("Sport shoes Adidas", 179.99m);
            Payment dog = new Payment("Husky", 90m);

            Customer gosho = new Customer(
                "Georgi",
                "Petrov",
                "Ivanov",
                9305054476,
                "Borisova 34",
                "0883-43-43-12",
                "JorjataBrat@abv.bg",
                new List<Payment>() { keyboard, monitor },
                CustomerType.Regular);

            Customer dancho = new Customer(
                "Yordan",
                "Yordanov",
                "Kirov",
                7305041495,
                "Borisova 55",
                "0883-44-66-92",
                "YordanovKirov@abv.bg",
                new List<Payment>() { glasses, shoes },
                CustomerType.Golden);

            Customer tanq = new Customer(
                "Tatqna",
                "Georgieva",
                "Petrova",
                7402031596,
                "Borisova 35",
                "0889-49-23-67",
                "TanqPetrova@abv.bg",
                new List<Payment>() { glasses, shoes, dog, monitor },
                CustomerType.Diamond);

            // correct copy
            Customer goshoCopy = (Customer)gosho.Clone();
            goshoCopy.FirstName = "Gecata";
            goshoCopy.Payments.Add(new Payment("Car audi A4", 5000m));
            Console.WriteLine(gosho);
            Console.WriteLine(goshoCopy);
            Console.WriteLine("goshoCopy == gosho : {0}", goshoCopy == gosho);
            Console.WriteLine("gosho.Equals(goshoCopy) : {0}", gosho.Equals(goshoCopy));
            Console.WriteLine("Object.ReferenceEquals(gosho, goshoCopy) : {0}", Object.ReferenceEquals(gosho, goshoCopy));
            Console.WriteLine("\n\n\n");

            // incorrect copy
            goshoCopy = gosho;
            gosho.FirstName = "Goshkata";
            goshoCopy.Payments.Add(new Payment("Car audi A4", 5000m));
            Console.WriteLine(gosho);
            Console.WriteLine(goshoCopy);
            Console.WriteLine("goshoCopy == gosho : {0}", goshoCopy == gosho);
            Console.WriteLine("gosho.Equals(goshoCopy) : {0}", gosho.Equals(goshoCopy));
            Console.WriteLine("Object.ReferenceEquals(gosho, goshoCopy) : {0}", Object.ReferenceEquals(gosho, goshoCopy));
        }
    }
}
