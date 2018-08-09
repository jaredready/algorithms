using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public static class Sorter
    {
        /// <summary>
        /// Determines if a list is sorted ascending
        /// </summary>
        /// <param name="list">The list to check if sorted</param>
        /// <returns>True if the list is sorted ascending. Returns false if the list is not sorted or if the list is null or empty</returns>
        public static bool ListIsSortedAscending(List<float> list)
        {
            if (list == null || list.Count < 1)
            {
                return false;
            }
            for (int i = 1; i < list.Count(); i++)
            {
                if (list.ElementAt(i).CompareTo(list.ElementAt(i - 1)) == -1)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Sorts the given list in ascending order.
        /// </summary>
        /// <param name="list">The list to be sorted. Will not be altered.</param>
        /// <returns>A sorted list containing the elements and only the elements pass in.</returns>
        public static List<float> Sort(List<float> list)
        {
            if (list == null || list.Count <= 1)
            {
                return list;
            }

            List<float> sortedList = new List<float>(list);
            QuickSort(sortedList, 0, list.Count() - 1);

            return sortedList;
        }

        static void QuickSort(List<float> list, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(list, left, right);
                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, right);
            }
        }

        static int Partition(List<float> list, int low, int high)
        {
            float pivot = list[low];
            int left = low + 1;
            int right = high;

            while (left <= right)
            {
                if (list.ElementAt(right) > pivot)
                {
                    right--;
                }
                else if (list.ElementAt(left) <= pivot)
                {
                    left++;
                }
                else if (right < left)
                {
                    break;
                }
                else
                {
                    Swap(list, left, right);
                }
            }

            Swap(list, low, right);
            return right;
        }

        private static void Swap(List<float> list, int i, int j)
        {
            float swapTemp = list[i];
            list[i] = list[j];
            list[j] = swapTemp;
        }
    }
}
