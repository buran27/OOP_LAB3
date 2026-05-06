namespace LAB3.Models;

public class Order
{
  public Customer Customer { get; }
  public List<Product> Products { get; }

  public Order(Customer customer, List<Product> products)
  {
    Customer = customer ?? throw new ArgumentNullException(nameof(customer));

    if (products == null || products.Count == 0)
      throw new ArgumentException("Заказ должен содержать хотя бы один товар.");

    Products = products;
}

  public decimal GetTotalPrice()
  {
    decimal total = 0;

    foreach (Product product in Products)
    {
      total += product.Price;
    }

    return total;
  }
}