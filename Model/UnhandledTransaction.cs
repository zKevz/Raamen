using System;
using System.Collections.Generic;

namespace Raamen.Model
{
    public class UnhandledTransaction
    {
        public User Customer { get; set; }
        public DateTime Date { get; set; }
        public List<RamenCart> Carts { get; set; }
    }
}