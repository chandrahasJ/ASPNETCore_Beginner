using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWithCRUD.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext db;
        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(AppDbContext _db)
        {
            db = _db;
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            db.Cutomers.Add(Customer);
            await db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}