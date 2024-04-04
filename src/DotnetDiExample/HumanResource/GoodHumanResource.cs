namespace DotnetDiExample.HumanResource;

public sealed class GoodHumanResource : IHumanResource
{
    public bool IsEmployee() => true;

    public string MotivateEmployee() => "You are doing a great job!";
}
