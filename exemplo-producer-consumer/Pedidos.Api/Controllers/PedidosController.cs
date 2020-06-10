using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedidos.Api.Domain;

namespace Pedidos.Api.Controllers
{
    [ApiController]
    [Route("pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;

        public PedidosController(ILogger<PedidosController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido(CriarPedido request)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var topic = "pedidos-topico";

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var response = await producer.ProduceAsync(topic, new Message<Null, string> { Value = requestJson });
                
                _logger.LogInformation($"Mensagem enviada '{response.Value}' para '{response.TopicPartitionOffset}'");
            }

            return Ok();
        }
    }
}
