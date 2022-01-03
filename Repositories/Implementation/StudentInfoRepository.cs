using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;

namespace Project.Repositories
{
    public class StudentInfoRepository : IStudentInfoRepository
    {

        private readonly ProjectContext _context;

        public StudentInfoRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<TonghopInfo> GetTonghoso()
        {
            var hosos = await _context.StudentInfos.CountAsync();
            var tonghoso_dc = await _context.StudentInfos.Where(s => s.DiemTb_UuTien > 27).CountAsync();

            var tonghoso_dtutien = await _context.StudentInfos.Where(s => s.MaDoiTuong != "00").CountAsync();
            var tonghoso_khuvucutien = await _context.StudentInfos.Where(s => s.MaKhuVuc != "KV3").CountAsync();

            List<TonghopPerDay> hosoperday = _context.StudentInfos.GroupBy(s => new CustomDate { Year = s.Create_At.Year, Month = s.Create_At.Month, Day = s.Create_At.Day }).Select(x => new TonghopPerDay
            {
                Day = x.Key,
                TongperDay = x.Count()

            }).ToList();

            var tonghop = new TonghopInfo()
            {
                TongHoso = hosos,
                TongHoso_diemcao = tonghoso_dc,
                TongHoso_dtutien = tonghoso_dtutien,
                TongHoso_khuvucutien = tonghoso_khuvucutien,
                HosoPerDay = hosoperday,
            };

            return tonghop;
        }

        public async Task<List<Tonghop_Tinh>> GetTonghopTinh()
        {
            var tinhinfo = await _context.StudentInfos.ToListAsync();
            var groupTinh = tinhinfo.GroupBy(t => t.Tinh12Id).Select(t => new Tonghop_Tinh
            {
                Tinh = t.Key,
                TongperTinh = t.Count()
            }).ToList();

            return groupTinh;
        }

        public async Task<List<Tonghop_Doituong>> GetTonghopDoituong()
        {
            var Doituonginfo = await _context.StudentInfos.ToListAsync();
            var groupDoituong = Doituonginfo.GroupBy(t => t.MaDoiTuong).Select(t => new Tonghop_Doituong
            {
                Doituong = t.Key,
                TongperDoituong = t.Count()
            }).ToList();

            return groupDoituong;
        }


        public async Task<List<Tonghop_Khuvuc>> GetTonghopKhuvuc()
        {
            var Khuvucinfo = await _context.StudentInfos.ToListAsync();
            var groupKhuvuc = Khuvucinfo.GroupBy(t => t.MaKhuVuc).Select(t => new Tonghop_Khuvuc
            {
                Khuvuc = t.Key,
                TongperKhuvuc = t.Count()
            }).ToList();

            return groupKhuvuc;
        }

        public async Task<IEnumerable<StudentInfo>> GetAll()
        {
            return await _context.StudentInfos.Include(s => s.StudentNguyenVongs).ToListAsync();
        }

        public async Task<StudentInfo> GetInfoById(int id)
        {
            return await _context.StudentInfos.Where(s => s.Id == id).Include(s => s.StudentNguyenVongs).FirstOrDefaultAsync();
        }

        public Tuple<double, double, double, double> CalculateA00(double DiemToan10, double DiemLy10, double DiemHoa10, double DiemToan11, double DiemLy11, double DiemHoa11,
            double DiemToan12, double DiemLy12, double DiemHoa12, string MaDoiTuong, string MaKhuVuc
        )
        {
            var diem_cal = 0.0;
            var diemtb10 = Math.Round((DiemToan10 + DiemLy10 + DiemHoa10) / 3, 2);
            var diemtb11 = Math.Round((DiemToan11 + DiemLy11 + DiemHoa11) / 3, 2);
            var diemtb12 = Math.Round((DiemToan12 + DiemLy12 + DiemHoa12) / 3, 2);

            var diemCongDoiTuong = 0;
            double diemCongKhuVuc = 0;
            if (MaDoiTuong == "01" || MaDoiTuong == "02" || MaDoiTuong == "03" || MaDoiTuong == "04")
            {
                diemCongDoiTuong = 2;
            }
            else if (MaDoiTuong == "05" || MaDoiTuong == "06" || MaDoiTuong == "07")
            {
                diemCongDoiTuong = 1;
            }

            if (MaKhuVuc == "1")
            {
                diemCongKhuVuc = 0.75;
            }
            else if (MaKhuVuc == "2")
            {
                diemCongKhuVuc = 0.25;
            }
            else if (MaKhuVuc == "2NT")
            {
                diemCongKhuVuc = 0.5;
            }
            diem_cal = Math.Round((diemtb10 + diemtb11 + diemtb12 + diemCongKhuVuc + diemCongDoiTuong), 2);
            return Tuple.Create(diemtb10, diemtb11, diemtb12, diem_cal);
        }


