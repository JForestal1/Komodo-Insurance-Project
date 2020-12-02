using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamApp_Repo
{
    public class DeveloperRepo
    {
        public List<Developer> _developerTeam = new List<Developer>();

        // Add list item

        public bool AddDeveloperToTeam(Developer newDev)
        {
            //* assumes an ID uniqueness check has been done
            _developerTeam.Add(newDev);

            return true;
        }

        // Read entire list item
        public List<Developer> GetEntireDeveloperList()
        {
            return _developerTeam;
        }

        // Read a single developer - by ID
        public Developer GetSingleDeveloper(int IDNum)
        {
            foreach (Developer individualDev in _developerTeam)
                if (individualDev.IDNumber == IDNum)
                    return individualDev;
            
            return null;
        }

        // Delete developer
        public bool DeleteDeveloperFromList(int IDNum)
        {
            Developer devToDelete = GetSingleDeveloper(IDNum);
            int initialCount = _developerTeam.Count;
            if (devToDelete != null)
            {
                _developerTeam.Remove(devToDelete);
                if (initialCount-1  == _developerTeam.Count)
                {
                    return true;
                } 
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        // Helper to determine if a pass ID NUm is in the list. return true if it IS in the list
        // if it is in the list you can update and delete but not add

        public bool IDNumIsAlreadyInList(int IDNum)
        { 
            foreach (Developer devToCheck in _developerTeam)
                if (devToCheck.IDNumber == IDNum)
                    return true;
            return false;
        }

        public bool UpdateDeveloper(int IDNum, Developer changedDeveloper)
        {
            Developer contentToChange = GetSingleDeveloper(IDNum);
            
                if(contentToChange != null)
                {
                    contentToChange.FirstName = changedDeveloper.FirstName;
                    contentToChange.LastName = changedDeveloper.LastName;
                    contentToChange.IDNumber = changedDeveloper.IDNumber;
                    return true;
                }
                else
                {
                    return false;
                }
            

        }
    }
}
