using StudentGradeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeManagementSystem.Methods
{
    internal class AssignGradeOnSubject
    {
        internal StudentSubjectGradeRecord GradeRecord()
        {
            StudentSubjectGradeRecord studentSubjectGradeRecord = new StudentSubjectGradeRecord();

            Console.WriteLine("Enter Subject: ");
            string subject = Console.ReadLine();

            Console.WriteLine("Enter Grade: ");
            string grade = Console.ReadLine();

            studentSubjectGradeRecord.Subject = subject;
            studentSubjectGradeRecord.Grade = grade;

            return studentSubjectGradeRecord;
        }

        internal string ValidateGrade(StudentSubjectGradeRecord studentSubjectGradeRecord)
        {
            if (int.TryParse(studentSubjectGradeRecord.Grade, out int resultID))
            {
                if (int.TryParse(studentSubjectGradeRecord.Subject, out int resultName))
                {
                    return "Name should not be integer.";
                }
                else
                {
                    return "Validated.";
                }
            }
            else if (string.IsNullOrEmpty(studentSubjectGradeRecord.Subject))
            {
                return "Subject should be supply.";
            }
            else if (string.IsNullOrEmpty(studentSubjectGradeRecord.Grade))
            {
                return "Grade should be supply.";
            }
            else
            {
                return "Invalid Grade. Grade should be integer only.";
            }
        }
    }
}
