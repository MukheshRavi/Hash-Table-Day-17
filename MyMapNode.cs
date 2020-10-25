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
        public int Frequency(V value)
        {
            int count = 0;
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                {
                    foreach (var element in linkedList)
                    {
                        if (element.Value.Equals(value))
                            count++;
                    }
                }
            }
            Console.WriteLine("The frequency of " + value + "is : " + count);
            return count;
        }
       

        public void RemoveElement(V value)
        {
             foreach (var linkedList in items)
             {
                 if (linkedList != null)
                 {
                     foreach (var element in linkedList)
                     {
                        if (element.Value.Equals(value))
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
