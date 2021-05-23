using Autofac;
using System;
using System.Windows.Forms;
using ZooSimulator.InterfaceLayer;
using ZooSimulator.ServiceLayer;

namespace ZooSimulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Zoo>().As<IZoo>();
            builder.RegisterType<AnimalFactory>().As<IAnimalFactory>();
            builder.RegisterType<DatabaseService>().As<IDatabaseService>();
            builder.RegisterType<DatabaseHandler>().As<IDatabaseHandler>();
            builder.RegisterType<MainDisplay>();
            var container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainDisplay>());
        }
    }
}
