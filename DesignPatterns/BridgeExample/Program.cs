using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Artist painter = new Painter("Raffaello Santi", new Star());
            painter.DoWork();
            painter.Shape = new Square();
            painter.DoWork();
            Console.Read();
        }
    }
    interface IShape
    {
        void Draw();
        void Rotate();
    }

    class Star : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Star was drawn");
        }

        public void Rotate()
        {
            Console.WriteLine("Star rotated");
        }
    }

    class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Square was drawn");
        }

        public void Rotate()
        {
            Console.WriteLine("Square rotated");
        }
    }
    abstract class Artist
    {
        protected IShape shape;
        public IShape Shape
        {
            set { shape = value; }
        }
        public Artist(IShape sh)
        {
            shape = sh;
        }
        public abstract void DoWork();
        public void DrawShape()
        {
            shape.Draw();
        }
        public void RotateShape()
        {
            shape.Rotate();
        }
    }

    class Painter : Artist
    {
        private String name;
        public Painter(String n, IShape sh) : base(sh)
        {
            name = n;
        }
        public override void DoWork()
        {
            DrawShape();

            Console.WriteLine(" by Painter:" +name);
        }
    }
    class Designer : Artist
    {
        private String name;
        public Designer(String n, IShape sh) : base(sh)
        {
            name = n;
        }
        public override void DoWork()
        {
            RotateShape();

            Console.WriteLine(" by Designer:" + name);
        }
    }
}