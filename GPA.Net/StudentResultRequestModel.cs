using System;
using System.Collections.Generic;
using System.Text;

namespace GPA.Net
{
    public class StudentResultRequestModel
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set;}

        public int CourseUnit { get; set; }

        public decimal CourseScore { get; set; }

        public string Grade { get; set; }

        public string  Remark { get; set; }

        public int Point { get; set; }

        public int Weight { get; set; }
    }
}
