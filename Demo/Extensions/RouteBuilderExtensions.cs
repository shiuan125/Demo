using Microsoft.AspNetCore.Routing;

public static class RouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapPageRoute(
        this IEndpointRouteBuilder app,
        string name,
        string pattern)
    {
        app.MapControllerRoute(
            name: name,
            pattern: pattern,
            defaults: new { controller = "Home", action = "Page", pageName = pattern });
        
        return app;
    }
} 