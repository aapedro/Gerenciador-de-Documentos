using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.DTOs;

public class AddDocumentDto
{
    [Required] public string Name { get; set; }

    [Required] public string Description { get; set; }

    [EnumDataType(typeof(DocumentStatus))] public DocumentStatus Status { get; set; } = DocumentStatus.PENDING;

    [Required] public IFormFile File { get; set; }
}