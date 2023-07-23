using System.ComponentModel.DataAnnotations;

namespace ecinema_aspnet_mvc_app.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Picture")]
        public string PictureUrl { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
