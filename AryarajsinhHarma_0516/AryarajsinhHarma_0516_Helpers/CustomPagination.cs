using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AryarajsinhHarma_0516_Helpers
{
    public class CustomPagination<T> : List<T>
    {
        public static int totalCount;
        public static int page;
        public static int pageSize;
        public static int totalPage;


        public static List<T> Pagination(List<T> _list, int page)
        {
            int pageSize = 5;

            int totalCount = _list.Count();
            int totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var DetailsPerPage = _list.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            CustomPagination<T>.totalCount = totalCount;
            CustomPagination<T>.page = page;
            CustomPagination<T>.pageSize = pageSize;
            CustomPagination<T>.totalPage = totalPage;
            return DetailsPerPage;
        }
    }
}
