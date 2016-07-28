using Xamarin.Forms;

namespace FavBook
{
    public partial class BookDetailPage : ContentPage
    {
        public BookDetailPage (Book book)
        {
            this.BindingContext = book;
            InitializeComponent ();
        }
    }
}

