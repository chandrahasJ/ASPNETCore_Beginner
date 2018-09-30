using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesWithCRUD
{
    public class MyPageModel : PageModel
    {
        protected readonly AppDbContext _db;
        public MyPageModel(AppDbContext db)
        {
            _db = db;
        }
        
        [BindProperty]
        public Customer Customer { get; set; }
        [BindProperty]
        public IList<Customer> Customers { get; set; }

    }
}
