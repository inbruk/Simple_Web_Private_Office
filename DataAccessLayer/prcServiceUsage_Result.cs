//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    
    public partial class prcServiceUsage_Result
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
