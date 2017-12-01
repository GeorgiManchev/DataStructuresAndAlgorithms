using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public static class Search
    {
        public static int BinaryIterative<T>(this IList<T> group, T key) where T : IComparable<T>
        {
            int min = 0;
            int mid = 0;
            int max = group.Count - 1;
            while (min <= max)
            {
                mid = (min + max) / 2;
                switch (key.CompareTo(group[mid]))
                {
                    //key is before middle element
                    case -1:
                        max = mid - 1;
                        break;
                    //key is after middle element
                    case 1:
                        min = mid + 1;
                        break;
                    //found a matching element
                    default:
                        return mid;
                }
            }
            //no matching element found
            return -1;
        }

        public static int BinaryRecursive<T>(IList<T> group, int key, int min, int max) where T : IComparable<T>
        {
            //no matching element found
            if (min > max)
            {
                return -1;
            }

            int mid = (min + max) / 2;
            switch (key.CompareTo(group[mid]))
            {
                //found a matching element
                case 0:
                    return mid;
                //key is before middle element
                case -1:
                    max = mid - 1;
                    break;
                //key is after middle element
                case 1:
                    min = mid + 1;
                    break;
            }

            return BinaryRecursive(group, key, min, max);
        }
    }
}
