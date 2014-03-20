using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ScheduleBsuir.Model
{
    public class SchoolDay : INotifyPropertyChanged
    {
        public List<lesson> lessons { get; set; }

        public string weekDay { get; set; }
        public int WeekNumber { get; set; }

        public SchoolDay()
        {
            lessons = new List<lesson>();
        }

        public void addLesson(lesson aLesson)
        {
            lessons.Add(aLesson);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
