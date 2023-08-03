using DevExpress.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottomSheetFilterUI.Model {
    public class Tutor : BindableBase {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string City { get; set; }
        public string AvatarPath { get; set; }
        public string Subject { get; set; }
        public decimal HourRate { get; set; }
        public int Experience { get; set; }
        public float Rating { get; set; }
    }
}
