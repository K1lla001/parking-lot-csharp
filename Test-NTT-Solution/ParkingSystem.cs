using Test_NTT_Solution;


public class ParkingLot
{
    private int totalSlots;
    private List<Vehicle> vehicles;

    public ParkingLot(int totalSlots)
    {
        this.totalSlots = totalSlots;
        this.vehicles = new List<Vehicle>(totalSlots);
    }

    public int TotalSlots
    {
        get { return totalSlots; }
    }

    public int OccupiedSlots
    {
        get { return vehicles.Count; }
    }

    public int AvailableSlots
    {
        get { return totalSlots - OccupiedSlots; }
    }

    public void ParkVehicle(string registrationNumber, string color, EVehicle type)
    {
        if (AvailableSlots > 0)
        {
            var vehicle = new Vehicle(registrationNumber, color, type);

            vehicles.Add(vehicle);
            Console.WriteLine($"Allocated slot number: {OccupiedSlots}");
        }
        else
        {
            Console.WriteLine("Sorry, parking lot is full");
        }
    }

    public void Leave(int slotNumber)
    {
        if (slotNumber > 0 && slotNumber <= OccupiedSlots)
        {
            vehicles.RemoveAt(slotNumber - 1);
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine("Invalid slot number");
        }
    }

    public void Status()
    {
        Console.WriteLine("Slot No. Type Registration No Colour");
        for (int i = 0; i < vehicles.Count; i++)
        {
            var vehicle = vehicles[i];
            Console.WriteLine($"{i + 1} {vehicle.Type} {vehicle.RegistrationNumber} {vehicle.Color}");
        }
    }

    public List<string> GetRegistrationNumbersByColor(string color)
    {
        return vehicles
            .Where(v => string.Equals(v.Color, color, StringComparison.OrdinalIgnoreCase))
            .Select(v => v.RegistrationNumber)
            .ToList();
    }

    public List<int> GetSlotNumbersByColor(string color)
    {
        return vehicles
            .Where(v => string.Equals(v.Color, color, StringComparison.OrdinalIgnoreCase))
            .Select((v, index) => index + 1)
            .ToList();
    }

    public int GetSlotNumberByRegistrationNumber(string registrationNumber)
    {
        var vehicle = vehicles.Find(v =>
            string.Equals(v.RegistrationNumber, registrationNumber, StringComparison.OrdinalIgnoreCase));

        if (vehicle != null)
        {
            return vehicles.IndexOf(vehicle) + 1;
        }
        else
        {
            return -1; // Not found
        }
    }
    
    public int GetOccupiedSlotsCount()
    {
        return vehicles.Count(v => v != null);
    }

    public int GetAvailableSlotsCount()
    {
        return totalSlots - GetOccupiedSlotsCount();
    }

    public int GetVehicleCountByOddRegistrationNumber()
    {
        return vehicles.Count(v => v != null && IsOddPlate(v.RegistrationNumber));
    }

    public int GetVehicleCountByEvenRegistrationNumber()
    {
        return vehicles.Count(v => v != null && !IsOddPlate(v.RegistrationNumber));
    }

    private bool IsOddPlate(string registrationNumber)
    {
        if (registrationNumber.Length >= 4)
        {
            string middleDigits = registrationNumber.Substring(2, 4);
            if (int.TryParse(middleDigits, out int middleNumber))
            {
                return middleNumber % 2 != 0;
            }
        }
    
        return false; 
    }


    public int GetVehicleCountByType(EVehicle type)
    {
        return vehicles.Count(v => v != null && v.Type == type);
    }

    public int GetVehicleCountByColor(string color)
    {
        return vehicles.Count(v => v != null && string.Equals(v.Color, color, StringComparison.OrdinalIgnoreCase));
    }
    
}