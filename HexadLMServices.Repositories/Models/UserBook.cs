using System;

namespace HexadLMServices.Repositories.Models
{
    public partial class UserBook
    {
        public int UserBookId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
