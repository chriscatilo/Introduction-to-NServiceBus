using NServiceBus;
using System;
using System.Windows;
using BusStop.Sales.InternalMessages;

namespace BusStop.BackOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var bus = App.Container.GetInstance<IBus>();

            var callback = bus.Send(new CancelOrder
            {
                OrderId = Guid.NewGuid(),
            });

            callback.Register<CommandStatus>(status =>
            {
                textBox.Text = status.ToString();
            });
        }
    }
}
