
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Models;
using Project.Repositories;

namespace Project.Services
{
    public class TonghopService : ITonghopService
    {
        private readonly IStudentInfoRepository _studentInfoRepo;

        private readonly IStudentNvRepository _studentNvRepo;
        public TonghopService(IStudentInfoRepository studentInfoRepo, IStudentNvRepository studentNvRepo)
        {
            _studentInfoRepo = studentInfoRepo;
            _studentNvRepo = studentNvRepo;
        }

        public async Task<TongHop> GetTongHops()
        {
            var tonghopInfoData = await _studentInfoRepo.GetTonghoso();
            var countBestNganh = _studentNvRepo.GetMaxNvNganh();

            var tonghop = new TongHop()
            {
                tonghopInfo = tonghopInfoData,
                TongBestNv_Nganh = countBestNganh
            };

            // var tongpernganh = await _studentNvRepo.GetperNganh();
            // var tongperkhoa = await _studentNvRepo.GetperKhoa();

            // var tonghop = new TongHop()
            // {
            //     TongHoso = tonghoso,
            //     TongHoso_diemcao = 0,
            //     TongHoso_utien = 0,

            // TongHoso_Nganhs = tongpernganh,
            // TongHoso_Khoas = null,
            // };
            return tonghop;
        }

        public async Task<List<Tonghop_nganh>> GetTonghopNganh()
        {
            var tongpernganh = await _studentNvRepo.GetperNganh();

            return tongpernganh;
        }

        public async Task<List<Tonghop_Tinh>> GetTonghopTinh()
        {
            var tongpertinh = await _studentInfoRepo.GetTonghopTinh();

            return tongpertinh;
        }

        public async Task<List<Tonghop_Doituong>> GetTonghopDoituong()
        {
            var tongperdoituong = await _studentInfoRepo.GetTonghopDoituong();

            return tongperdoituong;
        }
        public async Task<List<Tonghop_Khuvuc>> GetTonghopKhuvuc()
        {
            var tongperkhuvuc = await _studentInfoRepo.GetTonghopKhuvuc();

            return tongperkhuvuc;
        }
    }
}