﻿namespace MyWebApiApp.Data
{
    public enum TinhTrangDonDatHang
    {
        New = 0,
        Payment = 1,
        Complete =  2,
        Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDh {  get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao {  get; set; }
        public int TinhTrangDonDatHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
