using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_concurrency.Threads
{
    class PassingParameters
    {
        ParameterizedThreadStart pts;
        Thread ptsThread;
        Thread lambdaThread;
        public PassingParameters()
        {
            Person bill = new Person("Bill", 42);
            // ParameterizedThreadStart passing parameters
            pts = new ParameterizedThreadStart(PersonHandler);
            ptsThread = new Thread(pts);
            ptsThread.Start(bill);
            // Lambda passing parameters
            lambdaThread = new Thread(() =>
            {
                Console.WriteLine("Invoking with lambda expression");
                bill.SayHello();
            });
            lambdaThread.Start();
            // Looping lambda thread parameters
            Thread[] threads= new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                // temp variable solves problem with passing Thread parameters in lambda expression
                int temp = i;
                var t = new Thread(() =>
                {
                    Console.WriteLine(temp);
                });
                threads[i] = t;
            }
            Thread.Sleep(100);
            foreach(Thread t in threads)
            {
                t.Start();
            }
        }
        void PersonHandler(object person)
        {
            Person person1 = person as Person;
            Console.WriteLine("Invoking with ParameterizedThreadStart delegate");
            person1.SayHello();
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public void SayHello()
        {
            Console.WriteLine($"Hello my name is {this.Name}, I am {this.Age} years old.");
        }
    }
}
