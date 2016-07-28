using FavBook.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FavBook.ViewModels
{
    class SearchViewModel : BaseViewModel
    {
        ObservableCollection<Book> books;
        Command fetchBooksCommand;
        public ObservableCollection<Book> Books {
            get { return books; }
            set { books = value; }
        }

        public SearchViewModel ()
        {
            books = new ObservableCollection<Book> ();
        }

        public Command FetchBooksCommand {
            get { return fetchBooksCommand ?? (fetchBooksCommand = new Command (async () => await ExecuteFetchFriendsCommand ())); }
        }

        public async Task ExecuteFetchFriendsCommand ()
        {
            if (IsBusy) {
                return;
            }

            IsBusy = true;

            try {
                if (await ConnectivityService.IsConnected ()) {
                    await SearchService.Instance.GetBooks ("authorcontains=john");
                } else {
                    DialogService.ShowError (Strings.NoInternetConnection);
                }
            } catch (Exception ex) {
                Debug.WriteLine (ex.Message);
            }

            IsBusy = false;
        }

    }
}
