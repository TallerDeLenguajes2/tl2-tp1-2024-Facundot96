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

    public int OrderId => orderId;

    public string Reference => reference;

    public Client Client => client;

    public string Status => status;
}