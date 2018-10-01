using System.ComponentModel.DataAnnotations;
using AspNetCoreVideo.Models;

namespace AspNetCoreVideo.ViewModels
{
    public class VideoEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(80)]
        public string Title { get; set; }

        public Genres Genre { get; set; }
    }
}