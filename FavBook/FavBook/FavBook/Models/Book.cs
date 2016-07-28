using System.Collections.Generic;
using SQLite;

namespace FavBook
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int UID {
            get;
            set;
        }

        public string author { get; set; }
        public string authorBiography { get; set; }
        public string bicCodeList { get; set; }
        public string bisacCodeList { get; set; }
        public int estimatedReadingTimeMinutes { get; set; }
        public string extractHtml { get; set; }
        public string format { get; set; }
        public string formatDescription { get; set; }
        public string formatDetail { get; set; }
        public string illustrator { get; set; }
        public string imprintDisplayName { get; set; }
        public bool isFeatured { get; set; }
        public string isbn { get; set; }
        public string isbn10 { get; set; }
        public string jacketUrl { get; set; }
        public string keynote { get; set; }
        //public object nextPageLink { get; set; }
        public string publicationDate { get; set; }
        public string reader { get; set; }
        public string title { get; set; }
    }

    public class BookExtract
    {
        public List<Book> Extracts { get; set; }
        public string NextPageUrl { get; set; }
        public int PageCount { get; set; }
    }
}
