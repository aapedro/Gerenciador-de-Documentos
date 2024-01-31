using api.DTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _documents;

    public DocumentsController(IDocumentService documents)
    {
        _documents = documents;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _documents.GetAllDocuments());
        }
        catch (Exception e)
        {
            return NotFound(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] AddDocumentDto dto)
    {
        try
        {
            await _documents.AddDocument(dto);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _documents.DeleteDocument(id);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e);
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> Patch(int id, [FromBody] EditDocumentDto dto)
    {
        try
        {
            await _documents.EditDocument(id, dto);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e);
        }
    }

    [HttpGet("{id}/download")]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            string filePath = await _documents.GetFilePath(id);
            return PhysicalFile(filePath, "application/octet-stream", Path.GetFileName(filePath));
        }
        catch (Exception e)
        {
            return NotFound(e);
        }
    }
}