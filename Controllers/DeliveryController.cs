namespace _3_лабораторная.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using DeliveryService;
    using Swashbuckle.AspNetCore.Annotations;

    namespace DeliveryService.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class DeliveryController : ControllerBase
        {
            [HttpPost("calculate-cost")]

            [SwaggerOperation(
                EndpointSummaryAttribute = "Калькулятор стоимости",
                Description = "Этот метод высчитывает стоимость доставки")]
            public ActionResult<DeliveryResponse> CalculateCost([FromBody] DeliveryRequest request)
            {
                if (request == null || request.Weight <= 0 || request.Dimensions == null)
                {
                    return BadRequest("Invalid request");
                }

                // Логика расчета стоимости и срока доставки (пример)
                double cost = CalculateDeliveryCost(request.Weight, request.Dimensions, request.DeliveryType);
                string deliveryTime = request.DeliveryType == "экспресс" ? "1 день" : "3-5 дней";

                var response = new DeliveryResponse
                {
                    Cost = cost,
                    DeliveryTime = deliveryTime
                };

                return Ok(response);
            }

            [HttpGet("available-options")]
            [SwaggerOperation(
                EndpointSummaryAttribute = "Доступные опции",
                Description = "Этот метод определяет доступные опции лоставки")]
            public ActionResult<AvailableDeliveryOptionsResponse> GetAvailableOptions([FromQuery] string from, [FromQuery] string to)
            {
                if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                {
                    return BadRequest("From and To locations are required");
                }

                // Логика определения доступных способов доставки (пример)
                var options = new AvailableDeliveryOptionsResponse
                {
                    Options = new List<DeliveryOption>
                {
                    new DeliveryOption { Type = "Курьерская", DeliveryTime = "1-2 дня" },
                    new DeliveryOption { Type = "Почтовая", DeliveryTime = "3-7 дней" },
                    new DeliveryOption { Type = "Самовывоз", DeliveryTime = "в тот же день" }
                }
                };

                return Ok(options);
            }

            private double CalculateDeliveryCost(double weight, Dimensions dimensions, string deliveryType)
            {
                // Пример простой логики расчета стоимости
                double baseCost = 100; // Базовая стоимость
                double weightCost = weight * 10; // Стоимость за вес
                double dimensionsCost = (dimensions.Length + dimensions.Width + dimensions.Height) * 2; // Стоимость за габариты

                double totalCost = baseCost + weightCost + dimensionsCost;

                if (deliveryType == "экспресс")
                {
                    totalCost *= 1.5; // Увеличиваем стоимость для экспресс-доставки
                }

                return totalCost;
            }
        }
    }
}
