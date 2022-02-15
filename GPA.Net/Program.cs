using System;
using System.Collections.Generic;
using System.Linq;

namespace GPA.Net
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("------------FOLLOW THE INSTRUCTIONS CAREFULLY ------------------\n \n");
            Console.WriteLine("To Contine enter \"Yes\",to Exit enter \"No\"");
            string input = Console.ReadLine();

            var courseList = new List<StudentResultRequestModel>();

            while (input.ToLower() !="No".ToLower())
            {
                Console.WriteLine("Enter course name");
                var courseName = Console.ReadLine().ToUpper();

                while (string.IsNullOrEmpty(courseName) || courseName.Length != 3)
                {
                    Console.WriteLine("Course name input invalid, Course name must be three letters ");
                    Console.WriteLine("Enter course name");
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

                Console.WriteLine("Enter Yes to continue ");
               var proceed =  Console.ReadLine();
                if (proceed.ToLower() != "yes")
                {
                    break;
                }
            
            }
            
            var totalUnit = courseList.Sum(item => item.CourseUnit);

            var totalWeight = courseList.Sum(item => item.Weight);

            var totalGradePoint = courseList.Sum(item => item.Point);

            var GDP = totalWeight / totalGradePoint;

            Table.Display(courseList);

            Console.WriteLine($"Total Course Unit is {totalUnit}");

            Console.WriteLine($"Total Course Passed is {totalGradePoint}");
            
            Console.WriteLine($"Total  Weight Point is {totalWeight}");

            Console.WriteLine($"Your GDP is {GDP:N2}");
      


        }


        static ScoreGradeModel GetScoreGrade(decimal score)
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
                    Remark = "Pass"
                };
            }

            if(score >=45 && score <= 49)
            {
                return new ScoreGradeModel
                {
                    Grade = "D",
                    Point = 2,
                    Remark = "Fair"
                };
            }
            if (score >= 50 && score <= 59)
            {
                return new ScoreGradeModel
                {
                    Grade = "C",
                    Point = 3,
                    Remark = "Good"
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
