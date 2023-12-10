using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {

        static janitor[] janitors;
        static programmer[] programmers;
        static CEO[] CEOs;
        // Replace the main method with the following
        static void Main(string[] args)
        {
            createEmployees();

            int MAX = 200;
            employee[] arr = new employee[MAX];

            //arr[1] = new CEO() { name = "ThaCeo", salary = 10000 };
            for (int i = 0; i < janitors.Length && i < MAX; i++)
            {
                arr[i] = janitors[i];
            }

            for (int i = 0; i < programmers.Length && i < MAX; i++)
            {
                int index = i + janitors.Length;
                if (index < MAX)
                {
                    arr[index] = programmers[i];
                }
            }

            for (int i = 0; i < CEOs.Length && i < MAX; i++)
            {
                int index = i + janitors.Length + programmers.Length;
                if (index < MAX)
                {
                    arr[index] = CEOs[i];
                }
            }



            int n = janitors.Length + programmers.Length + CEOs.Length; // Initialize n with the total number of employees
            maxHeap heap = new maxHeap(MAX);

            for (int i = 0; i < n; i++)
            {
                heap.insertNode(arr[i]);
                

            }

            heap.printArray(arr, n);
            Console.ReadLine();
        }


        public static void createEmployees()
        {

            janitors = new janitor[3];
            programmers = new programmer[4];
            CEOs = new CEO[3];


            janitors[0] = new janitor() { name = "Josh", salary = 10 };
            janitors[1] = new janitor() { name = "Rebecca", salary = 20 };
            janitors[2] = new janitor() { name = "Geno", salary = 30 };
            programmers[0] = new programmer() { name = "Ahrianna", salary = 100 };
            programmers[1] = new programmer() { name = "Joffery", salary = 200 };
            programmers[2] = new programmer() { name = "Balard", salary = 500 };
            programmers[3] = new programmer() { name = "Cole", salary = 300 };
            CEOs[0] = new CEO() { name = "Joe", salary = 20420 };
            CEOs[1] = new CEO() { name = "Calley", salary = 10322 };
            CEOs[2] = new CEO() { name = "Joff", salary = 10222 };

        }
        class maxHeap
        {
            private employee[] heap;
            private int size;
            private int capacity;

            public maxHeap(int capacity)
            {
                this.capacity = capacity;
                this.size = 0;
                this.heap = new employee[capacity + 1];
            }

            public void heapify(int i)
            {
                int parent = (i - 1) / 2;

                if (parent >= 0 && heap[i].salary > heap[parent].salary)
                {
                    swap(i, parent);
                    heapify(parent);
                }
            }

            private void swap(int i, int j)
            {
                employee temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }

            public void insertNode(employee salary)
            {
                if (size < capacity)
                {
                    heap[size] = salary;
                    heapify(size);
                    size++;
                }
                else
                {
                    Console.WriteLine("Heap is full. Cannot insert more elements.");
                }
            }

            public void printArray(employee[] arr, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{arr[i].name} ({arr[i].salary}) ");
                }
                Console.WriteLine();
            }
        }


        class employee
        {
            public string name { get; set; }
            public int salary { get; set; }
            public virtual void OutputEarnings()
            {
                Print($"This Employee, '{name}' Earns {salary} a year.");
            }

            public virtual void OutputJobDescription()
            {
                Print("to create or clean or make as much money from their workers while paying them the least");
            }

        }





        class janitor : employee
        {
            public override void OutputJobDescription()
            {
                Print("The Janitorial position entails ensuring the cleanliness and hygiene of our facilities.\n Responsibilities include routine cleaning tasks such as sweeping, mopping, and sanitizing surfaces. \nThe Janitor is be responsible for trash removal, replenishing cleaning supplies, and monitoring inventory. \nAdditionally, the role involves basic maintenance tasks, reporting issues to management, and collaborating with the team to maintain a safe and organized environment.");
            }


        }



        class programmer : employee 
        {

            public override void OutputJobDescription()
            {
                int bugsSquashed = bugsFixed();
                int bugsBorn = bugsCreated(bugsSquashed);
                Print($"The programmer's job is to program whatever is required of them, swiftly and efficently. additionally, they will be required to review support tickets and fix any bugs found. they have fixed {bugsSquashed} and created {bugsBorn}");
            }
            public int bugsFixed()
            {
                return 0;
            }

            public int bugsCreated(int bugsFixed)
            {
                return bugsFixed + bugsFixed;
            }
        }

        class CEO : employee
        {
            private int annualBonus()
            {
                return 100000;
            }
            public override void OutputJobDescription()
            {
                int bonus = annualBonus();
                Print($"I'm not quite sure what our ceo does, I just know he gets annual bonuses of {bonus} ish");
            }

        }





        public static void Print(string text, int delay = 20) //type writer effect
        {
            foreach (var c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();

        }
    }




}
