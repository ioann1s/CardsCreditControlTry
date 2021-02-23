using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsCreditControl.src.CardsCreditControl.Core.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardsCreditControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        // GET: api/<TransactionsController>
        [HttpGet]

        public string Get(string CardNumber, int TransactionType, decimal Amount)
        {
            using var dbContext = new CardDbContext();

            var Transaction = new CardTransaction()
            {
                CardNumber = CardNumber,
                TransactionType = TransactionType,
                Amount = Amount

            };


            var CardInfo2 = new Card();
            CardInfo2.CardNumber = Transaction.CardNumber;
            CardInfo2.Date = Convert.ToDateTime(Transaction.Created);
            var CardInfo = dbContext
                .Set<Card>()
                .Where(c => c.CardNumber == CardNumber & c.Date == DateTimeOffset.Now.Date)
                .SingleOrDefault();

            bool CheckOrder;
            if (CardInfo is null)
            {
                decimal v = Convert.ToDecimal(0);
                CardInfo2.CardPresentLimit = v;
                CardInfo2.CardECommerceLimit = v;
                CheckOrder = false;
            }
            else
            {
                CheckOrder = true;
                CardInfo2.CardPresentLimit = CardInfo.CardPresentLimit;
                CardInfo2.CardECommerceLimit = CardInfo.CardECommerceLimit;
            };




            if (Transaction.TransactionType == 0)
            { if ((Amount + CardInfo2.CardPresentLimit) <= 1500)
                {
                    CardInfo2.CardPresentLimit = CardInfo2.CardPresentLimit + Amount;
                    
                    Transaction.status = true;
                    CheckOrder = true;
                    
                };
                if ((Amount + CardInfo2.CardPresentLimit) > 1500)
                {
                    
                    Transaction.status = false;
                    CheckOrder = false;
                }
            }
            else
            {
                if ((Amount + CardInfo2.CardECommerceLimit) <= 500)
                {
                    CardInfo2.CardECommerceLimit = CardInfo2.CardECommerceLimit + Amount;
                    
                    Transaction.status = true;
                    CheckOrder = true;
                };
                if ((Amount + CardInfo2.CardECommerceLimit) > 500)
                {
                    Transaction.status = false;
                    CheckOrder = false;
                }
            }



            dbContext.Add(Transaction);


            if (CardInfo is null)
            {
                if (CheckOrder == true)
                {
                    dbContext.Add(CardInfo2);
                };
            }
            else
                if (CheckOrder == true)
            {
               /*
                dbContext.Update<Card>
                .CardECommerceLimit = CardInfo2.CardPresentLimit;
                .CardPresentLimit = CardInfo2.CardPresentLimit;
                */
            };
            //else dbContext.Update(CardInfo2);


            dbContext.SaveChanges();


            if (CheckOrder == true)
            {
                return CardNumber +
                   //+ (if CheckOrder == true) {
                   " order was accepted,\n   CardPresentLimit ="
                        + CardInfo2.CardPresentLimit + " CardECommerceLimit="
                        + CardInfo2.CardECommerceLimit;
             }

            else
            {
                return CardNumber +
                   //+ (if CheckOrder == true) {
                   " order was NOT accepted,\n    CardPresentLimit ="
                        + CardInfo2.CardPresentLimit + " CardECommerceLimit="
                        + CardInfo2.CardECommerceLimit;
            };

                     //};
            //else { "order was accepted,\n CardPresentLimit ="
            //     + CardInfo2.CardPresentLimit + " CardECommerceLimit="
            //     + CardInfo2.CardECommerceLimit});
            //    ;

        }
    //CardsCreditControl.card


    //// GET api/<TransactionsController>/5
    //[HttpGet("{id}")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<TransactionsController>
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT api/<TransactionsController>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    }
}
