using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace NetCoreConsole
{
    static class MyStringExt
    {
        public static bool isValidEmail(this string value)
        {
            if (value.Contains("@"))
            {
                return true;
            }
            else
                return false;
        }
    }
    static class MyEx
    {
        public static bool IsOver17(this Student student)
        {
            if (student.Age > 17)
            {
                return true;
            }
            else
                return false;
        }
        public static bool CheckValidName(this Student student)
        {
            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
            if (regex.IsMatch(student.Name))
            {
                return true;
            }
            else return false;

        }
        public static int AgeNext5Year(this Student student)
        {
            return student.Age + 5;
        }
    }
    class Student
    {
        public String Name { get; set; }
        public int Age { get; set; }
    }

    class SortStudentByName : IComparer<Student>
    {
        public int Compare([AllowNull] Student x, [AllowNull] Student y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class SortStudentByAge : IComparer<Student>
    {
        public int Compare([AllowNull] Student x, [AllowNull] Student y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("What is your name?");
            //var name = Console.ReadLine();
            //Console.WriteLine("Your age?");
            //var age = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Hello {0}, your are {1}",name,age);

            CultureInfo lang = new CultureInfo("ja-JP");
            var today = DateTime.Now;
            Console.WriteLine("Today is {0} {1} {2}", today.Day, today.Month, today.Year);
            Console.WriteLine(today.ToString("D", lang));
            var salary = 455788d;
            Console.WriteLine(salary.ToString("C", lang));

            var myEmail = "binhdq @ fpt.edu.vn";

            if (myEmail.isValidEmail())
            {
                Console.WriteLine("This is a valid email!");
            } else
            {
                Console.WriteLine("This is invalid email!");
            }
            var email2 = "tung@gmail.com";
            Console.WriteLine(email2.isValidEmail());

            List<Student> myclass = new List<Student>();
            myclass.Add(new Student { Name = "Phuong", Age = 23 });
            myclass.Add(new Student { Name = "Linh", Age = 30 });
            myclass.Add(new Student { Name = "Cuong", Age = 20 });
            myclass.Sort(new SortStudentByName());
            for (int i = 0; i < myclass.Count; i++)
            {
                Console.WriteLine("Name: {0} and Age: {1}",myclass[i].Name,myclass[i].Age);
            }

            var s = new Student{ Name="joshon jos",Age=23};
            Console.WriteLine(s.IsOver17());
            Console.WriteLine(s.CheckValidName());

        }          
    }
}
