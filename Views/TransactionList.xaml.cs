namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
	public TransactionList()
	{
		InitializeComponent();
	}

	private void OnButtonClicked_To_TransactionAdd(object sender, EventArgs args)
	{
        Navigation.PushAsync(new TransactionAdd());

        // Chamar a página sem a Navigation
        //App.Current.MainPage = new TransactionAdd();
    }

    private void OnButtonClicked_To_TransactionEdit(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TransactionEdit());
        //App.Current.MainPage = new TransactionEdit();
    }
}