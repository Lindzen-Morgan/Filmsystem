using System.ComponentModel.DataAnnotations;
 public class Movie
    {
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1800, 2200)] 
        public int ReleaseYear { get; set; }

        [Required]
        public string Description { get; set; }
    }

