namespace RopeForEfficientStringEditing
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;

    public class StringEditor : IStringEditor
    {
        private BigList<char> content;

        public StringEditor()
        {
            this.content = new BigList<char>();
        }

        public void Insert(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            
            for (int i = 0; i < value.Length; i++)
            {
                this.content.Insert(i, value[i]);
            }
        }

        public void Append(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var index = this.content.Count;

            for (int i = value.Length - 1; i >= 0; i--)
            {
                this.content.Insert(index, value[i]);
            }
        }

        public void Delete(int index, int count)
        {
            if (index < 0 || index >= this.content.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (count < 0 || count >= this.content.Count - index)
            {
                throw new ArgumentException("The count should be non-negative and not too large.", "count");
            }

            this.content.RemoveRange(index, count);
        }

        public string Print()
        {
            var result = new StringBuilder();
            for (int i = 0; i < this.content.Count; i++)
            {
                result.Append(this.content[i]);
            }

            return result.ToString();
        }
    }
}
