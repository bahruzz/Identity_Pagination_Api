using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Helpers
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T> Datas { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public PaginationResponse(IEnumerable<T> datas, int totalPage, int currentPage)
        {
            Datas = datas;
            TotalPage = totalPage;
            CurrentPage = currentPage;
            
        }
    }
}
