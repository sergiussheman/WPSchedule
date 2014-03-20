using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace ScheduleBsuir.Model
{
    public class DateWorker
    {
        public static int getCurrentWeekNumber(DateTime today)
        {
            int todayday = (int)today.DayOfWeek - 1;
            int year = today.Year;
            if (today.Month < 9)
                year--;
            DateTime september = new DateTime(year, 9, 1);
            int controlWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(september, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            int checkWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            int weekDiff = checkWeek > controlWeek ? (checkWeek - controlWeek) : (checkWeek + controlWeek);
            if (september.DayOfWeek == DayOfWeek.Sunday)
                weekDiff--;

            return weekDiff % 4 + 1;
        }

        public static string getInfoAboutDay(DateTime today, List<SchoolDay> weekSchedule)
        {
            int currentWeekNumber = getCurrentWeekNumber(today);
            int dayofWeek = (int)today.DayOfWeek - 1;
            if (dayofWeek != -1)
            {
                SchoolDay cDay = weekSchedule[dayofWeek];
                return cDay.weekDay + ", " + currentWeekNumber + " неделя";
            }
            else
            {
                return "Воскресенье, " + currentWeekNumber + " неделя";
            }
        }

        public static SchoolDay getScheduleForDate(DateTime today, List<SchoolDay> weekSchedule)
        {
            int dayofWeek = (int)today.DayOfWeek - 1;
            int currentWeekNumber = getCurrentWeekNumber(today);
            if (dayofWeek != -1)
            {
                SchoolDay scheduleForDay = weekSchedule[dayofWeek];

                SchoolDay returnDay = new SchoolDay();
                returnDay.WeekNumber = currentWeekNumber;
                returnDay.weekDay = scheduleForDay.weekDay;
                //j = scheduleForDay.weekDay + currentWeekNumber;

                foreach (var lesson in scheduleForDay.lessons)
                {
                    if (lesson.weekNumbers.Contains(currentWeekNumber.ToString()))
                    {
                        var temp = lesson;
                        returnDay.lessons.Add(temp);
                    }
                }
                if (returnDay.lessons.Count == 0)
                {
                    List<lesson> l = new List<lesson>() { new lesson() { textForDisplayForToday = "Занятий нет" } };
                    //j = "";
                    return new SchoolDay() { lessons = l, WeekNumber = currentWeekNumber };
                }
                
                return returnDay;
            }
            else
            {
                List<lesson> l = new List<lesson>() { new lesson() { textForDisplayForToday = "Занятий нет" } };
                //j = "";
                return new SchoolDay() { lessons = l, WeekNumber = currentWeekNumber };                
            }
        }

        public static lesson getNearPair(DateTime date, List<SchoolDay> weekDays)
        {
            SchoolDay day = getScheduleForDate(date, weekDays);
            int dateHour = date.Hour;
            string m = date.Minute.ToString();
            if(m.Count() == 1)
                m = "0" + m;
            string stringTime = date.Hour.ToString() + m;
            int nowTime = int.Parse(stringTime);
            List<lesson> suitablePair = new List<lesson>();
            int prevPairStart = day.lessons[0].startTime;
            int prevPairEnd = day.lessons[0].endTime;
            foreach (var l in day.lessons)
            {
                if (nowTime > l.startTime && nowTime < l.endTime)
                    return l;
                
            }
            int minTimeBeforePair = int.MaxValue;
            lesson pair = null;
            foreach (var p in day.lessons)
            {
                int raz = p.startTime - nowTime;
                if (raz < minTimeBeforePair && raz >= 0)
                {
                    minTimeBeforePair = raz;
                    pair = p;
                }
            }
            if (pair == null)
            {
                date = date.AddDays(1);
                day = getScheduleForDate(date, weekDays);
                pair = day.lessons[0];
            }
            return pair;
        }
    }
}
