using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ScheduleBsuir.Resources;
using System.IO.IsolatedStorage;
using System.IO;
using System.Text;
using System.Xml.Linq;
using ScheduleBsuir.Model;
using System.Globalization;

namespace ScheduleBsuir
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        private List<SchoolDay> week = new List<SchoolDay>();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
            //defaultPicker.ItemsSource = daysOfWeek;
            DataContext = App.ViewModel;
            Loaded += PageLoaded;

            


        }



        void PageLoaded(object sender, RoutedEventArgs e)
        {
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //if (NavigationContext.QueryString.ContainsKey("scheduleForGroup"))
            //{
            //    string inputSchedule = NavigationContext.QueryString["scheduleForGroup"].ToString();
            //    Loaded -= PageLoaded;
            //    App.ViewModel.writeScheduleForGroup(inputSchedule);
            //    if(!App.ViewModel.IsDataLoaded)
            //        App.ViewModel.LoadData();
            //}
            //if (App.ViewModel.isExistDefaultGroup())
            //{
            //    if (!App.ViewModel.IsDataLoaded)
            //    {
            //        App.ViewModel.LoadData();
            //    }
            //}
            if (!App.ViewModel.isExistDefaultGroup())
            {
                NavigationService.Navigate(new Uri("/WelcomePage.xaml", UriKind.Relative));

            }
            else
            {
                if (!App.ViewModel.IsDataLoaded)
                {
                    App.ViewModel.LoadData(secondPivot);


                }
                List<ListBox> listBoxs = new List<ListBox>() { firstListBox, secondListBox, thirdListBox };
                DataTemplate temp = (DataTemplate)Resources["SubjectItemDataTemplate"];
                App.ViewModel.createPivotItems(this.myPivot, temp, listBoxs);
            }

        }

        private void setDate_Today(object sender, EventArgs e)
        {
            myPivot.SelectedItem = firstPivot;
            List<ListBox> listBoxs = new List<ListBox>() { firstListBox, secondListBox, thirdListBox };
            DataTemplate temp = (DataTemplate)Resources["SubjectItemDataTemplate"];
            App.ViewModel.createPivotItems(this.myPivot, temp, listBoxs);

        }

        private void ShowWeekSchedule(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScheduleForWeek.xaml", UriKind.Relative));
        }

        private void Show_Settings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/WelcomePage.xaml", UriKind.Relative));
        }
    }
}