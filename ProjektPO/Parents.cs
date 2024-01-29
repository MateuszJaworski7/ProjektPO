using System;

namespace ProjektPO
{
    public class Parents : Person
    {
        public int KidID { get; set; }

        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public Parents(int idP, string firstName, string lastName, int kidID, string phoneNumber, string role)
        {
            IdP = idP;
            FirstName = firstName;
            LastName = lastName;
            KidID = kidID;
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public Parents() { }
    }

}
