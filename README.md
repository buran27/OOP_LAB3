SRP — Single Responsibility Principle: 

Каждый класс выполняет одну задачу. Product, Customer и Order хранят данные предметной области. PercentDiscount, NoDiscount и FixedDiscount отвечают только за расчёт скидки. 
CardPaymentService и CashPaymentService отвечают только за оплату. EmailNotificationService и SmsNotificationService отвечают только за уведомления. 
OrderService отвечает только за сценарий оформления заказа. 

OCP — Open/Closed Principle: 

Для добавления нового способа скидки, оплаты или уведомления не нужно изменять OrderService. Достаточно создать новый класс, реализующий нужный интерфейс. 
Например, FixedDiscount был добавлен как новая стратегия скидки. 

LSP — Liskov Substitution Principle: OrderService работает с интерфейсами. 

CardPaymentService можно заменить на CashPaymentService. EmailNotificationService можно заменить на SmsNotificationService. 
Любая реализация интерфейса корректно работает вместо другой. 

ISP — Interface Segregation Principle: 

Интерфейсы разделены по назначению. IDiscountStrategy отвечает только за скидку. IPaymentService отвечает только за оплату. INotificationService отвечает только за уведомления. 
IOrderPrinter отвечает только за вывод заказа. 

DIP — Dependency Inversion Principle: 

OrderService зависит от абстракций, а не от конкретных классов. Все зависимости передаются через конструктор. 
Внутри OrderService не создаются CardPaymentService, EmailNotificationService или PercentDiscount через new.
