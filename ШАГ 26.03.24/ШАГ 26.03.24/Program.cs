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

        // Створення нового запису 
        Console.WriteLine("\nСтворення нового запису...");
        CreateRecord(xmlFilePath, "Alice", "alice123", "alice@example.com", 25, 100, "active", "2000-01-01", "Ukraine");
        Console.WriteLine("\nДані після створення нового запису:");
        ReadFromXml(xmlFilePath);

        // Редагування запису 
        Console.WriteLine("\nРедагування запису...");
        EditRecord(xmlFilePath, "Alice", "newAlice123", 30);
        Console.WriteLine("\nДані після редагування:");
        ReadFromXml(xmlFilePath);

        // Видалення запису 
        Console.WriteLine("\nВидалення запису...");
        DeleteRecord(xmlFilePath, "Alice");
        Console.WriteLine("\nДані після видалення запису:");
        ReadFromXml(xmlFilePath);
    }

    static void CreateRecord(string filePath, string name, string password, string email, int age, double balance, string status, string dob, string country)
    {
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

    static void EditRecord(string filePath, string nameToEdit, string newPassword, int newAge)
    {
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

    static void DeleteRecord(string filePath, string nameToDelete)
    {
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