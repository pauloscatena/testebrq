using TesteBrq.Interfaces.Entities;
using TesteBrq.Interfaces.Services;
using TesteBrq.Interfaces.Specifications;
using TesteBrq.Services.ClassificationServiceSpecifications;

namespace TesteBrq.Services;

public class ClassificationService: IClassificationService
{
    private readonly List<ISpecification> _specifications;

    public ClassificationService()
    {
        _specifications = new List<ISpecification>();

        // The order of the specifications defines its precedence
        _specifications.Add(new PepClassification());
        _specifications.Add(new ExpiredClassification());
        _specifications.Add(new HighRiskClassification());
        _specifications.Add(new MediumRiskClassification());
        
    }

    public IEnumerable<string> Run(ITradeClassifier tradeClassifier)
    {
        List<string> result = new();
        foreach (var trade in tradeClassifier.Trades)
        {
            string category = string.Empty;
            foreach (var classification in _specifications)
            {
                if (classification is IDateReferrableSpecification)
                {
                    ((IDateReferrableSpecification)classification).SetReferralDate(tradeClassifier.ReferenceDate);
                }

                if (classification.IsSatisfiedBy(trade))
                {
                    category = classification.Classification;
                    break;
                }
            }
            result.Add(category);
        }

        return result;
    }
}