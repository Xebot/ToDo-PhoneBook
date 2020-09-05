﻿using Microsoft.EntityFrameworkCore;
using ToDoPhoneBook.Domain.Entites;

namespace ToDoPhoneBook.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}