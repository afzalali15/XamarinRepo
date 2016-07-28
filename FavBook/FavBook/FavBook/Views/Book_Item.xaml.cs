using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FavBook;
using Xamarin.Forms;

namespace FavBook
{
    public partial class Book_Item : ContentView
    {
        public Book_Item ()
        {
            InitializeComponent ();
        }

        async void btnAddToFav_Click (object sender, System.EventArgs e)
        {
            var btn = (Button)sender;
            var dbService = new DatabaseService ();
            var book = (Book)this.BindingContext;

            if (dbService.IsPresentInCart (book)) {
                await btn.ScaleTo (1.5, 100, Easing.BounceIn);
                btn.Image = "heart_empty.png";
                await btn.ScaleTo (1, 100, Easing.BounceOut);
                dbService.RemoveFromCart (book);
            } else {
                await btn.ScaleTo (1.5, 100, Easing.BounceIn);
                btn.Image = "heart_fill.png";
                await btn.ScaleTo (1, 100, Easing.BounceOut);
                dbService.AddToCart (book);
            }
        }
    }
}
