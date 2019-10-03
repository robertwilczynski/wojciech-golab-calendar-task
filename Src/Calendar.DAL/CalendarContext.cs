using System;
using Calendar.DAL.Calendars;
using Calendar.DAL.Events;
using Calendar.DAL.Users;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace Calendar.DAL
{
    public class CalendarContext : DbContext
    {
        private string _connectionString;

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CalendarEntity> Calendars { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<EventExceptionEntity> EventExceptions { get; set; }
        public DbSet<RecurrencePatternEntity> RecurrencePatterns { get; set; } 

        public CalendarContext()
        {
            
        }

        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options)
        {
            _connectionString = options.GetExtension<NpgsqlOptionsExtension>()?.ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException(nameof(options));
        }
    }
}