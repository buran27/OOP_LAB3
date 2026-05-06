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
                phone: "+79990000000"
            );

            List<Product> products = new List<Product>
            {
                new Product("Ноутбук", 70000),
                new Product("Мышь", 2500),
                new Product("Клавиатура", 5000)
            };

            Order order = new Order(customer, products);

            Console.WriteLine("СЦЕНАРИЙ 1: Скидка 10%, оплата картой, уведомление по Email");
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

            Console.WriteLine("СЦЕНАРИЙ 2: Без скидки, оплата наличными, уведомление по SMS");
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

            Console.WriteLine("СЦЕНАРИЙ 3: Фиксированная скидка 5000 руб., оплата картой, уведомление по Email");
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

            PrintSolidExplanation();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    private static void PrintSolidExplanation()
    {
        Console.WriteLine("=== Где в программе реализованы принципы SOLID ===");
        Console.WriteLine();

        Console.WriteLine("SRP — Single Responsibility Principle:");
        Console.WriteLine("Каждый класс выполняет одну задачу.");
        Console.WriteLine("Product, Customer и Order хранят данные предметной области.");
        Console.WriteLine("PercentDiscount, NoDiscount и FixedDiscount отвечают только за расчёт скидки.");
        Console.WriteLine("CardPaymentService и CashPaymentService отвечают только за оплату.");
        Console.WriteLine("EmailNotificationService и SmsNotificationService отвечают только за уведомления.");
        Console.WriteLine("OrderService отвечает только за сценарий оформления заказа.");
        Console.WriteLine();

        Console.WriteLine("OCP — Open/Closed Principle:");
        Console.WriteLine("Для добавления нового способа скидки, оплаты или уведомления не нужно изменять OrderService.");
        Console.WriteLine("Достаточно создать новый класс, реализующий нужный интерфейс.");
        Console.WriteLine("Например, FixedDiscount был добавлен как новая стратегия скидки.");
        Console.WriteLine();

        Console.WriteLine("LSP — Liskov Substitution Principle:");
        Console.WriteLine("OrderService работает с интерфейсами.");
        Console.WriteLine("CardPaymentService можно заменить на CashPaymentService.");
        Console.WriteLine("EmailNotificationService можно заменить на SmsNotificationService.");
        Console.WriteLine("Любая реализация интерфейса корректно работает вместо другой.");
        Console.WriteLine();

        Console.WriteLine("ISP — Interface Segregation Principle:");
        Console.WriteLine("Интерфейсы разделены по назначению.");
        Console.WriteLine("IDiscountStrategy отвечает только за скидку.");
        Console.WriteLine("IPaymentService отвечает только за оплату.");
        Console.WriteLine("INotificationService отвечает только за уведомления.");
        Console.WriteLine("IOrderPrinter отвечает только за вывод заказа.");
        Console.WriteLine();

        Console.WriteLine("DIP — Dependency Inversion Principle:");
        Console.WriteLine("OrderService зависит от абстракций, а не от конкретных классов.");
        Console.WriteLine("Все зависимости передаются через конструктор.");
        Console.WriteLine("Внутри OrderService не создаются CardPaymentService, EmailNotificationService или PercentDiscount через new.");
    }
}