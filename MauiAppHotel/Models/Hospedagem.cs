namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int Estadias
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }

        public double ValorTotal
        {
            get
            {
                double valor_adultos = QntAdultos * QuartoSelecionado.valorDiariaAdulto;
                double valor_criancas = QntCriancas * QuartoSelecionado.valorDiariaCrianca;

                double total = (valor_adultos + valor_criancas) * Estadias;

                return total;
            }
        }
    }
}
