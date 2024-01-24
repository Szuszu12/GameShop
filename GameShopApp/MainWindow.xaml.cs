using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameShopApp
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

        private void OpenCategoryWindow()
        {
            CategoryWindow categoryWindow = new CategoryWindow();
            categoryWindow.Owner = this;
            categoryWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenCategoryWindow();
        }

        private void OpenClientWindow()
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.Owner = this;
            clientWindow.ShowDialog();
        }

        private void Button_Client_Click(object sender, RoutedEventArgs e)
        {
            OpenClientWindow();
        }

        private void OpenGameWindow()
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Owner = this;
            gameWindow.ShowDialog();
        }

        private void Button_Game_Click(object sender, RoutedEventArgs e)
        {
            OpenGameWindow();
        }

        private void OpenOrderWindow()
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Owner = this;
            orderWindow.ShowDialog();
        }

        private void Button_Order_Click(object sender, RoutedEventArgs e)
        {
            OpenOrderWindow();
        }

        private void OpenProducerWindow()
        {
            ProducerWindow producerWindow = new ProducerWindow();
            producerWindow.Owner = this;
            producerWindow.ShowDialog();
        }

        private void Button_Producer_Click(object sender, RoutedEventArgs e)
        {
            OpenProducerWindow();
        }
    }
}