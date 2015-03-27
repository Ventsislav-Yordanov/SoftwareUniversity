namespace ImportMountainsPeaksAndCountriesFromJSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    using MountainsCodeFirst;

    class ImportMountainsPeaksAndCountriesFromJSON
    {
        static void Main()
        {
            var json = File.ReadAllText(@"..\..\mountains.json");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var mountains = serializer.Deserialize<MountainDTO[]>(json);
            foreach (var mountainDTO in mountains)
            {
                try
                {
                    AddCountryToDB(mountainDTO);
                    Console.WriteLine("Mountain {0} imported.", mountainDTO.MountainName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static void AddCountryToDB(MountainDTO mountainDTO)
        {
            var context = new MountainsContext();
            if (mountainDTO.MountainName == null)
            {
                throw new Exception("Mountain name is required");
            }
            var m = new Mountain() { Name = mountainDTO.MountainName };
            foreach (var peakDTO in mountainDTO.Peaks)
            {
                if (peakDTO.PeakName == null)
                {
                    throw new Exception("Peak name is required");
                }
                if (peakDTO.Elevation == null)
                {
                    throw new Exception("Peak elevation is required");
                }
                Peak peak = new Peak();
                peak.Name = peakDTO.PeakName;
                peak.Elevation = peakDTO.Elevation.GetValueOrDefault();
                m.Peaks.Add(peak);
            }

            foreach (var countryName in mountainDTO.Countries)
            {
                var country = context.Countries.FirstOrDefault(c => c.Name == countryName);
                if (country == null)
                {
                    country = new Country()
                    {
                        Code = countryName.ToUpper().Substring(0, 2),
                        Name = countryName
                    };
                }
                m.Countries.Add(country);
            }
            context.Mountains.Add(m);
            context.SaveChanges();
        }
    }
}
