using LAB3.Interfaces;

namespace LAB3.Discounts;

public class NoDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal totalPrice)
    {
        if (totalPrice < 0)
            throw new ArgumentException("Сумма заказа не может быть отрицательной.");

        return totalPrice;
    }
}