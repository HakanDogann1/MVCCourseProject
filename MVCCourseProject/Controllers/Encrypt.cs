using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MVCCourseProject.Controllers
{
	public class Encrypt
	{
		public static string MD5Create(string text)
		{
			MD5 md5 = MD5.Create();
			md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
			byte[] result = md5.Hash;
			StringBuilder sb = new StringBuilder();
			for(int i=0; i<result.Length; i++)
			{
				sb.Append(result[i].ToString("x2"));
			}
			return sb.ToString();
		} 
	}
}