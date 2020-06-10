using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Worker.Messages
{
    public class CriarPedidoMessage
    {
        public string Cliente { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
