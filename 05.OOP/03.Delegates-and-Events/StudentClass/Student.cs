using System;

namespace StudentClass
{
    public delegate void ChangedPropertyEventHandler(object sender, PropertyChangedEventArgs eventArgs);

    public class Student
    {
        private string name;
        private int age;
        public event ChangedPropertyEventHandler PropertyChanged;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.PropertyChanged += this.GetMessage;
        }


        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be 0 or negative number");
                }
                if (this.age != value)
                {
                    var eventAge = new PropertyChangedEventArgs { OldAge = this.Age, Age = value, ChangedProperty = "Age" };
                    this.age = value;
                    this.OnChanged(this, eventAge);
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public string Name
        {
            get { return this.name;}
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
                if (this.Name != value)
                {
                    var eventName = new PropertyChangedEventArgs { OldName = this.Name, Name = value, ChangedProperty = "Name" };
                    this.name = value;
                    this.OnChanged(this, eventName);
                }
                else
                {
                    this.name = value;
                }
            }
        }

        protected virtual void OnChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, eventArgs);
            }
        }

        private void GetMessage(object sender, PropertyChangedEventArgs eventArgs)
        {
            switch (eventArgs.ChangedProperty)
            {
                case "Name":
                    Console.WriteLine("Property changed: {0} (from {1} to {2})"
                        , eventArgs.ChangedProperty, eventArgs.OldName, eventArgs.Name);
                    break;

                case "Age":
                    Console.WriteLine("Property changed: {0} (from {1} to {2})"
                        , eventArgs.ChangedProperty, eventArgs.OldAge, eventArgs.Age);
                    break;
            }
        }
    }
}
