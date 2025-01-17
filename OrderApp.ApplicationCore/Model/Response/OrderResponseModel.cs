namespace OrderApp.ApplicationCore.Model.Response;

public class OrderResponseModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateOnly OrderDate { get; set; }
    public string CustomerName { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentName { get; set; }
    public string ShippingAddress { get; set; }
    public string ShippingMethod { get; set; }
    public decimal BillingAmount { get; set; }
    public string OrderStatus { get; set; }
}