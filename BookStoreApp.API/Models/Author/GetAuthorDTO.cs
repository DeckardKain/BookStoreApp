using BookStoreApp.API.Data;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.Author
{
    public class GetAuthorDTO : BaseAuthorDTO
    {
        
        [StringLength(250)]
        public string Bio { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
