using KomodoDevTeamApp_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDeveloperRepo
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public DeveloperRepo _TeamList { get; set; }
        public int TeamID { get; set; }
        public DevTeam() { }
        public DevTeam(string teamName, int newTeamID, DeveloperRepo _devTeam)
        {
            TeamName = teamName;
            TeamID = newTeamID;
            _TeamList =  _devTeam;
        }
    }
}
