using LAB3.Interfaces;

namespace LAB3.Payments;

public class CashPaymentService : IPaymentService
{
    public void Pay(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Сумма оплаты не может быть отрицательной.");

        Console.WriteLine($"Оплата наличными на сумму {amount} руб. выполнена.");
    }
}