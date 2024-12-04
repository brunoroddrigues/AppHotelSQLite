using MauiAppHotel.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public Hospedagem Hospedagem { get; set; }

    public HospedagemContratada(Hospedagem? hospedagem)
	{
        if (hospedagem != null)
        {
            this.Hospedagem = hospedagem;
        }

		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            if (Hospedagem != null)
            {
                Quarto quarto = new Quarto()
                {
                    Descricao = this.Hospedagem.QuartoSelecionado.Descricao
                };

                Hospedagem hospedagem = new Hospedagem
                {
                    QuartoSelecionado = quarto,
                    QntAdultos = this.Hospedagem.QntAdultos,
                    QntCriancas = this.Hospedagem.QntCriancas,
                    DataCheckIn = this.Hospedagem.DataCheckIn,
                    DataCheckOut = this.Hospedagem.DataCheckOut                    
                };

                /*
                 * Removendo R$ do lebel valor_total;
                 */
                string valor = Regex.Match(valor_total.Text, @"\d+,\d+").Value;
                double valorDouble = double.Parse(valor, NumberStyles.Currency, new CultureInfo("pt-br"));

                Historico historico = new Historico
                {
                    ValorTotal = Convert.ToDouble(valor),
                    Hospedagem = hospedagem
                };
                
                DisplayAlert(
                    "Ops",
                    "DADOS:" +
                    $"\nQuarto: {hospedagem.QuartoSelecionado.Descricao}" +
                    $"\nQtd Adultos: {hospedagem.QntAdultos}" +
                    $"\nQtd Crianças{hospedagem.QntCriancas}" +
                    $"\nData Check-in: {hospedagem.DataCheckIn}" +
                    $"\nData Check-out: {hospedagem.DataCheckOut}" +
                    $"\nValor: {historico.ValorTotal}" +
                    $"\nEstadias: {hospedagem.Estadias}",
                    "Ok"
                );

                /*
                 * SALVAR NO BANCO DE DADOS
                */
                //await App.Database.Insert(historico);
            }


        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}