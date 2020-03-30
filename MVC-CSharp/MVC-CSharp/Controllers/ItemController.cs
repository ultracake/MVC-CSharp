using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CSharp.Data;
using MVC_CSharp.Models;

namespace MVC_CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemContext _context;

        public ItemController(ItemContext context)
        {
            _context = context;
        }

        // GET: api/ItemModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemModel()
        {
            return await _context.ItemModel.ToListAsync();
        }

        // GET: api/ItemModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemModel(int id)
        {
            var itemModel = await _context.ItemModel.FindAsync(id);

            if (itemModel == null)
            {
                return NotFound();
            }

            return itemModel;
        }

        // PUT: api/ItemModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemModel(int id, Item itemModel)
        {
            if (id != itemModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(itemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemModelExists(id))
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

        // POST: api/ItemModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Item>> PostItemModel(Item itemModel)
        {
            _context.ItemModel.Add(itemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemModel", new { id = itemModel.ID }, itemModel);
        }

        // DELETE: api/ItemModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItemModel(int id)
        {
            var itemModel = await _context.ItemModel.FindAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }

            _context.ItemModel.Remove(itemModel);
            await _context.SaveChangesAsync();

            return itemModel;
        }

        private bool ItemModelExists(int id)
        {
            return _context.ItemModel.Any(e => e.ID == id);
        }
    }
}
