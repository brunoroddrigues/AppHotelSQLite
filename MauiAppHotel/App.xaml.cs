using MauiAppHotel.Helpers;
using MauiAppHotel.Models;
namespace MauiAppHotel
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelper database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ContratacaoHospedagem());
        }

        /*
         * Declaração lista de objetos do tipo Quarto.
        */

        public List<Quarto> lista_quarto = new List<Quarto>()
        {
            new Quarto() {
                Descricao = "Suite Super Luxo",
                valorDiariaAdulto = 110.0,
                valorDiariaCrianca = 100.0
            },
            new Quarto() {
                Descricao = "Suite Super",
                valorDiariaAdulto = 100.0,
                valorDiariaCrianca = 90.0
            },
            new Quarto() {
                Descricao = "Suite Single",
                valorDiariaAdulto = 50.0,
                valorDiariaCrianca = 25.0
            }
        };

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 600;
            window.Height = 700;

            return window;
        }

        public static SQLiteDataBaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData
                        ), "slqlite.db3"
                    );

                    database = new SQLiteDataBaseHelper(path);
                }

                return database;
            }
        }
    }
}
