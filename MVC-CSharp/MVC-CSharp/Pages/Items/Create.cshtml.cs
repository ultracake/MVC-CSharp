﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_CSharp.Data;
using MVC_CSharp.Models;

namespace MVC_CSharp.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly MVC_CSharp.Data.ItemContext _context;

        public CreateModel(MVC_CSharp.Data.ItemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ItemModel.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public IActionResult MyIncrement(int i)
        {
            
            i++;
            return Page();
        }
    }

}
