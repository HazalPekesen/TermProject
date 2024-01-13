using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public AppUser Writer { get; set; }
        public string WriterId { get; set; }
        [Required]
        public string EmotionResultId { get; set; }
        [ForeignKey("EmotionResultId")]
        public EmotionResult EmotionResult { get; set; }
    }
}
