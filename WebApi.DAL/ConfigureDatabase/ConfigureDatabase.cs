using Microsoft.EntityFrameworkCore;
using WebApi.DAL.Entities;

namespace WebApi.DAL.ConfigureDatabase
{
    public static class ConfigureDatabase
    {
        public static void AddConfigureDatabase(this ModelBuilder modelBuilder)
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

            modelBuilder.Entity<FriendList>()
            .HasOne(x => x.Friend)
            .WithMany(x => x.FriendLists)
            .HasForeignKey(x => x.FriendId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}