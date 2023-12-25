using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.BizEntites;

namespace Services.Interface
{
    public interface IEmploye
    {
        Task<List<BizEmployeInfo>> GetAll();
        Task<BizEmployeInfo> GetById(int id);
        Task<bool> Create(BizEmployeInfo entity);
        Task<bool> Update(BizEmployeInfo entity);
        Task<bool> Delete(int id);
    }
}
