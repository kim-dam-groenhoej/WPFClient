using NeasEnergy.Core.Client;
using NeasEnergy.Core.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeasEnergy.WPFClient
{
    /// <summary>
    /// Interaction logic for DistrictsGrid.xaml
    /// </summary>
    public partial class DistrictsGrid : UserControl
    {
        private readonly BackgroundWorker dataGridworker = new BackgroundWorker();
        private IEnumerable<IDistrict> districts;
        private Window districtDetailWindow;

        public DistrictsGrid()
        {
            InitializeComponent();

            double left = (LoadingCanvas.ActualWidth - Loading.ActualWidth) / 2;
            Canvas.SetLeft(LoadingCanvas, left);

            double top = (LoadingCanvas.ActualHeight - Loading.ActualHeight) / 2;
            Canvas.SetTop(LoadingCanvas, top);
        }

        private void dataGridDistrict_Loaded(object sender, RoutedEventArgs e)
        {
            // load district data in background, so Window dont freeze
            dataGridworker.DoWork += LoadDistrict;
            dataGridworker.RunWorkerCompleted += LoadDistrict_UI;
            dataGridworker.RunWorkerAsync();
        }

        private void LoadDistrict(object sender, DoWorkEventArgs e)
        {
            this.districts = DistrictController.GetAsync().Result;
        }

        private void LoadDistrict_UI(object sender, RunWorkerCompletedEventArgs e)
        {
            // Execute code in main thread where dataGridDistrict is
            this.Dispatcher.Invoke(() =>
            {
                dataGridDistrict.ItemsSource = this.districts;
                Loading.Visibility = Visibility.Hidden;
            });
        }

        private void dataGridDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seletecdItem = dataGridDistrict.SelectedItem;

            if (seletecdItem != null)
            {
                var district = (IDistrict)seletecdItem;

                this.IsEnabled = true;

                // Open new window with district data
                this.districtDetailWindow = new Window();
                this.districtDetailWindow.Title = string.Format("NeasEnergy Manager - {0}", district.Name);
                this.districtDetailWindow.Width = 870;
                this.districtDetailWindow.Content = new DistrictDetail(district); // Instance of usercontrol for district detail Window
                this.districtDetailWindow.Height = 340;
                this.districtDetailWindow.Closing += districtDetailWindow_closing;
                this.districtDetailWindow.Show();
            }
        }

        private void districtDetailWindow_closing(object sender, CancelEventArgs e)
        {
            this.IsEnabled = true;
            dataGridDistrict.UnselectAll();
        }
    }
}
