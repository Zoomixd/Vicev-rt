using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedelApp.Contract;
using PedelApp.Contract.Dtos;

namespace PedelApp.Pages.TidsRegistrering
{
    public class DetailsModel : PageModel
    {
        private readonly ITidsRegistreringService _tidsRegistreringService;

        public DetailsModel(ITidsRegistreringService tidsRegistreringService)
        {
            _tidsRegistreringService = tidsRegistreringService;
        }

        [FromRoute] public int TidsRegistreringsId { get; set; }
        [BindProperty] public TidsRegistreringDetailsModel TidsRegistrering { get; set; } = new();


        public async Task<IActionResult> OnGetAsync(int? tidsRegistreringsid)
        {
            if (tidsRegistreringsid == null) return NotFound();

            var domainTidsRegistrerings = await _tidsRegistreringService.GetAsync(tidsRegistreringsid.Value);
            if (domainTidsRegistrerings == null) return NotFound();

            TidsRegistrering = TidsRegistreringDetailsModel.CreateFromTidsRegistreringDto(domainTidsRegistrerings);

            return Page();
        }

        public class TidsRegistreringDetailsModel
        {
            public TidsRegistreringDetailsModel()
            {
            }

            private TidsRegistreringDetailsModel(TidsRegistreringDto tidsRegistrering)
            {
                TidsRegistreringsId = tidsRegistrering.TidsRegistreringsId;
                Start = tidsRegistrering.Start;
                End = tidsRegistrering.End;
                PedelId = tidsRegistrering.PedelId;
                RekvisitionsId = tidsRegistrering.RekvisitionsId;
            }

            public int TidsRegistreringsId { get; set; }
            public DateTime Start { get; set; } = DateTime.Now;
            public DateTime End { get; set; } = DateTime.Now;
            public int PedelId { get; set; }
            public int RekvisitionsId { get; set; }

            public TidsRegistreringDto GetAsTidsRegistreringCommandDto()
            {
                return new TidsRegistreringDto { RekvisitionsId = RekvisitionsId, PedelId = PedelId, Start = Start, End = End, TidsRegistreringsId = TidsRegistreringsId };
            }

            public static TidsRegistreringDetailsModel CreateFromTidsRegistreringDto(TidsRegistreringDto tidsRegistrering)
            {
                return new TidsRegistreringDetailsModel(tidsRegistrering);
            }
        }
    }
}
