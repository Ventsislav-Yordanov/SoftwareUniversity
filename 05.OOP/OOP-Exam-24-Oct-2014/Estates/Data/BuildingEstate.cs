namespace Estates.Data
{
    using System;
    using Estates.Interfaces;

    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private const int minRooms = 0;
        private const int maxRooms = 20;

        private int rooms;
        private bool hasElevator;

        public int Rooms
        {
            get { return this.rooms; }
            set
            {
                if (value < minRooms || value > maxRooms)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Number of rooms must be in range [{0}...{1}]", minRooms, maxRooms));
                }

                this.rooms = value;
            }
        }

        public bool HasElevator
        {
            get { return this.hasElevator; }
            set { this.hasElevator = value; }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Rooms: {0}, Elevator: {1}", this.Rooms, this.HasElevator ? "Yes" : "No");
        }
    }
}
