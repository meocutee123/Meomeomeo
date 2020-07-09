﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KT20_59131580.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class QuanAo
    {
        [Required(ErrorMessage =" Phải nhập dòng này vào")]
        
        public string MaQA { get; set; }
        [Required(ErrorMessage ="Cái này đéo nhập cũng oke")]
        public string TenQA { get; set; }
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
        [DisplayName("Xuất xứ")]
        public Nullable<bool> XuatXu { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage ="Em là con chó")]
        [DisplayName("Đơn giá")]
        public Nullable<decimal> DonGia { get; set; }
        [DisplayName("Ảnh minh họa")]
        public string AnhMinhHoa { get; set; }
        [DisplayName("Mã loại")]
        public string MaLoai { get; set; }
    
        public virtual LOAIQUANAO LOAIQUANAO { get; set; }
    }
}
