public class Client
{
    private string name;
    private string address;
    private string phone;
    private string reference;

    public Client(string name, string address, string phone, string reference)
    {
        this.name = name;
        this.address = address;
        this.phone = phone;
        this.reference = reference;
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Address
    {
        get => address;
        set => address = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Phone
    {
        get => phone;
        set => phone = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Reference
    {
        get => reference;
        set => reference = value ?? throw new ArgumentNullException(nameof(value));
    }
}