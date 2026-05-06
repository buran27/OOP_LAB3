using LAB3.Interfaces;
using LAB3.Models;

namespace LAB3.Notifications;

public class SmsNotificationService : INotificationService
{
    public void Send(Customer customer, string message)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));

        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentException("Сообщение не может быть пустым.");

        Console.WriteLine($"SMS отправлено на номер {customer.Phone}: {message}");
    }
}