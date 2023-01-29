using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositories;
using Java.Lang;

namespace AppControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
	public TransactionAdd()
	{
		InitializeComponent();        
	}

    private void OnButtonClicked_Save(object sender, EventArgs e)
    {
        if (IsValiData() == false)
        {
            return;
        }
        SaveTransactionDataBase();

        Navigation.PopAsync();

        

        App.Current.MainPage.DisplayAlert("Mensagem", "", "OK" );
    }

    private void SaveTransactionDataBase()
    {
        Transaction transaction = new Transaction()
        {
            Type = RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expenses,
            Name = EntryName.Text,
            Date = DatePikerDate.Date,
            Value = double.Parse(EntryValue.Text)
        };

        var repository = this.Handler.MauiContext.Services.GetService<ITransactionRepository>();
        repository.add(transaction);
    }

    private bool IsValiData()
    {
        bool valid = true;

        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.Append("O campo 'Nome' PRECISA ser preenchido!");
            valid = false;
        }

        if (string.IsNullOrEmpty(EntryValue.Text) || string.IsNullOrWhiteSpace(EntryValue.Text))
        {
            sb.Append("O campo 'Valor' PRECISA ser preenchido!");
            valid = false;
        }

        double result;

        if (string.IsNullOrEmpty(EntryValue.Text) && double.TryParse(EntryValue.Text, out result))
        {
            sb.Append("O campo 'Valor' é inválido!");
            valid = false;
        }

        if(valid == false)
        {
            LabelError.Text = sb.ToString();
        }
         
        return valid;
    }

    //private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    //{
    //    Navigation.PopModalAsync();
    //}
}