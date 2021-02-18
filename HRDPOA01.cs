using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace hrdNet
{
    //구직자훈련과정
    class HRDPOA01
    {
        public void getHRDPOA01_01(string date)
        {
            try
            {
                string url = "http://www.hrd.go.kr/jsp/HRDP/HRDPO00/HRDPOA60/HRDPOA60_1.jsp?"; // Service Key
                url += "authKey=ePJ32XXfC33CWJO40X7UsBa3MPIA4j5J";
                url += "&returnType=XML";
                url += "&outType=1";
                url += "&pageNum=1";
                url += "&pageSize=100";
                url += "&srchTraStDt=" + date;
                url += "&srchTraEndDt=" + date;
                url += "&sort=ASC";
                url += "&sortCol=TOT_FXNUM";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/xml; chearset=utf-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.66 Safari/537.36";

                int totalCount = 0;
                string results = "";

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true);
                    results = reader.ReadToEnd();
                    XDocument doc = XDocument.Parse(results);
                    Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

                    foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
                    {
                        int keyInt = 0;
                        string keyName = element.Name.LocalName;

                        if (keyName == "scn_cnt")
                        {
                            totalCount = int.Parse(element.Value);

                            break;
                        }
                    }
                }

                int forCount = (totalCount / 100) + 1;
                int time = 0;

                for (int i = 1; i < forCount + 1; i++)
                {
                    Console.WriteLine("구직자훈련과정 : " + i + "번째");
                    string param = "http://www.hrd.go.kr/jsp/HRDP/HRDPO00/HRDPOA60/HRDPOA60_1.jsp?"; // Service Key
                    param += "authKey=ePJ32XXfC33CWJO40X7UsBa3MPIA4j5J";
                    param += "&returnType=XML";
                    param += "&outType=1";
                    param += "&pageNum=" + i;
                    param += "&pageSize=100";
                    param += "&srchTraStDt=" + date;
                    param += "&srchTraEndDt=" + date;
                    param += "&sort=ASC";
                    param += "&sortCol=TOT_FXNUM";
                    HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(param);
                    request2.Method = "GET";
                    request2.ContentType = "application/xml; chearset=utf-8";
                    request2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.66 Safari/537.36";
                    string results2 = "";

                    using (HttpWebResponse response = request2.GetResponse() as HttpWebResponse)
                    {
                        time++;
                        if (time == 50)
                        {
                            time = 0;
                            Console.WriteLine("대기중 ....");
                            Thread.Sleep(5000);
                        }

                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true);
                        results2 = reader.ReadToEnd();

                        XDocument doc = XDocument.Parse(results2);

                        var itemList = from r in doc.Descendants("scn_list")
                                       select new HRDPOA01_01
                                       {
                                           address = r.Element("address") == null ? "" : r.Element("address").Value,
                                           contents = r.Element("contents") == null ? "" : r.Element("contents").Value,
                                           courseMan = r.Element("courseMan") == null ? "" : r.Element("courseMan").Value,
                                           eiEmplCnt3 = r.Element("eiEmplCnt3") == null ? "" : r.Element("eiEmplCnt3").Value,
                                           eiEmplCnt3Gt10 = r.Element("eiEmplCnt3Gt10") == null ? "" : r.Element("eiEmplCnt3Gt10").Value,
                                           eiEmplRate3 = r.Element("eiEmplRate3") == null ? "" : r.Element("eiEmplRate3").Value,
                                           eiEmplRate6 = r.Element("eiEmplRate6") == null ? "" : r.Element("eiEmplRate6").Value,
                                           grade = r.Element("grade") == null ? "" : r.Element("grade").Value,
                                           imgGubun = r.Element("imgGubun") == null ? "" : r.Element("imgGubun").Value,
                                           instCd = r.Element("instCd") == null ? "" : r.Element("instCd").Value,
                                           ncsCd = r.Element("ncsCd") == null ? "" : r.Element("ncsCd").Value,
                                           realMan = r.Element("realMan") == null ? "" : r.Element("realMan").Value,
                                           regCourseMan = r.Element("regCourseMan") == null ? "" : r.Element("regCourseMan").Value,
                                           subTitle = r.Element("subTitle") == null ? "" : r.Element("subTitle").Value,
                                           subTitleLink = r.Element("subTitleLink") == null ? "" : r.Element("subTitleLink").Value,
                                           superViser = r.Element("superViser") == null ? "" : r.Element("superViser").Value,
                                           telNo = r.Element("telNo") == null ? "" : r.Element("telNo").Value,
                                           title = r.Element("title") == null ? "" : r.Element("title").Value,
                                           titleIcon = r.Element("titleIcon") == null ? "" : r.Element("titleIcon").Value,
                                           titleLink = r.Element("titleLink") == null ? "" : r.Element("titleLink").Value,
                                           traEndDate = r.Element("traEndDate") == null ? "" : r.Element("traEndDate").Value,
                                           traStartDate = r.Element("traStartDate") == null ? "" : r.Element("traStartDate").Value,
                                           trainTarget = r.Element("trainTarget") == null ? "" : r.Element("trainTarget").Value,
                                           trainTargetCd = r.Element("trainTargetCd") == null ? "" : r.Element("trainTargetCd").Value,
                                           trainstCstId = r.Element("trainstCstId") == null ? "" : r.Element("trainstCstId").Value,
                                           trprDegr = r.Element("trprDegr") == null ? "" : r.Element("trprDegr").Value,
                                           trprId = r.Element("trprId") == null ? "" : r.Element("trprId").Value,
                                           yardMan = r.Element("yardMan") == null ? "" : r.Element("yardMan").Value
                                       };

                        for (int j = 0; j < itemList.ToList().Count; j++)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(" EXEC PROC_hrdNet_jobHunting ");
                            sb.Append(" '" + itemList.ToList()[j].address.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].contents.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].courseMan.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].eiEmplCnt3.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].eiEmplCnt3Gt10.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].eiEmplRate3.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].eiEmplRate6.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].grade.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].imgGubun.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].instCd.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].ncsCd.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].realMan.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].regCourseMan.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].subTitle.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].subTitleLink.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].superViser.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].telNo.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].title.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].titleIcon.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].titleLink.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].traEndDate.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].traStartDate.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].trainTarget.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].trainTargetCd.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].trainstCstId.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].trprDegr.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].trprId.Replace("'", "") + "',");
                            sb.Append(" '" + itemList.ToList()[j].yardMan.Replace("'", "") + "'");

                            Program.insert(sb.ToString());
                        }
                    }
                }
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                }
            }
        }

        public void getHRDPOA01_02()
        {
            DataSet ds = Program.selectDS("select trprId,trprDegr,trainstCstId from HRDPOA01_01");

            Console.WriteLine("HRDPOA01_02 시작");
            int time = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                time++;
                if (time == 50)
                {
                    time = 0;
                    Console.WriteLine("대기중 ....");
                    Thread.Sleep(5000);
                }

                DataRow dr = ds.Tables[0].Rows[i];

                string url = "http://www.hrd.go.kr/jsp/HRDP/HRDPO00/HRDPOA60/HRDPOA60_2.jsp?authKey=ePJ32XXfC33CWJO40X7UsBa3MPIA4j5J&returnType=XML&outType=2" +
                    "&srchTrprId=" + dr["trprId"] +
                    "&srchTrprDegr=" + dr["trprDegr"] +
                    "&srchTorgId=" + dr["trainstCstId"];

                hrdNet_Detail detail = new hrdNet_Detail();
                detail.gethrdNet_Detail(url, "HRDPOA01");
            }

            Console.WriteLine("HRDPOA01_02 종료");
        }
    }

    class HRDPOA01_01
    {
        public string address { get; set; }
        public string contents { get; set; }
        public string courseMan { get; set; }
        public string eiEmplCnt3 { get; set; }
        public string eiEmplCnt3Gt10 { get; set; }
        public string eiEmplRate3 { get; set; }
        public string eiEmplRate6 { get; set; }
        public string grade { get; set; }
        public string imgGubun { get; set; }
        public string instCd { get; set; }
        public string ncsCd { get; set; }
        public string realMan { get; set; }
        public string regCourseMan { get; set; }
        public string subTitle { get; set; }
        public string subTitleLink { get; set; }
        public string superViser { get; set; }
        public string telNo { get; set; }
        public string title { get; set; }
        public string titleIcon { get; set; }
        public string titleLink { get; set; }
        public string traEndDate { get; set; }
        public string traStartDate { get; set; }
        public string trainTarget { get; set; }
        public string trainTargetCd { get; set; }
        public string trainstCstId { get; set; }
        public string trprDegr { get; set; }
        public string trprId { get; set; }
        public string yardMan { get; set; }
    }
}
