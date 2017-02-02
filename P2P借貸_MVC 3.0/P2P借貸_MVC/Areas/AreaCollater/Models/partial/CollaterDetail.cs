using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P2P借貸_MVC.Areas.AreaCollater.Models
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class CollaterDetail
    {
        public class ProductMetadata
        {
            public int CollateralID { get; set; }
            [DisplayName("借款人名稱")]
            public string MemberName { get; set; }
            [DisplayName("抵押品名稱")]
            public string CollateralName { get; set; }

            public int MemberID { get; set; }
            [DisplayName("利率")]
            public decimal interestrate { get; set; }
            [DisplayName("擔保品說明")]
            [DataType(DataType.MultilineText)]
            public string CollateralEX { get; set; }
            [DisplayName("抵押品圖片")]
            public byte[] Collateralimage { get; set; }
            [DisplayName("借款金額")]
            [DisplayFormat(DataFormatString = "{0:c0}")]
            public decimal loanPrice { get; set; }
            [DisplayName("擔保品說明")]
            public string Collateralsituation { get; set; }
            [DisplayName("擔保品用途")]
            public string Collateraluse { get; set; }

            public int investmentID { get; set; }

            public virtual BasicInfo BasicInfo { get; set; }
        }
    }
}