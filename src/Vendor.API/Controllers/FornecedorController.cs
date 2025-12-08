using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vendorhub.Model;

namespace vendorhub.Controllers;

[Route("api/v1/fornecedor")]
[ApiController]
public class FornecedorController : ControllerBase
{
    private readonly ApiDbContext _context;

    public FornecedorController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedor()
    {
        return await _context.Fornecedores.ToListAsync();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Fornecedor>> GetFornecedor(Guid id)
    {
        var fornecedor = await _context.Fornecedores.FindAsync(id);

        if (fornecedor == null)
        {
            return NotFound();
        }

        return fornecedor;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutFornecedor(Guid id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
        {
            return BadRequest();
        }

        _context.Entry(fornecedor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FornecedorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetFornecedor", new {id = fornecedor.Id}, fornecedor);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Fornecedor>> DeleteFornecedor(Guid id)
    {
        var fornecedor = await _context.Fornecedores.FindAsync(id);
        if (fornecedor == null)
        {
            return NotFound();
        }

        _context.Fornecedores.Remove(fornecedor);
        await _context.SaveChangesAsync();

        return fornecedor;

    }
    
    private bool FornecedorExists(Guid id)
    {
        return _context.Fornecedores.Any(e => e.Id == id);
    }
}