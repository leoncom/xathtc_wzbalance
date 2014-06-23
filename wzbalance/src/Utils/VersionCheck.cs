using System;
using System.Collections.Generic;
using System.Xml;

namespace wzbalance
{
    class VersionCheck
    {
        public static string getVersion()
        {
            string filename = "http://www.xathtc.com/wzbalance/wzbalance.xml";
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/program");
            XmlNode xmlNode = xmlNodeList[0];
            return xmlNode.SelectSingleNode("ver").InnerText;
        }

        public static int needUpdate()
        {
            int result;
            try
            {
                string strB = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string version = VersionCheck.getVersion();
                if (version.CompareTo(strB) > 0)
                {
                    result = 1;
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogEntry("WARNING", ex.Message + ex.StackTrace);
                result = -1;
                return result;
            }
            result = 0;
            return result;
        }

        public static string getUrl()
        {
            string filename = "http://www.xathtc.com/wzbalance/wzbalance.xml";
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/program");
            XmlNode xmlNode = xmlNodeList[0];
            return xmlNode.SelectSingleNode("url").InnerText;
        }
    }
}
