namespace _3_лабораторная
{
    public class AvailableDeliveryOptionsResponse
    {
        public List<DeliveryOption> Options { get; set; }
    }

    public class DeliveryOption
    {
        public string Type { get; set; } // Тип доставки (курьерская, почтовая, самовывоз)
        public string DeliveryTime { get; set; } // Срок доставки для данного способа
    }
}
