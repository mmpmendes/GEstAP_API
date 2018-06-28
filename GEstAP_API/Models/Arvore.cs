using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEstAP_API.Models
{
    public class Tree<K,V> : Dictionary<K, Tree<K,V>>
    {
        public V value { get; set; }
    }
}