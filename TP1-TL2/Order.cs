public class Order
{
    
    private int orderId;
    private string detail;
    private Client client;
    private string status;
    
    public Order(int orderId, string detail, string status, string name, string address, string phone, string reference)
    {
        this.orderId = orderId;
        this.detail = detail;
        this.client = new Client(name, address, phone, reference);
        this.status = status;
    }

    public Order()
    {
    }

    public int OrderId
    {
        get => orderId;
        set => orderId = value;
    }

    public string Reference
    {
        get => detail;
        set => detail = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Client Client
    {
        get => client;
        set => client = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Status
    {
        get => status;
        set => status = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void OrderDetails()
    {
        Console.WriteLine($"\nOrder nº: {this.orderId}");
        Console.WriteLine($"\nReference: {this.detail}");
        Console.WriteLine($"\nStatus: {this.status}");
        Console.WriteLine($"\nClient name: {this.client.Name}");
    }

    public void ViewOrderAdress()
    {
        Console.WriteLine($"Client address: {this.client.Address}");
        Console.WriteLine(this.client.Reference);
    }

    public void ViewClientDetails()
    {
        Console.WriteLine("Client Details:");
        this.client.ClientDetails();
    }
    
}