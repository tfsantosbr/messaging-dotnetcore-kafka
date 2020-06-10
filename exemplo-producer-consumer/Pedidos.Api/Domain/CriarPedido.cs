using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedidos.Api.Domain
{
    public class CriarPedido
    {
        public string Cliente { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
