using System.Collections.Generic;

namespace APM_Back.Models
{
    public class PagedData
    {
        public IEnumerable<Product> data { get; set; }
        public int totalRecords { get; set; }
        public PagedData(IEnumerable<Product> data, int totalRecords)
        {
            this.data = data;
            this.totalRecords = totalRecords;
        }
    }
}
