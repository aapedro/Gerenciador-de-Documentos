using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class DocumentFile
{
    [Required] public string? FileName { get; set; }
    [Required] public byte[]? FileBytes { get; set; }
}