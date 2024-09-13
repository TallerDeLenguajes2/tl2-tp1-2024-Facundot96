public class Client
{
    private string _name;
    private string _address;
    private string _phone;
    private string _reference;

    public Client(string name, string address, string phone, string reference)
    {
        this._name = name;
        this._address = address;
        this._phone = phone;
        this._reference = reference;
    }

    public Client()
    {
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Address
    {
        get => _address;
        set => _address = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Phone
    {
        get => _phone;
        set => _phone = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Reference
    {
        get => _reference;
        set => _reference = value ?? throw new ArgumentNullException(nameof(value));
    }

   /* public void ClientDetails()
    {
        Console.WriteLine($"Name: {_name}, Address: {_address}, Phone: {_phone}, Reference: {_reference}");
    }*/
    
    
}