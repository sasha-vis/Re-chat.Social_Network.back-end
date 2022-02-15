using Microsoft.EntityFrameworkCore;
using WebApi.DAL.Entities;

namespace WebApi.DAL.DefaultInfoForDatabase
{
    public static class DefaultInfo
    {
        public static void AddDefaultInfo(this ModelBuilder modelBuilder)
        {
            DateTime date = DateTime.Now;
            string dateTimeNow = date.ToString("g");

            string dateNow = date.ToString("d");
            string dayMonthNow = dateNow.Substring(0, 6);
            int yearNow = Convert.ToInt32(dateNow.Substring(6));
            string defaultYear = Convert.ToString(yearNow - 18);

            string defaultBirthdayDate = dayMonthNow + defaultYear;
          

            modelBuilder.Entity<User>()
                .Property(u => u.RegistrationDate)
                .HasDefaultValue(dateTimeNow);
            modelBuilder.Entity<User>()
                .Property(u => u.BirthdayDate)
                .HasDefaultValue(defaultBirthdayDate);
            modelBuilder.Entity<User>()
                .Property(u => u.Gender)
                .HasDefaultValue("Male");




            //modelBuilder.Entity<User>()
            //    .HasOne(x => x.Phone)
            //    .WithOne(x => x.User)
            //    .HasForeignKey<Phone>(x => x.UserId);

            //modelBuilder.Entity<ProductsOrder>()
            //    .HasKey(x => new { x.ProductId, x.OrderId });

            //modelBuilder.Entity<ProductsOrder>()
            //    .HasOne(x => x.Product)
            //    .WithMany(x => x.ProductsOrders)
            //    .HasForeignKey(x => x.ProductId);

            //modelBuilder.Entity<ProductsOrder>()
            //    .HasOne(x => x.Order)
            //    .WithMany(x => x.ProductsOrders)
            //    .HasForeignKey(x => x.OrderId);

            var sasha = new User()
            {
                Name = "Aleksandr",
                Surname = "Vysotski",
                Email = "sasha.vysotski@gmail.com",
                NormalizedEmail = "SASHA.VYSOTSKI@GMAIL.COM",
                UserName = "sasha.vysotski@gmail.com",
                NormalizedUserName = "SASHA.VYSOTSKI@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEBkYorHLrudV7o/AMc9bEGtaudVjE2Rsrzny9W4orlEeHLNG3oBhrbu4F27j5wRGbg==",
                SecurityStamp = "SUXDS2ENOSQRGR3PQ4USLV4UT7Z6GU4I",
                ConcurrencyStamp = "77d5ec9f-e202-4ebe-bb56-639cfc03e0c3",
                RegistrationDate = dateTimeNow,
                BirthdayDate = "10.09.1998",
                Gender = "Male"
            };
            var elena = new User()
            {
                Name = "Elena",
                Surname = "Samoilenko",
                Email = "e.samoilemko@mail.ru",
                NormalizedEmail = "E.SAMOILENKO@MAIL.RU",
                UserName = "e.samoilemko@mail.ru",
                NormalizedUserName = "E.SAMOILENKO@MAIL.RU",
                PasswordHash = "AQAAAAEAACcQAAAAEOO9jCT7O2L9y10Ft4LsKDl3blzxlBqKoPVWzKp0ftUg1Cv73Vc5B8Al8xN5TD+e8w==",
                SecurityStamp = "U43GQLZMYDGUOQWHVXLJBVOGMSRXWVLE",
                ConcurrencyStamp = "fc5df5ce-a97d-4551-a7b2-7afa33a80c42",
                RegistrationDate = dateTimeNow,
                BirthdayDate = "14.06.1976",
                Gender = "Female"
            };

            modelBuilder.Entity<User>().HasData(sasha);
            modelBuilder.Entity<User>().HasData(elena);

            var posts = new List<Post>()
            {
                new Post(){ Id = 1, PostContent = "Post1", UserId = sasha.Id },
                new Post(){ Id = 2, PostContent = "Post2", UserId = elena.Id },
                new Post(){ Id = 3, PostContent = "Post3", UserId = sasha.Id },
                new Post(){ Id = 4, PostContent = "Post4", UserId = elena.Id },
                new Post(){ Id = 5, PostContent = "Post5", UserId = sasha.Id },
                new Post(){ Id = 6, PostContent = "Post6", UserId = elena.Id }
            };

            modelBuilder.Entity<Post>().HasData(posts);

            //var comments = new List<Comment>()
            //{
            //    new Comment() { Id = 1, CommentContent = "Comment1", UserId = 1, PostId = 1 },
            //    new Comment() { Id = 2, CommentContent = "Comment2", UserId = 1, PostId = 2 },
            //    new Comment() { Id = 3, CommentContent = "Comment3", UserId = 1, PostId = 3 },
            //    new Comment() { Id = 4, CommentContent = "Comment4", UserId = 1, PostId = 4 },
            //    new Comment() { Id = 5, CommentContent = "Comment5", UserId = 1, PostId = 5 },
            //    new Comment() { Id = 6, CommentContent = "Comment6", UserId = 1, PostId = 6 },
            //    new Comment() { Id = 7, CommentContent = "Comment7", UserId = 2, PostId = 1 },
            //    new Comment() { Id = 8, CommentContent = "Comment8", UserId = 2, PostId = 3 },
            //    new Comment() { Id = 9, CommentContent = "Comment9", UserId = 3, PostId = 6 },
            //    new Comment() { Id = 10, CommentContent = "Comment10", UserId = 3, PostId = 1 },
            //    new Comment() { Id = 11, CommentContent = "Comment11", UserId = 3, PostId = 2 },
            //    new Comment() { Id = 12, CommentContent = "Comment12", UserId = 3, PostId = 4 }
            //};

            //modelBuilder.Entity<Comment>().HasData(comments);

            //var likes = new List<Like>()
            //{
            //    new Like() { Id = 1, UserId = 1, PostId = 1 },
            //    new Like() { Id = 2, UserId = 1, PostId = 4 },
            //    new Like() { Id = 3, UserId = 1, PostId = 5 },
            //    new Like() { Id = 4, UserId = 2, PostId = 1 },
            //    new Like() { Id = 5, UserId = 2, PostId = 2 },
            //    new Like() { Id = 6, UserId = 3, PostId = 1 },
            //    new Like() { Id = 7, UserId = 3, PostId = 3 },
            //    new Like() { Id = 8, UserId = 3, PostId = 6 },
            //};

            //modelBuilder.Entity<Like>().HasData(likes);

            //var friendLists = new List<FriendList>()
            //{
            //    new FriendList() { Id = 1, UserId = 1, FriendId = 2 },
            //    new FriendList() { Id = 2, UserId = 1, FriendId = 3 },
            //    new FriendList() { Id = 3, UserId = 1, FriendId = 2 },
            //    new FriendList() { Id = 4, UserId = 1, FriendId = 3 },
            //    new FriendList() { Id = 5, UserId = 1, FriendId = 2 },
            //    new FriendList() { Id = 6, UserId = 1, FriendId = 3 },
            //    new FriendList() { Id = 7, UserId = 1, FriendId = 2 },
            //    new FriendList() { Id = 8, UserId = 1, FriendId = 3 }
            //};

            //modelBuilder.Entity<FriendList>().HasData(friendLists);

            //var requestFriendLists = new List<RequestFriendList>()
            //{
            //    new RequestFriendList() { Id = 1, UserId = 1, FriendId = 4 },
            //    new RequestFriendList() { Id = 2, UserId = 1, FriendId = 5 },
            //    new RequestFriendList() { Id = 3, UserId = 1, FriendId = 6 },
            //    new RequestFriendList() { Id = 4, UserId = 2, FriendId = 4 },
            //    new RequestFriendList() { Id = 5, UserId = 2, FriendId = 5 },
            //    new RequestFriendList() { Id = 6, UserId = 2, FriendId = 6 },
            //    new RequestFriendList() { Id = 7, UserId = 3, FriendId = 4 },
            //    new RequestFriendList() { Id = 8, UserId = 3, FriendId = 5 },
            //    new RequestFriendList() { Id = 9, UserId = 3, FriendId = 6 }
            //};

            //modelBuilder.Entity<RequestFriendList>().HasData(requestFriendLists);

            //var products = new List<Product>()
            //{
            //    new Product() { Id = 1, Name = "California Pizza", Description = "Description of California Pizza", Price = 20, CategoryId = 1 },
            //    new Product() { Id = 2, Name = "Greek Pizza", Description = "Description of Greek Pizza", Price = 20, CategoryId = 1 },
            //    new Product() { Id = 3, Name = "Sicilian Pizza", Description = "Description of Sicilian Pizza", Price = 20, CategoryId = 1 },
            //    new Product() { Id = 4, Name = "Hamburger", Description = "Description of Hamburger", Price = 10, CategoryId = 2 },
            //    new Product() { Id = 5, Name = "Cheeseburger", Description = "Description of Cheeseburger", Price = 10, CategoryId = 2 },
            //    new Product() { Id = 6, Name = "Coca cola", Description = "Description of Coca cola", Price = 5, CategoryId = 3 },
            //    new Product() { Id = 7, Name = "Fanta", Description = "Description of Fanta", Price = 5, CategoryId = 3 },
            //    new Product() { Id = 8, Name = "Sprite", Description = "Description of Sprite", Price = 5, CategoryId = 3 },
            //    new Product() { Id = 9, Name = "Fries", Description = "Description of Fries", Price = 7, CategoryId = 4 },
            //    new Product() { Id = 10, Name = "Sushi", Description = "Description of Sushi", Price = 7, CategoryId = 4 },
            //    new Product() { Id = 11, Name = "Ketchup", Description = "Description of Ketchup", Price = 3, CategoryId = 5 },
            //    new Product() { Id = 12, Name = "Soy sauce", Description = "Description of Soy sauce", Price = 3, CategoryId = 5 },
            //    new Product() { Id = 13, Name = "Tartar sauce", Description = "Description of Tartar sauce", Price = 3, CategoryId = 5 },
            //    new Product() { Id = 14, Name = "Taco sauce", Description = "Description of Taco sauce", Price = 3, CategoryId = 5 },
            //    new Product() { Id = 15, Name = "Barbecue sauce", Description = "Description of Barbecue sauce", Price = 3, CategoryId = 5 },
            //    new Product() { Id = 16, Name = "Cheese sauce", Description = "Description of Cheese sauce", Price = 3, CategoryId = 5 }
            //};

            //modelBuilder.Entity<Product>().HasData(products);

            //DateTime date = DateTime.Now;
            //string dateString = date.ToString("g");

            //var orders = new List<Order>()
            //{
            //    new Order() { Id = 1, Date = $"{dateString}", UserId = 5 },
            //    new Order() { Id = 2, Date = $"{dateString}", UserId = 1 },
            //    new Order() { Id = 3, Date = $"{dateString}", UserId = 14 },
            //    new Order() { Id = 4, Date = $"{dateString}", UserId = 9 },
            //    new Order() { Id = 5, Date = $"{dateString}", UserId = 6 },
            //    new Order() { Id = 6, Date = $"{dateString}", UserId = 15 }
            //};

            //modelBuilder.Entity<Order>().HasData(orders);

            //var productsOrders = new List<ProductsOrder>()
            //{
            //    new ProductsOrder() { OrderId = 1, ProductId = 6 },
            //    new ProductsOrder() { OrderId = 2, ProductId = 1 },
            //    new ProductsOrder() { OrderId = 3, ProductId = 10 },
            //    new ProductsOrder() { OrderId = 4, ProductId = 8 },
            //    new ProductsOrder() { OrderId = 5, ProductId = 5 },
            //    new ProductsOrder() { OrderId = 6, ProductId = 14 }
            //};

            //modelBuilder.Entity<ProductsOrder>().HasData(productsOrders);
        }
    }
}