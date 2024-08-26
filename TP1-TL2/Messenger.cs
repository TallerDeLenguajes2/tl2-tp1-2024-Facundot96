public class Messenger
{
    private int _messengerId;
    private string _messengerName;
    private string _messengerAddress;
    private string _messengerPhone;
    private List<Order> _messengerOrders;
    private int _orderCount;

    

    public Messenger(int messengerId, string messengerName, string messengerAddress, string messengerPhone)
    {
        this._messengerId = messengerId;
        this._messengerName = messengerName;
        this._messengerAddress = messengerAddress;
        this._messengerPhone = messengerPhone;
        _messengerOrders = new List<Order>();
        OrderCount = 0;
    }

    public Messenger()
    {
    }

    public int OrderCount
    {
        get => _orderCount;
        set => _orderCount = value;
    }

    public int MessengerId
    {
        get => _messengerId;
        set => _messengerId = value;
    }

    public string MessengerName
    {
        get => _messengerName;
        set => _messengerName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string MessengerAddress
    {
        get => _messengerAddress;
        set => _messengerAddress = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string MessengerPhone
    {
        get => _messengerPhone;
        set => _messengerPhone = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Order> MessengerOrders
    {
        get => _messengerOrders;
        set => _messengerOrders = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Orders()
    {
        if (this._messengerOrders.Any())
        {
            Console.WriteLine($"\n------------------------");
            Console.WriteLine($"| Messenger Id: {this._messengerId} |");
        }

        foreach (Order o in this._messengerOrders)
        {
            if (o != null)
            {
                o.OrderDetails();
            }
            else
            {
                Console.WriteLine("The Messenger has not been ordered yet.");
            }
        }
    }

    public void ShowMessengerDetails()
    {
        Console.WriteLine($"\n-----------------------");
        Console.WriteLine($"| Messenger Name: {this._messengerName}, Messenger Id: {this._messengerId} |");
        Console.WriteLine($"| Messenger Address: {this._messengerAddress} |");
        Console.WriteLine($"| Messenger Phone: {this._messengerPhone} |");
        Console.WriteLine($"| Order Count: {this._messengerOrders.Count} |");
        Console.WriteLine($"-----------------------");
    }

    public int JournalPayment()
    {
        return this.OrderCount * 500;
    }

    public void AssignOrder(Order order)
    {
        this._messengerOrders.Add(order);
    }

    public Order GetOrder(int orderId)
    {
        Order ord = new Order();

        foreach (Order o in this._messengerOrders)
        {
            if (o.OrderId == orderId)
            {
                ord = o;
            }
        }

        return ord;
    }

    public void RemoveOrder(int orderId)
    {
        Order orderToRemove = null;
        foreach (Order o in this._messengerOrders)
        {
            if (o.OrderId == orderId)
            {
                orderToRemove = o;
                break; // salir del bucle después de encontrar la orden
            }
        }

        if (orderToRemove != null)
        {
            _messengerOrders.Remove(orderToRemove);
            Console.WriteLine("The order has been removed.");
        }
    }

    public void EndOrder(int orderId)
    {
        foreach (Order o in this._messengerOrders)
        {
            if (o.OrderId == orderId)
            {
                OrderCount++;
                _messengerOrders.Remove(o);
                Console.WriteLine("The order was successfully finished.");
            }
        }
    }

}