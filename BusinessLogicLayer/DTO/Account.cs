namespace BusinessLogicLayer.DTO
{
    using System;
    using System.Collections.Generic;

    public class Account
    {
        public int Id { get; set; }
        public long PersonalAccount { get; set; }
        public int Balance { get; set; }
        public int RecommendedPayment { get; set; }
        public int Credit { get; set; }
    }
}
