using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMapNode<int,string> myMapNode = new MyMapNode<int,string>(5);
            int key = 1;
            string input = "Paranoids are not paranoid because they are paranoid but because " +
                "they keep putting themselves deliberately into paranoid avoidable situations";
            string[] sample = input.Split(' ');
            foreach (string s in sample)
            {
                myMapNode.Add(key, s);
                key++;
            }
            myMapNode.Display();
            myMapNode.Frequency("paranoid");
          
           
            
        }
    }
}
