using System;
using System.Collections.Generic;

namespace HexadLMServices.Repositories.Models
{
    public partial class BookStore
    {
        public int BookStoreId { get; set; }
        public int BookId { get; set; }
        public int StockCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Book Book { get; set; }
    }
}
