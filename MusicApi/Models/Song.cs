using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be null or empty!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Language cannot be null or empty!")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Kindly provide the song duration!")]
        public string Duration { get; set; }
    }
}
