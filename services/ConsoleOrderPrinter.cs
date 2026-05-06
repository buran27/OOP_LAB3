using LAB3.Interfaces;
using LAB3.Models;

namespace LAB3.Services;

public class ConsoleOrderPrinter : IOrderPrinter
{
    public void Print(Order order, decimal finalPrice)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        Console.WriteLine("=== Информация о заказе ===");
        Console.WriteLine($"Покупатель: {order.Customer.Name}");

        Console.WriteLine("Товары:");

        foreach (Product product in order.Products)
        {
            Console.WriteLine($"- {product.Name}: {product.Price} руб.");
        }

        Console.WriteLine($"Сумма без скидки: {order.GetTotalPrice()} руб.");
        Console.WriteLine($"Итоговая сумма: {finalPrice} руб.");
    }
}