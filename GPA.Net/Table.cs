using System;
using System.Collections.Generic;
using System.Text;

namespace GPA.Net
{
    internal static class Table
    {
        static int tableWidth = 88;

        internal static void Display( List <StudentResultRequestModel> model)
        {
            Console.Clear();
            PrintLine();
            PrintRow("COURSE & CODE", "COURSE UNIT", "GRADE", "GRADE-UNIT", "WEIGHT PT", "REMARK");
            PrintLine();
            foreach (StudentResultRequestModel m in model)
            {
              
                PrintRow($"{m.CourseName} {m.CourseCode}", $"{m.CourseUnit}", $"{m.Grade}", $"{m.Point}", $"{m.Weight}", $"{m.Remark}");
            }
     
            PrintLine();
          
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
