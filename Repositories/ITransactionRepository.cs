using AppControleFinanceiro.Models;

namespace AppControleFinanceiro.Repositories
{
    internal interface ITransactionRepository
    {
        void add(Transaction transaction);
        List<Transaction> GetAll();
        void remove(Transaction transaction);
        void update(Transaction transaction);
    }
}