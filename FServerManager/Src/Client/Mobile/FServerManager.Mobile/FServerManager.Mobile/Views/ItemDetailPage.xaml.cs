using FServerManager.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FServerManager.Mobile.Views
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