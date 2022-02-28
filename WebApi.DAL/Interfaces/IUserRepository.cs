﻿using System.IdentityModel.Tokens.Jwt;

namespace WebApi.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        public IEnumerable<T> GetList();
        public T GetItem(string userName);
        public Task<JwtSecurityToken> Register(T item, string password);
        public JwtSecurityToken Login(T item, string password);

        public void ExcludeFromSearch(T item);
        //public void Edit(T item);
        //public void Delete(int Id);
    }
}