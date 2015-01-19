using MusicShopManager.Interfaces;
using MusicShopManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private bool caseIncluded;
        private StringMaterial stringMaterial;

        public AcousticGuitar(string make, string model, decimal price, string color, string bodyWood,
            string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
            : base(make, model, price, color, false, bodyWood, fingerboardWood, 6)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded
        {
            get
            {
                return this.caseIncluded;
            }
            set
            {
                this.caseIncluded = value;
            }
        }

        public StringMaterial StringMaterial
        {
            get
            {
                return this.stringMaterial;
            }
            set
            {
                this.stringMaterial = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Case included: {0}", this.CaseIncluded ? "yes" : "no").AppendLine()
                .AppendFormat("String material: {0}", this.StringMaterial);
            return result.ToString();
        }
    }
}
