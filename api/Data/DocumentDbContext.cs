using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class DocumentDbContext : DbContext
{
    public DocumentDbContext(DbContextOptions<DocumentDbContext> options)
        : base(options)
    {
    }

    public DbSet<Document> Documents { get; set; }
}