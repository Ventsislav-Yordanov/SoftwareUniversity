namespace FurnitureManufacturer
{
    using Engine;
    using System.Threading;
    
    public class FurnitureProgram
    {
        
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            FurnitureManufacturerEngine.Instance.Start();
        }
    }
}
