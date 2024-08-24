public class Delivery
{
    private string deliveryName;
    private string deliveryPhone;
    private List<Messenger> messengers;

    public Delivery(string deliveryName, string deliveryPhone)
    {
        this.deliveryName = deliveryName;
        this.deliveryPhone = deliveryPhone;
        messengers = new List<Messenger>();
    }

    public Delivery()
    {
    }

    public string DeliveryName
    {
        get => deliveryName;
        set => deliveryName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DeliveryPhone
    {
        get => deliveryPhone;
        set => deliveryPhone = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Messenger> Messengers
    {
        get => messengers;
        set => messengers = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void ShowDeliveryDetails()
    {
        Console.WriteLine($"\nName: {deliveryName}\nPhone number: {deliveryPhone}");
    }

    public void ShowAllMessengers()
    {
        foreach (Messenger m in messengers)
        {
            m.ShowMessengerDetails();
        }
    }

    public void EndOrder(int orderId)
    {
        // Buscar la orden y el mensajero correspondiente
        foreach (Messenger messenger in messengers)
        {
            Order orderToEnd = messenger.MessengerOrders.FirstOrDefault(order => order.OrderId == orderId);

            if (orderToEnd != null)
            {
                // Incrementar el orderCount del mensajero
                messenger.OrderCount += 1;

                // Eliminar la orden de la lista de órdenes del mensajero
                messenger.MessengerOrders.Remove(orderToEnd);

                Console.WriteLine($"Order {orderId} ended successfully. Messenger {messenger.MessengerId} now has {messenger.OrderCount} completed orders.");
                return;
            }
        }

        // Si no se encuentra la orden
        Console.WriteLine($"Order {orderId} not found.");
    }

    public void PaymentByMessenger(int messengerId)
    {
        foreach (Messenger m in messengers)
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

        foreach (Messenger m in messengers)
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine($"Messenger ID: {m.MessengerId}");
            Console.WriteLine($"Journal Payment: {m.JournalPayment()}");
            Console.WriteLine($"Orders completed: {m.OrderCount}");
            sum = sum + m.JournalPayment();
        }
        
        Console.WriteLine($"\nTotal profit: {sum}");
    }

    public void ShowMessengersOrders()
    {
        foreach (Messenger m in messengers)
        {
            m.Orders();
        }
    }

    public void ShowMessengerOrders(int messengerId)
    {
        foreach (Messenger m in messengers)
        {
            if (m.MessengerId == messengerId)
            {
                m.Orders();
            }
        }
    }

    public void TakeOrder(int orderNum, string detail, string status, string name, string address, string phone,
        string reference, int messengerId)
    {
        Order order = new Order(orderNum, detail, status, name, address, phone, reference);

        foreach (Messenger m in messengers)
        {
            if (m.MessengerId == messengerId)
            {
                m.AssignOrder(order);
            }
        }
    }

    
    public void ReassignOrder(int orderId, int newMessengerId)
    {
        // Encontrar la orden y el mensajero actual
        Order orderToReassign = null;
        Messenger currentMessenger = null;

        foreach (Messenger messenger in messengers)
        {
            foreach (Order order in messenger.MessengerOrders)
            {
                if (order.OrderId == orderId)
                {
                    orderToReassign = order;
                    currentMessenger = messenger;
                    break;
                }
            }
        
            // Si encontramos la orden, no necesitamos seguir buscando
            if (orderToReassign != null)
            {
                break;
            }
        }

        // Validar que encontramos la orden
        if (orderToReassign == null || currentMessenger == null)
        {
            Console.WriteLine("Order or messenger not found.");
            return;
        }

        // Eliminar la orden del mensajero actual
        currentMessenger.RemoveOrder(orderToReassign.OrderId);

        // Encontrar el nuevo mensajero y asignar la orden
        Messenger newMessenger = messengers.FirstOrDefault(m => m.MessengerId == newMessengerId);

        if (newMessenger != null)
        {
            newMessenger.AssignOrder(orderToReassign);
            Console.WriteLine("Order reassigned successfully.");
        }
        else
        {
            // Si no se encuentra el nuevo mensajero, devolver la orden al mensajero original
            currentMessenger.AssignOrder(orderToReassign);
            Console.WriteLine("New messenger not found. Order reassigned to the original messenger.");
        }
    }

    public void NewMessenger(Messenger newMessenger)
    {
        messengers.Add(newMessenger);
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
}