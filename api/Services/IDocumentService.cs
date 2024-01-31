using api.DTOs;
using api.Models;

namespace api.Services;

public interface IDocumentService
{
    public Task AddDocument(AddDocumentDto documentDto);
    public Task<List<Document?>> GetAllDocuments();
    public Task DeleteDocument(int id);
    public Task EditDocument(int id, EditDocumentDto dto);
    public Task<string> GetFilePath(int id);
}