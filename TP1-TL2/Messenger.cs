public class Messenger
{
    private int messengerId;
    private string messengerName;
    private string messengerAddress;
    private string messengerPhone;
    private List<Order> messengerOrders;

    public Messenger(int messengerId, string messengerName, string messengerAddress, string messengerPhone, List<Order> messengerOrders)
    {
        this.messengerId = messengerId;
        this.messengerName = messengerName;
        this.messengerAddress = messengerAddress;
        this.messengerPhone = messengerPhone;
        this.messengerOrders = messengerOrders;
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
}