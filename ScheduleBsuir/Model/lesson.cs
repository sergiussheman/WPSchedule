using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBsuir.Model 
{
    public class lesson
    {
        public List<string> weekNumbers { get; set; }
        public List<string> listEmployee { get; set; }
        public string employee { get; set; }
        public string lessonTime { get; set; }
        public string lessonType { get; set; }
        public string subject { get; set; }
        public string textForDisplay { get; set; }
        public string textForDisplayForToday { get; set; }
        public string auditory { get; set; }
        public string numsubGroup { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public string sStartTime { get; set; }
        public string sEndTime { get; set; }

        public lesson()
        {
            weekNumbers = new List<string>();
            listEmployee = new List<string>();
        }

        public void setTimes()
        {
            string[] timesPair = lessonTime.Split('-');
            sStartTime = timesPair[0];
            sEndTime = timesPair[1];
            int position = timesPair[0].IndexOf(':');
            timesPair[0] = timesPair[0].Remove(position,1);
            startTime = int.Parse(timesPair[0]);

            position = timesPair[1].IndexOf(':');
            timesPair[1] = timesPair[1].Remove(position,1);
            endTime = int.Parse(timesPair[1]);

            
        }

        public void createTextForDisplay()
        {
            setTimes();
            StringBuilder st = new StringBuilder();
            StringBuilder weekNumb = new StringBuilder();
                weekNumb = weekNumb.Append("(");
                foreach (var t in weekNumbers)
                {
                    if (!t.Equals("0"))
                        weekNumb.Append(t + ", ");
                }
                weekNumb = weekNumb.Remove(weekNumb.Length - 2, 1);
                weekNumb = weekNumb.Append(")  ");

            st = st.Append(lessonTime );
            foreach (var t in listEmployee)
                st = st.Append(", " + t);
            st = st.Append(", a." + auditory);
            if (!numsubGroup.Equals("0"))
            {
                st = st.Append( ", " + numsubGroup);
                st = st.Append(" подгр");
            }

            subject += "  " + lessonType.ToLower();
            employee = listEmployee[0];
            if (int.Parse(numsubGroup) != 0)
            {
                employee +=", " + numsubGroup + " подгр";
            }
            textForDisplayForToday = st.ToString();
            textForDisplay = weekNumb.ToString() + st.ToString();
        }
    }
}
