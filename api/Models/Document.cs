using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class Document
{
    [Key] public int Id { get; set; }

    [Required] public string? Name { get; set; }

    [Required] public string? FileName { get; set; }

    public string? Description { get; set; }

    [EnumDataType(typeof(DocumentStatus))] public DocumentStatus Status { get; set; }
}