using System.ComponentModel.DataAnnotations;

namespace OpenRA.ResourceCenter.Web.Dtos
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }
        
        [Required, StringLength(50)]
        public string Subject { get; set; }
        
        [Required, StringLength(1000)]
        public string Message { get; set; }
    }
}