using api.Data;
using api.DTOs;
using api.Models;

namespace api.Services;

public class DocumentService : IDocumentService
{
    private readonly IConfiguration _config;
    private readonly IUnitOfWork _uow;

    public DocumentService(IUnitOfWork uow, IConfiguration config)
    {
        _uow = uow;
        _config = config;
    }

    public async Task AddDocument(AddDocumentDto dto)
    {
        var fileName = Guid.NewGuid() + "_" + dto.File.FileName;

        await _uow.Documents.AddOne(new Document
        {
            Name = dto.Name,
            FileName = fileName,
            Description = dto.Description,
            Status = dto.Status
        });

        await SaveDocument(dto.File, fileName);

        _uow.Commit();
    }

    public async Task<List<Document?>> GetAllDocuments()
    {
        return await _uow.Documents.GetAll();
    }

    public async Task DeleteDocument(int id)
    {
        await _uow.Documents.DeleteOne(id);
        _uow.Commit();
    }

    public async Task EditDocument(int id, EditDocumentDto dto)
    {
        await _uow.Documents.EditOne(id, new DocumentUpdate
        {
            Description = dto.Description,
            Status = dto.Status
        });
        _uow.Commit();
    }

    public async Task<string> GetFilePath(int id)
    {
        Document document = await _uow.Documents.GetOne(id);
        string storageFolderName = _config.GetValue<string>("StorageFolderName");
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), storageFolderName, document.FileName);

        return filePath;
    }
    
    private async Task SaveDocument(IFormFile documentFile, string fileName)
    {
        var storageFolderName = _config.GetValue<string>("StorageFolderName");
        var storageFolder = Path.Combine(Directory.GetCurrentDirectory(), storageFolderName);
        if (!Directory.Exists(storageFolder)) Directory.CreateDirectory(storageFolder);

        var filePath = Path.Combine(storageFolder, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await documentFile.CopyToAsync(fileStream);
        }
    }
    
}