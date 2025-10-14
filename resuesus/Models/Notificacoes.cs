using static System.Runtime.InteropServices.JavaScript.JSType;

namespace resuesus.Models
{
    public class Notificacoes
    {
        public Guid Id { get; set; }
        public string Operacao { get; set; }
        public string Endereco { get; set; }
        public int NumeroCasa { get; set; }
        public DateTime? CreatedDate { get; set; }
        public TimeSpan? CreatedTime { get; set; }
        public bool Status { get; set; }
        public string Distancia { get; set; }
    }
}
