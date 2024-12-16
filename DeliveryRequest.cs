namespace _3_лабораторная
{
    public class DeliveryRequest
    {
        public string From { get; set; } // Адрес или координаты отправления
        public string To { get; set; } // Адрес или координаты назначения
        public double Weight { get; set; } // Вес груза
        public Dimensions Dimensions { get; set; } // Габариты груза
        public string DeliveryType { get; set; } // Тип доставки (стандартная, экспресс)
    }

    public class Dimensions
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
