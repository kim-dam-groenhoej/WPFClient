using TestCompany.Core.Client;
using TestCompany.Core.Client.Exceptions;
using TestCompany.Core.Client.Models;
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

namespace TestCompany.WPFClient
{
    /// <summary>
    /// Interaction logic for DistrictDetail.xaml
    /// </summary>
    public partial class DistrictDetail : UserControl
    {
        private IDistrict district;
        private readonly BackgroundWorker dataGridSellerworker = new BackgroundWorker();
        private readonly BackgroundWorker dataGridShopsworker = new BackgroundWorker();
        private IEnumerable<ISeller> sellers;
        private IEnumerable<IShop> shops;
        private Window districtDetailSellerAddWindow;

        public DistrictDetail(IDistrict district)
        {
            this.district = district;
            InitializeComponent();
        }

        // SELLER

        private void LoadSeller(object sender, DoWorkEventArgs e)
        {
            this.sellers = SellerController.GetByDistrictAsync(district.Id).Result;
        }

        private void LoadSeller_UI(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.sellers != null)
            {
                // Execute code in main thread where dataGridSeller is
                this.Dispatcher.Invoke(() =>
                {
                    sellersGrid.ItemsSource = this.sellers;
                });
            }
        }

        private void SellersGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // load sellers data in background, so Window dont freeze
            dataGridSellerworker.DoWork += LoadSeller;
            dataGridSellerworker.RunWorkerCompleted += LoadSeller_UI;
            this.UpdateSellersGrid();
        }

        // SHOP

        private void LoadShop(object sender, DoWorkEventArgs e)
        {
            this.shops = ShopController.GetByDistrictAsync(district.Id).Result;
        }

        private void LoadShop_UI(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.shops != null)
            {
                // Execute code in main thread where dataGridShop is
                this.Dispatcher.Invoke(() =>
                {
                    shopsGrid.ItemsSource = this.shops;
                });
            }
        }

        private void ShopsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // load shop data in background, so Window dont freeze
            dataGridShopsworker.DoWork += LoadShop;
            dataGridShopsworker.RunWorkerCompleted += LoadShop_UI;
            dataGridShopsworker.RunWorkerAsync();
        }

        public void UpdateSellersGrid()
        {
            this.dataGridSellerworker.RunWorkerAsync();
        }

        private void BtnDeleteSeller_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var seletecdItem = sellersGrid.SelectedItem;

                if (seletecdItem != null)
                {
                    var seller = (ISeller)seletecdItem;
                    var isSuccess = DistrictSellerController.DeleteAsync(seller.Id, district.Id).Result;

                    if (isSuccess)
                    {
                        // Reload seller grid
                        this.UpdateSellersGrid();
                        MessageBox.Show(string.Format("Sælger '{0}' er slettet", seller.Name));
                    }
                }
            } catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(string.Format("Der opstod en fejl: {0}", ex.InnerException.Message));
                } else
                {
                    MessageBox.Show(string.Format("Der opstod en fejl: {0}", ex.Message));
                }
            }
        }

        private void BtnAddSeller_Click(object sender, RoutedEventArgs e)
        {
            // center window info
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;

            // Open new window with district data
            this.districtDetailSellerAddWindow = new Window();
            this.districtDetailSellerAddWindow.Title = string.Format("TestCompany Manager - {0}: Tilknyt sælger", district.Name);
            this.districtDetailSellerAddWindow.Width = 250;
            this.districtDetailSellerAddWindow.Content = new DistrictSellerAdd(district, this); // Instance of usercontrol for district detail Window
            this.districtDetailSellerAddWindow.Height = 140;
            this.districtDetailSellerAddWindow.Show();
            this.districtDetailSellerAddWindow.Left = (screenWidth / 2) - (windowWidth / 2);
            this.districtDetailSellerAddWindow.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void ChkSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var seletecdItem = sellersGrid.SelectedItem;

                if (seletecdItem != null)
                {
                    var seller = (ISeller)seletecdItem;
                    // Convert to bool - no value then false
                    bool isChecked = ((CheckBox)e.Source).IsChecked.HasValue ? ((CheckBox)e.Source).IsChecked.Value : false;

                    var isSuccess = DistrictSellerController.UpdateAsync(seller.Id, district.Id, isChecked).Result;

                    if (isSuccess)
                    {
                        // Reload seller grid
                        this.UpdateSellersGrid(); 

                        MessageBox.Show(string.Format("Sælger '{0}' er opdateret", seller.Name));
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(string.Format("Der opstod en fejl: {0}", ex.InnerException.Message));
                }
                else
                {
                    MessageBox.Show(string.Format("Der opstod en fejl: {0}", ex.Message));
                }

                ((CheckBox)e.Source).IsChecked = true;
            }
        }
    }
}