        public async Task<StudentInfo> Insert(StudentInfoDtos dto)
        {
            // var diemtb10 = Math.Round((dto.DiemToan10 + dto.DiemLy10 + dto.DiemHoa10) / 3, 2);
            // var diemtb11 = Math.Round((dto.DiemToan11 + dto.DiemLy11 + dto.DiemHoa11) / 3, 2);
            // var diemtb12 = Math.Round((dto.DiemToan12 + dto.DiemLy12 + dto.DiemHoa12) / 3, 2);

            // var diemCongDoiTuong = 0;
            // double diemCongKhuVuc = 0;
            // if (dto.MaDoiTuong == "01" || dto.MaDoiTuong == "02" || dto.MaDoiTuong == "03" || dto.MaDoiTuong == "04")
            // {
            //     diemCongDoiTuong = 2;
            // }
            // else if (dto.MaDoiTuong == "05" || dto.MaDoiTuong == "06" || dto.MaDoiTuong == "07")
            // {
            //     diemCongDoiTuong = 1;
            // }

            // if (dto.MaKhuVuc == "1")
            // {
            //     diemCongKhuVuc = 0.75;
            // }
            // else if (dto.MaKhuVuc == "2")
            // {
            //     diemCongKhuVuc = 0.25;
            // }
            // else if (dto.MaKhuVuc == "2NT")
            // {
            //     diemCongKhuVuc = 0.5;
            // }

            // var diem_final = Math.Round((diemtb10 + diemtb11 + diemtb12 + diemCongKhuVuc + diemCongDoiTuong), 2);


            var CAL = CalculateA00(dto.DiemToan10, dto.DiemLy10, dto.DiemHoa10, dto.DiemToan11, dto.DiemLy11, dto.DiemHoa11,
                dto.DiemToan12, dto.DiemLy12, dto.DiemHoa12, dto.MaDoiTuong, dto.MaKhuVuc
            );
            var studentInfo = new StudentInfo()
            {
                HoTen = dto.HoTen,
                NgaySinh = dto.NgaySinh,
                GioiTinh = dto.GioiTinh,
                SoCCCD = dto.SoCCCD,
                SoDienThoai = dto.SoDienThoai,
                Email = dto.Email,
                DiaChiHoKhau = dto.DiaChiHoKhau,
                MaDoiTuong = dto.MaDoiTuong,
                MaKhuVuc = dto.MaKhuVuc,
                Tinh10Id = dto.Tinh10Id,
                Tinh11Id = dto.Tinh11Id,
                Tinh12Id = dto.Tinh12Id,
                TruongLop10Id = dto.TruongLop10Id,
                TruongLop11Id = dto.TruongLop11Id,
                TruongLop12Id = dto.TruongLop12Id,
                DiaChiLienHe = dto.DiaChiLienHe,
                HoTenBo = dto.HoTenBo,
                SdtBo = dto.SdtBo,
                HoTenMe = dto.HoTenMe,
                SdtMe = dto.SdtMe,
                Hocba10_url = dto.Hocba10_url,
                Hocba11_url = dto.Hocba11_url,
                Hocba12_url = dto.Hocba12_url,
                DiemToan10 = dto.DiemToan10,
                DiemLy10 = dto.DiemLy10,
                DiemHoa10 = dto.DiemHoa10,

                DiemToan11 = dto.DiemToan11,
                DiemLy11 = dto.DiemLy11,
                DiemHoa11 = dto.DiemHoa11,

                DiemToan12 = dto.DiemToan12,
                DiemLy12 = dto.DiemLy12,
                DiemHoa12 = dto.DiemHoa12,

                DiemTb10 = CAL.Item1,

                DiemTb11 = CAL.Item2,
                DiemTb12 = CAL.Item3,
                Create_At = DateTime.Now,
                DiemTb_UuTien = CAL.Item4,
                UserId = dto.UserId,
            };

            await _context.StudentInfos.AddAsync(studentInfo);
            await _context.SaveChangesAsync();

            return studentInfo;
        }

        public async Task<StudentInfo> Update(int id, StudentInfoDtos dto)
        {
            var studentInfo = await _context.StudentInfos.FirstOrDefaultAsync(t => t.Id == id);

            try
            {
                studentInfo.HoTen = dto.HoTen;
                studentInfo.NgaySinh = dto.NgaySinh;
                studentInfo.GioiTinh = dto.GioiTinh;
                studentInfo.SoCCCD = dto.SoCCCD;
                studentInfo.SoDienThoai = dto.SoDienThoai;
                studentInfo.Email = dto.Email;
                studentInfo.DiaChiHoKhau = dto.DiaChiHoKhau;
                studentInfo.MaDoiTuong = dto.MaDoiTuong;
                studentInfo.MaKhuVuc = dto.MaKhuVuc;
                studentInfo.Tinh10Id = dto.Tinh10Id;
                studentInfo.Tinh11Id = dto.Tinh11Id;
                studentInfo.Tinh12Id = dto.Tinh12Id;
                studentInfo.TruongLop10Id = dto.TruongLop10Id;
                studentInfo.TruongLop11Id = dto.TruongLop11Id;
                studentInfo.TruongLop12Id = dto.TruongLop12Id;
                studentInfo.DiaChiLienHe = dto.DiaChiLienHe;
                studentInfo.HoTenBo = dto.HoTenBo;
                studentInfo.SdtBo = dto.SdtBo;
                studentInfo.HoTenMe = dto.HoTenMe;
                studentInfo.SdtMe = dto.SdtMe;
                studentInfo.Hocba10_url = dto.Hocba10_url;
                studentInfo.Hocba11_url = dto.Hocba11_url;
                studentInfo.Hocba12_url = dto.Hocba12_url;
                studentInfo.DiemToan10 = dto.DiemToan10;
                studentInfo.DiemLy10 = dto.DiemLy10;
                studentInfo.DiemHoa10 = dto.DiemHoa10;

                studentInfo.DiemToan11 = dto.DiemToan11;
                studentInfo.DiemLy11 = dto.DiemLy11;
                studentInfo.DiemHoa11 = dto.DiemHoa11;

                studentInfo.DiemToan12 = dto.DiemToan12;
                studentInfo.DiemLy12 = dto.DiemLy12;
                studentInfo.DiemHoa12 = dto.DiemHoa12;

                studentInfo.UserId = dto.UserId;
                return studentInfo;
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        public async Task<bool> Delete(int id)
        {
            var studentInfo = await _context.StudentInfos.FirstOrDefaultAsync(t => t.Id == id);
            _context.StudentInfos.Remove(studentInfo);

            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}