using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly DocumentDbContext _context;

    public DocumentRepository(DocumentDbContext context)
    {
        _context = context;
    }

    public async Task<Document> GetOne(int id)
    {
        return await _context.Documents.FindAsync(id);
    }

    public async Task<List<Document?>> GetAll()
    {
        return await _context.Documents.ToListAsync();
    }

    public async Task AddOne(Document document)
    {
        await _context.Documents.AddAsync(document);
    }

    public async Task DeleteOne(int id)
    {
        var document = await _context.Documents.FindAsync(id);

        _context.Documents.Remove(document);
    }

    public async Task EditOne(int id, DocumentUpdate update)
    {
        var document = await _context.Documents.FindAsync(id);

        document.Description = string.IsNullOrEmpty(update.Description) ? document.Description : update.Description;
        document.Status = update.Status;
    }
}