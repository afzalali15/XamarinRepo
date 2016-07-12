using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinHive
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage ()
        {
            InitializeComponent ();
        }


        void btnLogin_Clicked (object sender, System.EventArgs e)
        {

        }

        void chkRemember_CheckChanged (object sender, System.EventArgs e)
        {
            var chk = (XCheckBox)sender;
            if (!chk.IsChecked) {
                //show password
                edtPassword.IsPassword = true;
            } else {
                //hide password
                edtPassword.IsPassword = false;
            }
        }
    }
}

