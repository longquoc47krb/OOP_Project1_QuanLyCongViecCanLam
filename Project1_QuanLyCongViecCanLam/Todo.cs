using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using static Project1_QuanLyCongViecCanLam.Task;

namespace Project1_QuanLyCongViecCanLam
{
    public delegate void Action(int input, List<Task> list);
   
    public class Todo
    {
        MucDoQuanTrong levelEnum;
        public event Action Action_Event;
        private List<Task> todoList = new List<Task>();
     
        Dictionary<int, string> checkCompleted = new Dictionary<int, string>()
        {
            {0,"Chưa hoàn thành"},
            {1,"Hoàn thành"}


        };
        private int GetKeyByValue(Dictionary<int, string> checkCompleted, string val)
        {
            int key = 0;
            foreach (KeyValuePair<int, string> pair in checkCompleted)
            {
                if (pair.Value == val)
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }
        public void TaskID(List<Task> List)
        {
            int i = 1;
            foreach (var task in List)
            {
                task.ID = i;
                i++;
            }
        }
        public void Activity(int input, List<Task> list)
        {
            Action_Event?.Invoke(input, list);
        }
        public void Delete(int input, List<Task> list)
        {
            try
            {
                foreach (var task in list)
                {
                    if (task.ID == input)
                    {
                        list.Remove(task);
                        Console.WriteLine("Công việc đã được xóa !");
                    }
                }
                Console.WriteLine("Không tìm thấy");

        }
            catch (InvalidOperationException)
            {
                if(list == null)
                {
                    Console.WriteLine("Danh sách rỗng");
                }
                else
                {
                    Console.WriteLine("Trở về Menu");
                }
            }

    }
    public void UpdateAll(int input, List<Task> list)
        {
            foreach (var task in list)
            {
                Console.WriteLine("Nhập nội dung công việc cần làm:");
                task.MoTaCongViec = Console.ReadLine();
                while (task.MoTaCongViec.Trim() == "")
                {
                    Console.WriteLine("Nội dung không được để trống, vui lòng nhập lại");
                    task.MoTaCongViec = Console.ReadLine();
                }
                Console.WriteLine("Nhập vào mức độ quan trọng:");
                Console.WriteLine("0 - Bình thường" +
                    "\n1 - Quan trọng" +
                    "\n2 - Cực kỳ quan trọng");
                string level = Console.ReadLine();
                while (level.Trim() == "")
                {
                    Console.WriteLine("Mức độ quan trọng không được để trống, vui lòng nhập lại");
                    level = Console.ReadLine();
                }
                if (level == "0") { levelEnum = MucDoQuanTrong.Normal; }
                else if (level == "1") { task.level = MucDoQuanTrong.Important; }
                else if (level == "2") { task.level = MucDoQuanTrong.VeryImportant; }
                while (level != "0" && level != "1" && level != "2")
                {
                    Console.WriteLine("Vui lòng xác định mức độ công việc \"Bình thường\" hay \"Quan trọng\"hay \"Rất quan trọng\"để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                    level = Console.ReadLine();
                    if (level == "0") { task.level = MucDoQuanTrong.Normal; }
                    else if (level == "1") { task.level = MucDoQuanTrong.Important; }
                    else if (level == "2") { task.level = MucDoQuanTrong.VeryImportant; }
                }
                Console.WriteLine("Công việc \"Hoàn thành\" hay \"Chưa hoàn thành\"( để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                task.isCompleted = Console.ReadLine();
                if (task.isCompleted == "") task.isCompleted = checkCompleted[0];
                else if (task.isCompleted == GetKeyByValue(checkCompleted, "Hoàn thành").ToString() || task.isCompleted == checkCompleted[1])
                {
                    task.isCompleted = checkCompleted[1];
                }
                while (task.isCompleted != GetKeyByValue(checkCompleted, "Hoàn thành").ToString() &&
                    task.isCompleted != GetKeyByValue(checkCompleted, "Chưa hoàn thành").ToString() && task.isCompleted != checkCompleted[0] && task.isCompleted != checkCompleted[1])
                {
                    Console.WriteLine("Công việc \"Hoàn thành\" hay \"Chưa hoàn thành\"( để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                    task.isCompleted = Console.ReadLine();
                    if (task.isCompleted == GetKeyByValue(checkCompleted, "Hoàn thành").ToString())
                    {
                        task.isCompleted = checkCompleted[1];
                    }
                    else
                    {
                        task.isCompleted = checkCompleted[0];
                    }
                    if (task.isCompleted == "" || task.isCompleted == GetKeyByValue(checkCompleted, "Chưa hoàn thành").ToString()) task.isCompleted = checkCompleted[0];
                }
                break;
            }
        }
        public void UpdateOnlyStatus(int input, List<Task> list)
        {
            foreach (var task in list)
            {
                Console.WriteLine("Công việc \"Hoàn thành\" hay \"Chưa hoàn thành\"( để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                task.isCompleted = Console.ReadLine();
                if (task.isCompleted == "") task.isCompleted = checkCompleted[0];
                else if (task.isCompleted == GetKeyByValue(checkCompleted, "Hoàn thành").ToString() || task.isCompleted == checkCompleted[1])
                {
                    task.isCompleted = checkCompleted[1];
                }
                while (task.isCompleted != GetKeyByValue(checkCompleted, "Hoàn thành").ToString() && task.isCompleted != GetKeyByValue(checkCompleted, "Chưa hoàn thành").ToString() 
                    && task.isCompleted != checkCompleted[0] && task.isCompleted != checkCompleted[1])
                {
                    Console.WriteLine("Công việc \"Hoàn thành\" hay \"Chưa hoàn thành\"( để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                    task.isCompleted = Console.ReadLine();
                    if (task.isCompleted == GetKeyByValue(checkCompleted, "Hoàn thành").ToString())
                    {
                        task.isCompleted = checkCompleted[1];
                    }
                    else
                    {
                        task.isCompleted = checkCompleted[0];
                    }
                    if (task.isCompleted == "" || task.isCompleted == GetKeyByValue(checkCompleted, "Chưa hoàn thành").ToString()) task.isCompleted = checkCompleted[0];
                }
                break;
            }
        }
        public void UpdateImportantLevelAndStatus(int input, List<Task> list)
        {

            foreach (var task in list)
            {
                Console.WriteLine("Nhập vào mức độ quan trọng:");
                Console.WriteLine("0 - Bình thường" +
                    "\n1 - Quan trọng" +
                    "\n2 - Cực kỳ quan trọng");
                string level = Console.ReadLine();
                while (level.Trim() == "")
                {
                    Console.WriteLine("Mức độ quan trọng không được để trống, vui lòng nhập lại");
                    level = Console.ReadLine();
                }
                if (level == "0") { levelEnum = MucDoQuanTrong.Normal; }
                else if (level == "1") { task.level = MucDoQuanTrong.Important; }
                else if (level == "2") { task.level = MucDoQuanTrong.VeryImportant; }
                while (level != "0" && level != "1" && level != "2")
                {
                    Console.WriteLine("Vui lòng xác định mức độ công việc \"Bình thường\" hay \"Quan trọng\"hay \"Rất quan trọng\"để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                    level = Console.ReadLine();
                    if (level == "0") { task.level = MucDoQuanTrong.Normal; }
                    else if (level == "1") { task.level = MucDoQuanTrong.Important; }
                    else if (level == "2") { task.level = MucDoQuanTrong.VeryImportant; }
                }
                Console.WriteLine("Công việc \"Hoàn thành\" hay \"Chưa hoàn thành\"( để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                task.isCompleted = Console.ReadLine();
                if (task.isCompleted == "") task.isCompleted = checkCompleted[0];
                else if (task.isCompleted == GetKeyByValue(checkCompleted, "Hoàn thành").ToString() || task.isCompleted == checkCompleted[1])
                {
                    task.isCompleted = checkCompleted[1];
                }
                while (task.isCompleted != GetKeyByValue(checkCompleted, "Hoàn thành").ToString() && task.isCompleted != GetKeyByValue(checkCompleted, "Chưa hoàn thành").ToString()
                    && task.isCompleted != checkCompleted[0] && task.isCompleted != checkCompleted[1])
                {
                    Console.WriteLine("Công việc \"Hoàn thành\" hay \"Chưa hoàn thành\"( để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                    task.isCompleted = Console.ReadLine();
                    if (task.isCompleted == GetKeyByValue(checkCompleted, "Hoàn thành").ToString())
                    {
                        task.isCompleted = checkCompleted[1];
                    }
                    else
                    {
                        task.isCompleted = checkCompleted[0];
                    }
                    if (task.isCompleted == "" || task.isCompleted == GetKeyByValue(checkCompleted, "Chưa hoàn thành").ToString()) task.isCompleted = checkCompleted[0];
                }
                break;
            }
        }

        public void UpdateOnlyImportantLevel(int input, List<Task> list)
        {
            foreach (var task in list)
            {
                Console.WriteLine("Nhập vào mức độ quan trọng:");
                Console.WriteLine("0 - Bình thường" +
                    "\n1 - Quan trọng" +
                    "\n2 - Cực kỳ quan trọng");
                string level = Console.ReadLine();
                while (level.Trim() == "")
                {
                    Console.WriteLine("Mức độ quan trọng không được để trống, vui lòng nhập lại");
                    level = Console.ReadLine();
                }
                while (level != "0" && level != "1" && level != "2")
                {
                    Console.WriteLine("Vui lòng xác định mức độ công việc \"Bình thường\" hay \"Quan trọng\"hay \"Rất quan trọng\"để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                    level = Console.ReadLine();
                    if (level == "0") { task.level = MucDoQuanTrong.Normal; }
                    else if (level == "1") { task.level = MucDoQuanTrong.Important; }
                    else if (level == "2") { task.level = MucDoQuanTrong.VeryImportant; }
                }
                break;
            }
        }
        public void Update(int input, List<Task> list)
        {
            string update = "";
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            foreach (var task in list)
            {
                if (task.ID == input)
                {
                    Console.WriteLine("Bạn có muốn sửa gì ? ");
                    Console.WriteLine("1 - Tất cả\n2 - Chỉ trạng thái\n3 - Chỉ mức độ quan trọng\n4 - Sửa mức độ quan trọng và trạng thái");
                    update = Console.ReadLine();
                    switch (update)
                    {
                        case "1": UpdateAll(task.ID, list); break;
                        case "2": UpdateOnlyStatus(task.ID, list); break;
                        case "3": UpdateOnlyImportantLevel(task.ID, list); break;
                        case "4": UpdateImportantLevelAndStatus(task.ID, list); break;
                        default: break;
                    }
                    
                    
                }
            }
            Console.WriteLine("Không tìm thấy");
        }

        public void Input(int ID, List<Task> list)
        {
            
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            bool flag = false;
            if (ID == 0)
            {
                ID = list.Count() + 1;
                flag = true;
            }
            Console.WriteLine("Nhập nội dung công việc cần làm:");
            string noidung = Console.ReadLine();
            while (noidung.Trim() == "")
            {
                Console.WriteLine("Nội dung không được để trống, vui lòng nhập lại");
                noidung = Console.ReadLine();
            }
            Console.WriteLine("Nhập vào mức độ quan trọng:");
            Console.WriteLine("0 - Bình thường" +
                "\n1 - Quan trọng" +
                "\n2 - Cực kỳ quan trọng");
            string level = Console.ReadLine();
            while (level.Trim() == "")
            {
                Console.WriteLine("Mức độ quan trọng không được để trống, vui lòng nhập lại");
                level = Console.ReadLine();
            }
            if (level == "0") { levelEnum = MucDoQuanTrong.Normal; }
            else if (level == "1") { levelEnum = MucDoQuanTrong.Important; }
            else if (level == "2") { levelEnum = MucDoQuanTrong.VeryImportant; }
            while (level != "0" && level != "1" && level != "2") {
                Console.WriteLine("Vui lòng xác định mức độ công việc \"Bình thường\" hay \"Quan trọng\"hay \"Rất quan trọng");
                level = Console.ReadLine();
                if (level == "0") { levelEnum = MucDoQuanTrong.Normal; }
                else if (level == "1") { levelEnum = MucDoQuanTrong.Important; }
                else if (level == "2") { levelEnum = MucDoQuanTrong.VeryImportant; }
            }
            Console.WriteLine("Công việc \"Hoàn thành\" hay \"Chưa hoàn thành\"( để" +
                " trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
            string isCompleted = Console.ReadLine();
            if (isCompleted == "" || isCompleted == GetKeyByValue(checkCompleted, "Chưa hoàn thành").ToString()) isCompleted = checkCompleted[0];
            else if (isCompleted == GetKeyByValue(checkCompleted, "Hoàn thành").ToString() || isCompleted == checkCompleted[1])
            {
                isCompleted = checkCompleted[1];
            }
            while (isCompleted != GetKeyByValue(checkCompleted, "Hoàn thành").ToString() && isCompleted != GetKeyByValue(checkCompleted, "Chưa hoàn thành").ToString()
                && isCompleted != checkCompleted[0] && isCompleted != checkCompleted[1])
            {
                Console.WriteLine("Vui lòng xác định công việc \"Hoàn thành\" hay \"Chưa hoàn thành\"( để trống có nghĩa là chưa hoàn thành nếu hoàn thành thì nhấn 1, chưa thì nhấn 0): ");
                isCompleted = Console.ReadLine();
                if (isCompleted == "") { isCompleted = checkCompleted[1]; }
                
            }
            var Task = new Task(ID, noidung, levelEnum, isCompleted);
            if (flag)
            {
                list.Add(Task);
            }
        }

        public void MainMenu()
        {
            Todo delete = new Todo();
            Todo update = new Todo();
            Todo input = new Todo();
            delete.Action_Event += Delete;
            update.Action_Event += Update;
            input.Action_Event += Input;



            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            string luachon;
            do
            {
                Console.WriteLine("\t ===============================");
                Console.WriteLine("\t|1.Việc cần làm               \t|");
                Console.WriteLine("\t|2.Hiển thị danh sách công việc |");
                Console.WriteLine("\t|3.Thoát                        |");
                Console.WriteLine("\t ===============================");
                Console.Write("\t\tVui lòng chọn: ");

                luachon = Console.ReadLine();

                if (luachon != "1" && luachon != "2" && luachon != "3")
                {
                    Console.WriteLine("\nNhập sai. Vui lòng nhập lại.\n");
                }
            } while (luachon != "1" && luachon != "2" && luachon != "3");

            switch (luachon)
            {
                case "1":
                    SubMenu();
                    break;
                case "2":
                    {
                         Console.WriteLine("\t*****************************************");
                        Console.WriteLine("\t*           Danh sách công việc:        *");

                            foreach (var it in todoList)
                            {
                                Console.Write("\t*\t");

                                it.HienThiDanhSach();
                           
                            }

       
                    }
                    break;
                case "3":
                    {
                        Console.WriteLine("Bạn muốn thoát? Y để đồng ý, N để hủy");
                        string flag = Console.ReadLine();
                        if(flag =="Y" || flag == "y")
                        {
                            Environment.Exit(0);
                        }
                        else if(flag == "N" || flag == "n")
                        {
                            MainMenu();
                        }
                        while(flag != "y" && flag != "Y" && flag != "N" && flag != "n")
                        {
                            Console.WriteLine("Nhập sai vui lòng nhập lại");
                            flag = Console.ReadLine();
                            if (flag == "Y" || flag == "y")
                            {
                                Environment.Exit(0);
                            }
                            else if (flag == "N" || flag == "n")
                            {
                                MainMenu();
                            }

                        }
                    }
                    break;
                    
            }
            void SubMenu()
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;

                
                while (true)
                {
                    string luachonSubMenu = "";

                    //SubMenu 
                    while (luachonSubMenu != "1" && luachonSubMenu != "2" && luachonSubMenu != "3" && luachonSubMenu != "4" )
                    {
                        Console.WriteLine("\t*****************************************");
                        Console.WriteLine("\t*               Danh sách công việc:     *");
                        foreach (var it in todoList)
                        {
                            Console.Write("\t*\t");
                            it.HienThiDanhSach();
                        }
                        Console.WriteLine("\t*****************************************");
                        Console.WriteLine("");
                        Console.WriteLine("\t ==========================");
                        Console.WriteLine("\t|\t1.Thêm mới          |");
                        Console.WriteLine("\t|\t2.Xóa               |");
                        Console.WriteLine("\t|\t3.Sửa               |");
                        Console.WriteLine("\t|\t4.Trở về Menu chính |");
                        Console.WriteLine("\t ==========================");
                        Console.Write("\t\tVui lòng chọn: ");
                        luachonSubMenu = Console.ReadLine();
                        if (luachonSubMenu != "1" && luachonSubMenu != "2" && luachonSubMenu != "3" && luachonSubMenu != "4") Console.WriteLine("Bạn đã nhập sai, Vui lòng nhập lại!");
                    }
                    try
                    {
                        switch (Convert.ToInt32(luachonSubMenu))
                        {
                            case 1:
                                input.Activity(0, todoList);
                                break;

                            case 2:
                                Console.WriteLine("Vui lòng nhập ID công việc bạn muốn xóa ");
                                int DeleteByID = int.Parse(Console.ReadLine());
                                delete.Activity(DeleteByID, todoList);
                                SubMenu();

                                break;

                            case 3:
                                Console.WriteLine("Vui lòng nhập ID công việc bạn muốn sửa ");
                                int UpdateByID = int.Parse(Console.ReadLine());
                                update.Activity(UpdateByID, todoList);
                                SubMenu();
                                break;

                            case 4:
                                MainMenu();
                                break;

                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(" Lỗi cú pháp ");
                    }
                }

                   
                }
            }
        }
    }

