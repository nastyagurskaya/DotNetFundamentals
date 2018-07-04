using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Soldier s = new Soldier();
            
            Gun gun = new Gun();

            s.Attack(gun);

            Knife k = new Knife();

            IFireArms knifeAttak = new KnifeToFireArmsAdapter(k);
     
            s.Attack(knifeAttak);

            Console.Read();
        }
    }
    interface IFireArms
    {
        void Shoot();
    }
    class Gun : IFireArms
    {
        public void Shoot()
        {
            Console.WriteLine("Gun is shooting");
        }
    }
    class Rifle : IFireArms
    {
        public void Shoot()
        {
            Console.WriteLine("Rifle is shooting");
        }
    }
    class Soldier
    {
        public void Attack(IFireArms weapon)
        {
            weapon.Shoot();
        }
    }
    interface IColdSteel
    {
        void Wound();
    }
    class Knife : IColdSteel
    {
        public void Wound()
        {
            Console.WriteLine("Attack with knife");
        }
    }
    class KnifeToFireArmsAdapter : IFireArms
    {
        Knife knife;
        public KnifeToFireArmsAdapter(Knife k)
        {
            knife = k;
        }

        public void Shoot()
        {
            knife.Wound();
        }
    }
}
