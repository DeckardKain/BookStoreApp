using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.Author
{
    public class CreateAuthorDTO : BaseAuthorDTO
    {
        [StringLength(250)]
        public string Bio { get; set; }
    }
}
