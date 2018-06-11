using Autofac;
using WordsCount.Application.IoC;
using WordsCount.Application.Views;

namespace WordsCount.Application
{
    class Program
    {
        public static IContainer Container;

        static void Main(string[] args)
        {
            Container = IoCBuilder.Build();

            //var view = new MainView(new ViewModel.MainViewModel());

            var view = Container.Resolve<MainView>();

            view.Run();
        }
    }
}
