using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKy
{
    class Globals
    {

        public static string role { get; set; }
        public static int ShiftinDay { get; set; }
        public static int SelectedID { get; set; }
        public static int SelectedID_Phong { get; set; }
        public static int SelectedID_Khach { get; set; }
        public static int GlobalUserId { get; private set; }
        public static DateTime CheckInTime { get; set; }
        public static void SetGlobalUserId(int userId)
        {
            GlobalUserId = userId;
        }
    }
}
