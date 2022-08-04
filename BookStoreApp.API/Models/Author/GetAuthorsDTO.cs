using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.Author
{
    public class GetAuthorsDTO : BaseAuthorDTO
    {
               
        [StringLength(250)]
        public string Bio { get; set; }
    
    }
}
