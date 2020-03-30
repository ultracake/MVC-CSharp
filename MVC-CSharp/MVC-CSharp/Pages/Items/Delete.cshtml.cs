using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVC_CSharp.Data;
using MVC_CSharp.Models;

namespace MVC_CSharp.Pages.Items
{
    public class DeleteModel : PageModel
    {
        private readonly MVC_CSharp.Data.ItemContext _context;

        public DeleteModel(MVC_CSharp.Data.ItemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.ItemModel.FirstOrDefaultAsync(m => m.ID == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.ItemModel.FindAsync(id);

            if (Item != null)
            {
                _context.ItemModel.Remove(Item);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
