using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;//正则表达式regex

namespace StudengUI
{
    public class IsOkForm
    {

        #region 处理:对体重的格式控制
        /// <summary>
        /// 使用正则表达式验证非零的正整数
        /// </summary>
        /// <param name="str_intNumber"></param>
        /// <returns></returns>
        public bool IsIntNumber(string str_intNumber)
        {
            return Regex.IsMatch(str_intNumber, @"^\+?[1-9][0-9]*$");// http://book.51cto.com/art/201107/278240.htm     
        }
        /// <summary>
        /// 判断是否是小于4位数的字符
        /// </summary>
        /// <param name="str_intNumber"></param>
        /// <returns></returns>
        public bool IsIntNumberLength(string str_intNumber)
        {
            if (str_intNumber.Length < 4)
            {
                return true;
            }
            return false;
        } 
        #endregion

        #region 处理:对身高的格式控制
        /// <summary>
        /// 使用正则表达式验证两位小数
        /// </summary>
        /// <param name="str_decimal"></param>
        /// <returns></returns>
        public bool IsDecimal(string str_decimal)
        {
            return Regex.IsMatch(str_decimal, @"^[0-9]+\.[0-9]{2}$");//http://book.51cto.com/art/201107/278233.htm   
        } 
        #endregion

        #region 若是不使用连动写日期，可以选择正则表达式来验证日期
        ////处理出生日期月份是否正确
        //public bool IsMonth(string str_Month)
        //{
        //    return Regex.IsMatch(str_Month, @"^(0?[1-9]|1[0-2])$");
        //}
        ////处理出生日期天数是否正确
        //public bool IsDay(string str_day)
        //{
        //    return Regex.IsMatch(str_day, @"^((0?[1-9])|((1|2)[0-9])|30|31)$");      
        //}  
        #endregion

    }
}
