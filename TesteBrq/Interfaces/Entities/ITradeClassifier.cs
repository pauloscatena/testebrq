namespace TesteBrq.Interfaces.Entities;

public interface ITradeClassifier
{
    DateTime ReferenceDate { get; }
    int TradeCount { get; }
    IEnumerable<ITrade> Trades { get; }

    void SetReferenceDate(DateTime referenceDate);
    void SetReferenceDate(string referenceDate);
    void AddTrade(ITrade trade);
}