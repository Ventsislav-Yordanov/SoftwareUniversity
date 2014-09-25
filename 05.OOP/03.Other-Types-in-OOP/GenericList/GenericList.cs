using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    [Version(0,5)]
    public class GenericList<T> where T : IComparable<T>
    {
        private const int CAPACITY = 16;

        private T[] inner;
        private int size;
        private int capacity;

        public GenericList(int capacity = CAPACITY)
        {
            this.Size = 0;
            this.Capacity = capacity;
            this.Inner = new T[this.Capacity];
        }

        public T[] Inner
        {
            get { return this.inner; }
            protected set // http://msdn.microsoft.com/en-us/library/bcd5672a.aspx
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Inner", "Inner array can not be null!");
                }
                this.inner = value;
            }
        }

        public int Size
        {
            get { return this.size; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("GenericList size can not be negative!");
                }
                this.size = value;

                if (value >= this.Capacity)
                {
                    this.DoubleSize();
                }
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("GenericList capacity can not be negative!");
                }
                this.capacity = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Size)
                {
                    throw new IndexOutOfRangeException("Invalid index!");
                }
                return this.Inner[index];
            }
            set
            {
                if (index < 0 || index >= this.Size)
                {
                    throw new IndexOutOfRangeException("Invalid index!");
                }
                this.Inner[index] = value;
            }
        }

        public void Add(T element)
        {
            this.Inner[this.Size] = element;
            this.Size++;
        }

        public void Insert(T element, int position)
        {
            T[] newArray = new T[this.Capacity];

            //Info about Array.Copy with examples: http://www.dotnetperls.com/array-copy
            Array.Copy(this.Inner, newArray, position);
            // копираме стойностите на старият масив в новият масив до дадената позиция


            Array.Copy(new T[1] { element }, 0, newArray, position, 1);
            //Създаваме нов масив който държи елемента който искаме да вкараме
            //копираме от новият масив ( с елемента ) от индекс 0 в новият масив от индекс: позицията . Дължина на масива : 1

            Array.Copy(this.inner, position, newArray, position + 1, this.Inner.Length - position - 2);
            //Копираме стойностите от старият масив от индекс: позицията в новият масив на индекс: позицията + 1
            // дължината на масива е : дължината на старият масив - позицията - 2

            //void.Array.Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
            //Copies a range of elements from an System.Array starting at the specified source index and pastes them to another 
            //System.Array starting at the specified destination index. The length and the indexes are specified as 32-bit integers.

            this.Inner = newArray;
            this.Size++;
        }

        public void Remove(int position)
        {
            T[] newArray = new T[this.Capacity];

            Array.Copy(this.Inner, newArray, position);
            // копираме стойностите на старият масив в новият масив до дадената позиция

            Array.Copy(this.Inner, position + 1, newArray, position, this.Inner.Length - position - 1);
            // копираме стойностите от старият масив от индекс: позицията + 1 в новият масив на индекс: позицията 
            // дължина на новият масив : дължината на старият - позицията - 1

            this.Inner = newArray;
            this.Size--;
        }

        public void Clear()
        {
            this.Inner = new T[this.Capacity];
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Contains(T element)
        {
            return this.Inner.Contains(element);
        }

        public T Min()
        {
            return this.Inner.Min();
        }

        public T Max()
        {
            return this.Inner.Max();
        }

        public void DoubleSize()
        {
            this.Capacity *= 2;
            T[] newArray = new T[this.Capacity];

            for (int i = 0; i < this.Size; i++)
            {
                newArray[i] = this.Inner[i];
            }

            this.Inner = newArray;
        }

        public override string ToString()
        {
            StringBuilder elements = new StringBuilder();
            for (int i = 0; i < this.Size; i++)
            {
                elements.Append(this.Inner[i]);

                if (i != this.Size - 1)
                {
                    elements.Append(", ");
                }
            }
            return elements.ToString();
        }
    }
}
