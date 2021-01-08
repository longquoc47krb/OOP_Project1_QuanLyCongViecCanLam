using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_QuanLyCongViecCanLam
{
    public interface ITask
    {
        public string MoTaCongViec { get ; set; }
        public string isCompleted { get; set; }
        public int ID { get; set; }

    }
}
