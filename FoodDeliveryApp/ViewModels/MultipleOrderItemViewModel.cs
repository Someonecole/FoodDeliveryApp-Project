namespace FoodDeliveryApp.ViewModels
{
    public class MultipleItemOrderViewModel
    {
        public List<OrderItemViewModel> Items { get; set; }
    }
    public class OrderItemViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public int Quantity { get; set; }
    }
}
