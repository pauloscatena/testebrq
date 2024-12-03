using TesteBrq.Interfaces.Entities;
using TesteBrq.Interfaces.Specifications;

namespace TesteBrq.Services.ClassificationServiceSpecifications;

public class ExpiredClassification: IDateReferrableSpecification
{
    private DateTime _referralDate;
    public bool IsSatisfiedBy(ITrade trade)
    {
        if (_referralDate.Equals(DateTime.MinValue))
        {
            throw new ArgumentException("Referral date not set");
        }

        return trade.NextPaymentDate.AddDays(30) < _referralDate;
    }

    public string Classification { get; } = "EXPIRED";

    public void SetReferralDate(DateTime date)
    {
        _referralDate = date;
    }
}