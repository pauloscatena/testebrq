using TesteBrq.Interfaces.Entities;
using TesteBrq.Interfaces.Specifications;

namespace TesteBrq.Services.ClassificationServiceSpecifications;

public class PepClassification: ISpecification
{
    public bool IsSatisfiedBy(ITrade trade)
    {
        return trade.IsPoliticallyExposed;
    }

    public string Classification { get; } = "PEP";
}