using LAB3.Models;

namespace LAB3.Interfaces;

public interface IOrderPrinter
{
  void Print(Order order, decimal finalPrice);
}