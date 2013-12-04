using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
namespace PassWordManager
{
    public partial class MainWind : Form
    {
        private XmlDocument ConfigXml = new XmlDocument();
        public MainWind()
        {
            InitializeComponent();
            UserLogin Login = new UserLogin();
            if (Login.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!LoadData("PassData.xml"))
                    {
                        if (MessageBox.Show("是否新建？", "找不到数据文件!", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            System.Environment.Exit(0);
                        else
                        {
                            XmlDeclaration dec = ConfigXml.CreateXmlDeclaration("1.0", "GB2312", null);
                            ConfigXml.AppendChild(dec);
                            //创建一个根节点（一级）
                            XmlElement root = ConfigXml.CreateElement("Datas");
                            ConfigXml.AppendChild(root);
                            ConfigXml.Save("PassData.xml");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("找不到数据文件!");
                    System.Environment.Exit(0);
                }
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        private bool LoadData(string FileName)
        {
            try
            {
                ConfigXml.Load(FileName);
                dataGridViewmain.Rows.Clear();
                XmlNodeList NodeList = ConfigXml.GetElementsByTagName("UserData");
                for (int i = 0; i < NodeList.Count; i++)
                {
                    int Index = dataGridViewmain.Rows.Add();
                    try
                    {
                        dataGridViewmain.Rows[Index].Cells["Program"].Value = DESDecrypt(NodeList[i].Attributes["Program"].Value,"testtest");
                        dataGridViewmain.Rows[Index].Cells["Username"].Value = DESDecrypt(NodeList[i].Attributes["Username"].Value, "testtest");
                        dataGridViewmain.Rows[Index].Cells["Password"].Value = DESDecrypt(NodeList[i].Attributes["Password"].Value, "testtest");
                        dataGridViewmain.Rows[Index].Cells["Remark"].Value = DESDecrypt(NodeList[i].Attributes["Remark"].Value, "testtest");
                    }
                    catch (Exception e)
                    {
                        dataGridViewmain.Rows.RemoveAt(Index);
                    }
                }
                dataGridViewmain.Sort(dataGridViewmain.Columns[0], ListSortDirection.Ascending);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ConfigXml.RemoveAll();
            XmlElement root = ConfigXml.CreateElement("Datas");
            ConfigXml.AppendChild(root);
            for (int Index = 0; Index < dataGridViewmain.Rows.Count; Index++)
            {
                if (dataGridViewmain.Rows[Index].Cells["Program"].Value == null || dataGridViewmain.Rows[Index].Cells["Program"].Value.ToString() == ""
                    || dataGridViewmain.Rows[Index].Cells["Username"].Value == null || dataGridViewmain.Rows[Index].Cells["Username"].Value.ToString() == ""
                    || dataGridViewmain.Rows[Index].Cells["Password"].Value == null || dataGridViewmain.Rows[Index].Cells["Password"].Value.ToString() == "")
                {
                    if (Index == dataGridViewmain.Rows.Count - 1)
                        continue;
                }
                XmlElement ThisAdd = ConfigXml.CreateElement("UserData");
                ThisAdd.SetAttribute("Program", DESEncrypt(dataGridViewmain.Rows[Index].Cells["Program"].Value, "testtest"));
                ThisAdd.SetAttribute("Username", DESEncrypt(dataGridViewmain.Rows[Index].Cells["Username"].Value, "testtest"));
                ThisAdd.SetAttribute("Password", DESEncrypt(dataGridViewmain.Rows[Index].Cells["Password"].Value, "testtest"));
                ThisAdd.SetAttribute("Remark", DESEncrypt(dataGridViewmain.Rows[Index].Cells["Remark"].Value, "testtest"));
                root.AppendChild(ThisAdd);
            }
            ConfigXml.Save("PassData.xml");
            MessageBox.Show("保存成功!");
        }
        
        public static string DESEncrypt(object EncryptText, string EncryptKey)
        {
            if (EncryptText == null) return "";
            string EncryptString = EncryptText.ToString();
            if (string.IsNullOrEmpty(EncryptString)) return "";
            if (string.IsNullOrEmpty(EncryptKey)) { throw (new Exception("密钥不得为空")); }
            if (EncryptKey.Length != 8) { throw (new Exception("密钥必须为8位")); }
            byte[] m_btIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            string m_strEncrypt = "";
            DESCryptoServiceProvider m_DESProvider = new DESCryptoServiceProvider();
            try
            {
                byte[] m_btEncryptString = Encoding.Default.GetBytes(EncryptString);
                MemoryStream m_stream = new MemoryStream();
                CryptoStream m_cstream = new CryptoStream(m_stream, m_DESProvider.CreateEncryptor(Encoding.Default.GetBytes(EncryptKey), m_btIV), CryptoStreamMode.Write);
                m_cstream.Write(m_btEncryptString, 0, m_btEncryptString.Length);
                m_cstream.FlushFinalBlock();
                m_strEncrypt = Convert.ToBase64String(m_stream.ToArray());
                m_stream.Close(); m_stream.Dispose();
                m_cstream.Close(); m_cstream.Dispose();
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_DESProvider.Clear(); }
            return m_strEncrypt;
        }
        /// <summary>
        /// DES 解密(数据加密标准，速度较快，适用于加密大量数据的场合)
        /// </summary>
        /// <param name="DecryptString">待解密的密文</param>
        /// <param name="DecryptKey">解密的密钥</param>
        /// <returns>returns</returns>
        public static string DESDecrypt(string DecryptString, string DecryptKey)
        {
            if (string.IsNullOrEmpty(DecryptString)) return "";
            if (string.IsNullOrEmpty(DecryptKey)) { throw (new Exception("密钥不得为空")); }
            if (DecryptKey.Length != 8) { throw (new Exception("密钥必须为8位")); }
            byte[] m_btIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            string m_strDecrypt = "";
            DESCryptoServiceProvider m_DESProvider = new DESCryptoServiceProvider();
            try
            {
                byte[] m_btDecryptString = Convert.FromBase64String(DecryptString);
                MemoryStream m_stream = new MemoryStream();
                CryptoStream m_cstream = new CryptoStream(m_stream, m_DESProvider.CreateDecryptor(Encoding.Default.GetBytes(DecryptKey), m_btIV), CryptoStreamMode.Write);
                m_cstream.Write(m_btDecryptString, 0, m_btDecryptString.Length);
                m_cstream.FlushFinalBlock();
                m_strDecrypt = Encoding.Default.GetString(m_stream.ToArray());
                m_stream.Close(); m_stream.Dispose();
                m_cstream.Close(); m_cstream.Dispose();
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_DESProvider.Clear(); }
            return m_strDecrypt;
        }


       
    }
}
