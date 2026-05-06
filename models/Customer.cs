namespace LAB3.Models;

public class Customer
{
  public string Name {get;}
  public string Email {get;}
  public string Phone {get;}

  public Customer(string name, string email, string phone)
  {
    if (string.IsNullOrWhiteSpace(name))
      throw new ArgumentException("Имя покупателя не может быть пустым.");

    if (string.IsNullOrWhiteSpace(email))
      throw new ArgumentException("Email покупателя не может быть пустым.");

    if (string.IsNullOrWhiteSpace(phone))
      throw new ArgumentException("Телефон покупателя не может быть пустым.");
      
    Name = name;
    Email = email;
    Phone = phone;
  }
}