using System;
using MCQAssignment3.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace MCQAssignment3.Data
{
	public class QuizContext : DbContext
	{
		public QuizContext(DbContextOptions<QuizContext> options): base(options)
		{
		}

		public DbSet<Question> Questions { get; set; }
		public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			// converting Options [] to json
			modelBuilder.Entity<Question>()
						.Property(q => q.Options)
						.HasConversion(
							options => JsonSerializer.Serialize(options, (JsonSerializerOptions)null),
							json => JsonSerializer.Deserialize<string[]>(json, (JsonSerializerOptions)null));
        }
    }
}

