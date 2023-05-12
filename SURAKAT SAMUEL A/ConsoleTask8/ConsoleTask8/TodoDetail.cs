using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTask8
{
    public class TodoDetail
    {
        public int Register { get; set; }
        public string Login { get; set; }
        public string Exist { get; set; }

    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
       


        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }

    public class Task
    {
        public Guid Id { get; } = Guid.NewGuid();
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duedate { get; set; }
        public PeriorityLevel PeriorityLevel { get; set; }
        public int UserID { get; set; }
        public bool IsCompleted { get; set; }

        public Task( int itemId, string title, string description, string duedate, PeriorityLevel periorityLevel, int userId)
        {
            Title = title;
            Description = description;
            Duedate = duedate;
            PeriorityLevel = periorityLevel;
            UserID = userId;
            IsCompleted = false;
            Id = new Guid();
            ItemId = itemId;
        }
    }
    public enum PeriorityLevel
    {
        low = 1, medium =2, high =3
    }
   
    public class CurrentUser
    {
        public static int Id { get; set; }
        //public Guid PersonId { get; }= Guid.NewGuid();
    }

    


}