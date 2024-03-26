using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Xml;


namespace ШАГ_26._03._24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = "users.xml";
            Console.WriteLine("Файл знайдено. Зчитування даних...");
            // Зчитування даних 
            ReadFromXml(xmlFilePath);

            while (true)
            {
                Console.WriteLine("\nОберіть опцію:");
                Console.WriteLine("1. Створити нового користувача");
                Console.WriteLine("2. Редагувати існуючого користувача");
                Console.WriteLine("3. Видалити користувача");
                Console.WriteLine("4. Вивести інформацію по усім користувачам");
                Console.WriteLine("5. Вивести інформацію по заданому фільтру");
                Console.WriteLine("6. Вийти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nСтворення нового користувача...");
                        CreateRecord(xmlFilePath);
                        break;
                    case "2":
                        Console.WriteLine("\nРедагування існуючого користувача...");
                        EditRecord(xmlFilePath);
                        break;
                    case "3":
                        Console.WriteLine("\nВидалення користувача...");
                        DeleteRecord(xmlFilePath);
                        break;
                    case "4":
                        Console.WriteLine("\nІнформація по усім користувачам:");
                        ReadFromXml(xmlFilePath);
                        break;
                    case "5":
                        Console.WriteLine("\nВивести інформацію по заданому фільтру:");
                        ReadFromXml(xmlFilePath);
                        break;
                    case "6":
                        Console.WriteLine("\nПрограма завершена.");
                        return;
                    default:
                        Console.WriteLine("\nНевірний вибір. Будь ласка, виберіть опцію знову.");
                        break;
                }
            }
        }


        static void CreateRecord(string filePath)
        {
            Console.WriteLine("Введіть дані нового користувача:");
            Console.Write("Ім'я: ");
            string name = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Вік: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Баланс: ");
            double balance = double.Parse(Console.ReadLine());
            Console.Write("Статус: ");
            string status = Console.ReadLine();
            Console.Write("Дата народження: ");
            string dob = Console.ReadLine();
            Console.Write("Країна: ");
            string country = Console.ReadLine();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlElement root = xmlDoc.DocumentElement;
            XmlElement person = xmlDoc.CreateElement("User");

            XmlElement nameElement = xmlDoc.CreateElement("Name");
            nameElement.InnerText = name;
            person.AppendChild(nameElement);

            XmlElement passwordElement = xmlDoc.CreateElement("Password");
            passwordElement.InnerText = password;
            person.AppendChild(passwordElement);

            XmlElement emailElement = xmlDoc.CreateElement("Email");
            emailElement.InnerText = email;
            person.AppendChild(emailElement);

            XmlElement ageElement = xmlDoc.CreateElement("Age");
            ageElement.InnerText = age.ToString();
            person.AppendChild(ageElement);

            XmlElement balanceElement = xmlDoc.CreateElement("Balance");
            balanceElement.InnerText = balance.ToString();
            person.AppendChild(balanceElement);

            XmlElement statusElement = xmlDoc.CreateElement("Status");
            statusElement.InnerText = status;
            person.AppendChild(statusElement);

            XmlElement dobElement = xmlDoc.CreateElement("DateOfBirth");
            dobElement.InnerText = dob;
            person.AppendChild(dobElement);

            XmlElement countryElement = xmlDoc.CreateElement("Country");
            countryElement.InnerText = country;
            person.AppendChild(countryElement);

            root.AppendChild(person);
            xmlDoc.Save(filePath);
            Console.WriteLine("Новий запис успішно створено.");
        }

        static void EditRecord(string filePath)
        {
            Console.Write("Введіть ім'я користувача, якого потрібно відредагувати: ");
            string nameToEdit = Console.ReadLine();

            Console.Write("Введіть новий пароль: ");
            string newPassword = Console.ReadLine();

            Console.Write("Введіть новий вік: ");
            int newAge = int.Parse(Console.ReadLine());

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNodeList nodes = xmlDoc.SelectNodes("//User[Name='" + nameToEdit + "']");
            foreach (XmlNode node in nodes)
            {
                XmlNode ageNode = node.SelectSingleNode("Age");
                XmlNode passwordNode = node.SelectSingleNode("Password");
                ageNode.InnerText = newAge.ToString();
                passwordNode.InnerText = newPassword;

                xmlDoc.Save(filePath);
                Console.WriteLine("Запис успішно відредаговано.");
            }
        }

        static void DeleteRecord(string filePath)
        {
            Console.Write("Введіть ім'я користувача, якого потрібно видалити: ");
            string nameToDelete = Console.ReadLine();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNodeList nodes = xmlDoc.SelectNodes("//User[Name='" + nameToDelete + "']");
            foreach (XmlNode node in nodes)
            {
                node.ParentNode.RemoveChild(node);
                xmlDoc.Save(filePath);
                Console.WriteLine("Запис успішно видалено.");
            }
        }

        static void ReadFromXml(string filePath)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);
        XmlNodeList nodes = xmlDoc.SelectNodes("//User");
        Console.WriteLine("Дані з файлу XML:");
        foreach (XmlNode node in nodes)
        {
            string name = node.SelectSingleNode("Name").InnerText;
            string age = node.SelectSingleNode("Age").InnerText;
            string password = node.SelectSingleNode("Password").InnerText;
            string email = node.SelectSingleNode("Email").InnerText;
            string balance = node.SelectSingleNode("Balance").InnerText;
            string status = node.SelectSingleNode("Status").InnerText;
            string dob = node.SelectSingleNode("DateOfBirth").InnerText;
            string country = node.SelectSingleNode("Country").InnerText;

            Console.WriteLine($"Ім'я: {name}, Вік: {age}, Пароль: {password}, Email: {email}, Баланс: {balance}, Статус: {status}, Дата народження: {dob}, Країна: {country}");
        }
    }
}
 }