using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoDevTeamApp_Repo;


namespace KomodoDeveloperRepo
{
    public class DevTeamRepo
    {

        // instantiate a list of Devteams
        public List<DevTeam> _ListofDevTeams = new List<DevTeam>();

        //Method to create a partial team using only a team name string
        public void AddDevTeam(string teamName, int newTeamID)
        {
            DeveloperRepo newDevRepo = new DeveloperRepo();
            Developer seedDev = new Developer();
            DevTeam newDevTeam = new DevTeam();
            newDevTeam.TeamName = teamName;
            newDevTeam.TeamID = newTeamID;
            newDevTeam._TeamList = newDevRepo;
            _ListofDevTeams.Add(newDevTeam);

        }
        
        // method override for seeding (and maybe bulk loading) addes a fully formed team with name and members upon getting a fully form teamed
        public void AddDevTeam(DevTeam newSeedTeam)
        {
            _ListofDevTeams.Add(newSeedTeam);
        }

        // Update a team name given the old and new names
        public void UpdateName(string oldTeamName, string newTeamName)
        {
            ReturnWholeDevTeam(oldTeamName).TeamName = newTeamName;
            Console.WriteLine("Team renamed to:"+newTeamName);
        }

        // Update a team ID given the old and new ID's
        public void UpdateID(int oldTeamID, int newTeamID)
        {
            ReturnWholeDevTeam(oldTeamID).TeamID = newTeamID;
            Console.WriteLine("New Team ID:" + newTeamID);
        }

        //Method to delete a team and its members
        public void DeleteTeamAndMembers(string teamNameToDelete)
        {
            DevTeam teamtoDelete = new DevTeam();
            if(ReturnWholeDevTeam(teamNameToDelete) != null)
            {
                _ListofDevTeams.Remove(ReturnWholeDevTeam(teamNameToDelete));
                Console.WriteLine("Team Deleted");
            }
            else
            {
                Console.WriteLine("No team found with that name");
            }              
        }

        //* method to list all teams and each teams members
        public void ListAllTeamsandMembers()
        {

            Console.Clear();
            Console.WriteLine("{0,10} {1,23} {2,15} {3,15} {4,15} {5,18}", "Team", "Team ID", "First Name", "Last Name", "ID NUmber", "Pluralsight Access");

            foreach (DevTeam teams in _ListofDevTeams)
            {
                foreach (Developer singleDev in teams._TeamList.GetEntireDeveloperList())
                    Console.WriteLine("{0,-20:N0} {1,10:N0} {2,15:N0} {3,15:N0} {4,15:N0} {5,15:N0}",teams.TeamName,teams.TeamID,singleDev.FirstName,singleDev.LastName,singleDev.IDNumber,singleDev.HasToolAccess);
            }

        }

        // Return a whole team using string name
        public DevTeam ReturnWholeDevTeam(string TeamNameToReturn)
            {
                foreach(DevTeam SearchListByName in _ListofDevTeams)
                {
                    if (SearchListByName.TeamName == TeamNameToReturn)
                        return SearchListByName;
                }
                return null;

            }

        // Return a whole team using int ID
        public DevTeam ReturnWholeDevTeam(int TeamIDToReturn)
        {
            foreach (DevTeam SearchListByID in _ListofDevTeams)
            {
                if (SearchListByID.TeamID == TeamIDToReturn)
                    return SearchListByID;
            }
            return null;

        }

        //* Method to Add a complete developer to a team using Developer and Team Name
        public bool AddDevToTeam(string TeamToAddMemberTo, Developer devToAdd)
        {
            if (ReturnWholeDevTeam(TeamToAddMemberTo) == null)
            {
                Console.WriteLine("No team exists with that name");
                return false;
            }
            foreach (DevTeam TeamToAddTo in _ListofDevTeams)
            {
                if (TeamToAddTo.TeamName == TeamToAddMemberTo)
                {
                    TeamToAddTo._TeamList.AddDeveloperToTeam(devToAdd);
                    return true;
                }

            }
            return false;
        }

        //* Method to enter and add members to a team using team name
        public bool AddMembersToTeam(string TeamToAddMemberTo)
        {
            // Test to see if a team with that name exists

            if (ReturnWholeDevTeam(TeamToAddMemberTo) == null)
            {
                Console.WriteLine("No team exists with that name");
                return  false;
            }
            Console.WriteLine("Enter ID Number of Developer to Add");
            string IDNumToAddAsString = Console.ReadLine();
            int IDNumToAdd = Int32.Parse(IDNumToAddAsString);

            // Test is the ID number is unique within all developer lists
            foreach (DevTeam TeamToAddTo in _ListofDevTeams)
            {               
                if (TeamToAddTo._TeamList.IDNumIsAlreadyInList(IDNumToAdd))
                {
                    Console.WriteLine("That ID Number is not Unique");
                    return false;
                }

            }

            //* having tested the ID for uniqueness, Find the team to add to
            foreach (DevTeam TeamToAddTo in _ListofDevTeams) // parse each team
            {              
                if (TeamToAddTo.TeamName == TeamToAddMemberTo)
                {
                    Developer devToAdd = new Developer();
                    devToAdd.IDNumber = IDNumToAdd;
                    Console.WriteLine("Enter the First Name");
                    devToAdd.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter the Last Name");
                    devToAdd.LastName = Console.ReadLine();
                    Console.WriteLine("Does this developer Pluralsight (yes or no)");
                    string yesOrNo = Console.ReadLine().ToLower();
                    devToAdd.HasToolAccess = false;
                    if (yesOrNo == "yes")
                    {
                        //devToAdd.HasToolAccess = true;
                    }
                    if (TeamToAddTo._TeamList.AddDeveloperToTeam(devToAdd))
                    {
                        Console.WriteLine("Developer Added!");
                        return true;
                    }

                }
            }
            return false;

        }

