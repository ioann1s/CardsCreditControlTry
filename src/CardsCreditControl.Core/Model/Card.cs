using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CardsCreditControl.src.CardsCreditControl.Core.Model
{
    public class Card
    {
        public string CardNumber { get; set; }
        public decimal CardBalance { get; set; }
        public decimal CardPresentLimit { get; set; }
        public decimal CardECommerceLimit { get; set; }

        public DateTimeOffset Date { get; set; }


    }
}
