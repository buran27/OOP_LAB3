using LAB3.Models;

namespace LAB3.Interfaces;

public interface INotificationService
{
  void Send(Customer customer, string message);
}