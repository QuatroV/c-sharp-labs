using System;
using System.Collections.Generic;
using System.Reflection;

namespace lab7
{
    class MarkValidationAttribute : Attribute
    {
        public int Age { get; };
        public MarkValidationAttribute(int age) => Age = age;
    }
    class Student
    {
        readonly int id;
        readonly string name;
        readonly string surname;
        readonly string lastName;

        Dictionary<string, List<int>> marks;

        public Student(int id, string name, string surname, string lastName)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.lastName = lastName;
            marks = new Dictionary<string, List<int>>();
        }

        public Student(int id, string name, string surname, string lastName, Dictionary<string, List<int>> marks)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.lastName = lastName;
            this.marks = marks;
        }

        public Dictionary<string, List<int>> AddMark(string subject, int mark) {
            marks[subject].Add(mark);
            return marks;
        }

        public Dictionary<string, List<int>> RemoveMark(string subject, int mark)
        {
            marks[subject].Remove(mark);
            return marks;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var John = new Student(1, "John", "Doe", "Michael");
            var studentType = John.GetType();
            Console.WriteLine("Поля:");
            foreach (FieldInfo field in studentType.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                string modificator = "";

                // получаем модификатор доступа
                if (field.IsPublic)
                    modificator += "public ";
                else if (field.IsPrivate)
                    modificator += "private ";
                else if (field.IsAssembly)
                    modificator += "internal ";
                else if (field.IsFamily)
                    modificator += "protected ";
                else if (field.IsFamilyAndAssembly)
                    modificator += "private protected ";
                else if (field.IsFamilyOrAssembly)
                    modificator += "protected internal ";

                // если поле статическое
                if (field.IsStatic) modificator += "static ";

                Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
            }

        }
    }
}
