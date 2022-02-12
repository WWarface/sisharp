using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinFormsApp1
{
    class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        private List<Student> People=new List<Student>();

        public List<Student> GetList()
        {
            return People;
        }
        public DateTime Date { get; set; }

        public string Group { get; set; }

        public string Gender { get; set; }

        public string Addres { get; set; }

        public string PhoneNumber { get; set; }

        private int iter = 0;

        public int YearOfStudy { get; set; }

        public int Math { get; set; }
        public int IT { get; set; }
        public int English { get; set; }
        public int Geography { get; set; }
        int IComparable<Student>.CompareTo(Student other)
        {
            return this.YearOfStudy.CompareTo(other.YearOfStudy);
        }

        public void Sort()
        {
            People.Sort();
        }




        public void Write(string path)
        {
            string writePath = path+".txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    
                        sw.WriteLine(Name);
                        sw.WriteLine(Surname);
                        sw.WriteLine(Date);
                        sw.WriteLine(Group);
                        sw.WriteLine(Gender);
                        sw.WriteLine(Addres);
                        sw.WriteLine(PhoneNumber);
                        sw.WriteLine(YearOfStudy);
                        sw.WriteLine(Math);
                        sw.WriteLine(IT);
                        sw.WriteLine(English);
                        sw.WriteLine(Geography);
                    
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Read(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path + ".txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        Student temp = new Student();
                        temp.Name = sr.ReadLine();
                        temp.Surname = sr.ReadLine();
                        temp.Date = System.DateTime.Parse(sr.ReadLine());
                        temp.Group = sr.ReadLine();
                        temp.Gender = sr.ReadLine();
                        temp.Addres = sr.ReadLine();
                        temp.PhoneNumber = sr.ReadLine();
                        temp.YearOfStudy = int.Parse(sr.ReadLine());
                        temp.Math = int.Parse(sr.ReadLine());
                        temp.IT = int.Parse(sr.ReadLine());
                        temp.English = int.Parse(sr.ReadLine());
                        temp.Geography = int.Parse(sr.ReadLine());
                        People.Add(temp);
                        iter++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
