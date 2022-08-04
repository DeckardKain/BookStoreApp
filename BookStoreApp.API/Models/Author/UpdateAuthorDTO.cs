using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.Author
{
    public class UpdateAuthorDTO : BaseAuthorDTO
    {
        [StringLength(250)]
        public string Bio { get; set; }
    }
}
