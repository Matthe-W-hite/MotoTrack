/*using Microsoft.AspNetCore.Mvc;
using MotoTrack.API.Data;
using MotoTrack.API.Models;

namespace MotoTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    public DocumentsController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    [HttpPost("{carId}")]
    public async Task<IActionResult> UploadDocument(int carId, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Nie przesłano pliku.");

        var uploadsPath = Path.Combine(_env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "uploads");
        Directory.CreateDirectory(uploadsPath);

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var fullPath = Path.Combine(uploadsPath, fileName);

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var doc = new Document
        {
            CarId = carId,
            FileName = file.FileName,
            FilePath = $"/uploads/{fileName}",
            UploadDate = DateTime.Now
        };

        _context.Documents.Add(doc);
        await _context.SaveChangesAsync();

        return Ok(doc);
    }
}
*/