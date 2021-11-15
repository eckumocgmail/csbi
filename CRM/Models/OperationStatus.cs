using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csbi_test_clients_dictionary.Models
{
    /// <summary>
    /// Результат выполнения операции
    /// </summary>
    public class OperationStatus
    {
        public int Status { get; set; }
        public object Result { get; set; }
    }
    public class OperationStatus<T> where T:class
    {
        public int Status { get; set; }
        public T Result { get; set; }
    }
}
