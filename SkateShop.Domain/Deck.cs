using System;
using System.Collections.Generic;
using System.Text;

namespace SkateShop.Domain
{
    public class Deck
    {
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public string Brand { get; set; }
        public float Size { get; set; }
        public float Price { get; set; }
    }
}
