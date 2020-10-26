using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ESproject.Schedule
{
    public class Day
    {
        public String week;
        public String weekDay;
        public String backupType;
        public String hour;
        public String minute;

        public Day(String week, String weekDay, String backupType, String hour, String minute)
        {
            this.week = week;
            this.weekDay = weekDay;
            this.backupType = backupType;
            this.hour = hour;
            this.minute = minute;
        }

        public static string getNumberOfDayInMonth() {
            int x = int.Parse(DateTime.Now.ToString("dd", new CultureInfo("es-ES")));
            if (x <= 7) {
                return "Primer";
            }
            else if (x <= 14) {
                return "Segundo";
            }
            else if (x <= 21) {
                return "Tercer";
            }
            else if (x <= 28) {
                return "Cuarto";
            } else { 
                return "Último";
            }
        }
        //redefinición de equals con los parámetros que influyen a la hora de activar un backup
        public override bool Equals(object obj) {
            Day d = (Day)obj;
  
           /*     Console.WriteLine(d.ToString());
                Console.WriteLine("\n" + ToString());
            */
            return (d.week == week &&
                    d.weekDay == weekDay &&
                    d.hour == hour &&
                    d.minute == minute);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(week);
            sb.Append(weekDay);
            sb.Append(hour);
            sb.Append(minute);
            return sb.ToString();
        }
    }
}
