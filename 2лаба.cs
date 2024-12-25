using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public abstract class Animal : Alive
    {
        int age;
        string name;
        string shape;

        public Animal(int age, string shape, string name)
        {
            if (age < 0)
                age = 0;

            this.age = age;
            this.name = name;
            this.shape = shape;
        }
        public virtual void MakeSound()
        {
            Console.WriteLine(shape);
        }

        public int GetAge()
        {
            return this.age;
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
    }

    public class Dog : Animal
    {
        public Dog(int age, string name) : base(age,
            "" +
                "           ^\\\n" +
                " /        //o__o\n" +
                "/\\       /  __/\n" +
                "\\ \\______\\  /     -ARF!\n" +
                " \\         /\n" +
                "  \\ \\----\\ \\\n" +
                "   \\_\\_   \\_\\_",
            name)
        {

        }
    }

    public class Cat : Animal
    {
        private static Random rnd = new Random();
        public Cat(int age, string name) : base(age,
            "" +
                "    /\\___/\\\n" +
                "   /       \\\n" +
                "  l  u   u  l\n" +
                "--l----*----l--\n" +
                "   \\   w   /     - Meow!\n" +
                "     ======\n" +
                "   /       \\ __\n" +
                "   l        l\\ \\\n" +
                "   l        l/ /\n" +
                "   l  l l   l /\n" +
                "   \\ ml lm /_/",
            name)
        {

        }

        public override void MakeSound()
        {
            if (rnd.Next(2) == 0)
            {
                Console.WriteLine($"" +
                "      /\\_/\\\n" +
                " /\\  / o o \\\n" +
                "//\\\\ \\~(*)~/\n" +
                "`  \\/   ^ /\n" +
                "   | \\|| \n" +
                "   \\ ' ||\n" +
                "    \\)()-()) [{0} the cat is not in the mood to meow]", GetName());
                return;
            }

            base.MakeSound();
        }
    }

    public interface Alive
    {
        void MakeSound();
        int GetAge();
        string GetName();
    }
    public class Person
    {
        private string name;
        private Alive companion;

        public Person(string name, Alive companion)
        {
            this.name = name;
            this.companion = companion;
        }

        public void GetCompanionInfo()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"Companion for {name} is named {companion.GetName()}");
            Console.WriteLine($"It is {companion.GetAge()} years ");
            Console.WriteLine("And it sounds like this:");
            companion.MakeSound();
            Console.WriteLine("--------------------");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog(3, "Bobik");
            Cat cat = new Cat(8, "Gav");

            Person person1 = new Person("Daria", cat);
            Person person2 = new Person("George", dog);

            person1.GetCompanionInfo();
            person2.GetCompanionInfo();
        }
    }
}
