using AppControleFinanceiro.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly LiteDatabase _database;
        private readonly string colletionName = "transaction";
        public TransactionRepository(LiteDatabase database)
        {
            _database = database;
        }
        public List<Transaction> GetAll()
        {
            return _database.GetCollection<Transaction>("transactions").Query().OrderByDescending(a=>a.Date).ToList();
        }
        public void add(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(colletionName);         
            col.Insert(transaction);

            col.EnsureIndex(a=>a);
        }
        public void update(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(colletionName);
            col.Update(transaction);
        }
        public void remove(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(colletionName);
            col.Delete(transaction.Id);
        }
    }
}
