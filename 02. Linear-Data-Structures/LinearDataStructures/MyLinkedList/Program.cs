//Implement the data structure linked list.
//  - Define a class `ListItem<T>` that has two fields: `value` (of type `T`) and `NextItem` (of type `ListItem<T>`). 
//  - Define additionally a class `LinkedList<T>` with a single field `FirstElement` (of type `ListItem<T>`).

namespace MyLinkedList
{
    using System;

    class Program
    {
        static void Main()
        {
            LinkedList<string> todoList = new LinkedList<string>();
            todoList.Add("Ana");
            todoList.Add("Marya");
            todoList.Add("Jasmina");
            todoList.Add("Stoyanka");
            todoList.Remove("Stoyanka");
            Console.WriteLine("I have to todo:");
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine(todoList[i]);
            }
            Console.WriteLine("Do I have to todo Pesho? " +
            todoList.Contains("Pesho"));
        }
    }
}