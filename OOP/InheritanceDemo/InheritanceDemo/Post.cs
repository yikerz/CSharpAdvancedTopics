using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    public class Post
    {
        // static type defines a sharable prop among all child classes
        private static int currentPostID;
        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Sender { get; set; }
        protected bool IsPublic { get; set; }
        // default constructor
        public Post()
        {
            ID = 0;
            Title = "This is the first post.";
            Sender = "Travis";
            IsPublic = true;
        }
        public Post(string title, string sender, bool isPublic)
        {
            ID = GetNextID();
            Title = title;
            Sender = sender;
            IsPublic = isPublic;
        }
        protected int GetNextID()
        {
            return ++currentPostID;
        }
        // virtual class let child class to override
        public virtual void Update(string newTitle, bool isPublic)
        {
            Title = newTitle;
            IsPublic = isPublic;
        }
        // override ToString method from Object class
        public override string ToString()
        {
            return String.Format("{0} post {1} is sent by {2}.", IsPublic ? "Public" : "Private", ID, Sender);
        }
    }
}
