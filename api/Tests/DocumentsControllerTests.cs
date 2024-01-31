using api.Controllers;
using api.DTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class DocumentsControllerTests
{
    [Fact]
    public async Task Get_ReturnsOkObjectResult()
    {
        var documentServiceMock = new Mock<IDocumentService>();
        documentServiceMock.Setup(service => service.GetAllDocuments()).ReturnsAsync(new List<Document>());

        var controller = new DocumentsController(documentServiceMock.Object);

        var result = await controller.Get();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Document>>(okResult.Value);
        Assert.Empty(model);
    }

    [Fact]
    public async Task Post_ReturnsOkResult()
    {
        var documentServiceMock = new Mock<IDocumentService>();
        var controller = new DocumentsController(documentServiceMock.Object);
        var dto = new AddDocumentDto();

        var result = await controller.Post(dto);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsOkResult()
    {
        
        var documentServiceMock = new Mock<IDocumentService>();
        var controller = new DocumentsController(documentServiceMock.Object);
        var id = 1;

        var result = await controller.Delete(id);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task Patch_ReturnsOkResult()
    {
        var documentServiceMock = new Mock<IDocumentService>();
        var controller = new DocumentsController(documentServiceMock.Object);
        var id = 1;
        var dto = new EditDocumentDto();

        var result = await controller.Patch(id, dto);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task GetDownload_ReturnsPhysicalFileResult()
    {
        var documentServiceMock = new Mock<IDocumentService>();
        documentServiceMock.Setup(service => service.GetFilePath(It.IsAny<int>())).ReturnsAsync("fake/path/document.pdf");

        var controller = new DocumentsController(documentServiceMock.Object);
        var id = 1;

        var result = await controller.Get(id);

        var physicalFileResult = Assert.IsType<PhysicalFileResult>(result);
        Assert.Equal("application/octet-stream", physicalFileResult.ContentType);
        Assert.Equal("document.pdf", physicalFileResult.FileName);
    }
}
