using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P2P借貸_MVC.Models
{
    [MetadataType(typeof(MemberMetaData))]
    public partial class BasicInfo
    {
        public class MemberMetaData
        {            
            [DisplayName("會員ID")]
            public int MemberID { get; set; }

            [Required(ErrorMessage = "需輸入名字")]
            [DisplayName("會員名稱")]
            public string MemberName { get; set; }

            [Required(ErrorMessage = "需輸入密碼")]
            [DisplayName("密碼")]
            public string Password { get; set; }

            [DisplayName("暱稱")]
            public string MemberNickName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            [EmailAddress(ErrorMessage = "信箱格式不正確")]
            //[DisplayName("eMail")]
            public string eMail { get; set; }

            [Required]
            [DisplayName("性別")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "需輸入出生日期")]
            [DisplayName("出生日期")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
            public System.DateTime Birthday { get; set; }

            [Required(ErrorMessage = "需輸入電話號碼")]
            [DisplayName("電話號碼")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "需輸入住址")]
            [DisplayName("住址")]
            public string Address { get; set; }

            [Required(ErrorMessage = "需輸入最高學歷")]
            [DisplayName("最高學歷")]
            public string 最高學歷 { get; set; }

            [Required(ErrorMessage = "需輸入就業狀態")]
            [DisplayName("就業狀態")]
            public string 就業狀態 { get; set; }

            [Required(ErrorMessage = "需輸入工作地點")]
            [DisplayName("工作地點")]
            public string WorkPlace { get; set; }

            [Required]
            [DisplayName("銀行代碼")]
            public string BankCode { get; set; }

            [Required(ErrorMessage = "需輸入銀行帳號")]
            [DisplayName("銀行帳號")]
            public string BankAccount { get; set; }

            [DisplayName("會員照片")]
            public byte[] Photo { get; set; }

            [Required]
            [DisplayName("權限等級")]
            public int PermissionLevel { get; set; }

            public virtual Bank Bank { get; set; }
            public virtual Definition Definition { get; set; }
        }

    }
}