using Test_NTT_Solution;

class Program
{
    static void Main(string[] args)
    {
        ParkingLot parkingLot = null;

        while (true)
        {
            string input = Console.ReadLine();
            string[] command = input.Split(' ');

            if (command.Length == 0)
            {
                Console.WriteLine("Invalid command");
                continue;
            }

            switch (command[0])
            {
                case "create_parking_lot":
                    if (command.Length < 2)
                    {
                        Console.WriteLine("Invalid command");
                        continue;
                    }

                    int totalSlots;
                    if (int.TryParse(command[1], out totalSlots))
                    {
                        parkingLot = new ParkingLot(totalSlots);
                        Console.WriteLine($"Created a parking lot with {totalSlots} slots");
                    }
                    else
                    {
                        Console.WriteLine("Invalid total slots");
                    }

                    break;

                case "park":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                    }
                    else if (command.Length >= 3)
                    {
                        string registrationNumber = command[1];
                        string color = command[2];
                        if (Enum.TryParse<EVehicle>(command[3], true, out EVehicle type))
                        {
                            parkingLot.ParkVehicle(registrationNumber, color, type);
                        }
                        else
                        {
                            Console.WriteLine("Invalid vehicle type");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }

                    break;


                case "leave":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                    }
                    else if (command.Length >= 1)
                    {
                        int slotNumber;
                        if (int.TryParse(command[1], out slotNumber))
                        {
                            parkingLot.Leave(slotNumber);
                        }
                        else
                        {
                            Console.WriteLine("Invalid slot number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }

                    break;

                case "status":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                    }
                    else
                    {
                        parkingLot.Status();
                    }

                    break;

                case "registration numbers for vehicles with color":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                    }
                    else if (command.Length >= 1)
                    {
                        string color = command[1];
                        var registrationNumbers = parkingLot.GetRegistrationNumbersByColor(color);
                        Console.WriteLine(string.Join(", ", registrationNumbers));
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }

                    break;

                case "slot numbers for vehicles with color":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                    }
                    else if (command.Length >= 1)
                    {
                        string color = command[1];
                        var slotNumbers = parkingLot.GetSlotNumbersByColor(color);
                        Console.WriteLine(string.Join(", ", slotNumbers));
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }

                    break;

                case "slot number for registration number":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                    }
                    else if (command.Length >= 1)
                    {
                        string registrationNumber = command[1];
                        int slotNumber = parkingLot.GetSlotNumberByRegistrationNumber(registrationNumber);
                        if (slotNumber != -1)
                        {
                            Console.WriteLine(slotNumber);
                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }

                    break;

                case "report":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                    }
                    else
                    {
                        Console.WriteLine("Report:");
                        Console.WriteLine($"Total occupied slots: {parkingLot.GetOccupiedSlotsCount()}");
                        Console.WriteLine($"Total available slots: {parkingLot.GetAvailableSlotsCount()}");
                        Console.WriteLine(
                            $"Total vehicles with odd registration numbers: {parkingLot.GetVehicleCountByOddRegistrationNumber()}");
                        Console.WriteLine(
                            $"Total vehicles with even registration numbers: {parkingLot.GetVehicleCountByEvenRegistrationNumber()}");
                        Console.WriteLine($"Total Mobil: {parkingLot.GetVehicleCountByType(EVehicle.Mobil)}");
                        Console.WriteLine($"Total Motor: {parkingLot.GetVehicleCountByType(EVehicle.Motor)}");
                    }

                    break;

                case "total mobil berdasarkan warna":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first");
                    }
                    else if (command.Length >= 1)
                    {
                        string color = command[1];
                        int mobilCountByColor = parkingLot.GetVehicleCountByColor(color);
                        Console.WriteLine($"Total Mobil vehicles with color {color}: {mobilCountByColor}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }

                    break;
                case "exit":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}