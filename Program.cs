using LAB3.Discounts;
using LAB3.Interfaces;
using LAB3.Models;
using LAB3.Notifications;
using LAB3.Payments;
using LAB3.Services;

namespace LAB3;

class Program
{
    static void Main()
    {
        try
        {
            Customer customer = new Customer(
                name: "Антон",
                email: "anton@example.com",
                phone: "+79730069812"
            );

            List<Product> products = new List<Product>
            {
                new Product("Ноутбук", 70000),
                new Product("Мышь", 2500),
                new Product("Клавиатура", 5000)
            };

            Order order = new Order(customer, products);

            Console.WriteLine("Вариант 1: Скидка 10%, оплата картой, уведомление по Email");
            Console.WriteLine();

            IDiscountStrategy percentDiscount = new PercentDiscount(10);
            IPaymentService cardPayment = new CardPaymentService();
            INotificationService emailNotification = new EmailNotificationService();
            IOrderPrinter orderPrinter = new ConsoleOrderPrinter();

            OrderService firstOrderService = new OrderService(
                percentDiscount,
                cardPayment,
                emailNotification,
                orderPrinter
            );

            firstOrderService.ProcessOrder(order);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Вариант 2: Без скидки, оплата наличными, уведомление по SMS");
            Console.WriteLine();

            IDiscountStrategy noDiscount = new NoDiscount();
            IPaymentService cashPayment = new CashPaymentService();
            INotificationService smsNotification = new SmsNotificationService();

            OrderService secondOrderService = new OrderService(
                noDiscount,
                cashPayment,
                smsNotification,
                orderPrinter
            );

            secondOrderService.ProcessOrder(order);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Вариант 3: Фиксированная скидка 5000 руб., оплата картой, уведомление по Email");
            Console.WriteLine();

            IDiscountStrategy fixedDiscount = new FixedDiscount(5000);

            OrderService thirdOrderService = new OrderService(
                fixedDiscount,
                cardPayment,
                emailNotification,
                orderPrinter
            );

            thirdOrderService.ProcessOrder(order);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}