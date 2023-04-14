using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedelApp.Contract;
using PedelApp.Contract.Dtos;

namespace PedelApp.Pages.TidsRegistrering
{
    public class CreateModel : PageModel
    {
        private readonly ITidsRegistreringService _tidsRegistreringService;

        public CreateModel(ITidsRegistreringService tidsRegistreringService)
        {
            _tidsRegistreringService = tidsRegistreringService;
        }


        [BindProperty]
        public TidsRegistreringCreateModel TidsRegistrering { get; set; } = new();

        public void OnGet()
        {
            TidsRegistrering = new TidsRegistreringCreateModel();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _tidsRegistreringService.CreateAsync(TidsRegistrering.GetAsTidsRegistreringDto());
            return RedirectToPage("./Index");
        }

        public class TidsRegistreringCreateModel
        {
            public int TidsRegistreringsId { get; set; }
            public DateTime Start { get; set; } = DateTime.Now;
            public DateTime End { get; set; } = DateTime.Now;
            public int PedelId { get; set; }
            public int RekvisitionsId { get; set; }

            public TidsRegistreringDto GetAsTidsRegistreringDto()
            {
                return new TidsRegistreringDto { RekvisitionsId = RekvisitionsId, PedelId = PedelId, Start = Start, End = End, TidsRegistreringsId = TidsRegistreringsId};
            }
        }
    }
}
