using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradeManagementSystem.Model;

namespace StudentGradeManagementSystem.Methods
{
    internal class AddNewStudent
    {
        internal Student NewStudent()

        {
            Student student = new Student();

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter ID: ");
            string id = Console.ReadLine();

            student.Name = name;
            student.ID = id;

            return student;
        }

        internal string ValidateStudent(Student student)
        {
            if (int.TryParse(student.ID, out int resultID))
            {
                if (int.TryParse(student.Name, out int resultName))
                {
                    return "Name should not be integer.";
                }
                else
                {
                    return "Validated.";
                }
            }
            else if (string.IsNullOrEmpty(student.Name))
            {
                return "Name should be supply.";
            }
            else if (string.IsNullOrEmpty(student.ID))
            {
                return "ID should be supply.";
            }
            else
            {
                return "Invalid ID. ID should be integer only.";
            }
        }
    }
}
