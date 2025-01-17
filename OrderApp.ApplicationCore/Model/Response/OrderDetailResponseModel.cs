namespace OrderApp.ApplicationCore.Model.Response;

public class OrderDetailResponseModel
{
    public int OrderDetailId { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
}