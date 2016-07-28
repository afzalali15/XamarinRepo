using FavBook.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FavBook
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage ()
        {
            InitializeComponent ();
        }

        async void btnSearch_Clicked (object sender, EventArgs args)
        {
            DialogService.ShowLoading ("Fetching books..");
            var searchResult = await SearchService.Instance.GetBooks (edtSearch.Text);
            DialogService.HideLoading ();

            if (searchResult.Item1 == ServiceResult.Exception) {
                DialogService.ShowError (searchResult.Item2);
                return;
            }

            lstBook.ItemsSource = searchResult.Item3.Extracts;
        }

        void lstBook_ItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            var book = (Book)e.SelectedItem;
            if (book == null)
                return;

            Navigation.PushAsync (new BookDetailPage (book));
            ((ListView)sender).SelectedItem = null;
        }
    }
}
