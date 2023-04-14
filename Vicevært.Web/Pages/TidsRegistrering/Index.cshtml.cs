using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedelApp.Contract;
using PedelApp.Contract.Dtos;

namespace PedelApp.Pages.TidsRegistrering
{
    public class IndexModel : PageModel
    {
        private readonly ITidsRegistreringService _tidsRegistreringService;

        public IndexModel(ITidsRegistreringService tidsRegistreringService)
        {
            _tidsRegistreringService = tidsRegistreringService;
        }

        [BindProperty] public IEnumerable<TidsRegistreringIndexModel> TidsRegistrerings { get; set; } = Enumerable.Empty<TidsRegistreringIndexModel>();
        public async Task OnGetAsync()
        {
            var tidsRegistrerings = new List<TidsRegistreringIndexModel>();
            var dbTidsRegistrerings = await _tidsRegistreringService.GetAsync();
            dbTidsRegistrerings.ToList().ForEach(a => tidsRegistrerings.Add(new TidsRegistreringIndexModel(a)));
            TidsRegistrerings = tidsRegistrerings;
        }

        public class TidsRegistreringIndexModel
        {
            public TidsRegistreringIndexModel(TidsRegistreringDto tidsRegistrering)
            {
                TidsRegistreringsId = tidsRegistrering.TidsRegistreringsId;
                Start = tidsRegistrering.Start;
                End = tidsRegistrering.End;
                PedelId = tidsRegistrering.PedelId;
                RekvisitionsId = tidsRegistrering.RekvisitionsId; 
            }


            public int TidsRegistreringsId { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public int PedelId { get; set; }
            public int RekvisitionsId { get; set; }
        }
    }
}
