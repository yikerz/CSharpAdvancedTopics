using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    public class ImagePost : Post
    {
        public string ImageURL { get; set; }
        // default constructor from parent class is called implicitly
        public ImagePost()
        {
            ImageURL = string.Empty;
        }
        public ImagePost(string title, string sender, bool isPublic, string imageURL) : base(title, sender, isPublic)
        {
            ImageURL = imageURL;
        }
        public override void Update(string newTitle, bool isPublic)
        {
            base.Update(newTitle, isPublic);
        }

    }
}
