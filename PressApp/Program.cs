using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PressApp.Dialogs;


var serviceCollection = new ServiceCollection();

serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ECutbildningen\Databaslagring\Assignment\Localdb\Data\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));
serviceCollection.AddScoped<IContactService, ContactService>();
serviceCollection.AddScoped<ICustomerService, CustomerService>();
serviceCollection.AddScoped<IMenu, Menu>();


var serviceProvider = serviceCollection.BuildServiceProvider();
var menu = serviceProvider.GetRequiredService<IMenu>();

while (true)
{
    menu.Show();
    menu.CreateContact();
    menu.CreateCustomer();
    menu.ViewAllContacts();
    menu.ShowCustomerContact();
}