using System;
using System.Collections.Generic;
using System.Text;

namespace SemEspera.Models
{
    public class ProdutoJson
    {
        public int ProdutoId { get; set; }
        public Dictionary<int, int> IngredientesAlterados { get; set; }
    }
}
