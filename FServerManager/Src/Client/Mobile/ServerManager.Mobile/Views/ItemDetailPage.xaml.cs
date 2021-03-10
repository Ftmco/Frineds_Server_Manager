using ServerManager.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ServerManager.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}