using KomodoDeveloperRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamApp_Repo
{
    class KomodoDevManagerUI
    {
        // instantiate a single dev team 
        public DeveloperRepo _DevTeam = new DeveloperRepo();

        // instantiate a  list of All Dev Teams (list of lists)
        public DevTeamRepo _AllDevTeams = new DevTeamRepo();
       
        //Menu       
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            // display the options
            // take user choice
            // evaluate input
            // take action

            bool active = true;

            // Create "Unassigned" team for developers

            CreateUnassignedTeam();

            while (active)
            {
                    Console.WriteLine("Team Management Options:\n" +
                    "1 - Seed a new team names Seed Team 1 for testing\n"+
                    "2 - Seed a new team names Seed Team 2 for testing\n" +
                    "3 - Add a new empty Team (with it's title)\n" +
                    "4 - View Developer Directory (all Teams and all Developers\n" +
                    "5 - Delete a list and all members (with it's title)\n" +
                    "6 - Rename a Team (with it's title)\n" +
                    "7 - Change a Teams ID (with it's ID)\n" +
                    "8 - View an entire Team (with it's title)\n\n" +

                    "Team Membership Options:\n" +
                    "A - Add a new Developer to a Team\n" +
                    "V - View one member of a team\n" +
                    "D - Delete a Member of a team\n" +
                    "U - Update a member of a team\n" +
                    "B - Batch load multiple members to a team\n" +
                    "R - Reassign Developer to a differient team\n\n" +

                    "PluralSight Management Options:\n" +
                    "P - List All Developers without a PLuralsight License\n\n" +
                    "X - Exit");


                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                        {
                            CreateNewSeedTeam1();
                            break;
                        }
                    case "2":
                        {
                            CreateSeedNewTeam2();
                            break;
                        }
                    case "3":
                        {
                            AddNewTeam();
                            break;
                        }
                    case "4":
                        {
                            ListAllTeamNames();
                            break;
                        }
                    case "5":
                        {
                            DeleteTeamAndMembers();
                            break;
                        }
                    case "6":
                        {
                            UpdateTeamName();
                            break;
                        }
                    case "7":
                        {
                            UpdateTeamID();
                            break;
                        }
                    case "8":
                        {
                            ViewTeamByName();
                            break;
                        }
                    case "a":
                        {
                        AddNewDeveloper();
                            break;
                        }
                    case "o":
                        {
                            ViewIndivdualDeveloper();
                            break;
                        }
                    case "d":
                        {
                            DeleteDeveloperFromTeam();
                            break;
                        }
                    case "u":
                        {
                            UpdateDeveloper();
                            break;
                        }
                    case "r":
                        {
                            ReassignDeveloper();
                            break;
                        }
                    case "b":
                        {
                            BatchLoad();
                            break;
                        }
                    case "p":
                        {
                            GetLicenseList();
                            break;
                        }
                    case "x":
                        {
                            Console.WriteLine("Thanks for coming by, now please enjoy this beep");
                            Console.Beep(1000, 500);
                            active = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a valid choice!");
                            break;
                        }

                }

                if (active)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void ViewIndivdualDeveloper()
        {
            // show header
            Console.WriteLine("Enter the ID of the developer you would like to view");
            string IDNumAsString = Console.ReadLine();
            int IDnum = Int32.Parse(IDNumAsString);
            _AllDevTeams.ViewIndivdiualTeamMember(IDnum);


         }
        private void AddNewDeveloper()
        {
            _AllDevTeams.GetTeamList();
            Console.WriteLine("Enter the team to which you would like to add a developer to:");
            string NameofTeamToAddTo = Console.ReadLine();
            if (_AllDevTeams.AddMembersToTeam(NameofTeamToAddTo))
            {
                Console.WriteLine("Team Member Added to Team:" + NameofTeamToAddTo);
            }
            else
            {
                Console.WriteLine("Team Member not added");
            }
        }

        private void UpdateDeveloper()
        {
            Console.WriteLine("Enter the ID Number you wish to Update");
            string IDNumAsString = Console.ReadLine();
            int IDToUpdate = Int32.Parse(IDNumAsString);
            if (_AllDevTeams.UpdateDevTeamMember(IDToUpdate))
            {
                Console.WriteLine("Developer updated");
            }
            else
                Console.WriteLine("Developer not updated");
        }

        private void DeleteDeveloperFromTeam()
        {
            Console.WriteLine("Enter the ID Number you wish to Delete");
            string IDNumAsString = Console.ReadLine();
            int IDToDelete = Int32.Parse(IDNumAsString);
            if (_AllDevTeams.DeleteDevTeamMember(IDToDelete))
            {
                Console.WriteLine("Developer Removed");
            }
            else
            {
                Console.WriteLine("Developer not Removed");
            }
        }

        //------------------------------------------------
        // Team Management Methods
        //------------------------------------------------

        public void AddNewTeam()
        {
            // create new team repo
            //DevTeamRepo newDevRepo = new DevTeamRepo();
            Console.WriteLine("Enter the new team's name:");
            string newTeamName = Console.ReadLine();
            Console.WriteLine("Enter the new team's ID:");
            int newTeamID = Int32.Parse(Console.ReadLine());
            // call the method to add a new team
            _AllDevTeams.AddDevTeam(newTeamName,newTeamID);
        }
        
        // Update a team name
        public void UpdateTeamName()
        {
            Console.WriteLine("Enter the old team's name:");
            string oldTeamName = Console.ReadLine();
            if(_AllDevTeams.ReturnWholeDevTeam(oldTeamName) == null)
            {
                Console.WriteLine("\nNo team exists with that name");
            }
            else
            {
                Console.WriteLine("Enter the new team's name:");
                string newTeamName = Console.ReadLine();
                _AllDevTeams.UpdateName(oldTeamName, newTeamName);
            }

        }

        public void UpdateTeamID()
        {
            Console.WriteLine("Enter the old team's ID:");
            int oldTeamID = Int32.Parse(Console.ReadLine());
            if (_AllDevTeams.ReturnWholeDevTeam(oldTeamID) == null)
            {
                Console.WriteLine("\nNo team exists with that ID");
            }
            else
            {
                Console.WriteLine("Enter the new team's ID:");
                int newTeamID = Int32.Parse(Console.ReadLine());
                _AllDevTeams.UpdateID(oldTeamID, newTeamID);
            }
        }

        public void ListAllTeamNames()
        {
            _AllDevTeams.ListAllTeamsandMembers();
        }

        public void CreateNewSeedTeam1()
        {
            /// Create the team

            DevTeam newSeedTeam = new DevTeam();
          
            // baffling line -----------------
            DeveloperRepo newDevRepo = new DeveloperRepo();
            // -------------------------------------

            newSeedTeam.TeamName = "Alpha Seed Team";
            newSeedTeam.TeamID = 1;

            // create a block of developers

            Developer seedDev1 = new Developer("Mickey", "Mouse", 1, true);
            newDevRepo.AddDeveloperToTeam(seedDev1);
            Developer seedDev2 = new Developer("Daffy", "Duck", 3, false);
            newDevRepo.AddDeveloperToTeam(seedDev2);
            Developer seedDev3 = new Developer("Donald", "Duck", 4, false);
            newDevRepo.AddDeveloperToTeam(seedDev3);
            Developer seedDev4 = new Developer("Pluto", "Thedog", 5, true);
            newDevRepo.AddDeveloperToTeam(seedDev4);


            // Move  temporary list of devs (newDevRepo) into the the team

            newSeedTeam._TeamList = newDevRepo;

            // move the temporary list (newDevRepo) into the persistant list
            _AllDevTeams.AddDevTeam(newSeedTeam);

            Console.WriteLine($"\n{newSeedTeam.TeamName} list seeded!!");
        }
        public void CreateSeedNewTeam2()
        {
            /// Create the team

            DevTeam newSeedTeam = new DevTeam();

            // baffling line -----------------
            DeveloperRepo newDevRepo = new DeveloperRepo();
            // -------------------------------------

            newSeedTeam.TeamName = "Beta Seed Team";
            newSeedTeam.TeamID = 2;

            // create a block of developers

            Developer seedDev1 = new Developer("Mickey", "Beta", 2, false);
            newDevRepo.AddDeveloperToTeam(seedDev1);
            Developer seedDev2 = new Developer("Daffy", "Beta", 7, true);
            newDevRepo.AddDeveloperToTeam(seedDev2);
            Developer seedDev3 = new Developer("Donald", "Beta", 9, true);
            newDevRepo.AddDeveloperToTeam(seedDev3);
            Developer seedDev4 = new Developer("Pluto", "Beta", 11, true);
            newDevRepo.AddDeveloperToTeam(seedDev4);


            // Move  temporary list of devs (newDevRepo) into the the team
            newSeedTeam._TeamList = newDevRepo;

            // move the temporary list (newDevRepo) into the persistant list
            _AllDevTeams.AddDevTeam(newSeedTeam);

            Console.WriteLine($"\n{newSeedTeam.TeamName} list seeded!!");
        }

        public void CreateUnassignedTeam()
        {
            /// Create the team
            _AllDevTeams.AddDevTeam("Unassigned", 1);
        }

        // Delete a team and all its members...YIKES
        public void DeleteTeamAndMembers()
        {
            Console.WriteLine("Enter of the name of the team to remove");
            string teamToDelete = Console.ReadLine();
            _AllDevTeams.DeleteTeamAndMembers(teamToDelete);
        }

        public void ViewTeamByName()
        {
            _AllDevTeams.GetTeamList();
            Console.WriteLine("Enter the name of the team you would like to view:");
            string nameofTeamToView = Console.ReadLine();
            DevTeam teamToView = new DevTeam();
            if (_AllDevTeams.ReturnWholeDevTeam(nameofTeamToView) == null)
            {
                Console.WriteLine("No Team with that Name");
            }
            else
            {
                teamToView = _AllDevTeams.ReturnWholeDevTeam(nameofTeamToView);
                Console.WriteLine($" Team Name: {teamToView.TeamName}");

                // display each team member
                if (teamToView._TeamList == null)
                {
                    Console.WriteLine("Team contains no members");
                }
                else
                {
                    Console.WriteLine("First Name,\tLast Name,\tID NUmber,\tPluralsight Indicator");
                    foreach (Developer singleDev in teamToView._TeamList.GetEntireDeveloperList())
                    Console.WriteLine($"{singleDev.FirstName},\t\t\t{singleDev.LastName},\t\t\t{singleDev.IDNumber},\t\t{singleDev.HasToolAccess}"); Console.WriteLine($"");
 
                }
            }



        }

        // Reassign Developer
        private void ReassignDeveloper()
        {
            Console.WriteLine("Enter the ID of the developer to reassign");
            
            int devToReAssign = Int32.Parse(Console.ReadLine());
            _AllDevTeams.ChangeTeamAssignment(devToReAssign);
        }

        private void GetLicenseList()
        {
            _AllDevTeams.GetLicenseList();
        }

        // Batch load members to a team using a delimited srting
        private void BatchLoad()
        {

            Developer newBatchDev = new Developer();
            _AllDevTeams.GetTeamList();
            Console.WriteLine("Enter the team to which you would like to add a developer to:");
            string newBatchTeam = Console.ReadLine();

            Console.WriteLine("Enter First Name, Last Name, ID Number, and Pluralsight indicator (true/false) for each developer. Seperate Developers with the ; character:\n");
            Console.WriteLine("for Example: John,Doe,21,false;Clark,Kent,22,true");
            string devString = Console.ReadLine();
            int devCount = 0;
            foreach (char c in devString)
                if (c == ';')
                    devCount++;
            devCount++;
            //System.Console.WriteLine(devCount);
            string devStringDelimiterRemoved = devString.Replace(";", ",");
            int loopCount = 0;
            int numberOfFields = 4;
            string[] devParsed = devStringDelimiterRemoved.Split(',');
            for (int element = 0; element < devCount; element++)
            {
                newBatchDev.FirstName = devParsed[loopCount];
                newBatchDev.LastName = devParsed[loopCount+1];
                newBatchDev.IDNumber = Int32.Parse(devParsed[loopCount + 2]);
                newBatchDev.HasToolAccess = bool.Parse(devParsed[loopCount + 3]);
                if (_AllDevTeams.AddDevToTeam(newBatchTeam, newBatchDev))
                {
                    Console.WriteLine("Team Member Added to Team:" + newBatchTeam);
                }
                else
                {
                     Console.WriteLine("Team Member not added");
                }
                loopCount = loopCount + numberOfFields;
            }
        }
    }
}