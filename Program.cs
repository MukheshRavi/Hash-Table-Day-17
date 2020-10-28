using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMapNode<string,int> myMapNode = new MyMapNode<string,int>(5);
            string input = "Paranoids are not paranoid because they are paranoid but because " +
                "they keep putting themselves deliberately into paranoid avoidable situations";
            string[] sample = input.Split(' ');
            foreach (string s in sample)
            {
                int count = 0;
                foreach (string m in sample)
                {
                    if (s.Equals(m))
                        count++;
                }
                myMapNode.Add(s,count);
               
            }



            myMapNode.Display();
            myMapNode.Frequency("paranoid");
            myMapNode.RemoveElement("avoidable");
            myMapNode.Display();
          
           
            
        }
    }
}
