using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csbi_test_clients_dictionary.Models
{

    public class SearchResults<T>: OperationStatus<T[]> where T: class
    { 
        public string QueryString { get; set; }
        public long StartedTime { get; set; }
        public long CompletedTime { get; set; }
        public long TimeMs { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
        public int PageSize { get; set; }

    }
   
}
