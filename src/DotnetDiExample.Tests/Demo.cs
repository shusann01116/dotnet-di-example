using DotnetDiExample.CompnayPR;
using DotnetDiExample.HumanResource;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotnetDiExample.Tests;

public class Demo
{
    [Fact]
    public void BadHumanResource_PR()
    {
        var badHumanResource = new BadHumanResource();
        var companyPR = new CompanyPR(badHumanResource);
        Assert.Equal(
            "Our company is the best! You are need to work more over 45h per month.",
            companyPR.GetPr()
        );
    }

    [Fact]
    public void GoodHumanResource_PR()
    {
        var goodHumanResource = new GoodHumanResource();
        var companyPR = new CompanyPR(goodHumanResource);
        Assert.Equal("Our company is the best! You are doing a great job!", companyPR.GetPr());
    }

    /// <summary>
    /// Microsoft.Extensions.Hosting を用いて、DIコンテナを利用する<br/>
    /// これによって、サービスクラスはコンストラクタに欲しいサービスを要求するだけで、<br/>
    /// そのサービスを自動的に受け取ることができる
    /// </summary>
    [Fact]
    public void HostedService_PR()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        // DIコンテナにサービスを登録している
        // ここでは IHumanResource に GoodHumanResource を登録している
        builder.Services.AddTransient<IHumanResource, GoodHumanResource>();
        // ここでは ICompanyPR に CompanyPR を登録している
        builder.Services.AddTransient<ICompanyPR, CompanyPR>();
        using IHost host = builder.Build();

        var result = SomeEndpoint(host.Services);
        Assert.Equal("Our company is the best! You are doing a great job!", result);
    }

    // ASP.NET の API サービスの簡易的なイメージ
    // このようにして、DIコンテナを利用することで、サービスクラスに必要なサービスを自動的に受け取ることができる
    static string SomeEndpoint(IServiceProvider serviceProvider)
    {
        // ここで ICompanyPR を要求しているが、DIコンテナに CompanyPR が登録されているため、自動的に CompanyPR が受け取れる
        var companyPR = serviceProvider.GetRequiredService<ICompanyPR>();
        return companyPR.GetPr();
    }
}
