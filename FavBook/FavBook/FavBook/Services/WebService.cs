using FavBook;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace FavBook.Services
{
    public enum ServiceResult
    {
        Success,
        Failed,
        Exception
    }

    public class SearchService
    {
        private static SearchService instance;

        public static SearchService Instance {
            get {
                if (instance == null) {
                    instance = new SearchService ();
                }

                return instance;
            }
        }

        public async Task<Tuple<ServiceResult, string, BookExtract>> GetBooks (string query)
        {
            string uri = $"http://extracts.panmacmillan.com/getextracts?titlecontains={query}";
            try {
                HttpClient client = new HttpClient ();
                var result = await client.GetStringAsync (uri);
                var bookExtract = Newtonsoft.Json.JsonConvert.DeserializeObject<BookExtract> (result);
                return new Tuple<ServiceResult, string, BookExtract> (ServiceResult.Success, "", bookExtract);
            } catch (Exception ex) {
                Debug.WriteLine (ex.Message);
                return new Tuple<ServiceResult, string, BookExtract> (ServiceResult.Exception, ex.Message, new BookExtract ());
            }
        }
    }
}
