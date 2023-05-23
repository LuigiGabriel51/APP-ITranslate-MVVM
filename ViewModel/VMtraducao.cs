using CommunityToolkit.Mvvm.ComponentModel;
using appMVVM.Models;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace appMVVM.ViewModel
{
    public class VMtraducao : ObservableObject
    {
        private Traducao _traducao;
        public Traducao TRADUCAO
        {
            get { return _traducao; }
            set { SetProperty(ref _traducao, value); }
        }
        private string _traduzir;
        public string Traduzir
        {
            get { return _traduzir; }
            set { SetProperty(ref _traduzir, value); }
        }

        private string _idiomaO;
        public string IdiomaO
        {
            get { return _idiomaO; }
            set { SetProperty(ref _idiomaO, value); }
        }



        private string _idiomaT;
        public string IdiomaT
        {
            get { return _idiomaT; }
            set { SetProperty(ref _idiomaT, value); }
        }
        public IAsyncRelayCommand favoritar { get; }
        public IAsyncRelayCommand gettraducao { get; }

        public VMtraducao()
        {
            gettraducao = new AsyncRelayCommand(getTraducao);
            favoritar = new AsyncRelayCommand(Favoritar);
        }
        private async Task getTraducao()
        {
            Dictionary<string, string> idiomaMapping = new Dictionary<string, string>
            {
                { "PORTUGUES", "pt" },
                { "INGLES", "en" },
                { "ESPANHOL", "es" },
                { "FRANCES", "fr" },
                { "ALEMAO", "de" },
                { "ITALIANO", "it" }
            };

            // Obtenha o valor selecionado do primeiro picker
            string idiomaOSelecionado = (string)IdiomaO;

            // Obtenha o valor mapeado correspondente
            string idiomaOMapeado = idiomaMapping[idiomaOSelecionado];

            // Faça o mesmo para o segundo picker
            string idiomaTSelecionado = (string)IdiomaT;
            string idiomaTMapeado = idiomaMapping[idiomaTSelecionado];


            Console.WriteLine(idiomaOMapeado+"  "+idiomaTMapeado+""+Traduzir);

            WeatherApiClient http = new WeatherApiClient();
            string dados = await http.GetWeatherData(Traduzir, idiomaOMapeado, idiomaTMapeado);


            TRADUCAO = new Traducao
            {
                traducao = dados
            };
            

        }

        private async Task Favoritar()
        {
            if(Traduzir != null && TRADUCAO.traducao != null)
            {
                Traducao tr = new Traducao
                {
                    traduzir = Traduzir,
                    traducao = TRADUCAO.traducao
                };
                BD bd = new BD();
                bd.Create(tr);
            }
        }

        public class WeatherApiClient
        {
            private readonly HttpClient _httpClient;
            private const string APIUrl = "https://api.mymemory.translated.net/get";

            public WeatherApiClient()
            {
                _httpClient = new HttpClient();
            }

            public async Task<string> GetWeatherData(string text, string sourceLanguage, string targetLanguage)
            {
                string apiUrl = $"{APIUrl}?q={Uri.EscapeDataString(text)}&langpair={sourceLanguage}|{targetLanguage}";

                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var translationResponse = JsonConvert.DeserializeObject<TranslationResponse>(responseBody);
                        string translatedText = translationResponse?.responseData?.translatedText;
                        Console.WriteLine(translatedText);
                        return translatedText;
                    }
                    else
                    {
                        return null;
                    }

                }
                catch
                {
                    return null;
                }
            }
        }
        public class ResponseData
        {
            public string translatedText { get; set; }
        }

        public class TranslationResponse
        {
            public ResponseData responseData { get; set; }
        }

    }
}
