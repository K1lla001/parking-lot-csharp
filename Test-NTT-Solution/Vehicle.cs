namespace Test_NTT_Solution;

public class Vehicle
{
    public string RegistrationNumber { get; set; }
    public string Color { get; set; }
    public EVehicle Type { get; set; }

    public Vehicle(string registrationNumber, string color, EVehicle type)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
        Type = type;
    }
}