﻿using System.ComponentModel.DataAnnotations;

namespace ecinema_aspnet_mvc_app.Models
{
    public class Actor : IActor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage ="Name was not in a correct format.")]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Biography")]
        [Required]
        public string Bio { get; set; }
        [Display(Name = "Picture")]
        [Required]
        public string PictureUrl { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
