using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWithCRUD.Pages
{
    public class CreateModel : MyPageModel
    {        
        public CreateModel(AppDbContext _db) : base(_db)
        {
            
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            this._db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $"Customer {Customer.Name} has been added!!!!";

            return RedirectToPage("/Index");
        }
    }
}