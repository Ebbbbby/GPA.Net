using System;
using System.Collections.Generic;
using System.Linq;

namespace GPA.Net
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please fill in the course name and unit");
            Console.WriteLine("To exit, enter No, to continue enter Yes");
            string input = Console.ReadLine();

            var courseList = new List<StudentResultRequestModel>();


            while (input.ToLower() != "no")
            {
                Console.WriteLine("Enter course name");
                var courseName = Console.ReadLine().ToUpper();

                while (string.IsNullOrEmpty(courseName) || courseName.Length != 3)
                {
                    Console.WriteLine("Course input invalid");

                    courseName = Console.ReadLine();

                }

                    Console.WriteLine("Enter course code");
                    var courseCode = (Console.ReadLine());
               
       
               
                Console.WriteLine("Enter course unit");
                int.TryParse( Console.ReadLine() ,out int courseUnit);
                if(courseUnit > 5)
                {
                    Console.WriteLine("Input the correct unit");
                    courseUnit = int.Parse(Console.ReadLine());
                }


                Console.WriteLine("Enter course score");
                var courseScore = decimal.Parse(Console.ReadLine());
                

                ScoreGradeModel gradeScore = GetScoreGrade(courseScore);
                if (gradeScore == null)
                {
                    Console.WriteLine("Could not determine score grade");
                    break;
                }

                var courseResult = new StudentResultRequestModel()
                {
                    CourseName = courseName,
                    CourseCode = courseCode,
                    CourseScore = courseScore,
                    CourseUnit = courseUnit,
                    Grade = gradeScore.Grade,
                    Point = gradeScore.Point,
                    Remark = gradeScore.Remark,
                    Weight = gradeScore.Point * courseUnit,

                };
                courseList.Add(courseResult);
                Console.WriteLine("Enter Yes to continue");
               var proceed =  Console.ReadLine();
                if (proceed.ToLower() != "yes")
                {
                    break;
                }
            
            }
            
            var totalUnit = courseList.Sum(x => x.CourseUnit);

            var totalWeight = courseList.Sum(x => x.Weight);

            var totalGradePoint = courseList.Sum(x => x.Point);

            var GDP = totalWeight / totalGradePoint;

            Table.Display(courseList);
            Console.WriteLine($"Total Course Unit Registered is {totalUnit}");

            Console.WriteLine($"Total Weight Point is {totalGradePoint}");

            Console.WriteLine($"Total  Weight Point is {totalWeight}");

            Console.WriteLine($"Your GDP is {GDP:N2}");
      


        }


        public static ScoreGradeModel GetScoreGrade(decimal score)
        {
            if(score > 100 || score < 0 )
            {
                return null;
            }
            if(score >= 0 && score <= 44)
            {
                return new ScoreGradeModel
                {
                    Grade = "E",
                    Point = 1,
                    Remark = "Very poor result"
                };
            }

            if(score >=45 && score <= 49)
            {
                return new ScoreGradeModel
                {
                    Grade = "D",
                    Point = 2,
                    Remark = "poor result"
                };
            }
            if (score >= 50 && score <= 59)
            {
                return new ScoreGradeModel
                {
                    Grade = "C",
                    Point = 3,
                    Remark = " Fair result"
                };
            }
            if (score >= 60 && score <= 69)
            {
                return new ScoreGradeModel
                {
                    Grade = "B",
                    Point = 4,
                    Remark = "Good result"
                };
            }
            if (score >= 70 && score <= 100)
            {
                return new ScoreGradeModel
                {
                    Grade = "A",
                    Point = 5,
                    Remark = "Excellent Result"
                };
            }
            return null;
        }
        
    }
}
