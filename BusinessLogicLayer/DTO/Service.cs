namespace BusinessLogicLayer.DTO
{
    using System;
    using System.Collections.Generic;

    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortTariffName { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public int Price { get; set; }
        public int UsagesCount { get; set; }
    }
}
