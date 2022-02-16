namespace BusinessLogicLayer.DTO
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public Nullable<int> Account { get; set; }
        public bool Blocked { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string FullName { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string WebPage { get; set; }
        public string ICQ { get; set; }
        public string Email { get; set; }
    }
}
