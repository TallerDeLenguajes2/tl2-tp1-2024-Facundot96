public class Order
{
    
    private int orderId;
    private string reference;
    private Client client;
    private string status;
    
    public Order(int orderId, string reference, Client client, string status)
    {
        this.orderId = orderId;
        this.reference = reference;
        this.client = client;
        this.status = status;
    }

    public int OrderId
    {
        get => orderId;
        set => orderId = value;
    }

    public string Reference
    {
        get => reference;
        set => reference = value ?? throw new ArgumentNullException(nameof(value));
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
}