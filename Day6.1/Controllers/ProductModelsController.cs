
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day6._1.Models;

public class ProductModelsController : Controller
{
    private readonly Day6_1Context _context;

    public ProductModelsController(Day6_1Context context)
    {
        _context = context;
    }

    // GET: PRODUCTMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.ProductModel.ToListAsync());
    }

    // GET: PRODUCTMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productmodel = await _context.ProductModel
            .FirstOrDefaultAsync(m => m.id == id);
        if (productmodel == null)
        {
            return NotFound();
        }

        return View(productmodel);
    }

    // GET: PRODUCTMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUCTMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,name,price,quantity")] ProductModel productmodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(productmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(productmodel);
    }

    // GET: PRODUCTMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productmodel = await _context.ProductModel.FindAsync(id);
        if (productmodel == null)
        {
            return NotFound();
        }
        return View(productmodel);
    }

    // POST: PRODUCTMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("id,name,price,quantity")] ProductModel productmodel)
    {
        if (id != productmodel.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(productmodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(productmodel.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(productmodel);
    }

    // GET: PRODUCTMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productmodel = await _context.ProductModel
            .FirstOrDefaultAsync(m => m.id == id);
        if (productmodel == null)
        {
            return NotFound();
        }

        return View(productmodel);
    }

    // POST: PRODUCTMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var productmodel = await _context.ProductModel.FindAsync(id);
        if (productmodel != null)
        {
            _context.ProductModel.Remove(productmodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductModelExists(int? id)
    {
        return _context.ProductModel.Any(e => e.id == id);
    }
}
