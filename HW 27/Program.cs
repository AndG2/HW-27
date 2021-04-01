using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new List<Course>
            {
                new Course {Id = 1, Name = "Calculus", Credits = 3 },
                new Course {Id = 2, Name = "Physics", Credits = 4 },
                new Course {Id = 3, Name = "Psychology", Credits = 1 },
                new Course {Id = 4, Name = "Underwater Basketweaving", Credits = 0 },
            };

            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Alice",
                    Age = 20,
                    EnrolledCourseId = 3
                },
                new Student
                {
                    Id = 2,
                    Name = "Bob",
                    Age = 23,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 3,
                    Name = "Charlie",
                    Age = 19,
                    EnrolledCourseId = 2
                },
                new Student
                {
                    Id = 4,
                    Name = "Diane",
                    Age = 20,
                    EnrolledCourseId = 4
                },
                new Student
                {
                    Id = 5,
                    Name = "Elliot",
                    Age = 21,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 6,
                    Name = "Frank",
                    Age = 18,
                    EnrolledCourseId = 3
                },
            };

            /*************************************************************
             * YOUR CODE GOES BELOW HERE                                 *
             *************************************************************/
            //1.Use LINQ to get just the names of all the students. Iterate over the result to print the names.
            var allNames = from n in students select n.Name;
            foreach (var name in allNames) Console.WriteLine(name);

            //2.Save the result of the query from #1 into a variable. After saving the LINQ query, but before iterating to print names, add a new student to the list. Observe the result.
            var allNames = from n in students select n.Name;
            var lateEntry = new Student() { Id = 7, Name = "Test", Age = 0, EnrolledCourseId = 5 };//nothing happens here
            foreach (var name in allNames) Console.WriteLine(name);

            //3.Add “.ToList()” to the end of the LINQ query from #2. Now observe the result.
            var allNames = from n in students select n.Name.ToList();
            var lateEntry = new Student() { Id = 7, Name = "Test", Age = 0, EnrolledCourseId = 5 };//nothing happens here
            foreach (var name in allNames) Console.WriteLine(name);

            //4.Use LINQ to get all the students enrolled in Course ID 3.Print the count of the result(Count()).
            var allInC3 = from third in students where third.EnrolledCourseId == 3 select third.Name;
            Console.WriteLine(allInC3.Count);

            //5.Use LINQ to get JUST the NAMES of all the students who are at least 21 years old. Iterate over the result to print the names.
            var min21 = from twon in students where twon.Age >= 21 select twon.Name;
            foreach (var name in min21) Console.WriteLine(name);

            //6.Print the names of all the courses worth at least 2 credits.
            var twoCredits = from minCredits in courses where minCredits.Credits >= 2 select minCredits.Name;
            foreach (var courseName in twoCredits) Console.WriteLine(courseName);

            //7.Print the average age of the students.
            var totalAge = students.Average(n => n.Age);
            Console.WriteLine("Average age of students is: " + totalAge);


            //8.Print the average age of the students enrolled in Course ID 1.
            var arvAgeC1 = students.Where(c => c.EnrolledCourseId == 1).Average(n => n.Age);
            Console.WriteLine("Course 1 average age: " + arvAgeC1);

            //9.Print the name of the student with the highest age.
            var ageSort = students.Aggregate((acc,curr) => curr.Age>acc.Age ? curr : acc);
            Console.WriteLine(ageSort.Name);

            Console.ReadLine();


           /*************************************************************
            * YOUR CODE GOES ABOVE HERE                                 *
            *************************************************************/

           Console.ReadKey(true);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public int EnrolledCourseId { get; set; }
    }

    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
    }

    class EnrolledStudent
    {
        public EnrolledStudent(Student s, Course c)
        {
            StudentId = s.Id;
            StudentAge = s.Age;
            StudentName = s.Name;
            CourseName = c.Name;
            Credits = c.Credits;
        }

        public int StudentId { get; set; }
        public int StudentAge { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
    }

}