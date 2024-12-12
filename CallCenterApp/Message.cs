using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterApp
{
    // internal => oluşturulan class bulunduğu aynı projede veya aynı derlemede erişimi sağlar
    internal class Message
    {
        // properties
        // değer ataması yapılabilir veya okuyabilir
        public int ID { get; set; }
        public string UserMessage { get; set; }
        public string Response {  get; set; }
    }
}
