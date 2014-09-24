using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    class ElementBuilder
    {
        private string tag;
        private string opening;
        private string content;
        private string closing;
        private bool isVoid;

        private string element;
        private bool isWholeElement;

        public ElementBuilder(string tag, bool isVoid = false)
        {
            this.Tag = tag;
            this.IsVoid = isVoid;
            this.Content = string.Empty;
            this.Opening = "<" + this.Tag + ">";
            if (this.IsVoid)
            {
                this.Closing = string.Empty;
            }
            else
            {
                this.Closing = "</" + this.Tag + ">";
            }
        }

        public ElementBuilder(bool isWholeElement, string element)
        {
            this.element = element;
            this.isWholeElement = isWholeElement;
        }

        private string Tag
        {
            get { return this.tag; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.tag = value;
            }
        }

        public string Opening
        {
            get { return this.opening; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.opening = value;
            }
        }

        public string Content
        {
            get { return this.content; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.content = value;
            }
        }

        public string Closing
        {
            get { return this.closing;}
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.closing = value;
            }
        }

        public bool IsVoid
        {
            get { return this.isVoid; }
            set { this.isVoid = value; }
        }

        public static implicit operator ElementBuilder(string elemenetStr)
        {
            return new ElementBuilder(true, elemenetStr);
        }

        public static ElementBuilder operator *(ElementBuilder element, int counter)
        {
            StringBuilder elementsStr = new StringBuilder();
            for (int i = 0; i < counter; i++)
            {
                elementsStr.Append(element.ToString());
            }
            return elementsStr.ToString();
        }

        public string AddAttribute(string attribute, string value)
        {
            this.Opening = this.Opening.TrimEnd(new[] { '/', '>', ' ' }) + string.Format(" {0}=\"{1}\"", attribute, value);
            // http://www.dotnetperls.com/trimend
            this.Opening += ">";
            return this.Opening;
        }

        public void AddContent(string content)
        {
            if (!this.IsVoid)
            {
                this.Content = content;
            }
            else
            {
                throw new ArgumentException("Void HTML elements can not have content!");
            }
        }

        public override string ToString()
        {
            if (this.isWholeElement)
            {
                return this.element;
            }
            else
            {
                return this.Opening + this.Content + this.Closing;
            }
        }
    }
}
