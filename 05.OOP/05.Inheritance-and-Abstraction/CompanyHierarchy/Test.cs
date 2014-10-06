namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    public static class Test
    {
        // projects
        static IProject canviz = new Project(
            "Canviz",
            new DateTime(2014, 1, 22),
            ProjectState.Open,
            "Canviz is art.");

        static IProject rico = new Project(
            "Rico",
            new DateTime(2014, 2, 22),
            ProjectState.Closed,
            "Rico is the world’s first smart-home security device that uses your spare smartphone as its brain and eyes.");

        static IProject scrubBoard = new Project(
            "ScrubBoard",
            new DateTime(2014, 2, 10),
            ProjectState.Open,
            "An audiotape-based alternative to the turntable, providing turntablists with a more versatile and intuitive way to scratch");

        // sales
        static ISale csGo = new Sale("Counter-Strike: Global Offensive", new DateTime(2014, 2, 22), 20m);
        static ISale wordpressTemplate = new Sale("Wordpress ultimate template", new DateTime(2014, 10, 13), 100m);
        static ISale alien = new Sale("Alien: Isolation", new DateTime(2013, 3, 9), 30m);
        static ISale blockAds = new Sale("Ad blocks", new DateTime(2014, 5, 1), 5m);
        static ISale vs = new Sale("Visual Studio Ultimate 2013", new DateTime(2012, 1, 23), 120m);

        // sales employees
        static IEmployee gosho = new SalesEmployee(
            "#1",
            "Georgi",
            "Petrov",
            670m,
            Department.Production,
            new List<ISale>() { csGo, alien });

        static IEmployee mariq = new SalesEmployee(
            "#2",
            "Mariq",
            "Petrova",
            870m,
            Department.Sales,
            new List<ISale>() { csGo, blockAds, wordpressTemplate });

        static IEmployee adi = new SalesEmployee(
            "#3",
            "Adelina",
            "Gankova",
            1570m,
            Department.Production,
            new List<ISale>() { csGo, blockAds, wordpressTemplate, vs });

        // developers
        static IEmployee geri = new Developer(
            "#4",
            "Gergana",
            "Petrova",
            550m,
            Department.Marketing,
            new List<IProject>() { canviz, rico, scrubBoard });

        static IEmployee pepi = new Developer(
            "#55",
            "Pepa",
            "Angelova",
            570m,
            Department.Production,
            new List<IProject>() { rico });

        static IEmployee pavcho = new Developer(
            "#65",
            "Pavlin",
            "Krustev",
            470m,
            Department.Production,
            new List<IProject>() { canviz });

        // managers
        static IManager rosko = new Manager(
            "#11",
            "Rostislav",
            "Savov",
            770m,
            Department.Marketing,
            new List<IEmployee>() { geri, pavcho });

        static IManager mitko = new Manager(
            "#12",
            "Dimitar",
            "Savov",
            720m,
            Department.Marketing,
            new List<IEmployee>() { geri, pavcho, pepi });

        static IManager bori = new Manager(
            "#13",
            "Boriana",
            "Argirova",
            1520m,
            Department.Sales,
            new List<IEmployee>() { geri, pavcho, gosho });

        public static IList<IEmployee> emmployees = new List<IEmployee>()
        {
            gosho, mariq, adi,
            geri, pepi, pavcho,
            rosko, mitko, bori
        };

        static void Main(string[] args)
        {
            foreach (var item in emmployees)
            {
                Console.WriteLine(item);
            }
        }
    }
}
