using Microsoft.Extensions.DependencyInjection;

namespace BT_COMMONS.Helpers;

public static class ServiceExtensions
{
    public static void AddViewFactory<TView>(this IServiceCollection services)
        where TView : class
    {
        services.AddSingleton<TView>();
        services.AddTransient<Func<TView>>(x => () => x.GetService<TView>()!);
        services.AddSingleton<IAbstractFactory<TView>, AbstractFactory<TView>>();
    }
}
