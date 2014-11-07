namespace Estates.Data
{
    using System;
    using Estates.Interfaces;

    public class Garage : Estate, IGarage
    {
        private const int minWidthOrHeight = 0;
        private const int maxWidthOrHeight = 500;

        private int width;
        private int height;

        public Garage()
        {
            this.Type = EstateType.Garage;
        }

        public int Width
        {
            get { return this.width; }
            set
            {
                if (value < minWidthOrHeight || value > maxWidthOrHeight)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Width must be in range [{0}...{1}]", minWidthOrHeight, maxWidthOrHeight));
                }

                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                if (value < minWidthOrHeight || value > maxWidthOrHeight)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Height must be in range [{0}...{1}]", minWidthOrHeight, maxWidthOrHeight));
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}
