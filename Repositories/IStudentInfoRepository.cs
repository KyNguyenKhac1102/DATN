
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;


public interface IStudentInfoRepository
{
    // GetAll Insert, Update, Delete

    Task<TonghopInfo> GetTonghoso();
    Task<List<Tonghop_Tinh>> GetTonghopTinh();
    Task<List<Tonghop_Doituong>> GetTonghopDoituong();
    Task<List<Tonghop_Khuvuc>> GetTonghopKhuvuc();
    Task<IEnumerable<StudentInfo>> GetAll();
    Task<StudentInfo> GetInfoById(int id);
    Task<StudentInfo> Insert(StudentInfoDtos dto);

    Task<StudentInfo> Update(int id, StudentInfoDtos dto);
    Task<bool> Delete(int id);


}
