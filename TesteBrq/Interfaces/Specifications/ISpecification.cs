using TesteBrq.Interfaces.Entities;

namespace TesteBrq.Interfaces.Specifications;

public interface ISpecification
{
    bool IsSatisfiedBy(ITrade trade);
    string Classification { get; }
}