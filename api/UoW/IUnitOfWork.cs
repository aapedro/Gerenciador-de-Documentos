using api.Repositories;
namespace api.Data;

public interface IUnitOfWork : IDisposable
{
    IDocumentRepository Documents { get; }
    void Commit();
}
