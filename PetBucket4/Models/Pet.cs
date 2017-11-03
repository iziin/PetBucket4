using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetBucket4.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public partial class Pet : IEnumerable
    {
        public int id { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string animal { get; set; }
        public Nullable<short> active { get; set; }
        public Nullable<short> indoors_safe { get; set; }
        public Nullable<short> under_13_safe { get; set; }
        public Nullable<int> customer_id { get; set; }
        public System.DateTime created { get; set; }
        public Nullable<System.DateTime> last_active { get; set; }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
