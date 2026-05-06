using LAB3.Interfaces;

namespace LAB3.Discounts;

public class FixedDiscount : IDiscountStrategy
{
    private readonly decimal _discountAmount;

    public FixedDiscount(decimal discountAmount)
    {
        if (discountAmount < 0)
            throw new ArgumentException("Размер скидки не может быть отрицательным.");

        _discountAmount = discountAmount;
    }

    public decimal ApplyDiscount(decimal totalPrice)
    {
        if (totalPrice < 0)
            throw new ArgumentException("Сумма заказа не может быть отрицательной.");

        decimal result = totalPrice - _discountAmount;

        if (result < 0)
            return 0;

        return result;
    }
}