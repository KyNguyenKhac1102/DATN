using Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Services
{
    public interface ITonghopService
    {
        Task<TongHop> GetTongHops();
        Task<List<Tonghop_nganh>> GetTonghopNganh();
        Task<List<Tonghop_Tinh>> GetTonghopTinh();
        Task<List<Tonghop_Doituong>> GetTonghopDoituong();
        Task<List<Tonghop_Khuvuc>> GetTonghopKhuvuc();
    }
}