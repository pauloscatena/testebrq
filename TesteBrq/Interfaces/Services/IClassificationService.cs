using TesteBrq.Interfaces.Entities;

namespace TesteBrq.Interfaces.Services;

public interface IClassificationService
{
    IEnumerable<string> Run(ITradeClassifier tradeClassifier);
}