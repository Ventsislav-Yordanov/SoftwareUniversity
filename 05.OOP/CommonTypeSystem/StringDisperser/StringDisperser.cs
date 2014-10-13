namespace StringDisperser
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
    {
        private StringBuilder totalString;

        public StringDisperser(params string[] strings)
        {
            this.TotalString = new StringBuilder();
            foreach (var str in strings)
            {
                this.TotalString.Append(str);
            }
        }

        public StringBuilder TotalString
        {
            get { return this.totalString; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("TotalString cannot be empty or null");
                }

                this.totalString = value;
            }
        }

        public override string ToString()
        {
            return this.TotalString.ToString();
        }

        public override bool Equals(object obj)
        {
            StringDisperser stringDisperser = obj as StringDisperser;
            // check if object is not StringDisperser
            if (stringDisperser == null)
            {
                return false;
            }

            string thisTotalString = this.TotalString.ToString();
            string stringDisperserTotalString = stringDisperser.totalString.ToString();

            return thisTotalString.Equals(stringDisperserTotalString);
        }

        public static bool operator ==(StringDisperser stringDisperser, StringDisperser otherStringDisperser)
        {
            return Object.Equals(stringDisperser, otherStringDisperser);
        }

        public static bool operator !=(StringDisperser stringDisperser, StringDisperser otherStringDisperser)
        {
            return Object.Equals(stringDisperser, otherStringDisperser);
        }

        public override int GetHashCode()
        {
            return this.TotalString.GetHashCode();
        }

        public object Clone()
        {
            StringDisperser newStringDisperser = this.MemberwiseClone() as StringDisperser;
            // check object is StringDisperser
            if (newStringDisperser == null)
            {
                throw new ArgumentNullException("Object can't be casted to StringDisperser type!");
            }

            newStringDisperser.TotalString = new StringBuilder().Append(this.TotalString.ToString());

            return newStringDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            string thisTotalString = this.TotalString.ToString();
            string otherTotalString = other.totalString.ToString();

            return thisTotalString.CompareTo(otherTotalString);
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < this.TotalString.Length; i++)
            {
                yield return this.TotalString[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
