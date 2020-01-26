using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreLibrary.DataAccess;
using StoreLibrary.Models;

namespace GoldenShoe.Site
{
    public class TestingModel : PageModel
    {
        private readonly StoreLibrary.DataAccess.PeopleContext _context;

        public TestingModel(StoreLibrary.DataAccess.PeopleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SupportRequests SupportRequests { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Requests.Add(SupportRequests);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
