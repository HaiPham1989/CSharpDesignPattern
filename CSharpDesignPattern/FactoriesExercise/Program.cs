using System;
using static System.Console;

namespace FactoriesExercise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Name = name;
            Id = id;
        }
    }

    public interface IPersonFactory
    {
        public Person CreatePerson(string name);
    }

    internal class PersonFactory : IPersonFactory
    {
        private int index;

        public Person CreatePerson(string name)
        {
            var person = new Person(index, name);
            index++;
            return person;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var personFactory = new PersonFactory();
            var person1 = personFactory.CreatePerson("HaiPT");
            var person2 = personFactory.CreatePerson("MaiNTT");
        }
    }
}
