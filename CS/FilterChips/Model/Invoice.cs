using DevExpress.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterChips.Model {
    public class Invoice : BindableBase {
        public int ID {
            get;
            set;
        }
        public string Company {
            get;
            set;
        }
        public DateTime CreatedDate {
            get;
            set;
        }
        public decimal Price {
            get;
            set;
        }
        public bool IsDraft {
            get;
            set;
        }
    }
}
