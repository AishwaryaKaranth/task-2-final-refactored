using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleApp{
    class Student
    {
        public string name;
        public int rollNumber;
        public List<int> marks = new List<int>();

        public Student(string name, int rollNumber)
        {
            this.name = name;
            this.rollNumber = rollNumber;
        }

        public Student(List<int> marks)
        {
            this.marks = marks;
        }


    }

}
