using System.ComponentModel.DataAnnotations;

public class Client
{
    public string _clientName { get; set; }
    public string _clientCompany { get; set; }
    public string _phone { get; set; }
    public string _email { get; set; }

    public Client(string clientName, string phone, string email)
    {
        _clientName = clientName;
        _phone = phone;
        _email = email;
    }

    public Client(string clientCompany, string clientName, string phone, string email)
    {
        _clientCompany = clientCompany;
        _clientName = clientName;
        _phone = phone;
        _email = email;
    }

    public void UpdateContactInfo()
    {
        Console.Write("What is the new phone number? ");
        string phone = Console.ReadLine();
        _phone = phone;
        Console.Write("What is the new email address? ");
        string email = Console.ReadLine();
        _email = email;
    }

    public void SendEmail()
    {
        Console.Write("Write the email content: ");
        string content = Console.ReadLine();
        Console.WriteLine(content);
        Console.WriteLine("Email sent");
    }
}