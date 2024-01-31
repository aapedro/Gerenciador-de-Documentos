using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class DocumentUpdate
{
    public string Description { get; set; }

    [EnumDataType(typeof(DocumentStatus))] public DocumentStatus Status { get; set; }
}