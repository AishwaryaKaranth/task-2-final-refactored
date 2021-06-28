using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleApp
{
    class MainClass
    {
        static List<Student> studList = new List<Student>();
        static List<School> schoolList = new List<School>();
        static List<int> marks = new List<int>();
        static int rollNumber;
        public static void Main(string[] args)
        {
            SchoolDetails();
        }


        public static void SchoolDetails()
        {
            Console.WriteLine("Enter School Name:");
            string schoolName = Console.ReadLine();
            schoolList.Add(new School(schoolName = schoolName));
            //School sc= new School();
            //var t=sc.setSchoolName(schoolName);

            if (!CheckStringValidity(schoolName) || schoolName.Length < 3)
            {
                Console.WriteLine("Enter valid school name");
                SchoolDetails();
            }
            Console.WriteLine("Welcome to " + schoolName + " Student Information Portal");
            Console.WriteLine("--------------------------------");
            MainMenu();
        }

        public static bool CheckStringValidity(string name)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(name))
                valid = false;
            else
            {
                valid = Regex.IsMatch(name, @"^[a-zA-Z]+$");
                foreach (char c in name)
                {
                    if (!Char.IsLetter(c))
                        valid = false;
                }
            }
            return valid;
        }

        public static bool CheckOptionValidity(int option)
        {

            if (option != 1 && option != 2 && option != 3 && option != 4)
            {
                Console.WriteLine("Enter valid option");
                option = int.Parse(Console.ReadLine());
                CheckOptionValidity(option);
            }
            return true;
        }


        public static void MainMenu()
        {
            //Student st=new Student();
            Console.WriteLine("1. Add student\n");
            Console.WriteLine("2. Add marks for student\n");
            Console.WriteLine("3. Show student progress card\n");
            Console.WriteLine("4. Exit the application\n");
            Console.WriteLine("Please provide valid input from menu options :");
            //int option=int.Parse(Console.ReadLine());
            int option;
            bool checkInteger = int.TryParse(Console.ReadLine(), out option);
            //Console.WriteLine(checkInteger);
            try
            {
                if (checkInteger)
                {
                    if (CheckOptionValidity(option))
                    {
                        //mainMenu();
                        switch (option)
                        {
                            case 1:
                                AddStudent();
                                break;
                            case 2:
                                AddMark();
                                break;
                            case 3:
                                ProgressCard(rollNumber, marks);
                                break;
                            case 4:
                                ExitApplication();
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("enter valid option");
                    MainMenu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter valid data");
                MainMenu();
            }

        }


        public static void AddStudent()
        {
            Console.WriteLine("1. Add Student\n ----------------------------------");
            try
            {
                Console.WriteLine("Enter Student Roll Number :");
                int rollNumber;
                bool checkInt = int.TryParse(Console.ReadLine(), out rollNumber);
                for (int i = 0; i < studList.Count; i++)
                {
                    if (rollNumber == studList[i].rollNumber)
                    {
                        Console.WriteLine("Student with this roll number already exists.");
                        AddStudent();
                    }
                }
                if (!checkInt || rollNumber <= 0)
                {
                    Console.WriteLine("Enter valid roll number");
                    AddStudent();
                }
                Console.WriteLine("Enter Student Name :");
                string name = Console.ReadLine();
                while (!CheckStringValidity(name) || name.Length < 3)
                {
                    Console.WriteLine("Enter valid name");
                    name = Console.ReadLine();
                }

                if (checkInt)
                {
                    studList.Add(new Student(name = name, rollNumber = rollNumber));
                }
                else
                {
                    Console.WriteLine("Enter valid roll number");
                    AddStudent();
                }

                Console.WriteLine("Student details successfully added.");
                MainMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter valid data.");
                MainMenu();
            }

        }


        public static bool checkValidity(int marks)
        {
            if (marks < 0 || marks > 100)
            {
                //Console.WriteLine("enter valid marks");
                return false;
            }
            return true;
        }

        public static void AddMark()
        {
            int[] array = new int[6];
            if (studList.Count == 0)
            {
                Console.WriteLine("Add a student first");
                AddStudent();
            }
            Console.WriteLine("2. Add Marks\n ---------------------");
            Console.WriteLine("Enter Student Roll Number :");
            int rollNumber;
            bool checkInteger = int.TryParse(Console.ReadLine(), out rollNumber);
            while (!checkInteger || rollNumber <= 0)
            {
                Console.WriteLine("Enter valid roll number");
                checkInteger = int.TryParse(Console.ReadLine(), out rollNumber);
            }

            int count = 0;
            for (int i = 0; i < studList.Count; i++)
            {
                if (studList[i].rollNumber == rollNumber)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Student does not exist, add student first\n");
                Console.WriteLine("Do you want to add a new student? y/n");
                char c = Console.ReadLine()[0];
                if (c == 'y')
                {
                    AddStudent();
                }
                if (c == 'n')
                {
                    AddMark();
                }
                if (c != 'y' || c != 'n')
                {
                    Console.WriteLine("Enter y or n");
                    AddMark();
                }
            }

            for (int i = 0; i < studList.Count; i++)
            {
                if (studList[i].rollNumber == rollNumber)
                {
                    if (studList[i].marks.Count != 0)
                    {
                        Console.WriteLine("Are you sure you want to change the marks? y/n");
                        char c = Console.ReadLine()[0];
                        if (c == 'n')
                        {
                            MainMenu();
                        }
                        if (c == 'y')
                        {
                            i = studList.Count;
                        }
                        else
                        {
                            Console.WriteLine("Please enter 'y' or 'n'");
                            AddMark();
                        }
                    }
                }
            }

            try
            {
                string[] subjects = { "Telugu", "English", "Hindi", "Maths", "Science", "Social" };
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine("Enter " + subjects[i] + " marks");
                    int mark;
                    checkInteger = int.TryParse(Console.ReadLine(), out mark);
                    while (!checkInteger || !checkValidity(mark))
                    {
                        Console.WriteLine("Enter valid " + subjects[i] + " marks");
                        checkInteger = int.TryParse(Console.ReadLine(), out mark);
                    }
                    if (checkInteger)
                    {
                        checkValidity(mark);
                        //st.AddMarks(mark);
                        array[i] = mark;
                    }
                    else
                    {
                        if (checkInteger)
                        {
                            while (!checkValidity(mark))
                            {
                                Console.WriteLine("Enter valid" + subjects[i] + " marks");
                                checkInteger = int.TryParse(Console.ReadLine(), out mark);
                            }
                        }
                        /*Console.WriteLine("Enter valid marks");
                        AddMark();*/
                    }
                }
                marks = array.ToList();
                int index = 0;
                for (int i = 0; i < studList.Count; i++)
                {
                    if (studList[i].rollNumber == rollNumber)
                    {
                        studList[i].marks = marks;
                        index = i;
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Enter valid integers");
                MainMenu();
            }
            MainMenu();
        }


        public static void ExitApplication()
        {
            Console.WriteLine("Exiting the application...");
            Environment.Exit(0);

        }

        public static void ProgressCard(int rollNumber, List<int> marks)
        {
            Console.WriteLine("3. Show student progress card\n --------------------------");
            int count = 0;
            for (int i = 0; i < studList.Count; i++)
            {
                if (studList[i].marks.Count != 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Marks not added.\n -------------------");
            }
            count = 0;
            if (studList.Count == 0)
            {
                Console.WriteLine("Add a student first");
                MainMenu();
            }
            string[] subjects = { "Telugu", "English", "Hindi", "Maths", "Science", "Social" };

            Console.WriteLine("Enter student roll number :");
            int rollNum;
            bool checkInt = int.TryParse(Console.ReadLine(), out rollNum);

            if (checkInt)
            {
                var totalMarks = 0;
                float percentage = 0;
                for (int i = 0; i < studList.Count; i++)
                {
                    if (studList[i].rollNumber == rollNum)
                    {
                        Console.WriteLine("Student name : " + studList[i].name + "\n");
                        Console.WriteLine("Student roll number : " + studList[i].rollNumber + "\n");
                        for (int j = 0; j < 6; j++)
                        {
                            Console.WriteLine(subjects[j] + " : " + studList[i].marks[j]);
                            totalMarks += studList[i].marks[j];
                        }
                        percentage = ((float)(totalMarks * 100)) / 600;
                        Console.WriteLine("\n--------------\n Total marks : " + totalMarks);
                        Console.WriteLine("\n---------------\n Percentage : " + percentage);
                        i = studList.Count;
                    }
                }
                MainMenu();
            }
            else
            {
                Console.WriteLine("enter valid roll number");
                ProgressCard(rollNumber, marks);
            }

            for (int i = 0; i < studList.Count; i++)
            {
                if (studList[i].rollNumber == rollNum)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Student with that roll number does not exist.");
                Console.WriteLine("Enter valid roll number or enter 0 to go back to main menu");
                int option;
                checkInt = int.TryParse(Console.ReadLine(), out option);
                if (option == 0)
                {
                    MainMenu();
                }
                else
                {
                    rollNum = option;
                    while (!checkInt || rollNum < 0)
                    {
                        Console.WriteLine("Enter valid roll number");
                    }
                    ProgressCard(rollNum, marks);
                }
            }
            MainMenu();
            SchoolDetails();
        }



    }
}
