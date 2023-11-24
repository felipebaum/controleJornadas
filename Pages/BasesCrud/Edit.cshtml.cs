﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.BasesCrud
{
    public class EditModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public EditModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bases Bases { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bases =  await _context.Bases.FirstOrDefaultAsync(m => m.Idbase == id);
            if (bases == null)
            {
                return NotFound();
            }
            Bases = bases;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bases).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasesExists(Bases.Idbase))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BasesExists(int id)
        {
            return _context.Bases.Any(e => e.Idbase == id);
        }
    }
}