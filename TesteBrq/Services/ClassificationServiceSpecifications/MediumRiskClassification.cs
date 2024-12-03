using TesteBrq.Interfaces.Entities;
using TesteBrq.Interfaces.Specifications;

namespace TesteBrq.Services.ClassificationServiceSpecifications;

public class MediumRiskClassification: ISpecification
{
    private const int __REFERENCE_VALUE = 1_000_000;
    private const string __SECTOR = "public";

    public bool IsSatisfiedBy(ITrade trade)
    {
        if (string.IsNullOrEmpty(trade.ClientSector))
        {
            throw new ArgumentException("Client Sector not set");
        }

        return trade.Value > __REFERENCE_VALUE && trade.ClientSector.ToLower().Equals(__SECTOR);
    }

    public string Classification { get; } = "MEDIUMRISK";
}