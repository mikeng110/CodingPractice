
using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        private List<double> Grades;
        private string Name;

        public Book(string name)
        {
            Grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            Grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in Grades)
            {
                result.Average += grade;
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
            }

            result.Average /= Grades.Count;

            return result;
        }

       
        public void ShowStatistics()
        {
            var stat = GetStatistics();

            Console.WriteLine($"The Lowest Grade is {stat.Low}");
            Console.WriteLine($"The Highest Grade is {stat.High}");
            Console.WriteLine($"average grade : {stat.Average:N1}");
        }
    }
}
