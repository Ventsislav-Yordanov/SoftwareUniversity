using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class BassGuitar : Guitar, IBassGuitar
    {
        public BassGuitar(string make, string model, decimal price, string color, string bodyWood,
            string fingerboardWood)
            : base(make, model, price, color, true, bodyWood, fingerboardWood, 4)
        {
        }

    }
}
