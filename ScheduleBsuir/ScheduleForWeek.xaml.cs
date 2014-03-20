using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ScheduleBsuir
{
    public partial class ScheduleForWeek : PhoneApplicationPage
    { 
        public ScheduleForWeek()
        {
            InitializeComponent();
            if (DataContext == null)
            {
                App.ViewModelForWeek = new ViewModels.ScheduleWeekController();
                DataContext = App.ViewModelForWeek;
            }


        }
        static bool temp = false;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.isExistDefaultGroup())
            {
                NavigationService.Navigate(new Uri("/WelcomePage.xaml", UriKind.Relative));

            }
            else
            {
                if (!App.ViewModelForWeek.dataLoaded)
                {
                   
                    App.ViewModelForWeek.LoadData();

                }
            }
        }

        private void ShowMainPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Show_Settings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/WelcomePage.xaml", UriKind.Relative));
        }
    }
}