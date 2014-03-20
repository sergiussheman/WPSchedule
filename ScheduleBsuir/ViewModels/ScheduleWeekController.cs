using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleBsuir.Model;

namespace ScheduleBsuir.ViewModels
{
    public class ScheduleWeekController :INotifyPropertyChanged
    {
        public ScheduleWeekController()
        {
            daysOfWeek = new List<string> { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
        }

        public List<SchoolDay> weekItems { get; set; }
        public List<string> daysOfWeek { get; set; }

        public bool dataLoaded;
        public bool IsDataLoaded
        {
            get
            {
                return IsDataLoaded;
            }
            private set
            {
                dataLoaded = value;
            }
        }

        private string _selectedItem;
        public string selectedItem //выбранный день недели(пн,вт,ср...), отображаются на 2 pivot
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged("selectedItem");
                    this.ChangedCurrentDay();
                }
            }
        }

        private List<lesson> _dayItems { get; set; }
        public List<lesson> dayItems //пары для выбранного дня недели, отображаются на 2 pivot
        {
            get
            {
                return _dayItems;
            }
            set
            {
                if (value != _dayItems)
                {
                    _dayItems = value;
                    NotifyPropertyChanged("dayItems");
                }
            }
        }

        public void ChangedCurrentDay()//пользователь выбирает день недели 2pivot
        {
            string currentSelDay = _selectedItem;
            int index = daysOfWeek.IndexOf(currentSelDay);
            if (!(index == -1))
                dayItems = weekItems[index].lessons;
        }

        public void LoadData()
        {
            weekItems = XmlWorker.ReadXml();
            foreach (var day in weekItems)
                if (day.lessons.Count > 0)
                    foreach (var l in day.lessons)
                        l.createTextForDisplay();

            dayItems = weekItems[0].lessons;
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
