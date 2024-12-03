using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using TesteBrq.Interfaces.Entities;

namespace TesteBrq.Entities;

public class TradeClassifier: ITradeClassifier
{
    private List<ITrade> _trades = new List<ITrade>();
    public TradeClassifier()
    {
        ReferenceDate = DateTime.Now.Date;
        _trades = new List<ITrade>();
    }

    public DateTime ReferenceDate { get; private set; }
    public int TradeCount => _trades.Count;
    public IEnumerable<ITrade> Trades => _trades.AsReadOnly().AsEnumerable();

    public void SetReferenceDate(DateTime referenceDate)
    {
        ReferenceDate = referenceDate;
    }
    public void SetReferenceDate(string referenceDate)
    {
        if (string.IsNullOrEmpty(referenceDate))
        {
            throw new ArgumentException("Invalid reference date");
        }

        var date = DateTime.Parse(referenceDate, CultureInfo.InvariantCulture);
        SetReferenceDate(date);
    }

    public void AddTrade(ITrade trade)
    {
        _trades.Add(trade);
    }

    public static ITradeClassifier FromFile(string fileName)
    {
        ITradeClassifier result = new TradeClassifier();

        var file = File.ReadLines(fileName, Encoding.UTF8).ToList();

        result.SetReferenceDate(file[0]);

        int.TryParse(file[1], out var count);

        for (int i = 0; i < count; i++)
        {
            Trade data = file[i + 2];
            result.AddTrade(data);
        }

        return result;
    }
}