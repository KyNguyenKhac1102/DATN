using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;

namespace Project.Repositories
{
    public class StudentNvRepository : IStudentNvRepository
    {

        private readonly ProjectContext _context;

        public StudentNvRepository(ProjectContext context)
        {
            _context = context;
        }

        public int GetMaxNvNganh()
        {

            return _context.StudentNguyenVongs.GroupBy(s => s.MaNganh).Select(t => new
            {
                a = t.Key,
                b = t.Count()
            }).Max(x => x.b);


        }

        public async Task<List<Tonghop_nganh>> GetperNganh()
        {
            // var listTenNganh = await _context.StudentNguyenVongs.Include(nv => nv.Nganh).ToListAsync();
            // var length = listTenNganh.Count();

            List<string> listManganhs = await _context.Nganhs.Select(n => n.MaNganh).ToListAsync();
            var length = listManganhs.Count();

            var tonghop_nganhs = new List<Tonghop_nganh>();

            // for (int i = 0; i < length; i++)
            // {
            //     var currentTenNganh = listTenNganh[i];
            //     var tongpernganh = _context.StudentNguyenVongs.Include(nv => nv.Nganh).Where().
            //     var tonghop_nganh = new Tonghop_nganh()
            //     {
            //         Nganh = currentTenNganh,
            //         TongperNganh = tongpernganh
            //     };
            //     tonghop_nganhs.Add(tonghop_nganh);
            // }



            for (int i = 0; i < length; i++)
            {
                var currentMaNganh = listManganhs[i];
                var tongpernganh = _context.StudentNguyenVongs.Where(nv => nv.MaNganh == currentMaNganh).Count();
                var tonghop_nganh = new Tonghop_nganh()
                {
                    Nganh = currentMaNganh,
                    TongperNganh = tongpernganh
                };
                tonghop_nganhs.Add(tonghop_nganh);
            }

            return tonghop_nganhs;
        }

        public async Task<List<Tonghop_khoa>> GetperKhoa()
        {
            // var joinTable = _context.StudentNguyenVongs.Include(nv => nv.Nganh).ThenInclude(n => n.Khoa);

            // var listCount = _context.StudentNguyenVongs.FromSqlRaw(@"
            // select Khoas.TenKhoa ,Count(Khoas.TenKhoa) as tongperkhoa
            // from 
            // StudentNguyenVongs
            // JOIN Nganhs ON StudentNguyenVongs.MaNganh = Nganhs.MaNganh 
            // JOIN Khoas ON Nganhs.KhoaId = Khoas.Id 
            // Group by Khoas.TenKhoa
            // ").ToList();

            // var listKhoa = await _context.Khoas.Select(k => k.TenKhoa).ToListAsync();

            // var length = listCount.Count();

            // listCount.ForEach(record => record.);

            // for(int i=0; i< length; i++)
            // {
            //     listCount.TenKhoa
            // }





            // var data = _context.StudentNguyenVongs.Include(nv => nv.Nganh).ThenInclude(n => n.Khoa).AsQueryable();
            // var listKhoa = await _context.Khoas.Select(k => k.TenKhoa).ToListAsync();

            // var length = listKhoa.Count();

            // for (int i = 0; i < length; i++)
            // {

            //     var tenkhoa = listKhoa[i];
            //     var tongperkhoa = await _context.StudentNguyenVongs.Include(nv => nv.Nganh).ThenInclude(khoa => khoa.Khoa == tenkhoa).CountAsync();

            //     var tonghop_khoa = new Tonghop_khoa()
            //     {
            //         Khoa = tenkhoa,
            //         TongperKhoa = tongperkhoa
            //     };
            //     output.Add(tonghop_khoa);
            // }

            // select Khoas.TenKhoa ,Count(Khoas.TenKhoa) as tongperkhoa
            // from 
            // StudentNguyenVongs
            // JOIN Nganhs ON StudentNguyenVongs.MaNganh = Nganhs.MaNganh 
            // JOIN Khoas ON Nganhs.KhoaId = Khoas.Id 
            // Group by Khoas.TenKhoa
            // ").ToList();


            // var output = new List<Tonghop_khoa>();

            // _context.StudentNguyenVongs.Include(s => s.Nganh).ThenInclude(n => n.Khoa)

            // var query = from s in _context.Set<StudentNguyenVong>()
            //             join n in  _context.Set<Nganh>()
            //                 on s.MaNganh equals n.MaNganh
            //             join k in _context.Set<Khoa>()
            //                 on n.KhoaId equals k.Id
            //             group k by k.TenKhoa into g
            //             select new {tenKhoa =  ,Count = g.Count()};
            return null;
        }

        public async Task<IEnumerable<StudentNguyenVong>> GetAll()
        {
            return await _context.StudentNguyenVongs.ToListAsync();
        }

        public async Task<StudentNguyenVong> GetNguyenVongById(int id)
        {
            return await _context.StudentNguyenVongs.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<StudentNguyenVong>> Insert(StudentNguyenVongDtos[] dto, int id)
        {
            int length = dto.Length;
            var storeNguyenVong = new List<StudentNguyenVong>();


            for (int i = 0; i < length; i++)
            {
                var studentNguyenVong = new StudentNguyenVong()
                {
                    Stt_NguyenVong = i + 1,
                    StudentInfoId = id,
                    MaNganh = dto[i].MaNganh,
                    MaToHop = dto[i].MaToHop
                };
                storeNguyenVong.Add(studentNguyenVong);
                await _context.StudentNguyenVongs.AddAsync(studentNguyenVong);
            }

            _context.SaveChanges();

            return storeNguyenVong;
        }


        public async Task<bool> Delete(int id)
        {
            var studentNguyenVong = await _context.StudentNguyenVongs.FirstOrDefaultAsync(t => t.Id == id);
            _context.StudentNguyenVongs.Remove(studentNguyenVong);

            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteByInfoId(int studentInfoId)
        {

            _context.StudentNguyenVongs.RemoveRange(_context.StudentNguyenVongs.Where(t => t.StudentInfoId == studentInfoId));

            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<StudentNguyenVong> Update(int id, StudentNguyenVongDtos dto)
        {
            throw new NotImplementedException();
        }


    }
}