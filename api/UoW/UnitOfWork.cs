using api.Repositories;

namespace api.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DocumentDbContext _context;

    public UnitOfWork(DocumentDbContext context)
    {
        _context = context;
        Documents = new DocumentRepository(_context);
    }

    public IDocumentRepository Documents { get; }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}