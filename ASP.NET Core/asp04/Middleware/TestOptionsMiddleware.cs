

using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

public class TestOptionsMiddleware : IMiddleware
{
    TestOptions _testOptions { set; get; }
    ProductNames _productNames { set; get; }
    public TestOptionsMiddleware(IOptions<TestOptions> options, ProductNames product)
    {
        _testOptions = options.Value;
        _productNames = product;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Show options in TestOptionsMiddleware\n");

        var stringBuilder = new StringBuilder();
        stringBuilder.Append("TestOPtions\n");
        stringBuilder.Append($"opt_key1 = {_testOptions.opt_key1}\n");
        stringBuilder.Append($"TestOPtions.opt_key2.k1 = {_testOptions.opt_key2.k1}\n");
        stringBuilder.Append($"TestOPtions.opt_key2.k2 = {_testOptions.opt_key2.k2}\n");

        foreach (var name in _productNames.GetNames())
        {
            stringBuilder.Append(name + "\n");
        }

        await context.Response.WriteAsync(stringBuilder.ToString());

        await next(context);
    }
}