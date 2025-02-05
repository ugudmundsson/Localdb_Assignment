using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;


namespace PressApp.Dialogs;

public class Menu(IContactService contactService, 
                  ICustomerService customerService, 
                  IEmployeesService employeesService,
                  IOrderRepository orderRepository,
                  IProjectRepository projectRepository,
                  IRoleService roleService) : IMenu
{
    private readonly IContactService _contactService = contactService;
    private readonly ICustomerService _customerService = customerService;
    private readonly IEmployeesService _employeeService = employeesService;
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IRoleService _rolesService = roleService;
   



    bool IsOn = true;
    public async Task Show()
    {

        do
        {
            Console.Clear();
            Console.WriteLine("  *------------- MENY ------------*");
            Console.WriteLine("  | 1. Add Employee:              |");
            Console.WriteLine("  | 2. Add ContactPerson:         |");
            Console.WriteLine("  | 3. Add Customer:              |");
            Console.WriteLine("  | 4. Add a Role:                |");
            Console.WriteLine("  | 5. Show Contactlist:          |");
            Console.WriteLine("  | 6. Show Customer With Contact:|");
            Console.WriteLine("  | 7. Show Roles at the Company: |");
            //Console.WriteLine("  | 8. Show Employees:            |");
            Console.WriteLine("  | Q. Exit AppConsole            |");
            Console.WriteLine("  `-------------------------------´");
            Console.WriteLine("");
            Console.WriteLine("----");
            Console.Write("Your Choice: ");
            string option = Console.ReadLine()!;
            switch (option.ToLower())
            {
                case "1":
                    await CreateEmployee();
                    break;
                case "2":
                    await CreateContact();
                    break;
                case "3":
                    await CreateCustomer();
                    break;
                case "4":
                    await RoleDialogs();
                    break;
                case "5":
                    await ViewAllContacts();
                    break;
                case "6":
                    await ShowCustomerContact();
                    break;
                case "7":
                    await ShowRoles();
                    break;
                //case "8":
                //    await ShowEmployees();
                //    break;
                case "q":
                    
                    break;
                default:
                    Console.WriteLine("Choose again!");
                    break;
            }


        } while (IsOn);
    }




    //1 ---------------------------
    public async Task CreateEmployee()
    {
       
        Console.Clear();
        Console.WriteLine("        CREATE NEW CONTACT         ");
        Console.WriteLine("----------------------------------------------------------");
        Console.Write("FirstName: ");
        var FirstName = Console.ReadLine()!;
        Console.Write("LastName: ");
        var LastName = Console.ReadLine()!;
        Console.Write("RoleId: ");
        var RoleId = Convert.ToInt32(Console.ReadLine()!);

        var registrationForm = new EmployeesRegistrationForm { FirstName = FirstName, LastName = LastName, RoleId = RoleId };
        var result = await _employeeService.CreateEmployeesAsync(registrationForm);
        if (result)
        {
            Console.WriteLine($"The Employee was created with id.");
            Console.Write($"{FirstName} {LastName}");
        }
        else
        {
            Console.Write("Something went wrong.");
        }
        Console.ReadKey();
    }





    //2 ---------------------------
    public async Task CreateContact()
    {
        
        Console.Clear();
        Console.WriteLine("        CREATE NEW CONTACT         ");
        Console.WriteLine("----------------------------------------------------------");
        Console.Write("FirstName: ");
        var FirstName = Console.ReadLine()!;
        Console.Write("LastName: ");
        var LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        var Email = Console.ReadLine()!;
        Console.Write("PhoneNumber: ");
        var PhoneNumber = Console.ReadLine()!;
        Console.WriteLine();

        var registrationForm = new ContactRegistrationForm
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber
        };
            var result = await _contactService.CreateContactAsync(registrationForm);
        if (result)
        {
            Console.WriteLine($"The Contact was created with id.");
            Console.Write($"{FirstName} {LastName}  {Email}  {PhoneNumber}");
        }
        else
        {
            Console.Write("Something went wrong.");
        }

        Console.ReadKey();
    }






    //3 ---------------------------
    public async Task CreateCustomer()
    {

        Console.Clear();
        Console.WriteLine("        CREATE NEW CUSTOMER         ");
        Console.WriteLine("----------------------------------------------------------");
        Console.Write("Company name:");
        var Name = Console.ReadLine()!;
        Console.Write("ContactId:");
        var ContactId = Convert.ToInt32(Console.ReadLine()!);

        var registrationForm = new CustomerRegistrationForm { Name = Name, ContactId = ContactId };
        var result = await _customerService.CreateCustomerAsync(registrationForm);
        if (result)
        {
            Console.WriteLine($"The Customer was created.");
        }
        else
        {
            Console.Write("Something went wrong.");
        }
        Console.ReadKey();
    }












    //4 ---------------------------
    public async Task RoleDialogs()
    {
        
        Console.Clear();
        Console.WriteLine("        CREATE NEW ROLE         ");
        Console.WriteLine("----------------------------------------------------------");
        Console.Write("RoleName: ");
        var roleName = Console.ReadLine()!;
        Console.WriteLine("");

        var registrationForm = new RoleRegistrationForm { RoleName = roleName };
        var result = await _rolesService.CreateRoleAsync(registrationForm);
        if (result)
        {
            Console.WriteLine($"The Role was created with id.");
        }
        else
        {
            Console.Write("Something went wrong.");
        }
        Console.ReadKey();
    }






    //5 ---------------------------
    public async Task ViewAllContacts()
    {
        Console.Clear();
        Console.WriteLine("        All Contacts list          ");
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine();

        var result = await _contactService.GetAllAsync();
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
                Console.WriteLine("    'Enter' hit return to menu");
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
        }
        Console.ReadKey();
    }









    //6 ---------------------------
    public async Task ShowCustomerContact()
    {
        

        var result = await _customerService.GetAllAsync();
        if (result.Any())
        {
            foreach (var customer in result)
            {
                var contact = await _contactService.GetByIdAsync(customer.ContactId);
                               
                Console.WriteLine($"Company:  {customer.Name}");
                Console.WriteLine($"Contact Info:  {contact.FirstName} {contact.LastName}");
                
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
        }
        Console.WriteLine("    'Enter' hit return to menu");
        Console.ReadKey();

    }








    //7 ---------------------------
    public async Task ShowRoles()
    {
        Console.Clear();
        Console.WriteLine("        All Roles list          ");
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine();

        var result = await _rolesService.GetAllAsync();
        if (result.Any())
        {
            foreach (var role in result)
            {
                Console.WriteLine($"Id: {role.Id}");
                Console.WriteLine($"RoleName: {role.RoleName}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No roles found.");
        }

        Console.ReadKey();
    }

    //8 ---------------------------

    //public async Task ShowEmployees()
    //    {
    //    Console.Clear();
    //    Console.WriteLine("        All Employees list          ");
    //    Console.WriteLine("----------------------------------------------------------");
    //    Console.WriteLine();
    //    var result = await _employeeService.GetEmployees();
    //    if (result.Any())
    //    {
    //        foreach (var employee in result)
    //        {
    //            Console.WriteLine($"Id: {employee.Id}");
    //            Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
    //            Console.WriteLine($"Role: {employee.RolesName.RoleName}");
    //            Console.WriteLine();
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("No employees found.");
    //    }
    //    Console.ReadKey();
    //}


}
