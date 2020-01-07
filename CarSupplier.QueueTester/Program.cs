using CarSupplier.Application.Messages.CarManufacturer;
using CarSupplier.Application.Messages.CarManufacturer.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace CarSupplier.QueueTester
{
    class Program
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "watership_down", durable: true, exclusive: false, autoDelete: false, arguments: null);
                    channel.BasicQos(0, 20, false);

                    var basicProperties = channel.CreateBasicProperties();
                    basicProperties.Persistent = true;

                    Console.WriteLine("Select Car: [H]onda or [F]ord?");
                    var key = Console.ReadKey();

                    while (key.Key != ConsoleKey.Escape)
                    {
                        ICarSpecificationMessage carSupplierMessage = null;
                        switch (key.Key)
                        {
                            case ConsoleKey.H:
                                carSupplierMessage = new HondaCarSpecificationMessage();
                                break;
                            case ConsoleKey.F:
                                carSupplierMessage = new FordCarSpecificationMessage();
                                break;
                            default:
                                throw new NotSupportedException($"unexpected input received {key.Key} is an invalid option");
                        }

                        Console.WriteLine("How many doors?");
                        key = Console.ReadKey();
                        carSupplierMessage.NumberOfDoors = getFromKeyPress(key.Key);

                        Console.WriteLine("Engine type?");
                        carSupplierMessage.EngineType = Console.ReadLine();

                        Console.WriteLine("Wheel type?");
                        carSupplierMessage.WheelType = Console.ReadLine();

                        Console.WriteLine("Tyre type?");
                        carSupplierMessage.TyreType = Console.ReadLine();

                        Console.WriteLine("Paint type?");
                        carSupplierMessage.PaintType = Console.ReadLine();

                        Console.WriteLine("Colour?");
                        carSupplierMessage.PaintColour = Console.ReadLine();


                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(carSupplierMessage));

                        channel.BasicPublish(exchange: "", routingKey: "watership_down", basicProperties: basicProperties, body: body);

                        Console.WriteLine("[x] Sent {0}", carSupplierMessage.GetType().Name);

                        Console.WriteLine("Select Car: [H]onda or [F]ord?");
                        key = Console.ReadKey();
                    }
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static int getFromKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return 1;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return 2;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return 3;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return 4;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    return 5;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    return 6;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    return 7;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    return 8;
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    return 9;                    
                default:
                    return 0;
            }
        }
    }
}
