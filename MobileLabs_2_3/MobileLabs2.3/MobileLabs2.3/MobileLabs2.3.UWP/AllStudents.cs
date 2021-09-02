using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Windows.Storage;
using System.Collections.ObjectModel;

namespace MobileLabs2._3.UWP
{
    [DataContract]
    internal class Student
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string FIO { get; set; }
        [DataMember] public string Mark1 { get; set; }
        [DataMember] public string Mark2 { get; set; }
        [DataMember] public string Mark3 { get; set; }
    }
    internal class allStudents
    {
        private ObservableCollection<Student> allStudentsLst;
        private DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Student>));
        public allStudents()
        {
            allStudentsLst = new ObservableCollection<Student>();
        }

        public void addStudent(string FIO, string mark1, string mark2, string mark3)
        {
            if (allStudentsLst.Count == 0)
            {
                allStudentsLst.Add(new Student { Id = 1, FIO = FIO, Mark1 = mark1, Mark2 = mark2, Mark3 = mark3});
            }
            else
            {
                allStudentsLst.Add(new Student { Id = int.Parse(allStudentsLst.Last().Id.ToString()) + 1, FIO = FIO, Mark1 = mark1, Mark2 = mark2, Mark3 = mark3 });
            }
        }

        public ObservableCollection<Student> getList()
        {
            return allStudentsLst;
        }

        public string savePath()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            return string.Format("{0}\\{1}", localFolder.Path, "save.json");
        }

        public void saveFile()
        {
            var p = savePath();
            using (FileStream fs = new FileStream(p, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, allStudentsLst);
            }
        }

        public void openFile()
        {
            var p = savePath();
            using (FileStream fs = new FileStream(p, FileMode.Open))
            {
                allStudentsLst = (ObservableCollection<Student>)jsonFormatter.ReadObject(fs);
            }
        }

        public void deleteStudent(int id)
        {
            var delitem = allStudentsLst.Where(t => t.Id == id).First();
            allStudentsLst.Remove(delitem);
        }
        //public void editStudent(int id, string fio)
        //{
        //    var delitem = allStudentsLst.Where(t => t.Id == id).First();
        //    delitem.FIO = fio;
        //    allStudentsLst.saveFile(delitem);
        //}
    }
}
