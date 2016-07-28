using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FavBook
{
    public partial class MainPage : MasterDetailPage
    {
        MasterPage master;
        SearchPage detail;
        public MainPage ()
        {
            InitializeComponent ();
            master = new MasterPage ();
            master.MenuList.ItemSelected += MenuList_ItemSelected; ;
            Master = master;

            detail = new SearchPage ();
            Detail = new NavigationPage (detail);
        }

        void MenuList_ItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Menu)e.SelectedItem;
            if (item == null)
                return;

            if (item.Title == "Home") {
                Detail = new NavigationPage (new SearchPage ());
            }

            if (item.Title == "Favorite Books") {
                Detail = new NavigationPage (new FavPage ());
            }

            if (item.Title == "About") {
                Detail = new NavigationPage (new AboutPage ());
            }

            IsPresented = !IsPresented;
        }
    }
}

