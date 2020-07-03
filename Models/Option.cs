using System.ComponentModel.DataAnnotations.Schema;

namespace gamocracy.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string Text { get; set; }
        
        [ForeignKey("Scene")]
        public int? LeadsTo { get; set; }

        public Scene NextScene { get; set; }
    }
}