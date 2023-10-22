using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

public class Genre
    {
        public int GenreID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public string Name { get; set; }
       
}

