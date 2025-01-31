using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PressApp.Dialogs;


var serviceCollection = new ServiceCollection();

serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ECutbildningen\Databaslagring\Assignment\Localdb\Data\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));

serviceCollection.AddScoped<IMenu, Menu>();

serviceCollection.AddScoped<IContactRepository, ContactRepository>();
serviceCollection.AddScoped<ICustomertRepository, CustomerRepository>();
serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();
serviceCollection.AddScoped<IRoleRepository, RoleRepository>();



serviceCollection.AddScoped<IContactService, ContactService>();
serviceCollection.AddScoped<ICustomerService, CustomerService>();
serviceCollection.AddScoped<IEmployeesService, EmployeesService>();
serviceCollection.AddScoped<IProjectService, ProjectService>();  
serviceCollection.AddScoped<IOrderService, OrderService>();
serviceCollection.AddScoped<IRoleService, RoleService>();




var serviceProvider = serviceCollection.BuildServiceProvider();
var menu = serviceProvider.GetRequiredService<IMenu>();

while (true)
{
    await menu.Show();
}