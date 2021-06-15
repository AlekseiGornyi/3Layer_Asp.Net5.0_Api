using LOGIC.Services.Models;
using LOGIC.Services.Models.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ISpecification_Service
    {
        Task<Generic_ResultSet<Specification_ResultSet>> AddSingleSpecification(string type, string size, string color,bool isgaming);
        Task<Generic_ResultSet<Specification_ResultSet>> GetSpecificationById(long specification_id);
        Task<Generic_ResultSet<Specification_ResultSet>> UpdateSpecification(long specification_id, string type, string size, string color, bool isgaming);
    }
}
