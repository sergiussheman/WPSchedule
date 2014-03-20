using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ScheduleBsuir.Resources;
using ScheduleBsuir.Model;
using System.Collections.Generic;
using Microsoft.Phone.Shell;
using System.Linq;
using System.Windows.Threading;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Windows.Controls;
using System.Windows;


namespace ScheduleBsuir.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool FirstShow = true;
        private int prevIndex = 0;
        public List<string> daysOfWeek { get; set; }
        private Pivot pointerPivot;
        private DateTime currentDate;
        private List<ListBox> listBoxs;
        public MainViewModel()
        {
            
            this.weekItems = new List<SchoolDay>();
            daysOfWeek = new List<string> { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
            currentDate = DateTime.Now;

        }

        public bool isExistDefaultGroup()
        {
            if (XmlWorker.getDefaultGroup() != null)
            {
                defaultGroup = int.Parse(XmlWorker.getDefaultGroup());
                return true;
            }
            else return false;
        }

        private static DispatcherTimer newTimer;
       
        private string _infoAboutDay;
        public string InfoAboutDay //содержит информацию(день недели, номер недели) о выбранном дне
        {
            get
            {
                return _infoAboutDay;
            }
            set
            {
                if (value != _infoAboutDay)
                {
                    _infoAboutDay = value;
                    NotifyPropertyChanged("InfoAboutDay");
                    //this.ChangedCurrentDay();
                }
            }
        }

        private lesson _nearLesson;
        public lesson nearLesson
        {
            get
            {
                return _nearLesson;
            }
            set
            {
                if (value != _nearLesson)
                {
                    _nearLesson = value;
                    NotifyPropertyChanged("nearLesson");
                    //this.ChangedCurrentDay();
                }
            }
        }
        
        public List<SchoolDay> weekItems { get; set; }
 
        public int defaultGroup { get; set; }

        public bool isSetGroup()
        {
            return false;
        }

        public bool IsDataLoaded
        {
            get
            {
                return XmlWorker.dataLoaded;
            }
            private set
            {
                XmlWorker.dataLoaded = true;
            }
        }

        public void createPivotItems(Pivot p, DataTemplate template, List<ListBox> list)
        {
            weekItems = XmlWorker.ReadXml();
            foreach (var day in weekItems)
                if (day.lessons.Count > 0)
                    foreach (var l in day.lessons)
                        l.createTextForDisplay();

            listBoxs = list;
            ListBox lb = new ListBox();
            pointerPivot = p;
            List<lesson> tempLessons = DateWorker.getScheduleForDate(DateTime.Now, weekItems).lessons;
            lb.ItemTemplate = template;
            lb.ItemsSource = tempLessons;
            //((PivotItem)p.Items[0]).Content = lb;
            listBoxs[pointerPivot.SelectedIndex].ItemsSource = tempLessons;
            DateTime t = DateTime.Now;
            ((PivotItem)pointerPivot.Items[0]).Header = t.ToShortDateString().ToString();
            ((PivotItem)pointerPivot.Items[1]).Header = t.AddDays(1).ToShortDateString().ToString();
            ((PivotItem)pointerPivot.Items[2]).Header = t.AddDays(2).ToShortDateString().ToString();
            p.SelectionChanged += pivot_SelectionChanged;

            InfoAboutDay = DateWorker.getInfoAboutDay(DateTime.Now, weekItems);
            prevIndex = pointerPivot.SelectedIndex;
            currentDate = DateTime.Now;
        }

        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!FirstShow)
            {

                int tmp = pointerPivot.SelectedIndex - prevIndex;
                if (tmp > 1) tmp = -1;
                if (tmp < -1) tmp = 1;

                currentDate = currentDate.AddDays(tmp);
                List<lesson> tempLesson = DateWorker.getScheduleForDate(currentDate, weekItems).lessons;
                listBoxs[pointerPivot.SelectedIndex].ItemsSource = tempLesson;
                
                createHeaders(currentDate);
                InfoAboutDay = DateWorker.getInfoAboutDay(currentDate, weekItems);
                prevIndex = pointerPivot.SelectedIndex;

            }
            else FirstShow = false;
        }

        public void createHeaders(DateTime currentDate)
        {
            ((PivotItem)pointerPivot.SelectedItem).Header = currentDate.ToShortDateString().ToString();
            ((PivotItem)pointerPivot.Items[(pointerPivot.SelectedIndex + 1) % 3]).Header = currentDate.AddDays(1).ToShortDateString().ToString();
            if (pointerPivot.SelectedIndex > 0)
                ((PivotItem)pointerPivot.Items[pointerPivot.SelectedIndex - 1]).Header = currentDate.AddDays(-1).ToShortDateString().ToString();
            else
                ((PivotItem)pointerPivot.Items[2]).Header = currentDate.AddDays(-1).ToShortDateString().ToString();
        }
        
        public void updateTile(Object sender, EventArgs args)
        {
            nearLesson = DateWorker.getNearPair(DateTime.Now, weekItems);
            ShellTileSchedule tileSchedule = new ShellTileSchedule();
            
            ShellTile apptile = ShellTile.ActiveTiles.First();
            StandardTileData appTileData = new StandardTileData();
            string title = nearLesson.subject.Substring(0, nearLesson.subject.IndexOf(" "));
            appTileData.Title = title + " " + nearLesson.lessonTime;
            appTileData.Count = 5;
            appTileData.BackTitle = title;
            appTileData.BackContent = nearLesson.textForDisplayForToday;
            apptile.Update(appTileData);
        }

        public void LoadData(PivotItem pivot)
        {
            
            weekItems = XmlWorker.ReadXml();
            foreach (var day in weekItems)
                if (day.lessons.Count > 0)
                    foreach (var l in day.lessons)
                        l.createTextForDisplay();
            InfoAboutDay = DateWorker.getInfoAboutDay(DateTime.Now, weekItems);
            this.IsDataLoaded = true;
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