namespace PressApp.Dialogs
{
    public interface IMenu
    {
        Task Show();
        Task CreateEmployee();
        Task CreateContact();
        Task CreateCustomer();
        Task RoleDialogs();
        Task ViewAllContacts();
        Task ShowCustomerContact();
        Task ShowRoles();
    }
}