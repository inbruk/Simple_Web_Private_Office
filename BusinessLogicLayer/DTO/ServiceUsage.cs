namespace BusinessLogicLayer.DTO
{
    using System;
    using System.Collections.Generic;

    public class ServiceUsage
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Service { get; set; }
        public DateTime BeginUsage { get; set; }
        public DateTime EndUsage { get; set; }
        public int TotalPayment { get; set; }
    }
}
