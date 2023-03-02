using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroSistema.Application.Common.Dtos
{
    public  class PaginatedDTO<T>
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalRows { get; private set; }
        public T Data { get; private set; }

        public PaginatedDTO(int pageNumber, int pageSize, int totalRows, T data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRows = totalRows;
            Data = data;
        }

    }
}
