
using TP1TL2;

Delivery delivery = LoadDeliveryCsvjson();


delivery.TakeOrder(1, "sanguche de milanesa", "In process", "Facundo", "Buenos Aires 662", "+5493875060018", "No anda el portero", 1);
delivery.TakeOrder(2, "Pizza Napolitana", "In process", "Julieta", "Buenos Aires 662", "+54938150974054", "No anda el portero", 2);
delivery.TakeOrder(3, "Cafe con medialunas", "Picked Up", "Facundo", "San Lorenzo 777", "+5493875060018", "Espera Afuera", 3);
delivery.TakeOrder(4, "Frappe", "Near Dropoff", "Facundo", "San Lorenzo 777", "+5493875060018", "Espera afuera", 1);
/*
delivery.ShowMessengerOrders(1);
delivery.ShowMessengerOrders(2);
delivery.ShowMessengerOrders(3);
*/
delivery.AssignMessengerToOrder(1, 2);
delivery.AssignMessengerToOrder(2, 3);
delivery.AssignMessengerToOrder(3, 1);
delivery.AssignMessengerToOrder(2, 4);
/*
delivery.ShowMessengerOrders(1);
delivery.ShowMessengerOrders(2);
delivery.ShowMessengerOrders(3);
*/
delivery.ReassignOrder(1,3,2);
/*
delivery.ShowMessengerOrders(1);
delivery.ShowMessengerOrders(2);
delivery.ShowMessengerOrders(3);
*/
delivery.EndOrder(1);
delivery.EndOrder(2);
delivery.PaymentByMessenger(3);
delivery.DailyReport();


Delivery LoadDeliveryCsvjson()
{
    Delivery delivery = new Delivery();
    Console.WriteLine("Load delivery data---------\nSELECT: \n 1 ) Load data from csv\n 2 ) Load data from json");
    int option = int.Parse(Console.ReadLine());

    while (option < 1 || option > 2)
    {
        Console.WriteLine("Select a valid option");
        option = int.Parse(Console.ReadLine());
    }

    if (option == 1)
    {
        LoaderCSV loaderCsv = new LoaderCSV();
        Console.WriteLine("Load delivery data from CSV");
        delivery = loaderCsv.LoadDelivery();
        delivery.ShowDeliveryDetails();
        
        Console.WriteLine("Load messengers from CSV");
        loaderCsv.LoadMessengers(delivery);
        delivery.ShowAllMessengers();
        
    }
    else
    {
        LoaderJSON loaderJSON = new LoaderJSON();
        Console.WriteLine("Load delivery data from JSON");
        delivery = loaderJSON.LoadDelivery();
        delivery.ShowDeliveryDetails();
        
        Console.WriteLine("Load messengers from JSON");
        
        loaderJSON.LoadMessengers(delivery);
        delivery.ShowAllMessengers();
    }

    return delivery;
}

