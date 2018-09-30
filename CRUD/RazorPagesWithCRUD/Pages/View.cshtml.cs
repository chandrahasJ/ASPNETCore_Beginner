using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesWithCRUD.Pages
{
    public class ViewModel : MyPageModel
    {
        public ViewModel(AppDbContext appDbContext):base(appDbContext)
        {

        }
        public async Task<IActionResult> OnGetAsync(int ViewId)
        {
            Customer = await _db.Customers.FindAsync(ViewId);
            if(Customer == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}