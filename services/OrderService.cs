using LAB3.Interfaces;
using LAB3.Models;

namespace LAB3.Services;

public class OrderService
{
    private readonly IDiscountStrategy _discountStrategy;
    private readonly IPaymentService _paymentService;
    private readonly INotificationService _notificationService;
    private readonly IOrderPrinter _orderPrinter;

    public OrderService(
        IDiscountStrategy discountStrategy,
        IPaymentService paymentService,
        INotificationService notificationService,
        IOrderPrinter orderPrinter)
    {
        _discountStrategy = discountStrategy 
            ?? throw new ArgumentNullException(nameof(discountStrategy));

        _paymentService = paymentService 
            ?? throw new ArgumentNullException(nameof(paymentService));

        _notificationService = notificationService 
            ?? throw new ArgumentNullException(nameof(notificationService));

        _orderPrinter = orderPrinter 
            ?? throw new ArgumentNullException(nameof(orderPrinter));
    }

    public void ProcessOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        decimal totalPrice = order.GetTotalPrice();
        decimal finalPrice = _discountStrategy.ApplyDiscount(totalPrice);

        _orderPrinter.Print(order, finalPrice);

        _paymentService.Pay(finalPrice);

        _notificationService.Send(
            order.Customer,
            $"Ваш заказ успешно оформлен. Итоговая сумма: {finalPrice} руб."
        );
    }
}