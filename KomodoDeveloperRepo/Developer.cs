using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamApp_Repo
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IDNumber { get; set; }
        public bool HasToolAccess { get; set; }


        public Developer() { }

        public Developer(string firstName, string lastName, int IDNum, bool hasToolAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            IDNumber = IDNum;
            HasToolAccess = hasToolAccess;
        }
    }
}