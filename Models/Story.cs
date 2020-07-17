using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace gamocracy.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public string Summary { get; set; }
        public int StartingSceneId { get; set; }
        public Scene StartingScene { get; set; }

        [ForeignKey("IdentityUser")]
        public string CreatedBy { get; set; }
        public IdentityUser CreatedByUser { get; set; }
    }
}