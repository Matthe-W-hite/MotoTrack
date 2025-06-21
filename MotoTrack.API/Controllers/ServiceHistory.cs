using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoTrack.API.Data;
using MotoTrack.API.Models;

[Route("api/[controller]")]
[ApiController]
public class ServiceHistoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServiceHistoryController(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Document> Documents { get; set; } = new();

    // GET: api/ServiceHistory/car/3
    [HttpGet("car/{carId}")]
    public async Task<IActionResult> GetByCarId(int carId)
    {
        var entries = await _context.ServiceHistories
            .Where(h => h.CarId == carId)
            .ToListAsync();
        return Ok(entries);
    }

    // GET: api/ServiceHistory/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entry = await _context.ServiceHistories.FindAsync(id);
        return entry == null ? NotFound() : Ok(entry);
    }

    // POST: api/ServiceHistory
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ServiceHistory entry)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.ServiceHistories.Add(entry);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = entry.Id }, entry);
    }


    // PUT: api/ServiceHistory/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ServiceHistory entry)
    {
        if (id != entry.Id)
            return BadRequest("Identyfikatory się nie zgadzają.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Entry(entry).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }


    // DELETE: api/ServiceHistory/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entry = await _context.ServiceHistories.FindAsync(id);
        if (entry == null) return NotFound();

        _context.ServiceHistories.Remove(entry);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // POST: api/ServiceHistory/{id}/documents
    [HttpPost("{id}/documents")]
    public async Task<IActionResult> UploadDocument(int id, IFormFile file)
    {
        Console.WriteLine($"[UPLOAD] Wywołano UploadDocument dla wpisu {id}");

        if (file == null)
        {
            Console.WriteLine("[UPLOAD] Brak pliku (null)");
            return BadRequest("Plik nie został przesłany.");
        }

        if (file.Length == 0)
        {
            Console.WriteLine($"[UPLOAD] Pusty plik: {file.FileName}");
            return BadRequest("Plik jest pusty.");
        }

        Console.WriteLine($"[UPLOAD] Otrzymano plik: {file.FileName}, typ: {file.ContentType}, rozmiar: {file.Length} bajtów");

        if (file == null || file.Length == 0)
            return BadRequest("Nie przesłano żadnego pliku.");

        var entry = await _context.ServiceHistories.FindAsync(id);
        if (entry == null)
            return NotFound("Nie znaleziono wpisu serwisowego.");

        var fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
        var uploadPath = Path.Combine("wwwroot", "uploads", fileName);

        using (var stream = new FileStream(uploadPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var document = new Document
        {
            FileName = file.FileName,
            FilePath = $"/uploads/{fileName}",
            UploadDate = DateTime.UtcNow,
            ServiceHistoryId = id
        };

        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        return Ok(new { document.Id, document.FileName, document.FilePath });
    }
    // GET: api/ServiceHistory/{id}/documents
    [HttpGet("{id}/documents")]
    public async Task<IActionResult> GetDocuments(int id)
    {
        var documents = await _context.Documents
            .Where(d => d.ServiceHistoryId == id)
            .Select(d => Url.Content(d.FilePath)) 
            .ToListAsync();

        return Ok(documents);
    }


}
