using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Domain.Common
{
    public class PaginatedEntity<T>
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalRows { get; private set; }
        public T Data { get; private set; }

        public PaginatedEntity(int pageNumber, int pageSize, int totalRows, T data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRows = totalRows;
            Data = data;
        }

    }
}
