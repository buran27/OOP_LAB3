using LAB3.Interfaces;

namespace LAB3.Payments;

public class CardPaymentService : IPaymentService
{
    public void Pay(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Сумма оплаты не может быть отрицательной.");

        Console.WriteLine($"Оплата банковской картой на сумму {amount} руб. выполнена.");
    }
}