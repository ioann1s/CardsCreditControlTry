using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardsCreditControl
{
    public class CardTransaction
    {
        
        public string CardNumber { get; set; }
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Created { get; set; }

        public bool status { get; set; }


        public int TransactionType { get; set; }
        public CardTransaction()
        {
            TransactionId = Guid.NewGuid(); //Αρχικοποίηση TransactionId
            Created = DateTimeOffset.Now.Date.ToString("yyyy-MM-dd");
            
        }
    }
}