using System;

public class Component
{
    private string name;
    private string details;
    private decimal price;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cannot be empty or null");
            }
            this.name = value;
        }
    }

    public string Details
    {
        get { return this.details; }
        set { this.details = value; }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negaite");
            }
            this.price = value;
        }
    }

    // constructor
    public Component(string name, string details, decimal price)
    {
        this.Name = name;
        this.Details = details;
        this.Price = price;
    }

    //second constructor
    public Component(string name, decimal price)
        : this(name, null, price)
    {

    }

    // override method
    public override string ToString()
    {
        string result = String.Format("- Component : [ name : {0}, ", this.name);
        if (this.Details != null)
        {
            result += "details : " + this.Details + ", ";
        }
        result += "price : " + this.Price + " ]";
        
        return result;
    }
}