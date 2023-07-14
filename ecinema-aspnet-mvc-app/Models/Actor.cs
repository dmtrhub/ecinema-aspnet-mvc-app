using System.ComponentModel.DataAnnotations;

namespace ecinema_aspnet_mvc_app.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
