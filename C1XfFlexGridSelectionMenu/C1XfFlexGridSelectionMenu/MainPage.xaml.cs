using C1.Xamarin.Forms.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace C1XfFlexGridSelectionMenu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            grid.ItemsSource = Customer.GetCustomerList(100);

            grid.CreatingSelectionMenu += Grid_CreatingSelectionMenu;
        }

        private void Grid_CreatingSelectionMenu(object sender, GridSelectionMenuEventArgs e)
        {
            e.Menu.Items.Add(new GridMenuItem("共有", () => ShareBehavior(e)));

        }

        public async void ShareBehavior(GridSelectionMenuEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            for (int c = e.CellRange.Column; c <= e.CellRange.Column2; c++)
            {
                var str = grid[e.CellRange.Row, c].ToString();

                sb.Append(str);
                sb.Append(" ");
            }

            await ShareText(sb.ToString());
        }

        public async Task ShareText(string text)
        {
            await DataTransfer.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "選択したデータを共有"
            });
        }
    }
}