        //* Update Developer using developer ID
        public bool UpdateDevTeamMember (int TeamMemberToUpdate)
        {
            foreach (DevTeam teams in _ListofDevTeams)
                foreach (Developer devToUpdate in teams._TeamList.GetEntireDeveloperList())
                {
                    if (devToUpdate.IDNumber == TeamMemberToUpdate)
                    {
                        Developer devToAdd = new Developer();
                        Console.WriteLine("Enter the new First Name");
                        devToUpdate.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter the New Last Name");
                        devToUpdate.LastName = Console.ReadLine();
                        Console.WriteLine("Does this developer Pluralsight (yes or no)");
                        string yesOrNo = Console.ReadLine().ToLower();
                        devToUpdate.HasToolAccess = false;
                        if (yesOrNo == "yes")
                            devToAdd.HasToolAccess = true;
                        return true;
                    }
                }
            Console.WriteLine("No Developer with that ID found");
            return false;

        }

        //* delete a member of a team using Developer ID
        public bool DeleteDevTeamMember(int TeamMemberToDelete)
        {
            foreach (DevTeam teams in _ListofDevTeams)
                foreach (Developer devToUpdate in teams._TeamList.GetEntireDeveloperList())
                {
                    if (devToUpdate.IDNumber == TeamMemberToDelete)
                    {
                        return teams._TeamList.DeleteDeveloperFromList(TeamMemberToDelete);
                    }
                }
            Console.WriteLine("No Developer with that ID found");
            return false;

        }

        //* View individual team member by ID Number
        public bool ViewIndivdiualTeamMember(int DevToView)
        {

            foreach (DevTeam teams in _ListofDevTeams)
            {
                foreach (Developer singleDev in teams._TeamList.GetEntireDeveloperList())
                    if (singleDev.IDNumber == DevToView)
                    {
                        Console.WriteLine("First Name,\t\tLast Name,\tID NUmber,\tPluralsight Indicator"); 
                        Console.WriteLine($"{singleDev.FirstName},\t\t\t{singleDev.LastName},\t\t\t{singleDev.IDNumber},\t\t{singleDev.HasToolAccess}");
                    }
            }
            Console.WriteLine("That ID Number is not in use");
            return false;

        }

        //* Reassign a team member by ID Number
        public void ChangeTeamAssignment(int DevToChange)
        {

            Developer foundDev = new Developer();
            bool devFound = false;
            foreach (DevTeam teams in _ListofDevTeams)
            {
                foreach (Developer singleDev in teams._TeamList.GetEntireDeveloperList())
                    if (singleDev.IDNumber == DevToChange)
                    {
                        foundDev = singleDev;
                        devFound = true;
                        Console.WriteLine("The Developer is currently assigned to Team:" + teams.TeamName);
                    }
            }
            if (devFound)
            {
                GetTeamList();
                Console.WriteLine("\n Enter the Team to which this developer should be reassigned:");
                string newTeamName = Console.ReadLine();

                // add to the new team and delete from the old team

                if (AddDevToTeam(newTeamName, foundDev)&& DeleteDevTeamMember(DevToChange))
                    Console.WriteLine("Developer reasigned");
                else
                    Console.WriteLine("Developer not reasigned"); 
            }
            else
                Console.WriteLine("That ID Number is not in use");
        }

        // get list of developers without PLuralsight license
        public void GetLicenseList()
        {
            Console.Clear();
            Console.WriteLine("{0,10} {1,17} {2,15} {3,15} {4,15}","Team","Team ID","First Name","Last Name","ID NUmber"); 
            foreach (DevTeam teams in _ListofDevTeams)
            {
                foreach (Developer singleDev in teams._TeamList.GetEntireDeveloperList())
                    if (!singleDev.HasToolAccess)
                    {
                        Console.WriteLine("{0,-20:N0} {1,5:N0} {2,15:N0} {3,15:N0} {4,15:N0}",teams.TeamName,teams.TeamID,singleDev.FirstName,singleDev.LastName,singleDev.IDNumber);
                    }
                        
                
            }
        }
        public void GetTeamList()
        {
            Console.WriteLine("The following teams exists:");
            foreach (DevTeam singleTeam in _ListofDevTeams)
                Console.WriteLine("  " + singleTeam.TeamName);
        }

    }
}
