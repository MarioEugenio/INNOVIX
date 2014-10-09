using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Reflection;
using System.Web.Security;
using System.Net;
using System.Security.Principal;
using System.Configuration;
using System.Collections.Specialized;

namespace INNOVIX_RFIX.Controllers
{
    public class ControllerBase : Controller
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();

        public JsonResult returnJson<T> (T result)
        {
            var resultado = Json(result, JsonRequestBehavior.AllowGet);
            resultado.MaxJsonLength = int.MaxValue;
            return resultado;
        }

        public JsonResult returnJson<T>(T result, int totalResults, T export)
        {
            Dictionary<string, Object> row = new Dictionary<string, Object>();
            row.Add("total", totalResults);
            row.Add("data", result);
            row.Add("export", export);

            return Json(row, JsonRequestBehavior.AllowGet);
        }

        // Converte uma string em um byte[]
        public string StrToByteArray(byte[] dBytes)
        {
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            return enc.GetString(dBytes);
        }

        public string getMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        public string converterJson<T>(T result)
        {
            return jss.Serialize(result);
        }

        public JsonResult returnMenssage(string message, Boolean success = true, Object retorno = null)
        {
            Dictionary<string, Object> row = new Dictionary<string, Object>();
            row.Add("message", message);
            row.Add("success", success);
            row.Add("return", retorno);

            return Json(row, JsonRequestBehavior.AllowGet);
        }
      
        public string GetBaseUrl()
        {
            var request = System.Web.HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;
            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}