using System;
namespace ObjectOrientedProgrammingBasics
{
    public class Car
    {
        private string _make;
        private int _yearOfProduction;
        private string _color;
        private int _petrolTankCapacity;
        private int _petrolUsagePer100Km;
        private int _kilometerCounter;
        private int _petrolLevel;
        private int _daylyKilometerCounter;

        public int DaylyKilometerCounter
        {
            set
            {
                if (value>999)
                { throw new ArgumentOutOfRangeException("DaylyKmCounter cannot be bigger then 999"); }
            }
            get
            {
                return Convert.ToInt32(_daylyKilometerCounter);
            }
        }
        public int KilometerCounter
        {
            set
            {
                if (value>999999)
                {
                    throw new ArgumentOutOfRangeException("KmCounter cannot be bigger than 999999");
                }
            }
            get
            {
                return Convert.ToInt32(_kilometerCounter);
            }
        }
        public string Make => _make;
        public int YearOfProduction => _yearOfProduction;
        public string Color => _color;
        public int PetrolTankCapacity => _petrolTankCapacity;
        public int PetrolUsagePer100Km => _petrolUsagePer100Km;
        public int PetrolLevel => _petrolLevel;

        public Car(string make, string color, int yearOfProduction, int petrolTankCapacity, int petrolUsagePer100km)
        {
            if (string.IsNullOrEmpty(make))
            { throw new ArgumentNullException(_make);            }
            if (string.IsNullOrEmpty(color))
            { throw new ArgumentNullException(_color);            }
            if (yearOfProduction<2000 || yearOfProduction>DateTime.Now.Year)
            { throw new ArgumentNullException("Year of production can be from 2000 till this year");  }
            if (petrolTankCapacity<1)
            { throw new ArgumentNullException("Petrol tank capacity has to be positive");            }
            if (petrolUsagePer100km<0)
            { throw new ArgumentNullException("Petrol usage has to be positive");            }
            _make = make;
            _color = color;
            _yearOfProduction = yearOfProduction;
            _petrolTankCapacity = petrolTankCapacity;
            _petrolUsagePer100Km = petrolUsagePer100km;
        }

    public void Tank(int litres)
    {
        if (litres < 0)
            throw new ArgumentException("Provide a positive value");

        if (_petrolLevel + litres > _petrolTankCapacity)
            _petrolLevel = _petrolTankCapacity;
        else
            _petrolLevel += litres;
    }

    public void Drive(int kilometers)
    {
        if (kilometers < 0.0)
                throw new ArgumentException("Kilometers have to be positive");

        var range = _petrolLevel * 100 / _petrolUsagePer100Km;
        if (kilometers > range)
        {
                _kilometerCounter += range;
                _daylyKilometerCounter += range;
                _petrolLevel = 0;
        }
        else
        {
                _kilometerCounter += kilometers;
                _daylyKilometerCounter += kilometers;
                _petrolLevel -= kilometers * PetrolUsagePer100Km / 100;
        }
    }

    public void Status ()
        {
            Console.WriteLine($"Your {_make} Color {_color} has {_petrolLevel} liters, kmC is {KilometerCounter}, dkmC is {DaylyKilometerCounter}");
        }

    public void ResetDaylyKilometers ()
        {
            _daylyKilometerCounter = 0.0;
        }

    public void ChangeTheColor (string color)
        {
            if (string.IsNullOrEmpty(color))
                throw new ArgumentNullException(_color);
            _color = color;
        }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Ford", "Red", 2019, 60, 6);

        Console.WriteLine($"{car1.Make} was produced in {car1.YearOfProduction}");
        car1.Tank(30);
        car1.Drive(250);

    }