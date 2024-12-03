using System.Globalization;
using TesteBrq.Interfaces.Entities;

namespace TesteBrq.Entities;

public class Trade : ITrade
{
    public Trade(double value, string clientSector, DateTime nextPaymentDate)
    {
        Value = value;
        ClientSector = clientSector;
        NextPaymentDate = nextPaymentDate;
    }

    public double Value { get; }
    public string ClientSector { get; }
    public DateTime NextPaymentDate { get; }

    public static Trade FromInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Invalid trade format");
        }

        var splitted = input.Split(" ");
        return new Trade(double.Parse(splitted[0]),
            splitted[1],
            DateTime.Parse(splitted[2], CultureInfo.InvariantCulture));
    }

    public static implicit operator Trade(string input) => FromInput(input);

}