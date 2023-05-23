using appMVVM.Models;
using appMVVM.ViewModel;

namespace appMVVM.View;

public partial class PageFavoritos : ContentPage
{
	public PageFavoritos()
	{
		InitializeComponent();
    }

    public void PegaJson()
    {
        BD bd = new BD();
        var data = bd.List();
        listaFav.ItemsSource = data;
    }

    private void RemoveFavorite(object sender, EventArgs e)
    {
        Button btRmove = (Button)sender;
        var item = btRmove.BindingContext as Traducao;

        if (item != null)
        {
            string traz = item.traduzir;
            string trac = item.traducao;
            Traducao tr = new Traducao
            {
                traduzir = traz,
                traducao = trac
            };

            BD bd = new BD();
            bd.Delete(tr);
            PegaJson();
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Atualizar a fonte de dados do ListView sempre que a página for exibida
        PegaJson();
    }
}