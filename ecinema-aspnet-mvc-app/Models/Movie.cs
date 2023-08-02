using ecinema_aspnet_mvc_app.Data.Base;
using ecinema_aspnet_mvc_app.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecinema_aspnet_mvc_app.Models
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory Category { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public List<Actor_Movie>? Movie_Actors { get; set; }
    }
}
