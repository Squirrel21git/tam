using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace xamarinPosty.Classes
{
    internal class Post
    {
        public static ObservableCollection<Post> List = new ObservableCollection<Post>();

        public User User { get; set; }
        public string Description { get; set; }

        public Post(User user, string description)
        {
            User = user;
            Description = description;
        }
    }
}
