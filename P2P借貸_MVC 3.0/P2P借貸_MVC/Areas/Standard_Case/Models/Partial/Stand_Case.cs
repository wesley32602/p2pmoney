using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P2P借貸_MVC.Areas.Standard_Case.Models.Partial
{
    [MetadataType(typeof(Stand_CaseMetadata))]
    public partial class Stand_Case
    {
        public class Stand_CaseMetadata
        {
            [DisplayName("標案編號")]
            public int StandcaseID { get; set; }


            [DisplayName("主辦者編號")]
            public Nullable<int> MemberSponer { get; set; }


            [DisplayName("可參加人數")]
            public Nullable<int> Memberprople { get; set; }

            [DisplayName("標案總金額")]
            public Nullable<int> Casemoney { get; set; }

            [DisplayName("標案期數")]
            public Nullable<int> CaseMonth { get; set; }

            [DisplayName("標案開始日")]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
            public Nullable<System.DateTime> CaseFirstday { get; set; }

            [DisplayName("標案結束日")]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
            public Nullable<System.DateTime> CaseEndnay { get; set; }

            [DisplayName("預計匯款日")]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
            public Nullable<System.DateTime> MoneyForday { get; set; }


            public Nullable<bool> CaseStatus { get; set; }


            public Nullable<bool> CaseStatus2 { get; set; }

            public virtual BasicInfo BasicInfo { get; set; }
        }
    }
}