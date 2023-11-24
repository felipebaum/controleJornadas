﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.JornadasCRUD
{
    public class CreateModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public CreateModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Jornadas Jornadas { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Jornadas.Add(Jornadas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
