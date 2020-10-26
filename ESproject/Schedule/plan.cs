using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace ESproject.Schedule
{
    public class Plan
    {
        public String scheduleName;
        public List<Day> days;
        public string backupType;

        public Plan()
        {
            days = new List<Day> { };
        }

        public void setScheduleName(String scheduleName)
        {
            this.scheduleName = scheduleName;
        }

        public String getScheduleName()
        {
            return scheduleName;
        }

        public bool hasToBeActivated() {
            string backup = "";
            Day now = new Day(Day.getNumberOfDayInMonth(), 
                UppercaseFirst(DateTime.Now.ToString("dddd", new CultureInfo("es-ES"))), null, DateTime.Now.ToString("HHHH", 
                new CultureInfo("es-ES")), DateTime.Now.ToString("mmmm", new CultureInfo("es-ES")));
            if (dayExistsOnList(now, ref backup)) {
                this.backupType = backup;
                return true;
            }
            return false;
        }

        private bool dayExistsOnList(Day d, ref string backup) {
            foreach(Day x in days) {
                if (x.Equals(d)) {
                    Console.WriteLine(d + " y " + x + " son iguales");
                    backup = x.backupType;
                    return true;
                }
                Console.WriteLine(d + " y " + x + " no son iguales");
            }
            return false;
        }

        public void addDay(String week, String weekDay, String backupType, String hour, String minute)
        {
            Day newDay = new Day(week, weekDay, backupType, hour, minute);
            days.Add(newDay);
        }

        private static string UppercaseFirst(string s) {
            // Check for empty string.
            if (string.IsNullOrEmpty(s)) {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
