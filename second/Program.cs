using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace second
{

    [Serializable]
    public class Student: IComparable<Student>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public DateTime Date { get; set; }

        public string Gender { get; set; }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
        public string Addres { get; set; }

        public string PhoneNumber { get; set; }
        public string Group { get; set; }

        public int YearOfStudy { get; set; }

        public int Math { get; set; }
        public int IT { get; set; }
        public int English { get; set; }
        public int Geography { get; set; }
        int IComparable<Student>.CompareTo(Student other)
        {
            if (this.Name.CompareTo(other.Name)==1) return -1;
            if (this.Name.CompareTo(other.Name) == -1) return 1;
            return 0;
        }

    }


    class Program
    {
        
       

        static void Main(string[] args)
        {
            Student stud = new Student();
            Student stud2 = new Student();
            stud.Date = new DateTime(2003, 7, 4);

            Console.WriteLine(stud.Date.ToString("dd:MM:yyyy"));


            stud.Name = "George";
            stud.IT = 5;
            stud.Math = 4;
            stud.English = 3;
            stud.Gender = "Male";
            stud.Surname = "Pitterson";
            stud.Group = "KI2-20-2";
            stud.YearOfStudy = 3;
            stud.Addres = "Zoryana 20";
            stud.PhoneNumber = "+38044242412";


            byte[] array=Student.ObjectToByteArray(stud);
            

            string path = "test.txt";
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    // записываем в файл значение каждого поля структуры
                    writer.Write(array);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            byte[] from = new byte[array.Length];
            int i = 0;
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        from[i]=reader.ReadByte();

                      
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            object temp = new Student();
            temp = Student.ByteArrayToObject(from);


            Console.WriteLine(stud2.Name);
            Console.WriteLine(stud2.YearOfStudy);
            Console.WriteLine(stud2.Date.ToString("dd:MM:yyyy"));
        }
    }
}
