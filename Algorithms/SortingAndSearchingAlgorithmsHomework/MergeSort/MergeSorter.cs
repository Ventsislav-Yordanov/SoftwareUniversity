namespace MergeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> list)
        {
            var sortedList = this.MergeSort(list);
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = sortedList[i];
            }
        }

        private List<T> MergeSort(List<T> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            var middle = list.Count / 2;
            var left = list.Take(middle).ToList();
            var right = list.Skip(middle).Take(list.Count - middle).ToList();

            left = this.MergeSort(left);
            right = this.MergeSort(right);
            return this.Merge(left, right);
        }

        public List<T> Merge(List<T> leftList, List<T> rightList)
        {
            var mergedList = new List<T>(leftList.Count + rightList.Count);
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < leftList.Count && rightIndex < rightList.Count)
            {
                if (leftList[leftIndex].CompareTo(rightList[rightIndex]) < 0)
                {
                    mergedList.Add(leftList[leftIndex++]);
                }
                else
                {
                    mergedList.Add(rightList[rightIndex++]);
                }
            }
            while (leftIndex < leftList.Count)
            {
                mergedList.Add(leftList[leftIndex++]);
            }
            while (rightIndex < rightList.Count)
            {
                mergedList.Add(rightList[rightIndex++]);
            }

            return mergedList;
        }
    }
}
