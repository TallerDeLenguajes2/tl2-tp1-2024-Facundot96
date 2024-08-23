public class Delivery
{
    private string deliveryName;
    private string deliveryPhone;
    private List<Messenger> messengers;

    public Delivery(string deliveryName, string deliveryPhone, List<Messenger> messengers)
    {
        this.deliveryName = deliveryName;
        this.deliveryPhone = deliveryPhone;
        this.messengers = messengers;
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
}