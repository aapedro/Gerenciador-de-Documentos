using api.Models;

namespace api.Repositories;

public interface IDocumentRepository
{
    public Task<Document> GetOne(int id);
    public Task<List<Document?>> GetAll();
    public Task AddOne(Document document);
    public Task DeleteOne(int id);
    public Task EditOne(int id, DocumentUpdate update);
}