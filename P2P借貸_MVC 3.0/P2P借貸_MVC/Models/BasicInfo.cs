//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace P2P借貸_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BasicInfo
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string Password { get; set; }
        public string MemberNickName { get; set; }
        public string eMail { get; set; }
        public string Gender { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string 最高學歷 { get; set; }
        public string 就業狀態 { get; set; }
        public string WorkPlace { get; set; }
        public string BankCode { get; set; }
        public string BankAccount { get; set; }
        public byte[] Photo { get; set; }
        public int PermissionLevel { get; set; }
    
        public virtual Bank Bank { get; set; }
        public virtual Definition Definition { get; set; }
    }
}
