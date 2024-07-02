using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_6._06
{
    public partial class Form1 : Form
    {
        private List<User> users = new List<User>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            int age = int.Parse(textBoxAge.Text);
            decimal balance = decimal.Parse(textBoxBalance.Text);

            User newUser = new User(name, surname, age, balance);
            users.Add(newUser);
            UpdateUserList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                users.RemoveAt(listBox1.SelectedIndex);
                UpdateUserList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxFind.Text.ToLower();
            List<User> searchResults = users.FindAll(user =>
                user.Name.ToLower().Contains(searchTerm) ||
                user.Surname.ToLower().Contains(searchTerm));

            listBox1.Items.Clear();
            foreach (User user in searchResults)
            {
                listBox1.Items.Add(user.ToString());
            }
        }
        private void UpdateUserList()
        {
            listBox1.Items.Clear();
            foreach (User user in users)
            {
                listBox1.Items.Add(user.ToString());
            }
        }
    }
        public class User
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
            public decimal Balance { get; set; }

            public User(string name, string surname, int age, decimal balance)
            {
                Name = name;
                Surname = surname;
                Age = age;
                Balance = balance;
            }

            public override string ToString()
            {
                return $"{Name} {Surname}, Age: {Age}, Balance: {Balance:C}";
            }
        }
}
