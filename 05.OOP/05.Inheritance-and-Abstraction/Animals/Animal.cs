namespace Animals
{
    using System;

    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private Genders gender;

        public Animal(string name, int age, Genders gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender=gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name", "name cannot be empty or null!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("age", "age cannot be negative!");
                }
                this.age = value;
            }
        }

        public Genders Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public abstract void ProduceSound();
    }
}
