using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool filled = this.Controls.OfType<TextBox>().All(textBox => textBox.Text != "");
            if (filled)
            {
                Student student = new Student();             
                student.Name = textBox1.Text;  
                student.Surname = textBox2.Text;
                listBox1.Items.Add($"{student.Name} {student.Surname}");
                student.Age = int.Parse(textBox3.Text);
                int year, day, month;
                day = int.Parse(textBox4.Text);
                month = int.Parse(textBox5.Text);
                year = int.Parse(textBox6.Text);
                DateTime date = new DateTime(year,month,day);
                student.Date = date;
                student.Gender = textBox7.Text;
                student.Addres = textBox8.Text;
                student.PhoneNumber = textBox9.Text;
                student.YearOfStudy = int.Parse(textBox10.Text);
                student.Group = textBox11.Text;
                student.Math = int.Parse(textBox12.Text);
                student.IT = int.Parse(textBox13.Text);
                student.Geography = int.Parse(textBox14.Text);
                student.English = int.Parse(textBox15.Text);


                student.Write("test");
            }
            else
            {
                MessageBox.Show("Fill all fields!");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void findStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Text1.Text==""||Text2.Text=="")
            {
                MessageBox.Show("Fill all fields!");
            }
            else
            {
                Student student = new Student();
                student.Read("test");
                student.Sort();
                List<Student> People = new List<Student>();
                People = student.GetList();
                string surname=Text1.Text;
                int course=int.Parse(Text2.Text);
                int notFound = 0;
                foreach (var item in People)
                {
                    if (item.Surname==surname && item.YearOfStudy==course)//found
                    {
                        listBox2.Items.Add("Name: " + item.Name);
                        listBox2.Items.Add("Surname: " + item.Surname);
                        listBox2.Items.Add("Age: " + item.Age);
                        listBox2.Items.Add("Course: " + item.YearOfStudy);
                        listBox2.Items.Add("Gender: " + item.Gender);
                        listBox2.Items.Add("Date of birth: " + item.Date.ToString("dd:MM:yyyy"));
                        listBox2.Items.Add("Group: " + item.Group);
                        listBox2.Items.Add("Session:");
                        listBox2.Items.Add("Math: " + item.Math);
                        listBox2.Items.Add("IT: " + item.IT);
                        listBox2.Items.Add("Geogpraphy: " + item.Geography);
                        listBox2.Items.Add("English: " + item.English);
                        listBox2.Items.Add(" ");
                    }
                    else
                    {
                        notFound++;
                        if(notFound==People.Count)MessageBox.Show("Not found");
                    }
                }

            }
        }
    }
}
