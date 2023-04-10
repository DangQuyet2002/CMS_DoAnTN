using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public static class CGVCommonHelper
    {
        public static int ToInt32(this object obj)
        {
            try
            {

                return Int32.Parse(obj.ToString().RemoveSpace());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static float ToFloat(this object obj)
        {
            try
            {
                return float.Parse(obj.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string RemoveSpace(this string input)
        {
            do
            {
                input.Replace(" ", "");
            }
            while (input.IndexOf(" ") >= 0);
            return input;
        }
        public static int MapInt(this object obj)
        {
            try
            {
                if (obj == null) return 0;
                if (!obj.ToString().IsNumeric()) return 0;
                return obj.ToInt32();
            }
            catch
            {
                return 0;
            }
        }

        public static float MapFloat(this object obj)
        {
            try
            {
                if (obj == null) return 0;
                return obj.ToFloat();
            }
            catch
            {
                return 0;
            }
        }

        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static string readDiemToString(this object number)
        {
            switch (number.ToString())
            {
                case "0":
                    return "Không";

                case "1":
                    return "Một";
                case "1.1":
                    return "Một phẩy một";
                case "1.2":
                    return "Một phẩy hai";
                case "1.3":
                    return "Một phẩy ba";
                case "1.4":
                    return "Một phẩy bốn";
                case "1.5":
                    return "Một phẩy năm";
                case "1.6":
                    return "Một phẩy sáu";
                case "1.7":
                    return "Một phẩy bảy";
                case "1.8":
                    return "Một phẩy tám";
                case "1.9":
                    return "Một phẩy chín";

                case "2":
                    return "Hai";
                case "2.1":
                    return "Hai phẩy một";
                case "2.2":
                    return "Hai phẩy hai";
                case "2.3":
                    return "Hai phẩy ba";
                case "2.4":
                    return "Hai phẩy bốn";
                case "2.5":
                    return "Hai phẩy năm";
                case "2.6":
                    return "Hai phẩy sáu";
                case "2.7":
                    return "Hai phẩy bảy";
                case "2.8":
                    return "Hai phẩy tám";
                case "2.9":
                    return "Hai phẩy chín";

                case "3":
                    return "Ba";
                case "3.1":
                    return "Ba phẩy một";
                case "3.2":
                    return "Ba phẩy hai";
                case "3.3":
                    return "Ba phẩy ba";
                case "3.4":
                    return "Ba phẩy bốn";
                case "3.5":
                    return "Ba phẩy năm";
                case "3.6":
                    return "Ba phẩy sáu";
                case "3.7":
                    return "Ba phẩy bảy";
                case "3.8":
                    return "Ba phẩy tám";
                case "3.9":
                    return "Ba phẩy chín";

                case "4":
                    return "Bốn";
                case "4.1":
                    return "Bốn phẩy một";
                case "4.2":
                    return "Bốn phẩy hai";
                case "4.3":
                    return "Bốn phẩy ba";
                case "4.4":
                    return "Bốn phẩy bốn";
                case "4.5":
                    return "Bốn phẩy năm";
                case "4.6":
                    return "Bốn phẩy sáu";
                case "4.7":
                    return "Bốn phẩy bảy";
                case "4.8":
                    return "Bốn phẩy tám";
                case "4.9":
                    return "Bốn phẩy chín";

                case "5":
                    return "Năm";
                case "5.1":
                    return "Năm phẩy một";
                case "5.2":
                    return "Năm phẩy hai";
                case "5.3":
                    return "Năm phẩy ba";
                case "5.4":
                    return "Năm phẩy bốn";
                case "5.5":
                    return "Năm phẩy năm";
                case "5.6":
                    return "Năm phẩy sáu";
                case "5.7":
                    return "Năm phẩy bảy";
                case "5.8":
                    return "Năm phẩy tám";
                case "5.9":
                    return "Năm phẩy chín";

                case "6":
                    return "Sáu";
                case "6.1":
                    return "Sáu phẩy một";
                case "6.2":
                    return "Sáu phẩy hai";
                case "6.3":
                    return "Sáu phẩy ba";
                case "6.4":
                    return "Sáu phẩy bốn";
                case "6.5":
                    return "Sáu phẩy năm";
                case "6.6":
                    return "Sáu phẩy sáu";
                case "6.7":
                    return "Sáu phẩy bảy";
                case "6.8":
                    return "Sáu phẩy tám";
                case "6.9":
                    return "Sáu phẩy chín";

                case "7":
                    return "Bảy";
                case "7.1":
                    return "Bảy phẩy một";
                case "7.2":
                    return "Bảy phẩy hai";
                case "7.3":
                    return "Bảy phẩy ba";
                case "7.4":
                    return "Bảy phẩy bốn";
                case "7.5":
                    return "Bảy phẩy năm";
                case "7.6":
                    return "Bảy phẩy sáu";
                case "7.7":
                    return "Bảy phẩy bảy";
                case "7.8":
                    return "Bảy phẩy tám";
                case "7.9":
                    return "Bảy phẩy chín";

                case "8":
                    return "Tám";
                case "8.1":
                    return "Tám phẩy một";
                case "8.2":
                    return "Tám phẩy hai";
                case "8.3":
                    return "Tám phẩy ba";
                case "8.4":
                    return "Tám phẩy bốn";
                case "8.5":
                    return "Tám phẩy năm";
                case "8.6":
                    return "Tám phẩy sáu";
                case "8.7":
                    return "Tám phẩy bảy";
                case "8.8":
                    return "Tám phẩy tám";
                case "8.9":
                    return "Tám phẩy chín";

                case "9":
                    return "Chín";
                case "9.1":
                    return "Chín phẩy một";
                case "9.2":
                    return "Chín phẩy hai";
                case "9.3":
                    return "Chín phẩy ba";
                case "9.4":
                    return "Chín phẩy bốn";
                case "9.5":
                    return "Chín phẩy năm";
                case "9.6":
                    return "Chín phẩy sáu";
                case "9.7":
                    return "Chín phẩy bảy";
                case "9.8":
                    return "Chín phẩy tám";
                case "9.9":
                    return "Chín phẩy chín";

                case "10":
                    return "Mười";
                default:
                    return "";
            }
        }

        //public static void Export(XtraReport _rpt, HttpResponseBase Response)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        try
        //        {
        //            _rpt.CreateDocument();
        //            XlsExportOptions opts = new XlsExportOptions();
        //            _rpt.ExportToXls(ms, opts);
        //            ms.Seek(0, SeekOrigin.Begin);
        //            byte[] report = ms.ToArray();
        //            Response.ContentType = "application/vnd.ms-excel";
        //            Response.Clear();
        //            Response.OutputStream.Write(report, 0, report.Length);
        //            Response.End();
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}

        public static string GetIPAddress()
        {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return Convert.ToString(IP);
                }
            }
            return "";
        }
    }
}
