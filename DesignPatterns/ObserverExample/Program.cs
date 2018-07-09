using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Project proj = new Project();
            Developer dev = new Developer("Mike", proj);
            QA qa = new QA("Hanna", proj);

            proj.NewTask();
            qa.StopWork();
            proj.NewTask();

            Console.Read();
        }
    }

    interface IObserver
    {
        void Update(int num);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers(int num);
    }

    class Project : IObservable
    {
        private Random rnd;
        List<IObserver> observers;
        public Project()
        {
            observers = new List<IObserver>();

           rnd = new Random();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(int num)
        {
            foreach (IObserver o in observers)
            {
                o.Update(num);
            }
        }

        public void NewTask()
        {
            int taskNum = rnd.Next(1000, 2000);
            NotifyObservers(taskNum);
        }
    }

    class Developer : IObserver
    {
        public string Name { get; set; }
        IObservable proj;
        public Developer(string name, IObservable obs)
        {
            this.Name = name;
            proj = obs;
            proj.RegisterObserver(this);
        }
        public void Update(int num)
        {
            Console.WriteLine("Developer "+ Name + " got a new task number " + num);
        }
        public void StopWork()
        {
            proj.RemoveObserver(this);
            proj = null;
        }
    }

    class QA : IObserver
    {
        public string Name { get; set; }
        IObservable proj;
        public QA(string name, IObservable obs)
        {
            this.Name = name;
            proj = obs;
            proj.RegisterObserver(this);
        }
        public void Update(int num)
        {
            Console.WriteLine("QA " + Name + " got a new task number " + num);
        }
        public void StopWork()
        {
            proj.RemoveObserver(this);
            proj = null;
        }
    }
}