﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.ViewModels.Comment;
using WebApi.BLL.ViewModels.Like;

namespace WebApi.BLL.ViewModels.Post
{
    public class PostGetVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }

        public DateTime PostDate { get; set; }

        public List<LikeForPostVM> Likes { get; set; }
        public List<CommentForPostVM> Comments { get; set; }
    }
}
