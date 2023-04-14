using System.ComponentModel.DataAnnotations;

namespace PedelApp.Domain
{
    public class Pedel
    {
        //public IServiceProvider? ServiceProvider { get; set; }

        [Key]
        public int PedelId { get; set; }
        public string PedelNavn { get; private set; }
        public int TelefonNr { get; private set; }


    }
}