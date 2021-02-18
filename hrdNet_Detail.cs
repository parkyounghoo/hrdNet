using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hrdNet
{
    class hrdNet_Detail
    {
        public void gethrdNet_Detail(string url, string hrdGubun)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/xml; chearset=utf-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.66 Safari/537.36";
            string results = "";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true);
                results = reader.ReadToEnd();

                XDocument doc = XDocument.Parse(results);

                var itemList = from r in doc.Descendants("inst_base_info")
                               select new inst_base_info
                               {
                                   trprId = r.Element("trprId") == null ? "" : r.Element("trprId").Value,
                                   trprDegr = r.Element("trprDegr") == null ? "" : r.Element("trprDegr").Value,
                                   trprGbn = r.Element("trprGbn") == null ? "" : r.Element("trprGbn").Value,
                                   trprNm = r.Element("trprNm") == null ? "" : r.Element("trprNm").Value,
                                   addr1 = r.Element("addr1") == null ? "" : r.Element("addr1").Value,
                                   addr2 = r.Element("addr2") == null ? "" : r.Element("addr2").Value,
                                   filePath = r.Element("filePath") == null ? "" : r.Element("filePath").Value,
                                   hpAddr = r.Element("hpAddr") == null ? "" : r.Element("hpAddr").Value,
                                   inoNm = r.Element("inoNm") == null ? "" : r.Element("inoNm").Value,
                                   instIno = r.Element("instIno") == null ? "" : r.Element("instIno").Value,
                                   instPerTrco = r.Element("instPerTrco") == null ? "" : r.Element("instPerTrco").Value,
                                   ncsCd = r.Element("ncsCd") == null ? "" : r.Element("ncsCd").Value,
                                   ncsNm = r.Element("ncsNm") == null ? "" : r.Element("ncsNm").Value,
                                   ncsYn = r.Element("ncsYn") == null ? "" : r.Element("ncsYn").Value,
                                   nonNcsCoursePrcttqTime = r.Element("nonNcsCoursePrcttqTime") == null ? "" : r.Element("nonNcsCoursePrcttqTime").Value,
                                   nonNcsCourseTheoryTime = r.Element("nonNcsCourseTheoryTime") == null ? "" : r.Element("nonNcsCourseTheoryTime").Value,
                                   pFileName = r.Element("pFileName") == null ? "" : r.Element("pFileName").Value,
                                   perTrco = r.Element("perTrco") == null ? "" : r.Element("perTrco").Value,
                                   torgParGrad = r.Element("torgParGrad") == null ? "" : r.Element("torgParGrad").Value,
                                   trDcnt = r.Element("trDcnt") == null ? "" : r.Element("trDcnt").Value,
                                   traingMthCd = r.Element("traingMthCd") == null ? "" : r.Element("traingMthCd").Value,
                                   trprChap = r.Element("trprChap") == null ? "" : r.Element("trprChap").Value,
                                   trprChapEmail = r.Element("trprChapEmail") == null ? "" : r.Element("trprChapEmail").Value,
                                   trprChapTel = r.Element("trprChapTel") == null ? "" : r.Element("trprChapTel").Value,
                                   trprTarget = r.Element("trprTarget") == null ? "" : r.Element("trprTarget").Value,
                                   trprTargetNm = r.Element("trprTargetNm") == null ? "" : r.Element("trprTargetNm").Value,
                                   trtm = r.Element("trtm") == null ? "" : r.Element("trtm").Value,
                                   zipCd = r.Element("zipCd") == null ? "" : r.Element("zipCd").Value
                               };

                var itemListSub = from r in doc.Descendants("inst_detail_info")
                               select new inst_detail_info
                               {
                                   trprId = r.Element("trprId") == null ? "" : r.Element("trprId").Value,
                                   trprDegr = r.Element("trprDegr") == null ? "" : r.Element("trprDegr").Value,
                                   govBusiNm = r.Element("govBusiNm") == null ? "" : r.Element("govBusiNm").Value,
                                   torgGbnCd = r.Element("torgGbnCd") == null ? "" : r.Element("torgGbnCd").Value,
                                   totTraingDyct = r.Element("totTraingDyct") == null ? "" : r.Element("totTraingDyct").Value,
                                   totTraingTime = r.Element("totTraingTime") == null ? "" : r.Element("totTraingTime").Value,
                                   totalCrsAt = r.Element("totalCrsAt") == null ? "" : r.Element("totalCrsAt").Value,
                                   trprNm = r.Element("trprNm") == null ? "" : r.Element("trprNm").Value
                               };

                for (int j = 0; j < itemList.ToList().Count; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(" insert into hrdNet_Detail values(");
                    sb.Append(" '" + hrdGubun + "',");
                    sb.Append(" '" + itemList.ToList()[j].trprId.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trprDegr.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trprGbn.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trprNm.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].addr1.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].addr2.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].filePath.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].hpAddr.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].inoNm.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].instIno.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].instPerTrco.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].ncsCd.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].ncsNm.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].ncsYn.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].nonNcsCoursePrcttqTime.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].nonNcsCourseTheoryTime.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].pFileName.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].perTrco.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].torgParGrad.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trDcnt.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].traingMthCd.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trprChap.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trprChapEmail.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trprChapTel.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trprTarget.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trprTargetNm.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].trtm.Replace("'", "") + "',");
                    sb.Append(" '" + itemList.ToList()[j].zipCd.Replace("'", "") + "')");

                    Program.insert(sb.ToString());
                }

                for (int j = 0; j < itemListSub.ToList().Count; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(" insert into hrdNet_Detail_info values(");
                    sb.Append(" '" + hrdGubun + "',");
                    sb.Append(" '" + itemListSub.ToList()[j].trprId.Replace("'", "") + "',");
                    sb.Append(" '" + itemListSub.ToList()[j].trprDegr.Replace("'", "") + "',");
                    sb.Append(" '" + itemListSub.ToList()[j].govBusiNm.Replace("'", "") + "',");
                    sb.Append(" '" + itemListSub.ToList()[j].torgGbnCd.Replace("'", "") + "',");
                    sb.Append(" '" + itemListSub.ToList()[j].totTraingDyct.Replace("'", "") + "',");
                    sb.Append(" '" + itemListSub.ToList()[j].totTraingTime.Replace("'", "") + "',");
                    sb.Append(" '" + itemListSub.ToList()[j].totalCrsAt.Replace("'", "") + "',");
                    sb.Append(" '" + itemListSub.ToList()[j].trprNm.Replace("'", "") + "')");

                    Program.insert(sb.ToString());
                }
            }
        }
    }

    internal class inst_base_info
    {
        #region model
        public string trprId { get; set; }
        public string trprDegr { get; set; }
        public string trprGbn { get; set; }
        public string trprNm { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string filePath { get; set; }
        public string hpAddr { get; set; }
        public string inoNm { get; set; }
        public string instIno { get; set; }
        public string instPerTrco { get; set; }
        public string ncsCd { get; set; }
        public string ncsNm { get; set; }
        public string ncsYn { get; set; }
        public string nonNcsCoursePrcttqTime { get; set; }
        public string nonNcsCourseTheoryTime { get; set; }
        public string pFileName { get; set; }
        public string perTrco { get; set; }
        public string torgParGrad { get; set; }
        public string trDcnt { get; set; }
        public string traingMthCd { get; set; }
        public string trprChap { get; set; }
        public string trprChapEmail { get; set; }
        public string trprChapTel { get; set; }
        public string trprTarget { get; set; }
        public string trprTargetNm { get; set; }
        public string trtm { get; set; }
        public string zipCd { get; set; }
        #endregion
    }

    internal class inst_detail_info
    {
        public string trprId { get; set; }
        public string trprDegr { get; set; }
        public string govBusiNm { get; set; }
        public string torgGbnCd { get; set; }
        public string totTraingDyct { get; set; }
        public string totTraingTime { get; set; }
        public string totalCrsAt { get; set; }
        public string trprNm { get; set; }
    }
}
