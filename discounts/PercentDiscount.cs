using LAB3.Interfaces;

namespace LAB3.Discounts;

public class PercentDiscount : IDiscountStrategy
{
    private readonly decimal _percent;

    public PercentDiscount(decimal percent)
    {
        if (percent < 0 || percent > 100)
            throw new ArgumentException("Процент скидки должен быть от 0 до 100.");

        _percent = percent;
    }

    public decimal ApplyDiscount(decimal totalPrice)
    {
        if (totalPrice < 0)
            throw new ArgumentException("Сумма заказа не может быть отрицательной.");

        return totalPrice - totalPrice * _percent / 100;
    }
}