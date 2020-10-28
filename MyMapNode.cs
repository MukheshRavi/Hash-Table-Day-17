using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public class MyMapNode<K, V>
    {
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        /// <summary>
        /// Parameterised constructor
        /// </summary>
        /// <param name="size"></param>
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        /// <summary>
        /// This method returns Position based on key entered 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected int GetPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = hash % size;
            return Math.Abs(position);
        }
        /// <summary>
        /// this method adds item in hash table
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            int position = GetPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>()
            { Key = key, Value = value };
            ///If element already present then it will not add in hash table
            if(!ElementPresent(key))
            linkedList.AddLast(item);
            Console.WriteLine(item.Key + " " + item.Value);

        }
        /// <summary>
        /// This method checks whether a linked list is already there or not
        /// If not present then creates linked list at that position 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        /// <summary>
        /// This method displays whole hash table
        /// </summary>
        public void Display()
        {
            Console.WriteLine(" ");
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
            }
        }
        /// <summary>
        /// This method searches every linked list and returns frequency of string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Frequency(K key)
        {
            int count = 0;
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                {
                    foreach (var element in linkedList)
                    {
                        if (element.Key.Equals(key))
                            count++;
                    }
                }
            }
            Console.WriteLine("The frequency of " + key + "is : " + count);
            return count;
        }
        /// <summary>
        /// This methods returns true if element already present
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ElementPresent(K key)
        {
            int hash = key.GetHashCode();
            int position = hash % size;
            foreach (var element in items[Math.Abs(position)])
            {
                if (element.Key.Equals(key))
                    return true;
                else
                    return false;
            }
            return false;
        }
        /// <summary>
        /// This method searches for a element based on key and later deletes that element
        /// </summary>
        /// <param name="key"></param>
        public void RemoveElement(K key)
        {
             foreach (var linkedList in items)
             {
                 if (linkedList != null)
                 {
                     foreach (var element in linkedList)
                     {
                        if (element.Key.Equals(key))
                        {
                            linkedList.Remove(element);
                            break;
                        }
                     }
                 }
             }

        }
    }
}
