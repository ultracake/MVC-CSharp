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
    public class IndexModel : PageModel
    {
        private readonly MVC_CSharp.Data.ItemContext _context;

        public IndexModel(MVC_CSharp.Data.ItemContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public async Task OnGetAsync()
        {
            Item = await _context.ItemModel.ToListAsync();
        }
    }
}
