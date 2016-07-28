using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FavBook
{
    public partial class MasterPage : ContentPage
    {
        public ListView MenuList { get { return lstMenu; } }
        public MasterPage ()
        {
            Title = "FavBook";
            List<Menu> menu = new List<Menu> () {
                new Menu{Title = "Home"},
                new Menu{Title = "Favorite Books"},
                new Menu{Title = "About"},
            };

            InitializeComponent ();
            lstMenu.ItemsSource = menu;
        }
    }
}

