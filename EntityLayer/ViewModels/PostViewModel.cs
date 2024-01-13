using EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public EmotionResult EmotionResult { get; set; }
        public UserViewModel User { get; set; }
    }
}
