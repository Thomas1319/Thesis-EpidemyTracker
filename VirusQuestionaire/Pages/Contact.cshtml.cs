using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirusQuestionaire.Data;
using VirusQuestionaire.Models;

namespace VirusQuestionaire.Pages
{
    public class ContactModel : PageModel
    {
        private readonly VirusQuestionaire.Data.ContactContext _context;

        public ContactModel(VirusQuestionaire.Data.ContactContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Message Message { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["contactResult"] = "The data you wrote is invalid, please revise.";
                return Page();
            }
            TempData["contactResult"] = "Your question has been sent successfully!";
            _context.Message.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Contact");
        }
    }
}
