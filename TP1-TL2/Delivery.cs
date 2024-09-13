

public class Delivery
{
    private string _deliveryName;
    private string _deliveryPhone;
    private List<Messenger> _messengers;
    private List<Order> _orders;

    public Delivery(string deliveryName, string deliveryPhone)
    {
        this._deliveryName = deliveryName;
        this._deliveryPhone = deliveryPhone;
        _messengers = new List<Messenger>();
        _orders = new List<Order>();
    }

    public Delivery()
    {
        _messengers = new List<Messenger>();
        _orders = new List<Order>();
    }

    public string DeliveryName
    {
        get => _deliveryName;
        set => _deliveryName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DeliveryPhone
    {
        get => _deliveryPhone;
        set => _deliveryPhone = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Messenger> Messengers
    {
        get => _messengers;
        set => _messengers = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void ShowDeliveryDetails()
    {
        Console.WriteLine($"\nName: {_deliveryName}\nPhone number: {_deliveryPhone}");
    }

    public List<Messenger> ShowAllMessengers()
    {
        /*foreach (Messenger m in _messengers)
        {
            m.ShowMessengerDetails();
        }*/
        return this._messengers;
    }
    
    public void TakeOrder(int orderNum, string detail, string status, string name, string address, string phone,
        string reference, int messengerId)
    {
        Order order = new Order(orderNum, detail, status, name, address, phone, reference);

        _orders.Add(order);
    }

    /*public void ShowAllOrders()
    {
        foreach (Order order in _orders)
        {
            Console.WriteLine("----------------------------");
            order.OrderDetails();
        }
    }*/

    public Order ReturnOrder(int orderNum)
    {
        Order order = new Order();
        foreach (Order o in _orders)
        {
            if (o.OrderId == orderNum)
            {
                order = o;
            }
        }

        return order;
    }
    
    
    public void PaymentByMessenger(int messengerId)
    {
        foreach (Messenger m in _messengers)
        {
            if (m.MessengerId == messengerId)
            {
                Console.WriteLine("Messenger Id: "+ messengerId);
                Console.WriteLine("\nPayment per day " + m.JournalPayment());
            }
        }
    }

    public void DailyReport()
    {
        int sum = 0;

        foreach (Messenger m in _messengers)
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine($"Messenger ID: {m.MessengerId}");
            Console.WriteLine($"Journal Payment: {m.JournalPayment()}");
            Console.WriteLine($"Orders completed: {m.OrderCount}");
            sum = sum + m.JournalPayment();
        }
        
        Console.WriteLine($"\nTotal profit: {sum}");
    }
/*
    public void ShowMessengersOrders()
    {
        foreach (Messenger m in _messengers)
        {
            m.Orders();
        }
    }
*/
    /*public void ShowMessengerOrders(int messengerId)
    {
        int flag = 0;
        
        Console.WriteLine("\n---------------------");
        Console.WriteLine($"\nMessenger ID: {messengerId}");

        foreach (Order o in _orders)
        {
            if (o.getMessengerId() == messengerId)
            {
                o.OrderDetails();
                flag = 1;
            }
        }

        if (flag == 0)
        {
            Console.WriteLine("\n------------No orders found------------");
        }
        
    }*/

    public void AssignMessengerToOrder(int orderNum, int messengerId)
    {
        foreach (Order o in _orders)
        {
            if (o.OrderId == orderNum)
            {
                foreach (Messenger m in _messengers)
                {
                    if (m.MessengerId == messengerId)
                    {
                        o.AssingMessenger(m);
                        Console.WriteLine($"\nOrder Nº{orderNum} Assigned To Messenger: {messengerId}");
                    }
                }
            }
        }
    }
    
    public void ReassignOrder(int orderId, int messengerId, int newMessengerId)
    {
        foreach (Order o in _orders)
        {
            if (o.getMessengerId()==messengerId)
            {
                foreach (Messenger m in _messengers)
                {
                    if (m.MessengerId == newMessengerId)
                    {
                        o.AssingMessenger(m);
                    }
                }
            }
        }
        Console.WriteLine($"\n Order Nº{orderId} Reassigned To Messenger: {newMessengerId}");
    }

    public void NewMessenger(Messenger newMessenger)
    {
        _messengers.Add(newMessenger);
    }

    public void RemoveMessenger(int messengerId)
    {
        
        // Buscar el mensajero por su ID en la lista de mensajeros
        Messenger messengerToRemove = Messengers.FirstOrDefault(m => m.MessengerId == messengerId);

        if (messengerToRemove != null)
        {
            // Si se encuentra, se elimina de la lista
            Messengers.Remove(messengerToRemove);
            Console.WriteLine($"Messenger Nº {messengerId} has been removed.");
        }
        else
        {
            Console.WriteLine($"Messenger Nº {messengerId} not found.");
        }
    }
    public void EndOrder(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
    
        if (order != null)
        {
            
            var messenger = _messengers.FirstOrDefault(m => m.MessengerId == order.getMessengerId());

            
            messenger?.IncreaseOrderCount();

            
            _orders.Remove(order);

            
            Console.WriteLine($"\nOrder Completed: {orderId} has been received.");
        }
        else
        {
            Console.WriteLine($"\nOrder not found: {orderId}");
        }
    }

    public void DeleteOrderNotSent(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.OrderId == orderId);

        if (order != null)
        {
            // Eliminar el pedido
            _orders.Remove(order);
        
            // Confirmación de eliminación
            Console.WriteLine("\nOrder removed from list.");
        }
        else
        {
            // En caso de que no exista el pedido
            Console.WriteLine("\nOrder not found.");
        }
    }

}

