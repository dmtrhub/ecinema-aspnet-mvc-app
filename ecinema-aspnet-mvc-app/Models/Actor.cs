using System.ComponentModel.DataAnnotations;

namespace ecinema_aspnet_mvc_app.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        [Display(Name = "Picture")]
        public string PictureUrl { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
