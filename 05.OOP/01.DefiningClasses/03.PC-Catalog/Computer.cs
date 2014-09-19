using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Computer
{
    private string name;
    private List<Component> components;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cannot be empty or null!");
            }
            this.name = value;
        }
    }

    public List<Component> Components
    {
        get { return this.components; }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Componenets cannot be empty or null");
            }
            this.components = value;
        }
    }

    public decimal Price
    {
        get
        {
            //decimal sum = 0;
            //foreach (var component in components)
            //{
            //    sum += component.Price;
            //}
            //return sum;

            return this.Components.Sum(a => a.Price); // functional programming
        }
    }

    // constructor
    public Computer(string name, List<Component> components)
    {
        this.Name = name;
        this.Components = components;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine("Computer Name : " + this.Name);
        foreach (var component in components)
        {
            result.AppendLine(component.ToString());
        }
        result.AppendLine("Price : " + this.Price + " BGN");

        return result.ToString();
    }
}