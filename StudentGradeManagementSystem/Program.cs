
using StudentGradeManagementSystem.Methods;
using StudentGradeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace StudentGradeManagementSystem 
{
    public class Program
    {
        public static void Main() 
        {
            //List Objects declaration
            List<StudentSubjectGradeRecord> listSudentGradeRecord = new List<StudentSubjectGradeRecord>();
            List<Student> listStudent = new List<Student>();
            List<AverageGrade> listAverageGrade = new List<AverageGrade>();
            
            //Objects declaration
            Student student = new Student();
            StudentSubjectGradeRecord studentSubjectGradeRecord = new StudentSubjectGradeRecord();
            AverageGrade averageGrade = new AverageGrade();

            //Methods
            AddNewStudent addNewStudent = new AddNewStudent();
            AssignGradeOnSubject assignGradeOnSubject = new AssignGradeOnSubject();

            int average = 0;

            string result = string.Empty;
            int choose = 0;

            int step = 1;
            while (step > 0) 
            {
                Console.WriteLine("Choose your desire transaction.");
                Console.WriteLine("[1] ADD STUDENT.");
                Console.WriteLine("[2] ASSIGN GRADES.");
                Console.WriteLine("[3] CALCULATE AVERAGE GRADE.");
                Console.WriteLine("[4] DISPLAY STUDENT RECORD.");
                string choosen = Console.ReadLine();

                if (int.TryParse(choosen, out int holder))
                {
                    choose = holder;
                    switch (choose)
                    {
                        case 1:
                            #region Add New Student
                            student = addNewStudent.NewStudent();
                            result = addNewStudent.ValidateStudent(student);
                            if (result == "Validated.")
                            {
                                listStudent.Add(student);
                                Console.WriteLine("Succefully Added.");
                            }
                            else
                            {
                                Console.WriteLine(result);
                            }
                            break;
                            #endregion
                        case 2:
                            #region Assign Grade
                            if(listStudent.Count == 0)
                            {
                                Console.WriteLine("Add student first.");
                            }
                            else
                            {
                                studentSubjectGradeRecord = assignGradeOnSubject.GradeRecord();
                                result = assignGradeOnSubject.ValidateGrade(studentSubjectGradeRecord);
                                if (result == "Validated.")
                                {
                                    listSudentGradeRecord.Add(studentSubjectGradeRecord);
                                }
                                else
                                {
                                    Console.WriteLine(result);
                                }
                            }
                            break;
                            #endregion
                        case 3:
                            #region Calculate Average
                            if (listSudentGradeRecord.Count == 0)
                            {
                                Console.WriteLine("No Grade Found.");
                                Console.WriteLine("Do you want to try again Y/N?");
                                string selected = Console.ReadLine();
                                selected = selected.ToUpper();
                                if (selected == "Y")
                                    step++;
                                else
                                    step = 0;
                            }
                            else
                            {
                                for(int i = 0; i < listSudentGradeRecord.Count; i++)
                                {
                                    studentSubjectGradeRecord = listSudentGradeRecord[i];
                                    average = average + Int32.Parse(studentSubjectGradeRecord.Grade);
                                }

                                Console.WriteLine("The minimum average grade of a student is " + average / listSudentGradeRecord.Count);
                            }
                            break;
                            #endregion
                        case 4:
                            #region View Record
                            if (listStudent.Count == 0 && listSudentGradeRecord.Count == 0) 
                            {
                                Console.WriteLine("No Record Found.");
                                Console.WriteLine("Do you want to try again Y/N?");
                                string selected = Console.ReadLine();
                                selected = selected.ToUpper();
                                if (selected == "Y")
                                    step++;
                                else
                                    step = 0;
                            }
                            else
                            {
                                Console.WriteLine("Records:");
                                if (listStudent.Count == 0) 
                                {
                                    Console.WriteLine("No student info found.");
                                    for (int j = 0; j < listSudentGradeRecord.Count; j++)
                                    {
                                        studentSubjectGradeRecord = listSudentGradeRecord[j];
                                        Console.WriteLine(studentSubjectGradeRecord.Subject + " - " + studentSubjectGradeRecord.Grade);
                                    }
                                }
                                else if (listSudentGradeRecord.Count == 0)
                                {
                                    Console.WriteLine("No grades found.");
                                    for (int i = 0; i < listStudent.Count; i++)
                                    {
                                        student = listStudent[i];
                                        Console.WriteLine(student.ID + " " + student.Name);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < listStudent.Count; i++)
                                    {
                                        student = listStudent[i];
                                        Console.WriteLine(student.ID + " " + student.Name);
                                    }
                                    for (int j = 0; j < listSudentGradeRecord.Count; j++)
                                    {
                                        studentSubjectGradeRecord = listSudentGradeRecord[j];
                                        Console.WriteLine(studentSubjectGradeRecord.Subject + " - " + studentSubjectGradeRecord.Grade);
                                    }
                                }
                            }
                            break;
                            #endregion  
                        default:
                            #region Default
                            Console.WriteLine("Invalid transaction.");
                            Console.WriteLine("Do you want to try again Y/N?");
                            string choice = Console.ReadLine();
                            choice = choice.ToUpper();
                            if (choice == "Y")
                                step++;
                            else
                                step = 0;
                            break;
                            #endregion
                    }
                }
                else 
                {
                    Console.WriteLine("Invalid choice. Choices should be integer only.");
                    Console.WriteLine("Do you want to try again Y/N?");
                    string choice = Console.ReadLine();
                    choice = choice.ToUpper();
                    if (choice == "Y")
                        step++;
                    else
                        step = 0;
                }
            }   
        }
    }
}