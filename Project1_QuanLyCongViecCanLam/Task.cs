using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_QuanLyCongViecCanLam
{

    public class Task : ITask
    {
        private string mo_ta_cong_viec;
        private string completed;
        protected int id;
               
        public string MoTaCongViec { get => mo_ta_cong_viec; set => mo_ta_cong_viec = value; }

        public MucDoQuanTrong level;

        public string isCompleted { get => completed; set => completed = value; }
        public int ID { get => id; set => id = value; }
        public enum MucDoQuanTrong
        {
            Normal = 0,
            Important = 1,
            VeryImportant = 2

        }
        public Task()
        {

        }
        public Task(int id, string mo_ta_cong_viec, MucDoQuanTrong level ,string completed)
        {
            this.ID = id;
            this.MoTaCongViec = mo_ta_cong_viec;
            this.level = level;
            this.isCompleted = completed;
        }
        public Task(Task task)
        {
            this.ID = task.ID;
            this.MoTaCongViec = task.MoTaCongViec;
            this.isCompleted = task.isCompleted;
            this.level = task.level;
        }
        public virtual void HienThiDanhSach()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            //Console.CLear();
            //Console.WriteLine("\t Task List");
            Console.WriteLine($"ID: {this.ID}\tNội dung: {this.MoTaCongViec}\t Mức độ quan trọng: {this.level}\tTrạng thái: {this.isCompleted} *" );
        }
    }
}
