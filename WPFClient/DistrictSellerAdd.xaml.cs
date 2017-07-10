using TestCompany.Core.Client;
using TestCompany.Core.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DistrictSellerAdd.xaml
    /// </summary>
    public partial class DistrictSellerAdd : UserControl
    {
        private IDistrict district;
        private DistrictDetail districtDetail;

        private IEnumerable<ISeller> sellers;
        private readonly BackgroundWorker comboSellerworker = new BackgroundWorker();

        public DistrictSellerAdd(IDistrict district, DistrictDetail districtDetail)
        {
            this.district = district;
            this.districtDetail = districtDetail;
            InitializeComponent();

            // load sellers data in background, so Window dont freeze
            comboSellerworker.DoWork += LoadSeller;
            comboSellerworker.RunWorkerCompleted += LoadSeller_UI;
            comboSellerworker.RunWorkerAsync();
        }

        // SELLER

        private void LoadSeller(object sender, DoWorkEventArgs e)
        {
            this.sellers = SellerController.GetByNotInDistrictAsync(district.Id).Result;
        }

        private void LoadSeller_UI(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.sellers != null)
            {
                // Execute code in main thread where dataGridSeller is
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in this.sellers)
                    {
                        comboBoxSellers.Items.Add(new KeyValuePair<int, string>(item.Id, item.Name));
                    }
                });
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Get key from selected seller
            var seletecd = (KeyValuePair<int, string>)comboBoxSellers.SelectedValue;
            var selectedItem = sellers.FirstOrDefault(i => i.Id == seletecd.Key);

            if (selectedItem != null)
            {
                var isSuccess = DistrictSellerController.InsertAsync(selectedItem.Id, district.Id, false).Result;

                if (isSuccess)
                {
                    districtDetail.Dispatcher.Invoke(new Action(() => {
                        // Reload seller grid
                        districtDetail.UpdateSellersGrid();
                    }));

                    MessageBox.Show(string.Format("Sælger '{0}' er tilknyttet", selectedItem.Name));

                    // Close Window
                    ((Window)this.Parent).Close();
                } else {
                    MessageBox.Show("Der opstod en fejl");
                }
            }
        }
    }
}
