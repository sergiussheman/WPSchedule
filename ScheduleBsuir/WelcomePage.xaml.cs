using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.IO;
using ScheduleBsuir.Model;
using System.Windows.Media.Imaging;

namespace ScheduleBsuir
{
    public partial class WelcomePage : PhoneApplicationPage
    {

        private static string group;
        private string refreshGroup;
        public WelcomePage()
        {
            InitializeComponent();
            RefreshScheduleList();
            Loaded += PageLoaded;
            

        }
        void PageLoaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.isExistDefaultGroup())
            {
                this.NavigationService.RemoveBackEntry();

            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (inputText.Text.Equals("") || (inputText.Text.Count() != 6))
                {
                    MessageBox.Show("Укажите правильный номер группы");
                }
                else
                {
                    okButton.IsEnabled = false;
                    group = inputText.Text;
                    string bsuir = "http://bsuir.by/schedule/rest/schedule/";
                    progressBar.IsVisible = true;
                    progressBar.Text = "Загрузка расписания";
                    progressBar.IsIndeterminate = true;
                    WebClient client = new WebClient();
                    client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
                    client.DownloadStringAsync(new Uri(bsuir + group));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте введенный номер группы");
            }
        }

        private void ScheduleList_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshScheduleList();
        }

        List<String> fileslist = new List<string>();

        void RefreshScheduleList()
        {
            ScheduleList.IsEnabled = false;
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            List<GroupScheduleLink> fileslist = new List<GroupScheduleLink>();
            foreach (string item in storage.GetFileNames("*" + XmlWorker.Extension))
            {
                if (item.Count() == 10)
                    fileslist.Add(new GroupScheduleLink(item));
            }
            ScheduleList.ItemsSource = fileslist;
            ScheduleList.IsEnabled = true;
        }

        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                progressBar.IsVisible = false;

                XmlWorker.setGroup(group);
                XmlWorker.dataLoaded = false;

                XmlWorker.WriteSchedule(group + XmlWorker.Extension, e.Result);
                XmlWorker.writeDefaultGroup(group);

                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Проверьте подключение к интернету");
            }

            okButton.IsEnabled = true;         
        }

        private void GroupName_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string selectedGroup =((GroupScheduleLink)ScheduleList.SelectedItem).Name;
            XmlWorker.writeDefaultGroup(selectedGroup);
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void DeleteGroupScheduleLinkButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string deleteGroup = ((List<GroupScheduleLink>)ScheduleList.ItemsSource)[ScheduleList.SelectedIndex].Name;
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                store.DeleteFile(deleteGroup + XmlWorker.Extension);
            RefreshScheduleList();
            if (XmlWorker.getDefaultGroup() == deleteGroup)
            {
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                foreach (string item in storage.GetFileNames("*" + XmlWorker.Extension))
                {
                    if (item.Count() == 10)
                    {
                        XmlWorker.writeDefaultGroup(item.Substring(0, item.Count() - 4));
                        return;
                    }
                }
                XmlWorker.writeDefaultGroup("");
            }
        }
        private void RefteshGroupScheduleLinkButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            refreshGroup = ((List<GroupScheduleLink>)ScheduleList.ItemsSource)[ScheduleList.SelectedIndex].Name;
            string bsuir = "http://bsuir.by/schedule/rest/schedule/";
            progressBar.IsVisible = true;
            progressBar.Text = "Загрузка расписания";
            progressBar.IsIndeterminate = true;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_RefreshStringCompleted);
            client.DownloadStringAsync(new Uri(bsuir + refreshGroup));
        }

        private void client_RefreshStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                progressBar.IsVisible = false;

                XmlWorker.setGroup(refreshGroup);
                XmlWorker.dataLoaded = false;

                XmlWorker.WriteSchedule(refreshGroup + XmlWorker.Extension, e.Result);
                XmlWorker.writeDefaultGroup(refreshGroup);
                MessageBox.Show("Расписание группы обновлено");
            }
            else
            {
                MessageBox.Show("Проверьте подключение к интернету");
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshScheduleList();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void RefteshGroupScheduleLinkButton_Loaded(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage();
            var darkVisibility = (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
            if (darkVisibility == Visibility.Visible)
            {
                bi.UriSource = new Uri("Assets/refresh.png", UriKind.Relative);
            }
            else
            {
                bi.UriSource = new Uri("Assets/refresh_dark.png", UriKind.Relative);
            }
            ((Image)sender).Source = bi;
        }

        private void DeleteGroupScheduleLinkButton_Loaded(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage();
            var darkVisibility = (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
            if (darkVisibility == Visibility.Visible)
            {
                bi.UriSource = new Uri("Assets/delete.png", UriKind.Relative);
            }
            else
            {
                bi.UriSource = new Uri("Assets/delete_dark.png", UriKind.Relative);
            }
            ((Image)sender).Source = bi;
        }

        public class GroupScheduleLink
        {
            public string Name { get; set; }
            public string Filename { get; set; }
            public GroupScheduleLink(string filename)
            {
                Filename = filename;
                Name = filename.Substring(0, filename.LastIndexOf('.'));
            }
        }


    }
}