using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
/*
ObservableCollection<T> thì nó cung cấp thêm sự kiện thông báo như: Số lượng phần tử thay đổi như thêm, bớt ...(nghĩa là giám sát được biến động phần tử).
Các sự kiện event này có tên là CollectionChanged, trong tham số mà sự kiện gửi đến, e.Action có cho biết hành động thay đổi trên tập hợp là gì
(ví dụ: thêm NotifyCollectionChangedAction.Add, bớt NotifyCollectionChangedAction.Remove), clear tập hợp NotifyCollectionChangedAction.Reset ...
*/
namespace ObservableCollection_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tạo tập hợp chứa các chuỗis
            ObservableCollection<string> obs = new ObservableCollection<string>();

            // Bắt sự kiện thi thay đổi obs
            obs.CollectionChanged += change;

            //Thay các phần tử tập hợp
            obs.Add("ZTest1");
            obs.Add("DTest2");
            obs.Add("ATest3");
            obs[2] = "AAAAA";

            obs.RemoveAt(1);
            obs.Clear();

        }

        // Phương thức nhận sự kiện CollectionChanged
        private static void change(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (String s in e.NewItems)
                        Console.WriteLine($"Thêm :  {s}");
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("Clear");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (String s in e.OldItems)
                        Console.WriteLine($"Remove :  {s}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Repaced - " + e.NewItems[0]);
                    break;
            }
        }
    }
}