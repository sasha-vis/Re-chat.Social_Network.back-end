﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Entities;

namespace WebApi.DAL.Interfaces
{
    public interface ILikeRepository<T> where T : class
    {
        List<Like> LikesOfUser(string id);

        public void Create(T item);

    }
}
