using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace gamocracy.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        public int StartingSceneId { get; set; }
        public Scene StartingScene { get; set; }
        public string CreatedBy { get; set; }
    }
}