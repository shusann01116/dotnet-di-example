namespace DotnetDiExample.HumanResource;

public sealed class BadHumanResource : IHumanResource
{
    public bool IsEmployee() => true;

    public string MotivateEmployee() => "You are need to work more over 45h per month.";
}
