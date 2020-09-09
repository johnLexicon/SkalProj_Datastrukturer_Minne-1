﻿using System;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        Console.WriteLine("Check Paranthesis");
                        string user = Console.ReadLine();
                        
                        var result = CheckParanthesis(user);
                        if (result == true)
                        {
                            Console.WriteLine("Your paranthesis is right");
                        }
                        else
                        {
                            Console.WriteLine("Your paranthesis is wrong");
                        }

                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            
            List<string> theList = new List<string>();
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the \n(+, -, 0) of your choice"
                    + "\n+. Add to list"
                    + "\n-. Remove from list"
                    + "\n0 Exit from list program");


                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Capacity: {theList.Capacity} Count: {theList.Count}");
                        break;
                    case '-':
                        theList.Remove(value); 
                        Console.WriteLine($"Capacity: {theList.Capacity} Count: {theList.Count}");
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter some valid input (+, -, 0");
                        break;
                }
            }


            
    }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> theQueue = new Queue<string>();
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the \n(+, -, 0) of your choice"
                    + "\n+. Add to queue"
                    + "\n-. Remove from queue"
                    + "\n0 Exit from queue");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        Console.WriteLine($"Count: {theQueue.Count}");
                        break;
                    case '-':
                        //Tips: Hantera Undantaget som kastas när man försöker anropa Dequeue() på tom lista.
                        try
                        {
                            theQueue.Dequeue();
                            Console.WriteLine($"Count: {theQueue.Count}");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("Queue is already empty");
                        }
                        break;
                    case '0':
                        return;

                    default:
                        Console.WriteLine("Please enter some valid input(+, -, 0");
                        break;
                }


            }
            
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Stack<string> theStack = new Stack<string>();
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the \n(+, -, 0) of your choice"
                    + "\n+. Add to stack"
                    + "\n-. Remove from stack"
                    + "\n0 Exit from stack");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theStack.Push(value);
                        Console.WriteLine($"Count: {theStack.Count}");
                        break;
                    case '-':
                        try
                        {
                            theStack.Pop();
                            Console.WriteLine($"Count: {theStack.Count}");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("The stack is already empty");
                        }
                        break;
                    case '0':
                        return;

                    default:
                        Console.WriteLine("Please enter some valid input(+, -, 0");
                        break;
                }


            }
        }

        static bool CheckParanthesis(string text)
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Stack<char> stack = new Stack<char>();

            foreach (var ch in text)
            {
                switch (ch)
                {
                    case '(':
                        stack.Push((char)(ch + 1));
                        break;
                    case '[':
                    case '{':
                        stack.Push((char)(ch + 2));
                        break;
                    case ')':
                    case ']':
                    case '}':
                        if (stack.Count == 0 || !ch.Equals(stack.Pop()))
                        {

                            return false;
                        }
                        break;
                    
                }

            }
            if (stack.Count > 0)
            {
                return false;
            }

            return true;
            


        }

    }
}

