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

        private string Tag ////////////////////////////////////////////////////////////// private ?
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
    }
}
