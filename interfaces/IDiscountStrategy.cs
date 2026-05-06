namespace LAB3.Interfaces;

public interface IDiscountStrategy
{
  decimal ApplyDiscount(decimal totalPrice);
}