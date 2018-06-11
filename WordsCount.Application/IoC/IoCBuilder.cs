using Autofac;
using WordsCount.Application.Views;
using WordsCount.ViewModel;

namespace WordsCount.Application.IoC
{
    public static class IoCBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainView>();
            builder.RegisterType<MainViewModel>();

            return builder.Build();
        }
    }
}
