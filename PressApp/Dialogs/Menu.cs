using Business.Interfaces;
using Data.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;


namespace PressApp.Dialogs;

public class Menu(IContactService contactService, ICustomerService customerService) : IMenu
{

    private readonly IContactService _contactService = contactService;
    private readonly ICustomerService _customerService = customerService;


    bool IsOn = true;
    public void Show()
    {

        do
        {
            Console.Clear();
            Console.WriteLine("  *------------- MENY ------------*");
            Console.WriteLine("  | 1. Add Employee:              |");
            Console.WriteLine("  | 2. Add ContactPerson:         |");
            Console.WriteLine("  | 3. Add Customer:              |");
            Console.WriteLine("  | 4. Show Contactlist:          |");
            Console.WriteLine("  | 5. Show Customer With Contact:|");
            Console.WriteLine("  | Q. Exit AppConsole            |");
            Console.WriteLine("  `-------------------------------´");
            Console.WriteLine("");
            Console.Write("Your Choice: ");
            string option = Console.ReadLine()!;
            switch (option.ToLower())
            {
                case "1":
                    CreateEmployee();
                    break;
                case "2":
                    CreateContact();
                    break;
                case "3":
                    CreateCustomer();
                    break;
                case "4":
                    ViewAllContacts();
                    break;
                case "5":
                    ShowCustomerContact();
                    break;
                case "q":
                    
                    break;
                default:
                    Console.WriteLine("Choose again!");
                    break;
            }


        } while (IsOn);
    }



    public void CreateEmployee()
    {
       
    }







    public void CreateContact()
    {
        var contactEntity = new ContactEntity();

        Console.Clear();
        Console.WriteLine("        CREATE NEW CONTACT         ");
        Console.Write("FirstName: ");
        contactEntity.FirstName = Console.ReadLine()!;
        Console.Write("LastName: ");
        contactEntity.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        contactEntity.Email = Console.ReadLine()!;
        Console.Write("PhoneNumber: ");
        contactEntity.PhoneNumber = Console.ReadLine()!;
        Console.WriteLine();

        var result = _contactService.CreateContact(contactEntity);
        if (result != null)
        {
            Console.WriteLine($"The Contact was created with id '{result.Id}'.");
            Console.Write($"{result.FirstName} {result.LastName}  {result.Email}  {result.PhoneNumber}");
        }
        else
        {
            Console.Write("Something went wrong.");
        }

        Console.ReadKey();
    }






    public void CreateCustomer()
    {
          var customerEntity = new CustomerEntity();

        Console.Clear();
        Console.WriteLine("        CREATE NEW CUSTOMER         ");
        Console.Write("Company name:");
        customerEntity.Name = Console.ReadLine()!;
        Console.Write("ContactId:");
        customerEntity.ContactId = Convert.ToInt32(Console.ReadLine()!);


        var result = _customerService.CreateCustomer(customerEntity);
        if (result != null)
        {
            Console.WriteLine($"The Customer was created with id '{result.Id}'.");
        }
        else
        {
            Console.Write("Something went wrong.");
        }

        Console.ReadKey();

    }



    public void ShowCustomerContact()
    {
        
        var result = _customerService.GetCustomer();
        if (result.Any())
        {
            foreach (var customer in result)
            {
                Console.WriteLine($"Company:  {customer.Name}");
                Console.WriteLine($"Contact Info:  {customer.Contact.FirstName} {customer.Contact.LastName}");
                
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
        }
        Console.ReadKey();



    }




    public void ViewAllContacts()
    {
        Console.Clear();
        Console.WriteLine("        All Contacts list          ");
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine();
        var result = _contactService.GetContacts();
        if (result.Any())
        {
            foreach (var contact in result)
            {
                Console.WriteLine($"Id: {contact.Id}");
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Contact Info: <{contact.Email}> {contact.PhoneNumber}");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
        }
        Console.ReadKey();
    }
}
