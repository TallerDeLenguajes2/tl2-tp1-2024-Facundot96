

Delivery delivery = LoadDelivery();
delivery.ShowDeliveryDetails();

/*Messenger messenger1 = new Messenger(1, "Esclavo 1", "La Rioja 751", "+5493814658");
Messenger messenger2 = new Messenger(2, "Esclavo 2", "Jujuy 4000", "+549381848");
Messenger messenger3 = new Messenger(3, "Esclavo 3", "Roca 4000", "+54938189487");
Messenger messenger4 = new Messenger(4, "Esclavo 4", "Algún lugar", "+549381487875");

delivery.NewMessenger(messenger1);
delivery.NewMessenger(messenger2);
delivery.NewMessenger(messenger3);
delivery.NewMessenger(messenger4);
*/

LoadMessengers(delivery);

delivery.ShowAllMessengers();

delivery.TakeOrder(1, "sanguche de milanesa", "In process", "Facundo", "Buenos Aires 662", "+5493875060018", "No anda el portero", 1);
delivery.TakeOrder(2, "Pizza Napolitana", "In process", "Julieta", "Buenos Aires 662", "+54938150974054", "No anda el portero", 2);
delivery.TakeOrder(3, "Cafe con medialunas", "Picked Up", "Facundo", "San Lorenzo 777", "+5493875060018", "Espera Afuera", 3);
delivery.TakeOrder(4, "Frappe", "Near Dropoff", "Facundo", "San Lorenzo 777", "+5493875060018", "Espera afuera", 1);

delivery.ShowMessengersOrders();
delivery.ShowMessengerOrders(1);

delivery.ReassignOrder(1,4);
delivery.ShowMessengersOrders();

delivery.EndOrder(1);
delivery.PaymentByMessenger(4);

delivery.DailyReport();

delivery.RemoveMessenger(1);

delivery.ShowAllMessengers();

Delivery LoadDelivery()
{
    Console.WriteLine("Load delivery data---------");

    string filePath = "Deliverycsv.csv";
    
    Console.WriteLine($"Ruta del archivo: {filePath}");

    Delivery loadDelivery = new Delivery();

    try
    {
        string[] lines = System.IO.File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] fields = line.Split(',');

            string column = fields[0];
            string column2 = fields[1];

            loadDelivery = new Delivery(column, column2);
        }

    }
    catch (IOException e)
    {
        Console.WriteLine($"error: {e.Message}");
    }
    
    return loadDelivery;
}

void LoadMessengers(Delivery d)
{
    Console.WriteLine("Load messengers data---------");
    
    string filePath = "Messengerscsv.csv";

    try
    {
        string[] lines = System.IO.File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] fields = line.Split(',');

            string column = fields[0];
            string column2 = fields[1];
            string column3 = fields[2];
            string column4 = fields[3];

            Messenger messenger = new Messenger(int.Parse(column), column2, column3, column4);
            d.NewMessenger(messenger);
        }
    }
    catch (IOException e)
    {
        Console.WriteLine($"error: {e.Message}");
    }
}