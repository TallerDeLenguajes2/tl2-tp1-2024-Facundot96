public class Messenger
{
    private int messengerId;
    private string messengerName;
    private string messengerAddress;
    private string messengerPhone;
    private List<Order> messengerOrders;
    private int orderCount;

    

    public Messenger(int messengerId, string messengerName, string messengerAddress, string messengerPhone)
    {
        this.messengerId = messengerId;
        this.messengerName = messengerName;
        this.messengerAddress = messengerAddress;
        this.messengerPhone = messengerPhone;
        messengerOrders = new List<Order>();
        OrderCount = 0;
    }

    public Messenger()
    {
    }

    public int OrderCount
    {
        get => orderCount;
        set => orderCount = value;
    }

    public int MessengerId
    {
        get => messengerId;
        set => messengerId = value;
    }

    public string MessengerName
    {
        get => messengerName;
        set => messengerName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string MessengerAddress
    {
        get => messengerAddress;
        set => messengerAddress = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string MessengerPhone
    {
        get => messengerPhone;
        set => messengerPhone = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Order> MessengerOrders
    {
        get => messengerOrders;
        set => messengerOrders = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void Orders()
    {
        if (this.messengerOrders.Any())
        {
            Console.WriteLine($"\n------------------------");
            Console.WriteLine($"| Messenger Id: {this.messengerId} |");
        }

        foreach (Order o in this.messengerOrders)
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
        Console.WriteLine($"| Messenger Name: {this.messengerName}, Messenger Id: {this.messengerId} |");
        Console.WriteLine($"| Messenger Address: {this.messengerAddress} |");
        Console.WriteLine($"| Messenger Phone: {this.messengerPhone} |");
        Console.WriteLine($"| Order Count: {this.messengerOrders.Count} |");
        Console.WriteLine($"-----------------------");
    }

    public int JournalPayment()
    {
        return this.OrderCount * 500;
    }

    public void AssignOrder(Order order)
    {
        this.messengerOrders.Add(order);
    }

    public Order GetOrder(int orderId)
    {
        Order ord = new Order();

        foreach (Order o in this.messengerOrders)
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
        foreach (Order o in this.messengerOrders)
        {
            if (o.OrderId == orderId)
            {
                orderToRemove = o;
                break; // salir del bucle después de encontrar la orden
            }
        }

        if (orderToRemove != null)
        {
            messengerOrders.Remove(orderToRemove);
            Console.WriteLine("The order has been removed.");
        }
    }

    public void EndOrder(int orderId)
    {
        foreach (Order o in this.messengerOrders)
        {
            if (o.OrderId == orderId)
            {
                OrderCount++;
                messengerOrders.Remove(o);
                Console.WriteLine("The order was successfully finished.");
            }
        }
    }

}