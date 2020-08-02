using System;
using System.Collections.Generic;

namespace HexadLMServices.Repositories.Models
{
    public partial class Book
    {
        public Book()
        {
            BookStore = new HashSet<BookStore>();
            UserBook = new HashSet<UserBook>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Publication { get; set; }
        public DateTime? Yearofpub { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<BookStore> BookStore { get; set; }
        public virtual ICollection<UserBook> UserBook { get; set; }
    }
}
