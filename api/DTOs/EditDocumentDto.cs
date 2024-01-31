using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.DTOs;

public class EditDocumentDto
{
    [Required] public string Description { get; set; }

    [EnumDataType(typeof(DocumentStatus))] public DocumentStatus Status { get; set; }
}