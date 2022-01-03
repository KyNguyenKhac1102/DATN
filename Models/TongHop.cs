using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class Tonghop_nganh
    {
        public string Nganh { get; set; }
        public int TongperNganh { get; set; }
    }
    public class Tonghop_khoa
    {
        public string Khoa { get; set; }
        public int TongperKhoa { get; set; }
    }

    public class Tonghop_Tinh
    {
        public string Tinh { get; set; }
        public int TongperTinh { get; set; }
    }

    public class Tonghop_Doituong
    {
        public string Doituong { get; set; }
        public int TongperDoituong { get; set; }
    }

    public class CustomDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }

    public class Tonghop_Khuvuc
    {
        public string Khuvuc { get; set; }
        public int TongperKhuvuc { get; set; }
    }

    public class TonghopPerDay
    {
        public CustomDate Day { get; set; }
        public int TongperDay { get; set; }
    }

    public class TonghopInfo
    {
        public int TongHoso { get; set; }

        public int TongHoso_dtutien { get; set; }
        public int TongHoso_khuvucutien { get; set; }

        public int TongHoso_diemcao { get; set; }
        public List<TonghopPerDay> HosoPerDay { get; set; }
    }

    public class TongHop
    {
        public TonghopInfo tonghopInfo { get; set; }

        public int TongBestNv_Nganh { get; set; }


    }
}