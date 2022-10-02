//V11
namespace Lab3
{
    //Task 1
    class Point
    {
        protected int x, y;
        protected int c;
        public (int X, int Y) Coordinates
        {
            get
            {
                return (x, y);
            }
            set
            {
                x = value.X;
                y = value.Y;
            }
        }
        public int Color
        {
            get
            {
                return c;
            }
        }

        public Point() : this(0, 0) { }

        public Point(int x, int y) : this(x, y, 0) { }

        public Point(int x, int y, int c)
        {
            this.x = x;
            this.y = y;
            this.c = c;
        }

        public void PrintCoordinates() => Console.WriteLine($"({x}:{y})");
        public double GetLengthFromOrigin() => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        public void SetPointOnVector(int x1, int y1)
        {
            Coordinates = (x1 - x, y1 - y);
        }

    }

    //Task 2
    abstract class Transport
    {
        protected Transport(double maxVelocity)
        {
            MaxVelocity = maxVelocity;
        }

        public double MaxVelocity { get; init; }
        public abstract void Show();
    }
    class Car : Transport
    {
        public Car(double maxVelocity, double fuelConsumption, string fuelType) : base(maxVelocity)
        {
            FuelConsumption = fuelConsumption;
            FuelType = fuelType;
        }

        public double FuelConsumption { get; init; }
        public string FuelType { get; init; }
        public override void Show()
        {
            Console.WriteLine("Car:");
            Console.WriteLine($"Fuel consumption: {FuelConsumption} (l)");
            Console.WriteLine($"Fuel type: {FuelType}");
            Console.WriteLine($"Max velocity {MaxVelocity} (km/h)");
        }
    }
    class Train : Transport
    {
        public int RailwayCarriageCount { get; init; }
        public Train(double maxVelocity, int railwayCarriageCount) : base(maxVelocity)
        {
            RailwayCarriageCount = railwayCarriageCount;
        }

        public override void Show()
        {
            Console.WriteLine("Train:");
            Console.WriteLine($"Railway carriage count: {RailwayCarriageCount}");
            Console.WriteLine($"Max velocity {MaxVelocity} (km/h)");
        }
    }
    class Express : Train
    {
        public Express(double maxVelocity, int railwayCarriageCount) : base(maxVelocity, railwayCarriageCount)
        {
        }
        public override void Show()
        {
            Console.WriteLine("Express:");
            Console.WriteLine($"Railway carriage count: {RailwayCarriageCount}");
            Console.WriteLine($"Max velocity {MaxVelocity} (km/h)");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(1, 1);
            Console.WriteLine($"Coordinates by property: {point.Coordinates}");
            Console.Write("Coordinates by method: ");
            point.PrintCoordinates();
            Console.WriteLine($"Color: {point.Color}");
            Console.WriteLine($"Length from origin: {point.GetLengthFromOrigin()}");
            Console.WriteLine();
            List<Transport> transports = new List<Transport>();
            transports.Add(new Car(170, 10.5, "Gas"));
            transports.Add(new Train(90, 5));
            transports.Add(new Express(150, 10));
            foreach (var transport in transports)
            {
                transport.Show();
            }
        }
    }
}