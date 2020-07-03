using System.Collections.Generic;

namespace gamocracy.Models
{
    public class Scene
    {
        public int SceneId { get; set; }
        public string Text { get; set; }

        public ICollection<Option> Options { get; set;}
    }
}