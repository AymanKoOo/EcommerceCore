using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites.Base;

namespace Core.Entites
{
    public class Cart:EntityBase
    {
        public string UserName { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
