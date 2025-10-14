namespace resuesus.Models
{
    public class Historico
    {
        public Guid HistoricoId { get; set; }
        public string Operacao { get; set; }
        public string Endereco { get; set; }
        public int? NumeroCasa { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Status { get; set; }
        // vincular o historico ao perfil
        public Guid? PerfilId { get; set; }
        public Perfil? Perfil { get; set; }
    }
}
