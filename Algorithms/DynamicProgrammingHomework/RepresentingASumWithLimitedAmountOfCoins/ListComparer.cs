namespace RepresentingASumWithLimitedAmountOfCoins
{
    using System.Collections.Generic;

    public class ListComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (x.Count != y.Count)
            {
                return false;
            }

            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(List<int> list)
        {
            unchecked
            {
                int hashCode = 19;
                foreach (var item in list)
                {
                    hashCode = hashCode * 31 + item.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}