/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2019/7/15
 * Time: 10:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management;

namespace LockScreen
{
	/// <summary>
	/// Description of Device.
	/// </summary>
	public class Device
	{
		public Device()
		{
			
		}

		public static string getDeviceId() {
			string uid = GetCPUSerialNumber() + GetDiskSerialNumber() + GetMacAddressNumber();
			byte[] tmp = System.Text.Encoding.ASCII.GetBytes ( uid );
			uint crc = CRCUtil.GetCRC32(tmp);
			string res = Convert.ToString(crc,16);
			string prefix = "";
			for(int i=8-res.Length; i>0; i--) {
				prefix += "0";
			}
			return prefix + res.ToUpperInvariant();
		}
		
		/// <summary>
		/// 获取cpu序列号
		///  string getInfo = cm.GetCPUSerialNumber()
		///  if (getInfo != _info){Application.Exit();}
		/// </summary>
		/// <returns></returns>
		public static string GetCPUSerialNumber()
		{
			string cpuSerialNumber = string.Empty;
			ManagementClass mc = new ManagementClass("Win32_Processor");
			ManagementObjectCollection moc = mc.GetInstances();
			foreach (ManagementObject mo in moc)
			{
				cpuSerialNumber = mo["ProcessorId"].ToString();
				break;
			}
			mc.Dispose();
			moc.Dispose();
			return cpuSerialNumber;
		}

		/// <summary>
		/// 获取硬盘序列号 static
		/// </summary>
		/// <returns></returns>
		public static string GetDiskSerialNumber()
		{
			ManagementObjectSearcher mos = new ManagementObjectSearcher();
			mos.Query = new SelectQuery("Win32_DiskDrive", "", new string[] { "PNPDeviceID", "Signature" });
			ManagementObjectCollection myCollection = mos.Get();
			ManagementObjectCollection.ManagementObjectEnumerator em = myCollection.GetEnumerator();
			em.MoveNext();
			ManagementBaseObject moo = em.Current;
			string id = moo.Properties["signature"].Value.ToString().Trim();
			return id;
		}

		/// <summary>
		/// 获取网卡ID
		/// </summary>
		/// <returns></returns>
		public static string GetMacAddressNumber()
		{
			try
			{
				string mac = "";
				ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
				ManagementObjectCollection moc = mc.GetInstances();
				foreach (ManagementObject mo in moc)
					if ((bool)mo["IPEnabled"] == true)
				{
					mac += mo["MacAddress"].ToString() + " ";
					break;
				}
				moc = null;
				mc = null;
				return mac.Trim();
			}
			catch (Exception e)
			{
				return e.Message + "uMnIk";
			}
		}
	}
}
