namespace Business.Models;


public class OrderUpdateForm()
{
    public int Id { get; set; }

    public string OrderName { get; set; } = null!;

    public decimal Price { get; set; }
}
