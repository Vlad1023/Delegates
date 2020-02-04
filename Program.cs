using System;
using System.Linq;
using System.Collections.Generic;
namespace Delegates
{
    delegate double Average(double x, double y, double z);

    delegate double Add(double x, double y);
    delegate double Sub(double x, double y);
    delegate double Mul(double x, double y);
    delegate double Divide(double x, double y);


    class Program
    {
        static double GetAvg(Func<Func<int>[], double> avg, params Func<int>[] delArr)
        {
            return avg(delArr);
        }
        static void Main(string[] args)
        {
            #region task1
            Average oper = delegate (double x, double y, double z) { return (x + y + z) / 3; };
            List<int> dd = new List<int>();
            Console.WriteLine(oper(1, 2, 3));
            #endregion

            #region task2
            Add add = (x, y) => (x + y);
            Sub sub = (x, y) => (x - y);
            Mul mul = (x, y) => (x * y);
            Divide divide = (x, y) => { return y != 0 ? x / y : throw new Exception("Dividing by zero"); };
            #endregion

            #region task3
            Func<Delegate[], double> func = (delArr) => { List<int> methods = new List<int>(); Array.ForEach(delArr, (delElem) => { Array.ForEach(delElem.GetInvocationList(), (method) => { methods.Add(Convert.ToInt32(method.DynamicInvoke())); }); }); return methods.Average(); };
            #endregion
        }

    }

}