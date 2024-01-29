using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class StudentCouncil : Student
    {
        public string Role { get; set; }

        public StudentCouncil(int studentId, string firstName, string lastName, string role)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }

}
