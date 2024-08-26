public class Order
{
    
    private int _orderId;
    private string _detail;
    private Client _client;
    private string _status;
    
    public Order(int orderId, string detail, string status, string name, string address, string phone, string reference)
    {
        this._orderId = orderId;
        this._detail = detail;
        this._client = new Client(name, address, phone, reference);
        this._status = status;
    }

    public Order()
    {
    }

    public int OrderId
    {
        get => _orderId;
        set => _orderId = value;
    }

    public string Reference
    {
        get => _detail;
        set => _detail = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Client Client
    {
        get => _client;
        set => _client = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Status
    {
        get => _status;
        set => _status = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void OrderDetails()
    {
        Console.WriteLine($"\nOrder nº: {this._orderId}");
        Console.WriteLine($"\nReference: {this._detail}");
        Console.WriteLine($"\nStatus: {this._status}");
        Console.WriteLine($"\nClient name: {this._client.Name}");
    }

    public void ViewOrderAdress()
    {
        Console.WriteLine($"Client address: {this._client.Address}");
        Console.WriteLine(this._client.Reference);
    }

    public void ViewClientDetails()
    {
        Console.WriteLine("Client Details:");
        this._client.ClientDetails();
    }
    
}