using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.Sort
{
    public static class Sort
    {
        //personal favorite
        public static void CountingSort(this ICollection<int> items, int min, int max)
        {
            var holder = new int[max - min + 1];
            foreach (int item in items)
            {
                holder[item - min]++;
            }

            items.Clear();

            for (int i = 0; i < holder.Length; i++)
            {
                while (holder[i] > 0)
                {
                    items.Add(i + min);
                    holder[i]--;
                }
            }
        }

        //use: for items having a narrow range of integers
        public static void CountingSort<T>(this ICollection<T> items, int minRangeValue, Func<T, int> getRangeValue)
        {
            //can also use a array if maxRangeValue is known
            var map = new SortedDictionary<int, ICollection<T>>();

            while (items.Any())
            {
                T item = items.First();
                int index = getRangeValue(item) - minRangeValue;
                if (!map.ContainsKey(index))
                {
                    map.Add(index, new List<T>());
                }
                map[index].Add(item);
                items.Remove(item);
            }

            //re-fill
            foreach (var value in map.Values)
            {
                items.Concat(value);
            }
        }

        public static void SelectionSort<T>(this IList<T> items) where T : IComparable<T>
        {
            //save access to momory
            int lastIndex = items.Count;

            for (int item = 0; item < lastIndex - 1; item++)
            {
                int min = item;
                for (int next = item + 1; next < lastIndex; next++)
                {
                    if (items[min].CompareTo(items[next]) > 0)
                    {
                        min = next;
                    }
                }

                if (min != item)
                {
                    items.SwapItems(item, min);
                }
            }
        }

        public static void BubbleSort(this IList<int> items)
        {
            //save accessing momory
            int lastIndex = items.Count;
            int next;
            bool IsSorted = false;
            while (!IsSorted)
            {
                IsSorted = true;
                for (int selected = 0; selected < lastIndex - 1;)
                {
                    next = selected + 1;
                    if (items[selected] > items[next])
                    {
                        items.SwapItems(selected, next);
                        IsSorted = false;
                    }
                    selected = next;
                }

            }
        }

        //fastest for around 20 elements
        public static void InsertionSort(this IList<int> items)
        {
            for (int selected = 1; selected < items.Count; selected++)
            {
                int pos = selected;

                while (pos > 0 && items[pos] < items[pos - 1])
                {
                    items.SwapItems(pos, pos - 1);
                    pos--;
                }
            }
        }

        public static IEnumerable<int> QuickSort(this IList<int> items)
        {
            if (items.Count < 2)
            {
                return items;
            }

            int pivodIndex = items.Count / 2;
            var head = new List<int>(pivodIndex);
            var tail = new List<int>(pivodIndex);

            for (int i = 0; i < items.Count; i++)
            {
                if (i == pivodIndex)
                {
                    continue;
                }

                if (items[i] < items[pivodIndex])
                {
                    head.Add(items[i]);
                }
                else
                {
                    tail.Add(items[i]);
                }
            }
            var result = new List<int>(items.Count);

            result.AddRange(head.QuickSort());
            result.Add(items[pivodIndex]);
            result.AddRange(tail.QuickSort());
            return result;
        }

        public static void SwapItems<T>(this IList<T> source, int itemOneIndex, int itemTwoIndex)
        {
            T temp = source[itemOneIndex];
            source[itemOneIndex] = source[itemTwoIndex];
            source[itemTwoIndex] = temp;
        }
    }
}
