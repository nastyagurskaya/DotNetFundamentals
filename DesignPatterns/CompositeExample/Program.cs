using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompositeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Component musicLibrary = new Playlist("Music Library");
            Component indie = new Playlist("Indie");
            Component song1 = new Song("Foals - What went down", 10);
            Component song2 = new Song("Enter Shikari - Constallation", 12);
            Component song3 = new Song("Enter Shikari - Solidarity", 4);
            indie.Add(song1);
            indie.Add(song2);
            musicLibrary.Add(indie);
            musicLibrary.Add(song3);
            musicLibrary.Play();
            Console.WriteLine();

            Console.Read();
        }
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }
        public virtual void Play() { }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
    }
    class Playlist : Component
    {
        private List<Component> components = new List<Component>();

        public Playlist(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }
        public override void Play()
        {
            Console.WriteLine("Playlist " + name);
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Play();
            }
            Console.WriteLine("Playing finished");
        }
    }

    class Song : Component
    {
        private int duration;
        public Song(string name, int duration)
                : base(name)
        {
            this.duration = duration;
        }
        public override void Play()
        {
            Console.WriteLine(this.name + " is playing");
            Thread.Sleep(duration * 1000);
        }
    }
}