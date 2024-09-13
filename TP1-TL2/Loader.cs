namespace TP1TL2;
using System.Text.Json;

public abstract class Loader
{
    protected Loader()
    {
    }
    
    public abstract Delivery LoadDelivery();
    public abstract void LoadMessengers(Delivery delivery);
}

public class LoaderCSV : Loader
{
    public LoaderCSV() : base()
    {
        
    }

    public override Delivery LoadDelivery()
    {
        string filepath = "Deliverycsv.csv";
        Delivery delivery = new Delivery();

        try
        {
            string[] lines = File.ReadAllLines(filepath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                
                string column1 = values[0];
                string column2 = values[1];
                
                delivery = new Delivery(column1, column2);
            }
        }
        catch(IOException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }


        return delivery;
    }

    public override void LoadMessengers(Delivery delivery)
    {
        string filepath = "Messengerscsv.csv";

        try
        {
            string[] lines = File.ReadAllLines(filepath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                
                string column1 = values[0];
                string column2 = values[1];
                string column3 = values[2];
                string column4 = values[3];
                
                Messenger messenger = new Messenger(int.Parse(column1), column2, column3, column4);
                delivery.NewMessenger(messenger);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
    
}

public class LoaderJSON : Loader
{
    public LoaderJSON() : base()
    {
        
    }
    
    public override Delivery LoadDelivery()
    {
        string filepath = "Deliveryjson.json";
        Delivery delivery = new Delivery();  

        try
        {
            if (File.Exists(filepath))  
            {
                var json = File.ReadAllText(filepath);
                delivery = JsonSerializer.Deserialize<Delivery>(json);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error : {e.Message}");
        }

        
        return delivery;
    }

    public override void LoadMessengers(Delivery delivery)
    {
        if (delivery == null)
        {
            Console.WriteLine("Error");
            return;
        }

        string filepath = "messengersjson.json";

        try
        {
            
            if (!File.Exists(filepath))
            {
                Console.WriteLine($"'{filepath}' not found");
                return;
            }

            
            string json = File.ReadAllText(filepath);

            
            List<Messenger> messengers = JsonSerializer.Deserialize<List<Messenger>>(json);

            if (messengers == null || messengers.Count == 0)
            {
                Console.WriteLine("Error: messengers not found.");
                return;
            }

           
            foreach (Messenger messenger in messengers)
            {
                delivery.NewMessenger(messenger);
            }

            Console.WriteLine($"messengers loaded");
        }
        
        catch (IOException e)
        {
            Console.WriteLine($"Error : {e.Message}");
        }
    }
}