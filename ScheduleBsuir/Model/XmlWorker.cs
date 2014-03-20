using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScheduleBsuir.Model
{
    class XmlWorker
    {
        public static string Extension = ".xml";
        public static string group;
        public static void setGroup(string g)
        {
            if(group != "")
                group = g;
        }
        public static bool dataLoaded = false;
        public static void tempWrite()
        {
            using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (StreamWriter w = new StreamWriter(f.OpenFile("settings.txt", FileMode.Create)))

                {
                    w.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><scheduleXmlModels><scheduleModel><schedule><auditory>209-4</auditory><employee><academicDepartment>Физики</academicDepartment><firstName>Вера</firstName><id>500683</id><lastName>Бурцева</lastName><middleName>Петровна</middleName></employee><lessonTime>9:40-11:15</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>Физика</subject><weekNumber>0</weekNumber><weekNumber>1</weekNumber><weekNumber>2</weekNumber><weekNumber>3</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>320-4</auditory><employee><academicDepartment>ВМ</academicDepartment><firstName>Инесса</firstName><id>500668</id><lastName>Смирнова</lastName><middleName>Анатольевна</middleName></employee><lessonTime>11:45-13:20</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>Матем</subject><weekNumber>0</weekNumber><weekNumber>1</weekNumber><weekNumber>2</weekNumber><weekNumber>3</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>400-4</auditory><employee><academicDepartment>Ин.яз.№2</academicDepartment><firstName>Маргарита</firstName><id>501031</id><lastName>Кравченко</lastName><middleName>Валентиновна</middleName></employee><lessonTime>13:25-15:00</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>ИнЯз</subject><weekNumber>0</weekNumber><weekNumber>1</weekNumber><weekNumber>2</weekNumber><weekNumber>3</weekNumber><weekNumber>4</weekNumber></schedule><weekDay>Понедельник</weekDay></scheduleModel><scheduleModel><schedule><auditory>209-4</auditory><employee><academicDepartment>ЭВМ</academicDepartment><academicDepartment>ЭИ</academicDepartment><firstName>Юрий</firstName><id>500550</id><lastName>Луцик</lastName><middleName>Александрович</middleName></employee><lessonTime>8:00-9:35</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>АиЛОВТ</subject><weekNumber>0</weekNumber><weekNumber>1</weekNumber><weekNumber>2</weekNumber><weekNumber>3</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>209-4</auditory><employee><academicDepartment>ЭВМ</academicDepartment><academicDepartment>ЭИ</academicDepartment><firstName>Юрий</firstName><id>500550</id><lastName>Луцик</lastName><middleName>Александрович</middleName></employee><lessonTime>9:40-11:15</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>АиЛОВТ</subject><weekNumber>1</weekNumber><weekNumber>3</weekNumber></schedule><schedule><auditory>209-4</auditory><employee><academicDepartment>ЭВМ</academicDepartment><academicDepartment>ЭИ</academicDepartment><firstName>Юрий</firstName><id>500550</id><lastName>Луцик</lastName><middleName>Александрович</middleName></employee><lessonTime>9:40-11:15</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>ОАиП</subject><weekNumber>2</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>420-4</auditory><employee><academicDepartment>ВМ</academicDepartment><firstName>Инесса</firstName><id>500668</id><lastName>Смирнова</lastName><middleName>Анатольевна</middleName></employee><lessonTime>11:45-13:20</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>Матем</subject><weekNumber>1</weekNumber><weekNumber>3</weekNumber></schedule><schedule><auditory>420-4</auditory><employee><academicDepartment>ЭВМ</academicDepartment><firstName>Ирина</firstName><id>500549</id><lastName>Лукьянова</lastName><middleName>Викторовна</middleName></employee><lessonTime>11:45-13:20</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>АиЛОВТ</subject><weekNumber>2</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>400-4</auditory><employee><academicDepartment>Ин.яз.№2</academicDepartment><firstName>Маргарита</firstName><id>501031</id><lastName>Кравченко</lastName><middleName>Валентиновна</middleName></employee><lessonTime>13:25-15:00</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>ИнЯз</subject><weekNumber>0</weekNumber><weekNumber>1</weekNumber><weekNumber>2</weekNumber><weekNumber>3</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>902б-5</auditory><employee><academicDepartment>Ин.яз.№2</academicDepartment><academicDepartment>Ин.яз.№1</academicDepartment><firstName>Раиса</firstName><id>501036</id><lastName>Максимчук</lastName><middleName>Тихоновна</middleName></employee><lessonTime>13:25-15:00</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>ИнЯз</subject><weekNumber>0</weekNumber><weekNumber>1</weekNumber><weekNumber>2</weekNumber><weekNumber>3</weekNumber><weekNumber>4</weekNumber></schedule><weekDay>Вторник</weekDay></scheduleModel><scheduleModel><schedule><auditory>209-4</auditory><employee><academicDepartment>ЭВМ</academicDepartment><academicDepartment>ЭИ</academicDepartment><firstName>Юрий</firstName><id>500550</id><lastName>Луцик</lastName><middleName>Александрович</middleName></employee><lessonTime>8:00-9:35</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>АиЛОВТ</subject><weekNumber>1</weekNumber><weekNumber>3</weekNumber></schedule><schedule><auditory>209-4</auditory><employee><academicDepartment>Физики</academicDepartment><firstName>Вера</firstName><id>500683</id><lastName>Бурцева</lastName><middleName>Петровна</middleName></employee><lessonTime>8:00-9:35</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>Физика</subject><weekNumber>2</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>902-5</auditory><employee><academicDepartment>Ин.яз.№2</academicDepartment><academicDepartment>Ин.яз.№1</academicDepartment><firstName>Раиса</firstName><id>501036</id><lastName>Максимчук</lastName><middleName>Тихоновна</middleName></employee><lessonTime>11:45-13:20</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>ИнЯз</subject><weekNumber>0</weekNumber><weekNumber>1</weekNumber><weekNumber>2</weekNumber><weekNumber>3</weekNumber><weekNumber>4</weekNumber></schedule><weekDay>Среда</weekDay></scheduleModel><scheduleModel><schedule><auditory>418-4</auditory><employee><academicDepartment>ЭВМ</academicDepartment><firstName>Ирина</firstName><id>500549</id><lastName>Лукьянова</lastName><middleName>Викторовна</middleName></employee><lessonTime>8:00-9:35</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>АиЛОВТ</subject><weekNumber>2</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>209-4</auditory><employee><academicDepartment>ВМ</academicDepartment><firstName>Инесса</firstName><id>500668</id><lastName>Смирнова</lastName><middleName>Анатольевна</middleName></employee><lessonTime>9:40-11:15</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>Матем</subject><weekNumber>2</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>209-4</auditory><employee><academicDepartment>ВМ</academicDepartment><firstName>Татьяна</firstName><id>500670</id><lastName>Степанова</lastName><middleName>Сергеевна</middleName></employee><lessonTime>11:45-13:20</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>Матем</subject><weekNumber>1</weekNumber><weekNumber>3</weekNumber></schedule><schedule><auditory>209-4</auditory><employee><academicDepartment>ЭВМ</academicDepartment><academicDepartment>ЭИ</academicDepartment><firstName>Юрий</firstName><id>500550</id><lastName>Луцик</lastName><middleName>Александрович</middleName></employee><lessonTime>11:45-13:20</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>АиЛОВТ</subject><weekNumber>2</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>506-4</auditory><employee><academicDepartment>Физики</academicDepartment><firstName>Елена</firstName><id>500680</id><lastName>Андрианова</lastName><middleName>Вилоровна</middleName></employee><lessonTime>8:00-11:15</lessonTime><lessonType>ЛР</lessonType><note></note><numSubgroup>1</numSubgroup><studentGroup>350505</studentGroup><subject>Физика</subject><weekNumber>1</weekNumber></schedule><schedule><auditory>512-5</auditory><employee><academicDepartment>ЭВМ</academicDepartment><firstName>Евгений</firstName><id>500561</id><lastName>Сасин</lastName><middleName>Александрович</middleName></employee><lessonTime>8:00-11:15</lessonTime><lessonType>ЛР</lessonType><note></note><numSubgroup>2</numSubgroup><studentGroup>350505</studentGroup><subject>ОАиП</subject><weekNumber>1</weekNumber></schedule><schedule><auditory>512-4</auditory><employee><academicDepartment>ЭВМ</academicDepartment><firstName>Евгений</firstName><id>500561</id><lastName>Сасин</lastName><middleName>Александрович</middleName></employee><lessonTime>8:00-11:15</lessonTime><lessonType>ЛР</lessonType><note></note><numSubgroup>1</numSubgroup><studentGroup>350505</studentGroup><subject>ОАиП</subject><weekNumber>3</weekNumber></schedule><schedule><auditory>506-4</auditory><employee><academicDepartment>Физики</academicDepartment><firstName>Елена</firstName><id>500680</id><lastName>Андрианова</lastName><middleName>Вилоровна</middleName></employee><lessonTime>8:00-11:15</lessonTime><lessonType>ЛР</lessonType><note></note><numSubgroup>2</numSubgroup><studentGroup>350505</studentGroup><subject>Физика</subject><weekNumber>3</weekNumber></schedule><weekDay>Четверг</weekDay></scheduleModel><scheduleModel><schedule><auditory>104-4</auditory><employee><academicDepartment>ВМ</academicDepartment><firstName>Татьяна</firstName><id>500670</id><lastName>Степанова</lastName><middleName>Сергеевна</middleName></employee><lessonTime>9:40-11:15</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>Матем</subject><weekNumber>0</weekNumber><weekNumber>1</weekNumber><weekNumber>2</weekNumber><weekNumber>3</weekNumber><weekNumber>4</weekNumber></schedule><schedule><auditory>310a-4</auditory><employee><academicDepartment>ЭВМ</academicDepartment><firstName>Ирина</firstName><id>500549</id><lastName>Лукьянова</lastName><middleName>Викторовна</middleName></employee><lessonTime>11:45-13:20</lessonTime><lessonType>ЛК</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>АиЛОВТ</subject><weekNumber>1</weekNumber><weekNumber>3</weekNumber></schedule><schedule><auditory>501-5</auditory><employee><academicDepartment>ЭВМ</academicDepartment><firstName>Евгений</firstName><id>500561</id><lastName>Сасин</lastName><middleName>Александрович</middleName></employee><lessonTime>11:45-13:20</lessonTime><lessonType>ЛР</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>ОАиП</subject><weekNumber>2</weekNumber><weekNumber>4</weekNumber></schedule><weekDay>Пятница</weekDay></scheduleModel><scheduleModel><schedule><auditory>515-4</auditory><employee><academicDepartment>Физики</academicDepartment><firstName>Елена</firstName><id>500680</id><lastName>Андрианова</lastName><middleName>Вилоровна</middleName></employee><lessonTime>8:00-9:35</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>Физика</subject><weekNumber>1</weekNumber><weekNumber>3</weekNumber></schedule><schedule><auditory>314-4</auditory><employee><academicDepartment>ГД</academicDepartment><firstName>Юрий</firstName><id>500373</id><lastName>Янковский</lastName><middleName>Юрьевич</middleName></employee><lessonTime>9:40-11:15</lessonTime><lessonType>ПЗ</lessonType><note></note><numSubgroup>0</numSubgroup><studentGroup>350505</studentGroup><subject>ИМП</subject><weekNumber>1</weekNumber><weekNumber>3</weekNumber></schedule><weekDay>Суббота</weekDay></scheduleModel></scheduleXmlModels>");
                }
            }
        }

        public static void LoadXml(string g)
        {
            group = g;
            string bsuir = "http://bsuir.by/schedule/rest/schedule/";
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri(bsuir + g));
        }

        private static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (StreamWriter w = new StreamWriter(f.OpenFile(group + "xml", FileMode.Create)))
                {
                    //w.Write(e.Result);

                }
            }
        }

        public static void writeScheduleForGroup(string schedule)
        {
            using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (StreamWriter w = new StreamWriter(f.OpenFile(group + ".xml", FileMode.Create)))
                {
                    w.Write(schedule);
                    writeDefaultGroup(group);
                }
            }
        }

        public static string getDefaultGroup()
        {
            IsolatedStorageFile groupFileStorage = IsolatedStorageFile.GetUserStoreForApplication();
            if(isSettingExist())
            {
                string tGroup = "";
                IsolatedStorageFileStream groupFileStream = groupFileStorage.OpenFile("settings.xml", FileMode.Open);
                using (var sr = new StreamReader(groupFileStream))
                {
                    tGroup = sr.ReadToEnd();
                }
                if (!tGroup.Equals(""))
                    return tGroup;
                else
                    return null;
            }
            else
                return null;
        }

        private static bool isSettingExist()
        {
            IsolatedStorageFile settingFleStorage = IsolatedStorageFile.GetUserStoreForApplication();
            return settingFleStorage.FileExists("settings.xml");
        }

        public static void writeDefaultGroup(string defaultGroup)
        {

            using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (StreamWriter w = new StreamWriter(f.OpenFile("settings.xml", FileMode.Create)))
                {
                    w.Write(defaultGroup);

                }
            }
        }


        public static void WriteSchedule(string filePath, string content)
        {
            using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (StreamWriter w = new StreamWriter(f.OpenFile(filePath, FileMode.Create)))
                {
                    w.Write(content);
                }
            }
        }

        public static List<SchoolDay> ReadXml()
        {
            group = getDefaultGroup();
            string filePath = group + ".xml";
            List<SchoolDay> week = new List<SchoolDay>();
            using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
            {
                
                StringBuilder build = new StringBuilder();
                using (StreamReader r = new StreamReader(f.OpenFile(filePath, FileMode.OpenOrCreate)))
                {

                    XDocument doc = XDocument.Load(r);
                    foreach (XElement element in doc.Descendants("scheduleModel"))
                    {
                        SchoolDay curSchoolDay = new SchoolDay();
                        foreach (var e in element.Descendants("schedule"))
                        {
                            lesson curLesson = new lesson();
                            curLesson.auditory = e.Element("auditory").Value.ToString();
                            curLesson.lessonTime = e.Element("lessonTime").Value.ToString();
                            curLesson.lessonType = e.Element("lessonType").Value.ToString();
                            curLesson.numsubGroup = e.Element("numSubgroup").Value.ToString();
                            curLesson.subject = e.Element("subject").Value.ToString();
                            foreach (var empl in e.Descendants("employee"))
                            {
                                curLesson.listEmployee.Add(empl.Element("lastName").Value.ToString());
                            }
                            foreach (var wNum in e.Elements("weekNumber"))
                            {
                                curLesson.weekNumbers.Add(wNum.Value.ToString());
                            }
                            curSchoolDay.addLesson(curLesson);
                        }
                        curSchoolDay.weekDay = element.Element("weekDay").Value.ToString();
                        week.Add(curSchoolDay);
                    }

                }
            }
            return week;
        }
    }
}
