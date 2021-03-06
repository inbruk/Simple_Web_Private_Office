namespace BusinessLogicLayer.DTO
{
    using System;
    using System.Collections.Generic;

    public class UserAccountUserType
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Blocked { get; set; }
        public DateTime CreationDate { get; set; }
        public string FullName { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string WebPage { get; set; }
        public string ICQ { get; set; }
        public string Email { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeComment { get; set; }
        public int AccountId { get; set; }
        public long AccountPersonalAccount { get; set; }
        public int AccountBalance { get; set; }
        public int AccountRecommendedPayment { get; set; }
        public int AccountCredit { get; set; }
    }
}
