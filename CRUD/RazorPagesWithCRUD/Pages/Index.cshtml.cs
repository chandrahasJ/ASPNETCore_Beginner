using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesWithCRUD.Pages
{
    public class IndexModel : MyPageModel
    { 
        public IndexModel(AppDbContext dbContext) : base(dbContext)
        {            
        }

        public async Task OnGetAsync()
        {
            this.Customers = await _db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int deleteId)
        {
            var customer = _db.Customers.Find(deleteId);
            if(customer != null)
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostView(int ViewId)
        {
            return RedirectToPage("/View", routeValues: new { ViewId = ViewId });
        }
    }
}
