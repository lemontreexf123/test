using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            EmployeeView.ItemAppearing += async (object sender, ItemVisibilityEventArgs e) =>
            {
                if (EmployeeView.IsScrolling) {
                    await DisplayAlert("ItemAppearing", e.Item + " row is appearing", "OK");
                    Console.WriteLine("ItemAppearing!!!!!!!!!!");
                }
            };

        }
    }
}
