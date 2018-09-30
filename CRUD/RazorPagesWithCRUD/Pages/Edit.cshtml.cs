using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesWithCRUD.Pages
{
    public class EditModel : MyPageModel
    {
        public EditModel(AppDbContext appDbContext):base(appDbContext)
        {

        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _db.Customers.FindAsync(id);
            if(Customer == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {                       
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                _db.Customers.Attach(Customer).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"Customer {Customer.Name} not found. Try Again", e);                
            }
            

            return RedirectToPage("/Index");
        }
    }
}