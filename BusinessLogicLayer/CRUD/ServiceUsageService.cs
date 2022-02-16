namespace BusinessLogicLayer.DTO
{
    using System;
    using System.Collections.Generic;

    public class ServiceUsageService
    {
        public int ServiceUsageId { get; set; }
        public int UserId { get; set; }
        public System.DateTime BeginUsage { get; set; }
        public System.DateTime EndUsage { get; set; }
        public int TotalPayment { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string ServiceShortTariffName { get; set; }
        public string ServiceComment { get; set; }
        public System.DateTime ServiceCreationDate { get; set; }
        public int ServicePrice { get; set; }
        public int ServiceUsagesCount { get; set; }
    }
}
