using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FavBook
{
    public partial class FavPage : ContentPage
    {
        public FavPage ()
        {
            InitializeComponent ();
            var db = new DatabaseService ();

            lstBook.ItemsSource = db.GetBooks ();
        }
    }
}

