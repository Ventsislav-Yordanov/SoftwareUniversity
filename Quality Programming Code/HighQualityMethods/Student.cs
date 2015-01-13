using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            if (string.IsNullOrEmpty(this.OtherInfo) && string.IsNullOrEmpty(other.OtherInfo))
            {
                throw new ArgumentException("Students don't have birthday info");
            }
            else if (string.IsNullOrEmpty(this.OtherInfo))
            {
                throw new ArgumentException("This student don't have birthday info");
            }
            else if (string.IsNullOrEmpty(other.OtherInfo))
            {
                throw new ArgumentException("Other student don't have birthday info");
            }

            DateTime firstDate = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime secondDate = DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));
            return firstDate < secondDate;
        }
    }
}
