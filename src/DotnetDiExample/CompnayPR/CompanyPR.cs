using DotnetDiExample.HumanResource;

namespace DotnetDiExample.CompnayPR;

public sealed class CompanyPR : ICompanyPR
{
    private readonly IHumanResource _humanResource;

    public CompanyPR(IHumanResource humanResource)
    {
        _humanResource = humanResource;
    }

    public string GetPr()
    {
        var motivateMessage = _humanResource.MotivateEmployee();
        return $"Our company is the best! {motivateMessage}";
    }
}
