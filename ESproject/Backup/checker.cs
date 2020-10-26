using ESproject.Schedule;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ESproject.Backup {
    public class checker {

        public static void Run() {
            //cargar todas los momentos en los que se debe realizar un backup
            while (true) {
                var schedulesNow = getSchedulesWithActualDate();
                foreach (Plan p in schedulesNow) {
                    var worksToDo = getWorksToDo(p);
                    foreach (Work work in worksToDo) {
                        work.doWork(p.backupType);
                    }
                }
                Thread.Sleep(50000);
            }
        }

        public static List<Plan> getSchedulesWithActualDate() {
            //Comprobar todos los schedules y sacar los que tengan el momento actual como hora asociada
            var schedules = new List<Plan>();

            foreach (Plan p in User.getSchedules()) {
                if (p.hasToBeActivated()) {
                    Console.WriteLine("Añado:" + p);
                    schedules.Add(p);
                }
            }
            return schedules;
        }

        public static List<Work> getWorksToDo(Plan p) {
            //cargar todos los trabajos del usuario logueado
            List<Work> worksToDo = new List<Work>();
            var allWorks = User.getWorks();
            foreach (Work w in allWorks) {
                if (w.checkPlan(p.getScheduleName())) {
                    worksToDo.Add(w);
                }
            }
            return worksToDo;
        }
    }
}
