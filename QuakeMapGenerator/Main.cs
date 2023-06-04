using CoreTweet;
using Newtonsoft.Json;
using QuakeMapGenerator.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace QuakeMapGenerator
{
    public partial class Main : Form//todo:telopに送る
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Click(object sender, EventArgs e)
        {

        }
        bool NoFirst = false;
        private async void P2P_Tick(object sender, EventArgs e)
        {
            try
            {
                P2P.Interval = 15000;
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　動作開始");
                WebClient wc_P2PQuake = new WebClient
                {
                    Encoding = Encoding.UTF8
                };
                //通常
                string P2Pquake_json = await wc_P2PQuake.DownloadStringTaskAsync("https://api.p2pquake.net/v2/history?codes=551");
                //○個前
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?offset=1"); Test.Text = "過去の情報です。";
                //福島県沖2022(通常)
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?until_date=20220316");Test.Text = "過去の情報です。";
                //福島県沖2022(しんどそくほー)
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?offset=1&until_date=20220316");Test.Text = "過去の情報です。";
                //胆振東部
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?offset=2&order=1&since_date=20180906");Test.Text = "過去の情報です。";
                //胆振東部震源
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?offset=5&order=1&since_date=20180906"); Test.Text = "過去の情報です。";
                //しんどそくほー
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?quake_type=ScalePrompt&min_scale=40&max_scale=50");Test.Text = "過去の情報です。";
                //ケルデマック
                //string P2Pquake_json = wc_P2PQuake.DownloadString(" https://api.p2pquake.net/v2/jma/quake?order=1&since_date=20210305");Test.Text = "過去の情報です。";
                //大阪北部
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?offset=1&until_date=20180618&min_scale=45"); Test.Text = "過去の情報です。";
                //大阪北部(しんどそくほー)
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?offset=95&until_date=20180618"); Test.Text = "過去の情報です。";
                //山形県沖
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?offset=2&until_date=20190618&min_scale=45"); Test.Text = "過去の情報です。";
                //山形県沖(しんどそくほー)
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?quake_type=ScalePrompt&offset=1&until_date=20190618&min_scale=45"); Test.Text = "過去の情報です。";
                //2022能登(しんげんじょーほー)
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?offset=17&until_date=20220619"); Test.Text = "過去の情報です。";
                //2022能登(しんどそくほー)
                //string P2Pquake_json = wc_P2PQuake.DownloadString("https://api.p2pquake.net/v2/jma/quake?offset=18&until_date=20220619"); Test.Text = "過去の情報です。";


                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　ダウンロード終了");
                double StartTime = Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmss.ffff"));
                List<Json> P2PQuake_json = JsonConvert.DeserializeObject<List<Json>>(P2Pquake_json);
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　デシアライズ終了");

                string RemoteTalkText = "";
                UpdateTime.Text = "更新時刻:" + DateTime.Now.ToString("HH:mm:ss");
                if (P2PQuake_json[0].Id != LatestEarthquakeID)
                {
                    LatestEarthquakeID = P2PQuake_json[0].Id;
                    string MaxInt = "";

                    if (P2PQuake_json[0].Issue.Type == "ScalePrompt")//震度速報
                    {

                        Map.Image = null;
                        Map.BackgroundImage = null;
                        List<string> Area_Sindo1 = new List<string>();
                        List<string> Area_Sindo2 = new List<string>();
                        List<string> Area_Sindo3 = new List<string>();
                        List<string> Area_Sindo4 = new List<string>();
                        List<string> Area_Sindo5 = new List<string>();
                        List<string> Area_Sindo6 = new List<string>();
                        List<string> Area_Sindo7 = new List<string>();
                        List<string> Area_Sindo8 = new List<string>();
                        List<string> Area_Sindo9 = new List<string>();
                        List<string> Area_SindoNull = new List<string>();
                        string AreaString = "";
                        Dictionary<string, int> AreaDic = new Dictionary<string, int>();
                        for (int x = 0; x < P2PQuake_json[0].Points.Count; x++)
                        {
                            AreaString += P2PQuake_json[0].Points[x].Addr;
                            AreaDic.Add(P2PQuake_json[0].Points[x].Addr, P2PQuake_json[0].Points[x].Scale);

                            if (P2PQuake_json[0].Points[x].Scale == 10)
                                Area_Sindo1.Add(P2PQuake_json[0].Points[x].Addr);
                            else if (P2PQuake_json[0].Points[x].Scale == 20)
                                Area_Sindo2.Add(P2PQuake_json[0].Points[x].Addr);
                            else if (P2PQuake_json[0].Points[x].Scale == 30)
                                Area_Sindo3.Add(P2PQuake_json[0].Points[x].Addr);
                            else if (P2PQuake_json[0].Points[x].Scale == 40)
                                Area_Sindo4.Add(P2PQuake_json[0].Points[x].Addr);
                            else if (P2PQuake_json[0].Points[x].Scale == 45)
                                Area_Sindo5.Add(P2PQuake_json[0].Points[x].Addr);
                            else if (P2PQuake_json[0].Points[x].Scale == 50)
                                Area_Sindo6.Add(P2PQuake_json[0].Points[x].Addr);
                            else if (P2PQuake_json[0].Points[x].Scale == 55)
                                Area_Sindo7.Add(P2PQuake_json[0].Points[x].Addr);
                            else if (P2PQuake_json[0].Points[x].Scale == 60)
                                Area_Sindo8.Add(P2PQuake_json[0].Points[x].Addr);
                            else if (P2PQuake_json[0].Points[x].Scale == 70)
                                Area_Sindo9.Add(P2PQuake_json[0].Points[x].Addr);
                            else if (P2PQuake_json[0].Points[x].Scale == 46)
                                Area_SindoNull.Add(P2PQuake_json[0].Points[x].Addr);
                        }
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　震度別分配終了");
                        string Area = "";
                        foreach (string Area_ in AreaDic.Keys)
                            Area += Area_;
                        string AreaAll = "";
                        double PointXMin = 9999;
                        double PointXMax = 0;
                        double PointYMin = 9999;
                        double PointYMax = 0;

                        Bitmap canvas2 = new Bitmap(Resources.JapanMap1);
                        Graphics ShindoImage2 = Graphics.FromImage(canvas2);
                        if (Area_Sindo3.Count != 0)
                        {
                            string Area3 = "《震度3》";
                            for (int x = 0; x < Area_Sindo3.Count; x++)
                            {
                                int imagex = LocationDicX[Area_Sindo3[x]] - 10;
                                int imagey = LocationDicY[Area_Sindo3[x]] - 10;
                                ShindoImage2.DrawImage(Resources.MapShindo32, imagex, imagey);
                                Area3 += " " + Area_Sindo3[x];
                                if (imagex - 40 < PointXMin)
                                    PointXMin = imagex - 40;
                                if (imagex + 60 > PointXMax)
                                    PointXMax = imagex + 60;
                                if (imagey - 40 < PointYMin)
                                    PointYMin = imagey - 40;
                                if (imagey + 60 > PointYMax)
                                    PointYMax = imagey + 60;
                            }
                            AreaAll = Area3 + "\n" + AreaAll;
                            MaxInt = "3";
                        }
                        if (P2PQuake_json[0].Earthquake.MaxScale >= 40)
                        {
                            if (Area_Sindo4.Count != 0)
                            {
                                string Area4 = "《震度4》";
                                for (int x = 0; x < Area_Sindo4.Count; x++)
                                {
                                    int imagex = LocationDicX[Area_Sindo4[x]] - 10;
                                    int imagey = LocationDicY[Area_Sindo4[x]] - 10;
                                    ShindoImage2.DrawImage(Resources.MapShindo42, imagex, imagey);
                                    Area4 += " " + Area_Sindo4[x];
                                    if (imagex - 40 < PointXMin)
                                        PointXMin = imagex - 40;
                                    if (imagex + 60 > PointXMax)
                                        PointXMax = imagex + 60;
                                    if (imagey - 40 < PointYMin)
                                        PointYMin = imagey - 40;
                                    if (imagey + 60 > PointYMax)
                                        PointYMax = imagey + 60;
                                }
                                AreaAll = Area4 + "\n" + AreaAll;
                                MaxInt = "4";
                            }
                            if (P2PQuake_json[0].Earthquake.MaxScale >= 45)
                            {
                                if (Area_Sindo5.Count != 0)
                                {
                                    string Area5 = "《震度5弱》";
                                    for (int x = 0; x < Area_Sindo5.Count; x++)
                                    {
                                        int imagex = LocationDicX[Area_Sindo5[x]] - 10;
                                        int imagey = LocationDicY[Area_Sindo5[x]] - 10;
                                        ShindoImage2.DrawImage(Resources.MapShindo52, imagex, imagey);
                                        Area5 += " " + Area_Sindo5[x];
                                        if (imagex - 40 < PointXMin)
                                            PointXMin = imagex - 40;
                                        if (imagex + 60 > PointXMax)
                                            PointXMax = imagex + 60;
                                        if (imagey - 40 < PointYMin)
                                            PointYMin = imagey - 40;
                                        if (imagey + 60 > PointYMax)
                                            PointYMax = imagey + 60;
                                    }
                                    AreaAll = Area5 + "\n" + AreaAll;
                                    MaxInt = "5弱";
                                }
                                if (P2PQuake_json[0].Earthquake.MaxScale >= 50)
                                {
                                    if (Area_Sindo6.Count != 0)
                                    {
                                        string Area6 = "《震度5強》";
                                        for (int x = 0; x < Area_Sindo6.Count; x++)
                                        {
                                            int imagex = LocationDicX[Area_Sindo6[x]] - 10;
                                            int imagey = LocationDicY[Area_Sindo6[x]] - 10;
                                            ShindoImage2.DrawImage(Resources.MapShindo62, imagex, imagey);
                                            Area6 += " " + Area_Sindo6[x];
                                            if (imagex - 40 < PointXMin)
                                                PointXMin = imagex - 40;
                                            if (imagex + 60 > PointXMax)
                                                PointXMax = imagex + 60;
                                            if (imagey - 40 < PointYMin)
                                                PointYMin = imagey - 40;
                                            if (imagey + 60 > PointYMax)
                                                PointYMax = imagey + 60;
                                        }
                                        AreaAll = Area6 + "\n" + AreaAll;
                                        MaxInt = "5強";
                                    }
                                    if (P2PQuake_json[0].Earthquake.MaxScale >= 55)
                                    {
                                        if (Area_Sindo7.Count != 0)
                                        {
                                            string Area7 = "《震度6弱》";
                                            for (int x = 0; x < Area_Sindo7.Count; x++)
                                            {
                                                int imagex = LocationDicX[Area_Sindo7[x]] - 10;
                                                int imagey = LocationDicY[Area_Sindo7[x]] - 10;
                                                ShindoImage2.DrawImage(Resources.MapShindo72, imagex, imagey);
                                                Area7 += " " + Area_Sindo7[x];
                                                if (imagex - 40 < PointXMin)
                                                    PointXMin = imagex - 40;
                                                if (imagex + 60 > PointXMax)
                                                    PointXMax = imagex + 60;
                                                if (imagey - 40 < PointYMin)
                                                    PointYMin = imagey - 40;
                                                if (imagey + 60 > PointYMax)
                                                    PointYMax = imagey + 60;
                                            }
                                            AreaAll = Area7 + "\n" + AreaAll;
                                            MaxInt = "6弱";
                                        }
                                        if (P2PQuake_json[0].Earthquake.MaxScale >= 60)
                                        {
                                            if (Area_Sindo8.Count != 0)
                                            {
                                                string Area8 = "《震度6強》";
                                                for (int x = 0; x < Area_Sindo8.Count; x++)
                                                {
                                                    int imagex = LocationDicX[Area_Sindo8[x]] - 10;
                                                    int imagey = LocationDicY[Area_Sindo8[x]] - 10;
                                                    ShindoImage2.DrawImage(Resources.MapShindo82, imagex, imagey);
                                                    Area8 += " " + Area_Sindo8[x];
                                                    if (imagex - 40 < PointXMin)
                                                        PointXMin = imagex - 40;
                                                    if (imagex + 60 > PointXMax)
                                                        PointXMax = imagex + 60;
                                                    if (imagey - 40 < PointYMin)
                                                        PointYMin = imagey - 40;
                                                    if (imagey + 60 > PointYMax)
                                                        PointYMax = imagey + 60;
                                                }
                                                AreaAll = Area8 + "\n" + AreaAll;
                                                MaxInt = "6強";
                                            }
                                            if (P2PQuake_json[0].Earthquake.MaxScale >= 70)
                                            {
                                                if (Area_Sindo9.Count != 0)
                                                {
                                                    string Area9 = "《震度7》";
                                                    for (int x = 0; x < Area_Sindo9.Count; x++)
                                                    {
                                                        int imagex = LocationDicX[Area_Sindo9[x]] - 10;
                                                        int imagey = LocationDicY[Area_Sindo9[x]] - 10;
                                                        ShindoImage2.DrawImage(Resources.MapShindo92, imagex, imagey);
                                                        Area9 += " " + Area_Sindo9[x];
                                                        if (imagex - 40 < PointXMin)
                                                            PointXMin = imagex - 40;
                                                        if (imagex + 60 > PointXMax)
                                                            PointXMax = imagex + 60;
                                                        if (imagey - 40 < PointYMin)
                                                            PointYMin = imagey - 40;
                                                        if (imagey + 60 > PointYMax)
                                                            PointYMax = imagey + 60;
                                                    }
                                                    AreaAll = Area9 + "\n" + AreaAll;
                                                    MaxInt = "7";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Xmax:" + PointXMax);
                        Console.WriteLine("Xmin:" + PointXMin);
                        Console.WriteLine("Ymax:" + PointYMax);
                        Console.WriteLine("Ymin:" + PointYMin);
                        double MagnificationX = 1 / ((PointXMax - PointXMin) / 720);
                        double MagnificationY = 1 / ((PointYMax - PointYMin) / 480);
                        double Magnification = MagnificationX;
                        if (MagnificationX < MagnificationY)
                            Magnification = MagnificationY;
                        if (Magnification > 2)
                            Magnification = 2;
                        if (P2PQuake_json[1].Issue.Type == "Destination" && P2PQuake_json[0].Earthquake.Time == P2PQuake_json[1].Earthquake.Time)
                        {
                            double MagnificationX_ = (PointXMax - PointXMin) / 720;
                            double MagnificationY_ = (PointYMax - PointYMin) / 480;
                            double Magnification_ = MagnificationX_;
                            if (MagnificationX_ > MagnificationY_)
                                Magnification_ = MagnificationY_;
                            if (Magnification_ < 0.5)
                                Magnification_ = 0.5;
                            int Ssize = (int)(50 * Magnification_);
                            int Ssize2 = Ssize / 2;
                            int Simagex = (int)((P2PQuake_json[1].Earthquake.Hypocenter.Longitude - 115) * 88.88888) - Ssize2;
                            int Simagey = (int)((50 - P2PQuake_json[1].Earthquake.Hypocenter.Latitude) * 88.68571) - Ssize2;

                            ShindoImage2.DrawImage(Resources.Point, Simagex, Simagey, Ssize, Ssize);
                            Console.WriteLine($"x{Simagex}y{Simagey}s{Ssize}");
                        }
                        else if (P2PQuake_json[2].Issue.Type == "Destination" && P2PQuake_json[0].Earthquake.Time == P2PQuake_json[2].Earthquake.Time)
                        {
                            double MagnificationX_ = (PointXMax - PointXMin) / 720;
                            double MagnificationY_ = (PointYMax - PointYMin) / 480;
                            double Magnification_ = MagnificationX_;
                            if (MagnificationX_ > MagnificationY_)
                                Magnification_ = MagnificationY_;
                            if (Magnification_ < 0.5)
                                Magnification_ = 0.5;
                            int Ssize = (int)(50 * Magnification_);
                            int Ssize2 = Ssize / 2;
                            int Simagex = (int)((P2PQuake_json[2].Earthquake.Hypocenter.Longitude - 115) * 88.88888) - Ssize2;
                            int Simagey = (int)((50 - P2PQuake_json[2].Earthquake.Hypocenter.Latitude) * 88.68571) - Ssize2;

                            ShindoImage2.DrawImage(Resources.Point, Simagex, Simagey, Ssize, Ssize);
                            Console.WriteLine($"x{Simagex}y{Simagey}s{Ssize}");
                        }
                        else if (P2PQuake_json[3].Issue.Type == "Destination" && P2PQuake_json[0].Earthquake.Time == P2PQuake_json[3].Earthquake.Time)
                        {
                            double MagnificationX_ = (PointXMax - PointXMin) / 720;
                            double MagnificationY_ = (PointYMax - PointYMin) / 480;
                            double Magnification_ = MagnificationX_;
                            if (MagnificationX_ > MagnificationY_)
                                Magnification_ = MagnificationY_;
                            if (Magnification_ < 0.5)
                                Magnification_ = 0.5;
                            int Ssize = (int)(50 * Magnification_);
                            int Ssize2 = Ssize / 2;
                            int Simagex = (int)((P2PQuake_json[3].Earthquake.Hypocenter.Longitude - 115) * 88.88888) - Ssize2;
                            int Simagey = (int)((50 - P2PQuake_json[3].Earthquake.Hypocenter.Latitude) * 88.68571) - Ssize2;

                            ShindoImage2.DrawImage(Resources.Point, Simagex, Simagey, Ssize, Ssize);
                            Console.WriteLine($"x{Simagex}y{Simagey}s{Ssize}");
                        }



                        Console.WriteLine("倍率X:" + MagnificationX);
                        Console.WriteLine("倍率Y:" + MagnificationY);
                        Console.WriteLine("倍率:" + Magnification);
                        Map.Size = new Size((int)(4000 * Magnification), (int)(3104 * Magnification));
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　震度アイコン描画終了");
                        Map.BackgroundImage = null;
                        Map.BackgroundImage = canvas2;
                        ShindoImage2.Dispose();
                        int ImageLocX2 = (int)((PointXMax + PointXMin) * Magnification) / -2 + 360;
                        int ImageLocY2 = (int)((PointYMax + PointYMin) * Magnification) / -2 + 240;
                        Console.WriteLine("X:" + ImageLocX2);
                        Console.WriteLine("Y:" + ImageLocY2);
                        Map.Location = new System.Drawing.Point(ImageLocX2, ImageLocY2);
                        //震度別処理終了
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　画像描画終了");
                        AreaTextBox.Text = null;
                        AreaTextBox.Text = AreaAll;

                        RemoteTalkText = ("震度速報、" + AreaAll).Replace(" ", "、").Replace("《", "、").Replace("》", "").Replace("\n", "").Replace("、、", "、");
                        DateTime InfoTime = Convert.ToDateTime(P2PQuake_json[0].Time);
                        DateTime NowTime = DateTime.Now;
                        if ((NowTime - InfoTime).TotalDays <= 1 && P2PQuake_json[0].Earthquake.MaxScale >= 30)
                        {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                            string tokens_json = File.ReadAllText($"Tokens.json");
                            Tokens_JSON Tokens_jsondata = JsonConvert.DeserializeObject<Tokens_JSON>(tokens_json);
                            Tokens tokens = Tokens.Create(Tokens_jsondata.ConsumerKey, Tokens_jsondata.ConsumerSecret, Tokens_jsondata.AccessToken, Tokens_jsondata.AccessSecret);
                            string TweetText = $"震度速報【最大震度{MaxInt}】{P2PQuake_json[0].Earthquake.Time.Remove(16, 3)}\n{AreaAll}";
                            if (TweetText.Length > 120)
                                TweetText = TweetText.Remove(120, TweetText.Length - 120) + "…";
                            if (NoFirst)
                                try
                                {
                                    if (LatestTime == P2PQuake_json[0].Earthquake.Time)
                                    {
                                        Status status = await tokens.Statuses.UpdateAsync(new { status = TweetText, in_reply_to_status_id = LatestTweetID });
                                        LatestTweetID = status.Id;
                                    }
                                    else
                                    {
                                        Status status = await tokens.Statuses.UpdateAsync(new { status = TweetText });
                                        LatestTweetID = status.Id;
                                    }
                                }
                                catch
                                {

                                }
                            LatestArea = AreaAll;
                            LatestTime = P2PQuake_json[0].Earthquake.Time;
                        }
                        else
                        {
                            string TweetText = $"震度速報【最大震度{MaxInt}】{P2PQuake_json[0].Earthquake.Time.Remove(16, 3)}\n{AreaAll}";
                            if (TweetText.Length >= 120)
                            {
                                TweetText = TweetText.Remove(120, TweetText.Length - 120) + "…";
                                Console.WriteLine(TweetText);
                            }
                        }
                    }//震度速報終了
                    else if (P2PQuake_json[0].Issue.Type == "Destination")
                    {

                        Map.Image = null;
                        Map.BackgroundImage = null;
                        if (P2PQuake_json[1].Issue.Type == "ScalePrompt" && P2PQuake_json[0].Earthquake.Time == P2PQuake_json[1].Earthquake.Time)
                        {
                            List<string> Area_Sindo1 = new List<string>();
                            List<string> Area_Sindo2 = new List<string>();
                            List<string> Area_Sindo3 = new List<string>();
                            List<string> Area_Sindo4 = new List<string>();
                            List<string> Area_Sindo5 = new List<string>();
                            List<string> Area_Sindo6 = new List<string>();
                            List<string> Area_Sindo7 = new List<string>();
                            List<string> Area_Sindo8 = new List<string>();
                            List<string> Area_Sindo9 = new List<string>();
                            List<string> Area_SindoNull = new List<string>();
                            string AreaString = "";
                            Dictionary<string, int> AreaDic = new Dictionary<string, int>();
                            for (int x = 0; x < P2PQuake_json[1].Points.Count; x++)
                            {
                                AreaString += P2PQuake_json[1].Points[x].Addr;
                                AreaDic.Add(P2PQuake_json[1].Points[x].Addr, P2PQuake_json[1].Points[x].Scale);

                                if (P2PQuake_json[1].Points[x].Scale == 10)
                                    Area_Sindo1.Add(P2PQuake_json[1].Points[x].Addr);
                                else if (P2PQuake_json[1].Points[x].Scale == 20)
                                    Area_Sindo2.Add(P2PQuake_json[1].Points[x].Addr);
                                else if (P2PQuake_json[1].Points[x].Scale == 30)
                                    Area_Sindo3.Add(P2PQuake_json[1].Points[x].Addr);
                                else if (P2PQuake_json[1].Points[x].Scale == 40)
                                    Area_Sindo4.Add(P2PQuake_json[1].Points[x].Addr);
                                else if (P2PQuake_json[1].Points[x].Scale == 45)
                                    Area_Sindo5.Add(P2PQuake_json[1].Points[x].Addr);
                                else if (P2PQuake_json[1].Points[x].Scale == 50)
                                    Area_Sindo6.Add(P2PQuake_json[1].Points[x].Addr);
                                else if (P2PQuake_json[1].Points[x].Scale == 55)
                                    Area_Sindo7.Add(P2PQuake_json[1].Points[x].Addr);
                                else if (P2PQuake_json[1].Points[x].Scale == 60)
                                    Area_Sindo8.Add(P2PQuake_json[1].Points[x].Addr);
                                else if (P2PQuake_json[1].Points[x].Scale == 70)
                                    Area_Sindo9.Add(P2PQuake_json[1].Points[x].Addr);
                                else if (P2PQuake_json[1].Points[x].Scale == 46)
                                    Area_SindoNull.Add(P2PQuake_json[1].Points[x].Addr);
                            }
                            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　震度別分配終了");
                            string Area = "";
                            foreach (string Area_ in AreaDic.Keys)
                                Area += Area_;
                            string AreaAll = "";
                            double PointXMin = 9999;
                            double PointXMax = 0;
                            double PointYMin = 9999;
                            double PointYMax = 0;

                            Bitmap canvas2 = new Bitmap(Resources.JapanMap1);
                            Graphics ShindoImage2 = Graphics.FromImage(canvas2);
                            string Area3 = "《震度3》";
                            for (int x = 0; x < Area_Sindo3.Count; x++)
                            {
                                int imagex = LocationDicX[Area_Sindo3[x]] - 10;
                                int imagey = LocationDicY[Area_Sindo3[x]] - 10;
                                ShindoImage2.DrawImage(Resources.MapShindo32, imagex, imagey);
                                Area3 += " " + Area_Sindo3[x];
                                if (imagex - 40 < PointXMin)
                                    PointXMin = imagex - 40;
                                if (imagex + 60 > PointXMax)
                                    PointXMax = imagex + 60;
                                if (imagey - 40 < PointYMin)
                                    PointYMin = imagey - 40;
                                if (imagey + 60 > PointYMax)
                                    PointYMax = imagey + 60;
                            }
                            AreaAll = Area3 + "\n" + AreaAll;
                            if (P2PQuake_json[1].Earthquake.MaxScale >= 40)
                            {
                                string Area4 = "《震度4》";
                                for (int x = 0; x < Area_Sindo4.Count; x++)
                                {
                                    int imagex = LocationDicX[Area_Sindo4[x]] - 10;
                                    int imagey = LocationDicY[Area_Sindo4[x]] - 10;
                                    ShindoImage2.DrawImage(Resources.MapShindo42, imagex, imagey);
                                    Area4 += " " + Area_Sindo4[x];
                                    if (imagex - 40 < PointXMin)
                                        PointXMin = imagex - 40;
                                    if (imagex + 60 > PointXMax)
                                        PointXMax = imagex + 60;
                                    if (imagey - 40 < PointYMin)
                                        PointYMin = imagey - 40;
                                    if (imagey + 60 > PointYMax)
                                        PointYMax = imagey + 60;
                                }
                                AreaAll = Area4 + "\n" + AreaAll;
                                if (P2PQuake_json[1].Earthquake.MaxScale >= 45)
                                {
                                    string Area5 = "《震度5弱》";
                                    for (int x = 0; x < Area_Sindo5.Count; x++)
                                    {
                                        int imagex = LocationDicX[Area_Sindo5[x]] - 10;
                                        int imagey = LocationDicY[Area_Sindo5[x]] - 10;
                                        ShindoImage2.DrawImage(Resources.MapShindo52, imagex, imagey);
                                        Area5 += " " + Area_Sindo5[x];
                                        if (imagex - 40 < PointXMin)
                                            PointXMin = imagex - 40;
                                        if (imagex + 60 > PointXMax)
                                            PointXMax = imagex + 60;
                                        if (imagey - 40 < PointYMin)
                                            PointYMin = imagey - 40;
                                        if (imagey + 60 > PointYMax)
                                            PointYMax = imagey + 60;
                                    }
                                    AreaAll = Area5 + "\n" + AreaAll;
                                    if (P2PQuake_json[1].Earthquake.MaxScale >= 50)
                                    {
                                        string Area6 = "《震度5強》";
                                        for (int x = 0; x < Area_Sindo6.Count; x++)
                                        {
                                            int imagex = LocationDicX[Area_Sindo6[x]] - 10;
                                            int imagey = LocationDicY[Area_Sindo6[x]] - 10;
                                            ShindoImage2.DrawImage(Resources.MapShindo62, imagex, imagey);
                                            Area6 += " " + Area_Sindo6[x];
                                            if (imagex - 40 < PointXMin)
                                                PointXMin = imagex - 40;
                                            if (imagex + 60 > PointXMax)
                                                PointXMax = imagex + 60;
                                            if (imagey - 40 < PointYMin)
                                                PointYMin = imagey - 40;
                                            if (imagey + 60 > PointYMax)
                                                PointYMax = imagey + 60;
                                        }
                                        AreaAll = Area6 + "\n" + AreaAll;
                                        if (P2PQuake_json[1].Earthquake.MaxScale >= 55)
                                        {
                                            string Area7 = "《震度6弱》";
                                            for (int x = 0; x < Area_Sindo7.Count; x++)
                                            {
                                                int imagex = LocationDicX[Area_Sindo7[x]] - 10;
                                                int imagey = LocationDicY[Area_Sindo7[x]] - 10;
                                                ShindoImage2.DrawImage(Resources.MapShindo72, imagex, imagey);
                                                Area7 += " " + Area_Sindo7[x];
                                                if (imagex - 40 < PointXMin)
                                                    PointXMin = imagex - 40;
                                                if (imagex + 60 > PointXMax)
                                                    PointXMax = imagex + 60;
                                                if (imagey - 40 < PointYMin)
                                                    PointYMin = imagey - 40;
                                                if (imagey + 60 > PointYMax)
                                                    PointYMax = imagey + 60;
                                            }
                                            AreaAll = Area7 + "\n" + AreaAll;
                                            if (P2PQuake_json[1].Earthquake.MaxScale >= 60)
                                            {
                                                string Area8 = "《震度6強》";
                                                for (int x = 0; x < Area_Sindo8.Count; x++)
                                                {
                                                    int imagex = LocationDicX[Area_Sindo8[x]] - 10;
                                                    int imagey = LocationDicY[Area_Sindo8[x]] - 10;
                                                    ShindoImage2.DrawImage(Resources.MapShindo82, imagex, imagey);
                                                    Console.WriteLine($"x{imagex}y{imagey}");
                                                    Area8 += " " + Area_Sindo8[x];
                                                    if (imagex - 40 < PointXMin)
                                                        PointXMin = imagex - 40;
                                                    if (imagex + 60 > PointXMax)
                                                        PointXMax = imagex + 60;
                                                    if (imagey - 40 < PointYMin)
                                                        PointYMin = imagey - 40;
                                                    if (imagey + 60 > PointYMax)
                                                        PointYMax = imagey + 60;
                                                }
                                                AreaAll = Area8 + "\n" + AreaAll;
                                                if (P2PQuake_json[1].Earthquake.MaxScale >= 70)
                                                {
                                                    string Area9 = "《震度7》";
                                                    for (int x = 0; x < Area_Sindo9.Count; x++)
                                                    {
                                                        int imagex = LocationDicX[Area_Sindo9[x]] - 10;
                                                        int imagey = LocationDicY[Area_Sindo9[x]] - 10;
                                                        ShindoImage2.DrawImage(Resources.MapShindo92, imagex, imagey);
                                                        Area9 += " " + Area_Sindo9[x];
                                                        if (imagex - 40 < PointXMin)
                                                            PointXMin = imagex - 40;
                                                        if (imagex + 60 > PointXMax)
                                                            PointXMax = imagex + 60;
                                                        if (imagey - 40 < PointYMin)
                                                            PointYMin = imagey - 40;
                                                        if (imagey + 60 > PointYMax)
                                                            PointYMax = imagey + 60;
                                                    }
                                                    AreaAll = Area9 + "\n" + AreaAll;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("Xmax:" + PointXMax);
                            Console.WriteLine("Xmin:" + PointXMin);
                            Console.WriteLine("Ymax:" + PointYMax);
                            Console.WriteLine("Ymin:" + PointYMin);
                            double MagnificationX = 1 / ((PointXMax - PointXMin) / 720);
                            double MagnificationY = 1 / ((PointYMax - PointYMin) / 480);
                            double MagnificationX_ = (PointXMax - PointXMin) / 720;
                            double MagnificationY_ = (PointYMax - PointYMin) / 480;
                            double Magnification = MagnificationX;
                            double Magnification_ = MagnificationX_;
                            if (MagnificationX > MagnificationY)
                                Magnification = MagnificationY;
                            if (Magnification > 2)
                                Magnification = 2;
                            if (MagnificationX_ > MagnificationY_)
                                Magnification_ = MagnificationY_;
                            if (Magnification_ < 0.5)
                                Magnification_ = 0.5;
                            int Ssize = (int)(50 * Magnification_);
                            int Ssize2 = Ssize / 2;
                            int Simagex = (int)((P2PQuake_json[0].Earthquake.Hypocenter.Longitude - 115) * 88.88888) - Ssize2;
                            int Simagey = (int)((50 - P2PQuake_json[0].Earthquake.Hypocenter.Latitude) * 88.68571) - Ssize2;

                            ShindoImage2.DrawImage(Resources.Point, Simagex, Simagey, Ssize, Ssize);
                            Console.WriteLine($"x{Simagex}y{Simagey}s{Ssize}");

                            Console.WriteLine("倍率X:" + MagnificationX);
                            Console.WriteLine("倍率Y:" + MagnificationY);
                            Console.WriteLine("倍率:" + Magnification);
                            Map.Size = new Size((int)(4000 * Magnification), (int)(3104 * Magnification));
                            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　震度アイコン描画終了");
                            Map.BackgroundImage = null;
                            Map.BackgroundImage = canvas2;
                            ShindoImage2.Dispose();
                            int ImageLocX2 = (int)((PointXMax + PointXMin) * Magnification) / -2 + 360;
                            int ImageLocY2 = (int)((PointYMax + PointYMin) * Magnification) / -2 + 240;
                            Console.WriteLine("X:" + ImageLocX2);
                            Console.WriteLine("Y:" + ImageLocY2);
                            Map.Location = new System.Drawing.Point(ImageLocX2, ImageLocY2);
                            //震度別処理終了
                            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　画像描画終了");
                            AreaTextBox.Text = null;
                            AreaTextBox.Text = AreaAll;

                            RemoteTalkText = ($"震源情報、震源、{P2PQuake_json[0].Earthquake.Hypocenter.Name}、マグニチュード{((P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9"))}、{$"深さ{P2PQuake_json[0].Earthquake.Hypocenter.Depth}キロメートル。".Replace("深さ0キロメートル", "深さごく浅い")}{P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "この地震による津波の心配はありません。").Replace("Unknown", "この地震による津波は不明です。").Replace("Checking", "現在津波について調査中です。").Replace("NonEffective", "若干の海面変動があるかもしれませんが、被害の心配はありません。").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報を発表中です。")}");
                            DateTime InfoTime = Convert.ToDateTime(P2PQuake_json[0].Time);
                            DateTime NowTime = DateTime.Now;
                            if ((NowTime - InfoTime).TotalHours <= 1 && P2PQuake_json[0].Earthquake.MaxScale >= 30)
                            {
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                                string tokens_json = File.ReadAllText($"Tokens.json");
                                Tokens_JSON Tokens_jsondata = JsonConvert.DeserializeObject<Tokens_JSON>(tokens_json);
                                Tokens tokens = Tokens.Create(Tokens_jsondata.ConsumerKey, Tokens_jsondata.ConsumerSecret, Tokens_jsondata.AccessToken, Tokens_jsondata.AccessSecret);
                                string TweetText = $"震源に関する情報  {P2PQuake_json[0].Earthquake.Time.Remove(16, 3)}\n震源:{P2PQuake_json[0].Earthquake.Hypocenter.Name}  M{((P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9"))} {$"深さ{P2PQuake_json[0].Earthquake.Hypocenter.Depth}km".Replace("深さ0km", "深さごく浅い")}\n{P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "この地震による津波の心配はありません。").Replace("Unknown", "この地震による津波は不明です。").Replace("Checking", "現在津波について調査中です。").Replace("NonEffective", "若干の海面変動があるかもしれませんが、被害の心配はありません。").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。")}";
                                if (NoFirst)

                                    try
                                    {
                                        if (LatestTime == P2PQuake_json[0].Earthquake.Time)
                                        {
                                            Status status = await tokens.Statuses.UpdateAsync(new { status = TweetText, in_reply_to_status_id = LatestTweetID });
                                            LatestTweetID = status.Id;
                                        }
                                        else
                                        {
                                            Status status = await tokens.Statuses.UpdateAsync(new { status = TweetText });
                                            LatestTweetID = status.Id;
                                        }
                                    }
                                    catch
                                    {

                                    }

                                LatestTime = P2PQuake_json[0].Earthquake.Time;
                            }

                        }
                    }
                    else if (P2PQuake_json[0].Issue.Type == "DetailScale")
                    {

                        Map.Image = null;
                        Map.BackgroundImage = null;
                        Map.Size = new Size(4500, 3500);

                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　各地の震度に関する情報");

                        Dictionary<string, int> PrefShindo = new Dictionary<string, int>
                    {
                        {"北海道",0},
                        {"青森県",0},
                        {"岩手県",0},
                        {"宮城県",0},
                        {"秋田県",0},
                        {"山形県",0},
                        {"福島県",0},
                        {"茨城県",0},
                        {"栃木県",0},
                        {"群馬県",0},
                        {"埼玉県",0},
                        {"千葉県",0},
                        {"東京都",0},
                        {"神奈川県",0},
                        {"新潟県",0},
                        {"富山県",0},
                        {"石川県",0},
                        {"福井県",0},
                        {"山梨県",0},
                        {"長野県",0},
                        {"岐阜県",0},
                        {"静岡県",0},
                        {"愛知県",0},
                        {"三重県",0},
                        {"滋賀県",0},
                        {"京都府",0},
                        {"大阪府",0},
                        {"兵庫県",0},
                        {"奈良県",0},
                        {"和歌山県",0},
                        {"鳥取県",0},
                        {"島根県",0},
                        {"岡山県",0},
                        {"広島県",0},
                        {"山口県",0},
                        {"徳島県",0},
                        {"香川県",0},
                        {"愛媛県",0},
                        {"高知県",0},
                        {"福岡県",0},
                        {"佐賀県",0},
                        {"長崎県",0},
                        {"熊本県",0},
                        {"大分県",0},
                        {"宮崎県",0},
                        {"鹿児島県",0},
                        {"沖縄県",0}
                    };
                        for (int x = 0; x < P2PQuake_json[0].Points.Count; x++)
                        {
                            if (PrefShindo[P2PQuake_json[0].Points[x].Pref] < P2PQuake_json[0].Points[x].Scale)
                                PrefShindo[P2PQuake_json[0].Points[x].Pref] = P2PQuake_json[0].Points[x].Scale;
                        }
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　県別最大震度完了");


                        Bitmap MapImage = new Bitmap(Resources.JapanMap2_Replace);
                        Bitmap Bitmap = new Bitmap(4500, 3500);
                        Graphics Graphics = Graphics.FromImage(Bitmap);
                        ColorMap[] ColorChange = new ColorMap[]
                    {
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap(),
                    new ColorMap()
                    };
                        {
                            ColorChange[0].OldColor = Color.FromArgb(1, 1, 1);
                            ColorChange[1].OldColor = Color.FromArgb(2, 1, 1);
                            ColorChange[2].OldColor = Color.FromArgb(2, 2, 1);
                            ColorChange[3].OldColor = Color.FromArgb(2, 3, 1);
                            ColorChange[4].OldColor = Color.FromArgb(2, 4, 1);
                            ColorChange[5].OldColor = Color.FromArgb(2, 5, 1);
                            ColorChange[6].OldColor = Color.FromArgb(2, 6, 1);
                            ColorChange[7].OldColor = Color.FromArgb(3, 1, 1);
                            ColorChange[8].OldColor = Color.FromArgb(3, 2, 1);
                            ColorChange[9].OldColor = Color.FromArgb(3, 3, 1);
                            ColorChange[10].OldColor = Color.FromArgb(3, 4, 1);
                            ColorChange[11].OldColor = Color.FromArgb(3, 5, 1);
                            ColorChange[12].OldColor = Color.FromArgb(3, 6, 1);
                            ColorChange[13].OldColor = Color.FromArgb(3, 7, 1);
                            ColorChange[14].OldColor = Color.FromArgb(4, 1, 1);
                            ColorChange[15].OldColor = Color.FromArgb(4, 2, 1);
                            ColorChange[16].OldColor = Color.FromArgb(4, 3, 1);
                            ColorChange[17].OldColor = Color.FromArgb(4, 4, 1);
                            ColorChange[18].OldColor = Color.FromArgb(4, 5, 1);
                            ColorChange[19].OldColor = Color.FromArgb(4, 6, 1);
                            ColorChange[20].OldColor = Color.FromArgb(4, 7, 1);
                            ColorChange[21].OldColor = Color.FromArgb(4, 8, 1);
                            ColorChange[22].OldColor = Color.FromArgb(4, 9, 1);
                            ColorChange[23].OldColor = Color.FromArgb(5, 1, 1);
                            ColorChange[24].OldColor = Color.FromArgb(5, 2, 1);
                            ColorChange[25].OldColor = Color.FromArgb(5, 3, 1);
                            ColorChange[26].OldColor = Color.FromArgb(5, 4, 1);
                            ColorChange[27].OldColor = Color.FromArgb(5, 5, 1);
                            ColorChange[28].OldColor = Color.FromArgb(5, 6, 1);
                            ColorChange[29].OldColor = Color.FromArgb(5, 7, 1);
                            ColorChange[30].OldColor = Color.FromArgb(6, 1, 1);
                            ColorChange[31].OldColor = Color.FromArgb(6, 2, 1);
                            ColorChange[32].OldColor = Color.FromArgb(6, 3, 1);
                            ColorChange[33].OldColor = Color.FromArgb(6, 4, 1);
                            ColorChange[34].OldColor = Color.FromArgb(6, 5, 1);
                            ColorChange[35].OldColor = Color.FromArgb(7, 1, 1);
                            ColorChange[36].OldColor = Color.FromArgb(7, 2, 1);
                            ColorChange[37].OldColor = Color.FromArgb(7, 3, 1);
                            ColorChange[38].OldColor = Color.FromArgb(7, 4, 1);
                            ColorChange[39].OldColor = Color.FromArgb(8, 1, 1);
                            ColorChange[40].OldColor = Color.FromArgb(8, 2, 1);
                            ColorChange[41].OldColor = Color.FromArgb(8, 3, 1);
                            ColorChange[42].OldColor = Color.FromArgb(8, 4, 1);
                            ColorChange[43].OldColor = Color.FromArgb(8, 5, 1);
                            ColorChange[44].OldColor = Color.FromArgb(8, 6, 1);
                            ColorChange[45].OldColor = Color.FromArgb(8, 7, 1);
                            ColorChange[46].OldColor = Color.FromArgb(8, 8, 1);
                        }
                        bool FileFlag = false;
                        for (int i = 0; i < 47; i++)
                            ColorChange[i].NewColor = Color.FromArgb(90, 90, 120);
                        for (int p = 0; p < P2PQuake_json[0].Points.Count; p++)
                        {
                            if (PrefShindo[P2PQuake_json[0].Points[p].Pref] == 10)
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(70, 100, 110);
                            else if (PrefShindo[P2PQuake_json[0].Points[p].Pref] == 20)
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(30, 110, 230);
                            else if (PrefShindo[P2PQuake_json[0].Points[p].Pref] == 30)
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(0, 200, 200);
                            else if (PrefShindo[P2PQuake_json[0].Points[p].Pref] == 40)
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(250, 250, 100);
                            else if (PrefShindo[P2PQuake_json[0].Points[p].Pref] == 45)
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(255, 180, 0);
                            else if (PrefShindo[P2PQuake_json[0].Points[p].Pref] == 50)
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(255, 120, 0);
                            else if (PrefShindo[P2PQuake_json[0].Points[p].Pref] == 55)
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(230, 0, 0);
                            else if (PrefShindo[P2PQuake_json[0].Points[p].Pref] == 60)
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(160, 0, 0);
                            else if (PrefShindo[P2PQuake_json[0].Points[p].Pref] == 70)
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(150, 0, 150);
                            else
                                ColorChange[PrefID[P2PQuake_json[0].Points[p].Pref]].NewColor = Color.FromArgb(90, 90, 120);
                            if (P2PQuake_json[0].Points[p].Pref == Settings.Default.FilePref)
                            {
                                FileFlag = true;
                                Console.WriteLine("一致");
                            }
                        }
                        if (P2PQuake_json[0].Earthquake.MaxScale >= 30)
                            FileFlag = true;

                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　置換色準備完了");

                        int SimageX = (int)((P2PQuake_json[0].Earthquake.Hypocenter.Longitude - 115) * 100) - 25;
                        int SimageY = (int)((50 - P2PQuake_json[0].Earthquake.Hypocenter.Latitude) * 100) - 25;
                        ImageAttributes IA = new ImageAttributes();
                        IA.SetRemapTable(ColorChange);
                        Graphics.DrawImage(MapImage, new Rectangle(0, 0, 4500, 3500), 0, 0, 4500, 3500, GraphicsUnit.Pixel, IA);
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　色置換完了");

                        Graphics.DrawImage(Resources.Point, SimageX, SimageY, 50, 50);
                        Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　画像描画終了");
                        //最大震度
                        //int ImageX = PrefLocX[P2PQuake_json[0].Points[0].Pref]*-1+360;
                        //int ImageY = PrefLocY[P2PQuake_json[0].Points[0].Pref]*-1+240;
                        //震源
                        int ImageX = (SimageX + 25) * -1 + 360;
                        int ImageY = (SimageY + 25) * -1 + 240;

                        Map.BackgroundImage = Bitmap;
                        Map.Location = new System.Drawing.Point(ImageX, ImageY);
                        Graphics.Dispose();
                        MapImage.Dispose();
                        if (P2PQuake_json[0].Earthquake.MaxScale == 10)
                            MaxInt = "1";
                        else if (P2PQuake_json[0].Earthquake.MaxScale == 20)
                            MaxInt = "2";
                        else if (P2PQuake_json[0].Earthquake.MaxScale == 30)
                            MaxInt = "3";
                        else if (P2PQuake_json[0].Earthquake.MaxScale == 40)
                            MaxInt = "4";
                        else if (P2PQuake_json[0].Earthquake.MaxScale == 45)
                            MaxInt = "5弱";
                        else if (P2PQuake_json[0].Earthquake.MaxScale == 50)
                            MaxInt = "5強";
                        else if (P2PQuake_json[0].Earthquake.MaxScale == 55)
                            MaxInt = "6弱";
                        else if (P2PQuake_json[0].Earthquake.MaxScale == 60)
                            MaxInt = "6強";
                        else if (P2PQuake_json[0].Earthquake.MaxScale == 70)
                            MaxInt = "7";
                        if (FileFlag == true)
                            FileOpen.Enabled = true;
                        RemoteTalkText = ($"地震情報。最大震度{MaxInt}、震源、{P2PQuake_json[0].Earthquake.Hypocenter.Name}、マグニチュード{((P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9"))}、{$"深さ{P2PQuake_json[0].Earthquake.Hypocenter.Depth}キロメートル。".Replace("深さ0キロメートル", "深さごく浅い")}{P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "この地震による津波の心配はありません。").Replace("Unknown", "この地震による津波は不明です。").Replace("Checking", "現在津波について調査中です。").Replace("NonEffective", "若干の海面変動があるかもしれませんが、被害の心配はありません。").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。")}");
                        DateTime InfoTime = Convert.ToDateTime(P2PQuake_json[0].Time);
                        DateTime NowTime = DateTime.Now;
                        if ((NowTime - InfoTime).TotalHours <= 1 && P2PQuake_json[0].Earthquake.MaxScale >= 30)
                        {

                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                            string tokens_json = File.ReadAllText($"Tokens.json");
                            Tokens_JSON Tokens_jsondata = JsonConvert.DeserializeObject<Tokens_JSON>(tokens_json);
                            Tokens tokens = Tokens.Create(Tokens_jsondata.ConsumerKey, Tokens_jsondata.ConsumerSecret, Tokens_jsondata.AccessToken, Tokens_jsondata.AccessSecret);
                            string TweetText = $"各地の震度に関する情報【最大震度{MaxInt}】{P2PQuake_json[0].Earthquake.Time.Remove(16, 3)}\n震源:{P2PQuake_json[0].Earthquake.Hypocenter.Name}  M{((P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9"))} {$"深さ{P2PQuake_json[0].Earthquake.Hypocenter.Depth}km".Replace("深さ0km", "深さごく浅い")}\n{P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "この地震による津波の心配はありません。").Replace("Unknown", "この地震による津波は不明です。").Replace("Checking", "現在津波について調査中です。").Replace("NonEffective", "若干の海面変動があるかもしれませんが、被害の心配はありません。").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。")}";
                            if (NoFirst)
                                try
                                {
                                    if (LatestTime == P2PQuake_json[0].Earthquake.Time)
                                    {
                                        Status status = await tokens.Statuses.UpdateAsync(new { status = TweetText, in_reply_to_status_id = LatestTweetID });
                                        LatestTweetID = status.Id;
                                    }
                                    else
                                    {
                                        Status status = await tokens.Statuses.UpdateAsync(new { status = TweetText });
                                        LatestTweetID = status.Id;
                                    }
                                }
                                catch
                                {

                                }

                            LatestTime = P2PQuake_json[0].Earthquake.Time;
                        }
                    }
                    else if (P2PQuake_json[0].Issue.Type == "Foreign")
                    {
                        Map.Image = null;
                        Map.BackgroundImage = null;
                        Map.Size = new Size(1226, 480);//余白左右133
                        Bitmap MapImage = new Bitmap(Resources.WorldMap);
                        Graphics Graphics = Graphics.FromImage(MapImage);

                        int LocX = (int)Math.Round((P2PQuake_json[0].Earthquake.Hypocenter.Longitude + 180) * 2.6666666666 + 133, MidpointRounding.AwayFromZero);
                        int LocY = (int)Math.Round((90 - P2PQuake_json[0].Earthquake.Hypocenter.Latitude) * 2.6666666666, MidpointRounding.AwayFromZero);
                        Graphics.DrawImage(Resources.Point, LocX - 20, LocY - 20, 40, 40);
                        int LocX_ = LocX * -1 + 360;
                        if (LocX_ > 0)
                            LocX_ = 0;
                        else if (LocX_ < -506)
                            LocX_ = -506;

                        Map.Location = new System.Drawing.Point(LocX_, 0);
                        Map.BackgroundImage = MapImage;
                        RemoteTalkText = $"遠地地震情報。震源、{P2PQuake_json[0].Earthquake.Hypocenter.Name}、マグニチュード{(P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9")}、{$"深さ{P2PQuake_json[0].Earthquake.Hypocenter.Depth}キロメートル。".Replace("深さ0キロメートル", "深さごく浅い")}{P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "この地震による津波の心配はありません。").Replace("Unknown", "この地震による津波は不明です。").Replace("Checking", "現在津波について調査中です。").Replace("NonEffective", "若干の海面変動があるかもしれませんが、被害の心配はありません。").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。")}".Replace("、マグニチュード-1.0", "").Replace("、深さ-1キロメートル", "");
                        DateTime InfoTime = Convert.ToDateTime(P2PQuake_json[0].Time);
                        DateTime NowTime = DateTime.Now;
                        if ((NowTime - InfoTime).TotalDays <= 1)
                        {
                            double Lat = P2PQuake_json[0].Earthquake.Hypocenter.Latitude;
                            double Long = P2PQuake_json[0].Earthquake.Hypocenter.Longitude;
                            string LatSt = $"北緯{Lat}度";
                            string LongSt = $"東経{Long}度";
                            if (Lat < 0)
                                LatSt = $"南緯{-Lat}度";
                            if (Long < 0)
                                LongSt = $"西経{-Long}度";
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                            string tokens_json = File.ReadAllText($"Tokens.json");
                            Tokens_JSON Tokens_jsondata = JsonConvert.DeserializeObject<Tokens_JSON>(tokens_json);
                            Tokens tokens = Tokens.Create(Tokens_jsondata.ConsumerKey, Tokens_jsondata.ConsumerSecret, Tokens_jsondata.AccessToken, Tokens_jsondata.AccessSecret);
                            string TweetText = $"遠地地震情報  {P2PQuake_json[0].Earthquake.Time.Remove(16, 3)}\n震源:{P2PQuake_json[0].Earthquake.Hypocenter.Name}({LatSt}、{LongSt})\nM{(P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9").Replace("-1.0", "不明")} {$"深さ{P2PQuake_json[0].Earthquake.Hypocenter.Depth}km".Replace("深さ0km", "深さごく浅い").Replace("深さ-1km", "深さ不明")}\n{P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "この地震による津波の心配はありません。").Replace("Unknown", "この地震による津波は不明です。").Replace("Checking", "現在津波について調査中です。").Replace("NonEffective", "若干の海面変動があるかもしれませんが、被害の心配はありません。").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。")}";
                            if (P2PQuake_json[0].Earthquake.Hypocenter.Magnitude == -1)
                            {
                                TweetText = TweetText.Replace("遠地地震情報", "遠地地震情報(大規模な火山噴火)");
                                RemoteTalkText = RemoteTalkText.Replace("遠地地震情報", "遠地地震情報、大規模な火山噴火");
                            }
                            if (NoFirst)
                                try
                                {
                                    await tokens.Statuses.UpdateAsync(new { status = TweetText });
                                }
                                catch
                                {

                                }
                        }
                    }
                    else
                    {
                        Map.Image = null;
                        Map.BackgroundImage = null;
                    }
                    //Info1 -　'緊急地震速報(予報) 第99報 最終'　/　'各地の震度に関する情報'　/　'震度速報'　/　'震源に関する情報　/　震度・震源に関する情報　/　遠地地震に関する情報　#EEW予報0,255,0　警報255,0,0 地震15,15,30
                    //Info2 -　'1'　/　'2'　/　'5弱'　/　'不明'　#震度別色-20
                    //Info3 -　'         山梨県東部・富士五湖'　//　'         M0.0 999km'　#震度別色
                    //Info4 -　'2022/11/11 22:22:22　#震度別色
                    //Info0 -　'最大震度'　#震度別色-10
                    if (P2PQuake_json[0].Earthquake.MaxScale == 10)
                    {
                        Info2.BackgroundImage = Resources.k1;
                        Info3.BackColor = Color.FromArgb(70, 100, 110);
                        Info4.BackColor = Color.FromArgb(70, 100, 110);
                        Info0.BackColor = Color.FromArgb(50, 80, 90);
                        Info2.ForeColor = Color.White;
                        Info3.ForeColor = Color.White;
                        Info4.ForeColor = Color.White;
                        Info0.ForeColor = Color.White;
                    }
                    else if (P2PQuake_json[0].Earthquake.MaxScale == 20)
                    {
                        Info2.BackgroundImage = Resources.k2;
                        Info3.BackColor = Color.FromArgb(30, 110, 230);
                        Info4.BackColor = Color.FromArgb(30, 110, 230);
                        Info0.BackColor = Color.FromArgb(10, 90, 210);
                        Info2.ForeColor = Color.White;
                        Info3.ForeColor = Color.White;
                        Info4.ForeColor = Color.White;
                        Info0.ForeColor = Color.White;
                    }
                    else if (P2PQuake_json[0].Earthquake.MaxScale == 30)
                    {
                        Info2.BackgroundImage = Resources.k3;
                        Info3.BackColor = Color.FromArgb(0, 200, 200);
                        Info4.BackColor = Color.FromArgb(0, 200, 200);
                        Info0.BackColor = Color.FromArgb(0, 180, 180);
                        Info2.ForeColor = Color.Black;
                        Info3.ForeColor = Color.Black;
                        Info4.ForeColor = Color.Black;
                        Info0.ForeColor = Color.Black;
                    }
                    else if (P2PQuake_json[0].Earthquake.MaxScale == 40)
                    {
                        Info2.BackgroundImage = Resources.k4;
                        Info3.BackColor = Color.FromArgb(250, 250, 100);
                        Info4.BackColor = Color.FromArgb(250, 250, 100);
                        Info0.BackColor = Color.FromArgb(230, 230, 80);
                        Info2.ForeColor = Color.Black;
                        Info3.ForeColor = Color.Black;
                        Info4.ForeColor = Color.Black;
                        Info0.ForeColor = Color.Black;
                    }
                    else if (P2PQuake_json[0].Earthquake.MaxScale == 45)
                    {
                        Info2.BackgroundImage = Resources.k5;
                        Info3.BackColor = Color.FromArgb(255, 180, 0);
                        Info4.BackColor = Color.FromArgb(255, 180, 0);
                        Info0.BackColor = Color.FromArgb(235, 150, 0);
                        Info2.ForeColor = Color.Black;
                        Info3.ForeColor = Color.Black;
                        Info4.ForeColor = Color.Black;
                        Info0.ForeColor = Color.Black;
                    }
                    else if (P2PQuake_json[0].Earthquake.MaxScale == 50)
                    {
                        Info2.BackgroundImage = Resources.k6;
                        Info3.BackColor = Color.FromArgb(255, 120, 0);
                        Info4.BackColor = Color.FromArgb(255, 120, 0);
                        Info0.BackColor = Color.FromArgb(235, 100, 0);
                        Info2.ForeColor = Color.Black;
                        Info3.ForeColor = Color.Black;
                        Info4.ForeColor = Color.Black;
                        Info0.ForeColor = Color.Black;
                    }
                    else if (P2PQuake_json[0].Earthquake.MaxScale == 55)
                    {
                        Info2.BackgroundImage = Resources.k7;
                        Info3.BackColor = Color.FromArgb(230, 0, 0);
                        Info4.BackColor = Color.FromArgb(230, 0, 0);
                        Info0.BackColor = Color.FromArgb(210, 0, 0);
                        Info2.ForeColor = Color.White;
                        Info3.ForeColor = Color.White;
                        Info4.ForeColor = Color.White;
                        Info0.ForeColor = Color.White;
                    }
                    else if (P2PQuake_json[0].Earthquake.MaxScale == 60)
                    {
                        Info2.BackgroundImage = Resources.k8;
                        Info3.BackColor = Color.FromArgb(160, 0, 0);
                        Info4.BackColor = Color.FromArgb(160, 0, 0);
                        Info0.BackColor = Color.FromArgb(140, 0, 0);
                        Info2.ForeColor = Color.White;
                        Info3.ForeColor = Color.White;
                        Info4.ForeColor = Color.White;
                        Info0.ForeColor = Color.White;
                    }
                    else if (P2PQuake_json[0].Earthquake.MaxScale == 70)
                    {
                        Info2.BackgroundImage = Resources.k9;
                        Info3.BackColor = Color.FromArgb(150, 0, 150);
                        Info4.BackColor = Color.FromArgb(150, 0, 150);
                        Info0.BackColor = Color.FromArgb(130, 0, 130);
                        Info2.ForeColor = Color.White;
                        Info3.ForeColor = Color.White;
                        Info4.ForeColor = Color.White;
                        Info0.ForeColor = Color.White;
                    }
                    else
                    {
                        Info2.BackgroundImage = Resources.k0;
                        Info3.BackColor = Color.FromArgb(70, 80, 100);
                        Info4.BackColor = Color.FromArgb(70, 80, 100);
                        Info0.BackColor = Color.FromArgb(50, 60, 80);
                        Info2.ForeColor = Color.White;
                        Info3.ForeColor = Color.White;
                        Info4.ForeColor = Color.White;
                        Info0.ForeColor = Color.White;
                    }
                    string Info1Text = "";
                    string Info3Text = "";
                    if (P2PQuake_json[0].Issue.Type == "ScalePrompt")
                    {
                        Info1Text = "震度速報\n\n\n\n" + P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "津波の心配はありません。").Replace("Unknown", "津波は不明です。").Replace("Checking", "津波について調査中です。").Replace("NonEffective", "若干の海面変動 被害の心配なし").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。");

                        Info3Text = "         震源調査中";
                        if (P2PQuake_json[1].Issue.Type == "Destination" && P2PQuake_json[0].Earthquake.Time == P2PQuake_json[1].Earthquake.Time)
                        {
                            Info1Text = "震度速報・震源に関する情報\n\n\n\n" + P2PQuake_json[1].Earthquake.DomesticTsunami.Replace("None", "津波の心配はありません。").Replace("Unknown", "津波は不明です。").Replace("Checking", "津波について調査中です。").Replace("NonEffective", "若干の海面変動 被害の心配なし").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。");
                            Info3Text = $"         {P2PQuake_json[1].Earthquake.Hypocenter.Name}\n         M{(P2PQuake_json[1].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9")}{$"　　{P2PQuake_json[1].Earthquake.Hypocenter.Depth}km".Replace("　　0km", "　　ごく浅い")}";

                        }
                        else if (P2PQuake_json[2].Issue.Type == "Destination" && P2PQuake_json[0].Earthquake.Time == P2PQuake_json[2].Earthquake.Time)
                        {
                            Info1Text = "震度速報・震源に関する情報\n\n\n\n" + P2PQuake_json[2].Earthquake.DomesticTsunami.Replace("None", "津波の心配はありません。").Replace("Unknown", "津波は不明です。").Replace("Checking", "津波について調査中です。").Replace("NonEffective", "若干の海面変動 被害の心配なし").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。");
                            Info3Text = $"         {P2PQuake_json[2].Earthquake.Hypocenter.Name}\n         M{(P2PQuake_json[2].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9")}{$"　　{P2PQuake_json[2].Earthquake.Hypocenter.Depth}km".Replace("　　0km", "　　ごく浅い")}";

                        }
                        else if (P2PQuake_json[3].Issue.Type == "Destination" && P2PQuake_json[0].Earthquake.Time == P2PQuake_json[3].Earthquake.Time)
                        {
                            Info1Text = "震度速報・震源に関する情報\n\n\n\n" + P2PQuake_json[3].Earthquake.DomesticTsunami.Replace("None", "津波の心配はありません。").Replace("Unknown", "津波は不明です。").Replace("Checking", "津波について調査中です。").Replace("NonEffective", "若干の海面変動 被害の心配なし").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。");
                            Info3Text = $"         {P2PQuake_json[3].Earthquake.Hypocenter.Name}\n         M{(P2PQuake_json[3].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9")}{$"　　{P2PQuake_json[3].Earthquake.Hypocenter.Depth}km".Replace("　　0km", "　　ごく浅い")}";

                        }
                    }
                    else if (P2PQuake_json[0].Issue.Type == "Destination")
                    {
                        Info1Text = "震源に関する情報\n\n\n\n" + P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "津波の心配はありません。").Replace("Unknown", "津波は不明です。").Replace("Checking", "津波について調査中です。").Replace("NonEffective", "若干の海面変動 被害の心配なし").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。");
                        Info3Text = $"         {P2PQuake_json[0].Earthquake.Hypocenter.Name}\n         M{(P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9")}{$"　　{P2PQuake_json[0].Earthquake.Hypocenter.Depth}km".Replace("　　0km", "　　ごく浅い")}";
                        if (P2PQuake_json[1].Issue.Type == "ScalePrompt" && P2PQuake_json[0].Earthquake.Time == P2PQuake_json[1].Earthquake.Time)
                        {
                            Info1Text = "震度速報・震源に関する情報\n\n\n\n" + P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "津波の心配はありません。").Replace("Unknown", "津波は不明です。").Replace("Checking", "津波について調査中です。").Replace("NonEffective", "若干の海面変動 被害の心配なし").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。");
                            if (P2PQuake_json[0].Earthquake.Time == P2PQuake_json[1].Earthquake.Time)
                            {
                                if (P2PQuake_json[1].Earthquake.MaxScale == 10)
                                {
                                    Info2.BackgroundImage = Resources.k1;
                                    Info3.BackColor = Color.FromArgb(70, 100, 110);
                                    Info4.BackColor = Color.FromArgb(70, 100, 110);
                                    Info0.BackColor = Color.FromArgb(50, 80, 90);
                                    Info2.ForeColor = Color.White;
                                    Info3.ForeColor = Color.White;
                                    Info4.ForeColor = Color.White;
                                    Info0.ForeColor = Color.White;
                                }
                                else if (P2PQuake_json[1].Earthquake.MaxScale == 20)
                                {
                                    Info2.BackgroundImage = Resources.k2;
                                    Info3.BackColor = Color.FromArgb(30, 110, 230);
                                    Info4.BackColor = Color.FromArgb(30, 110, 230);
                                    Info0.BackColor = Color.FromArgb(10, 90, 210);
                                    Info2.ForeColor = Color.White;
                                    Info3.ForeColor = Color.White;
                                    Info4.ForeColor = Color.White;
                                    Info0.ForeColor = Color.White;
                                }
                                else if (P2PQuake_json[1].Earthquake.MaxScale == 30)
                                {
                                    Info2.BackgroundImage = Resources.k3;
                                    Info3.BackColor = Color.FromArgb(0, 200, 200);
                                    Info4.BackColor = Color.FromArgb(0, 200, 200);
                                    Info0.BackColor = Color.FromArgb(0, 180, 180);
                                    Info2.ForeColor = Color.Black;
                                    Info3.ForeColor = Color.Black;
                                    Info4.ForeColor = Color.Black;
                                    Info0.ForeColor = Color.Black;
                                }
                                else if (P2PQuake_json[1].Earthquake.MaxScale == 40)
                                {
                                    Info2.BackgroundImage = Resources.k4;
                                    Info3.BackColor = Color.FromArgb(250, 250, 100);
                                    Info4.BackColor = Color.FromArgb(250, 250, 100);
                                    Info0.BackColor = Color.FromArgb(230, 230, 80);
                                    Info2.ForeColor = Color.Black;
                                    Info3.ForeColor = Color.Black;
                                    Info4.ForeColor = Color.Black;
                                    Info0.ForeColor = Color.Black;
                                }
                                else if (P2PQuake_json[1].Earthquake.MaxScale == 45)
                                {
                                    Info2.BackgroundImage = Resources.k5;
                                    Info3.BackColor = Color.FromArgb(255, 180, 0);
                                    Info4.BackColor = Color.FromArgb(255, 180, 0);
                                    Info0.BackColor = Color.FromArgb(235, 150, 0);
                                    Info2.ForeColor = Color.Black;
                                    Info3.ForeColor = Color.Black;
                                    Info4.ForeColor = Color.Black;
                                    Info0.ForeColor = Color.Black;
                                }
                                else if (P2PQuake_json[1].Earthquake.MaxScale == 50)
                                {
                                    Info2.BackgroundImage = Resources.k6;
                                    Info3.BackColor = Color.FromArgb(255, 120, 0);
                                    Info4.BackColor = Color.FromArgb(255, 120, 0);
                                    Info0.BackColor = Color.FromArgb(235, 100, 0);
                                    Info2.ForeColor = Color.Black;
                                    Info3.ForeColor = Color.Black;
                                    Info4.ForeColor = Color.Black;
                                    Info0.ForeColor = Color.Black;
                                }
                                else if (P2PQuake_json[1].Earthquake.MaxScale == 55)
                                {
                                    Info2.BackgroundImage = Resources.k7;
                                    Info3.BackColor = Color.FromArgb(230, 0, 0);
                                    Info4.BackColor = Color.FromArgb(230, 0, 0);
                                    Info0.BackColor = Color.FromArgb(210, 0, 0);
                                    Info2.ForeColor = Color.White;
                                    Info3.ForeColor = Color.White;
                                    Info4.ForeColor = Color.White;
                                    Info0.ForeColor = Color.White;
                                }
                                else if (P2PQuake_json[1].Earthquake.MaxScale == 60)
                                {
                                    Info2.BackgroundImage = Resources.k8;
                                    Info3.BackColor = Color.FromArgb(160, 0, 0);
                                    Info4.BackColor = Color.FromArgb(160, 0, 0);
                                    Info0.BackColor = Color.FromArgb(140, 0, 0);
                                    Info2.ForeColor = Color.White;
                                    Info3.ForeColor = Color.White;
                                    Info4.ForeColor = Color.White;
                                    Info0.ForeColor = Color.White;
                                }
                                else if (P2PQuake_json[1].Earthquake.MaxScale == 70)
                                {
                                    Info2.BackgroundImage = Resources.k9;
                                    Info3.BackColor = Color.FromArgb(150, 0, 150);
                                    Info4.BackColor = Color.FromArgb(150, 0, 150);
                                    Info0.BackColor = Color.FromArgb(130, 0, 130);
                                    Info2.ForeColor = Color.White;
                                    Info3.ForeColor = Color.White;
                                    Info4.ForeColor = Color.White;
                                    Info0.ForeColor = Color.White;
                                }
                                else
                                {
                                    Info2.BackgroundImage = Resources.k0;
                                    Info3.BackColor = Color.FromArgb(70, 80, 100);
                                    Info4.BackColor = Color.FromArgb(70, 80, 100);
                                    Info0.BackColor = Color.FromArgb(50, 60, 80);
                                    Info2.ForeColor = Color.White;
                                    Info3.ForeColor = Color.White;
                                    Info4.ForeColor = Color.White;
                                    Info0.ForeColor = Color.White;
                                }
                            }
                        }
                    }
                    else if (P2PQuake_json[0].Issue.Type == "ScaleAndDestination")
                    {
                        Info1Text = "震度・震源に関する情報\n\n\n\n" + P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "津波の心配はありません。").Replace("Unknown", "津波は不明です。").Replace("Checking", "津波について調査中です。").Replace("NonEffective", "若干の海面変動 被害の心配なし").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。");
                        Info3Text = $"         {P2PQuake_json[0].Earthquake.Hypocenter.Name}\n         M{(P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9")}{$"　　{P2PQuake_json[0].Earthquake.Hypocenter.Depth}km".Replace("　　0km", "　　ごく浅い")}";
                    }
                    else if (P2PQuake_json[0].Issue.Type == "DetailScale")
                    {
                        Info1Text = "各地の震度に関する情報\n\n\n\n" + P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "津波の心配はありません。").Replace("Unknown", "津波は不明です。").Replace("Checking", "津波について調査中です。").Replace("NonEffective", "若干の海面変動 被害の心配なし").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。");
                        Info3Text = $"         {P2PQuake_json[0].Earthquake.Hypocenter.Name}\n         M{(P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9")}{$"　　{P2PQuake_json[0].Earthquake.Hypocenter.Depth}km".Replace("　　0km", "　　ごく浅い")}";
                    }
                    else if (P2PQuake_json[0].Issue.Type == "Foreign")
                    {
                        Info1Text = "遠地地震に関する情報\n\n\n\n" + P2PQuake_json[0].Earthquake.DomesticTsunami.Replace("None", "津波の心配はありません。").Replace("Unknown", "津波は不明です。").Replace("Checking", "津波について調査中です。").Replace("NonEffective", "若干の海面変動 被害の心配なし").Replace("Watch", "津波注意報発表中です。").Replace("Warning", "津波情報発表中です。");
                        Info3Wid.Text = P2PQuake_json[0].Earthquake.Hypocenter.Name;
                        Info3Text = $"{P2PQuake_json[0].Earthquake.Hypocenter.Name}\nM{(P2PQuake_json[0].Earthquake.Hypocenter.Magnitude + ".0").Replace(".1.0", ".1").Replace(".2.0", ".2").Replace(".3.0", ".3").Replace(".4.0", ".4").Replace(".5.0", ".5").Replace(".6.0", ".6").Replace(".7.0", ".7").Replace(".8.0", ".8").Replace(".9.0", ".9")}{$"　　{P2PQuake_json[0].Earthquake.Hypocenter.Depth}km".Replace("　　0km", "　　ごく浅い")}".Replace("M-1.0　　", "(大規模な火山噴火)").Replace("-1km", "");
                    }
                    string Info4Text = P2PQuake_json[0].Earthquake.Time.Remove(16, 3);


                    Info1.Text = Info1Text;
                    Info3.Text = Info3Text;
                    Info4.Text = Info4Text;
                    Console.WriteLine(Info1Text);

                    if (P2PQuake_json[0].Issue.Type == "Foreign")
                    {
                        Info0.Location = new System.Drawing.Point(-100, -100);
                        Info2.Location = new System.Drawing.Point(-100, -100);
                        if (Info3Wid.Size.Width > 292)
                        {
                            Info3.Size = new Size(Info3Wid.Size.Width, 74);
                            Info1.Size = new Size(Info3Wid.Size.Width + 4, 131);
                        }
                        Back.Text = "地図データ:NaturalEarth";
                    }
                    else
                    {
                        Info0.Location = new System.Drawing.Point(5, 30);
                        Info2.Location = new System.Drawing.Point(8, 47);
                        Info3.Size = new Size(288, 74);
                        Info1.Size = new Size(292, 131);
                        Back.Text = "地図データ:気象庁";

                    }




                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　履歴画像描画終了");
                    if (Settings.Default.IsRemoteTalk)
                    {
                        string sMessage = RemoteTalkText;
                        byte bCode = 0;
                        Int16 iVoice = 2;
                        Int16 iVolume = 100;
                        Int16 iSpeed = 100;
                        Int16 iTone = 150;
                        Int16 iCommand = 0x0001;

                        byte[] bMessage = Encoding.UTF8.GetBytes(sMessage);
                        Int32 iLength = bMessage.Length;

                        //棒読みちゃんのTCPサーバへ接続
                        string sHost = "127.0.0.1"; //棒読みちゃんが動いているホスト
                        int iPort = 50001;       //棒読みちゃんのTCPサーバのポート番号(デフォルト値)
                        TcpClient tc = null;
                        try
                        {
                            tc = new TcpClient(sHost, iPort);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("接続失敗");
                        }
                        Console.WriteLine(iCommand + "　" + iSpeed + "　" + iTone + "　" + iVolume + "　" + iVoice + "　" + bCode + "　" + iLength + "　" + sMessage);

                        if (tc != null)
                        {
                            //メッセージ送信
                            using (NetworkStream ns = tc.GetStream())
                            {
                                using (BinaryWriter bw = new BinaryWriter(ns))
                                {
                                    bw.Write(iCommand); //コマンド（ 0:メッセージ読み上げ）
                                    bw.Write(iSpeed);   //速度    （-1:棒読みちゃん画面上の設定）
                                    bw.Write(iTone);    //音程    （-1:棒読みちゃん画面上の設定）
                                    bw.Write(iVolume);  //音量    （-1:棒読みちゃん画面上の設定）
                                    bw.Write(iVoice);   //声質    （ 0:棒読みちゃん画面上の設定、1:女性1、2:女性2、3:男性1、4:男性2、5:中性、6:ロボット、7:機械1、8:機械2、10001～:SAPI5）
                                    bw.Write(bCode);    //文字列のbyte配列の文字コード(0:UTF-8, 1:Unicode, 2:Shift-JIS)
                                    bw.Write(iLength);  //文字列のbyte配列の長さ
                                    bw.Write(bMessage); //文字列のbyte配列
                                }
                            }
                            tc.Close();
                        }
                    }

                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + "　更新時動作終了");
                    double EndTime = Convert.ToDouble(DateTime.Now.ToString("yyyyMMddHHmmss.ffff"));
                    int KeikaTime = (int)((EndTime - StartTime) * 1000);
                    Gratime.Text = $"描画時間:{KeikaTime}ミリ秒";
                }//更新時動作終了
            }
            catch (Exception ex)
            {
                if (Directory.Exists("Log") == false)
                    Directory.CreateDirectory("Log");
                if (Directory.Exists("Log\\ErrorLog") == false)
                    Directory.CreateDirectory("Log\\ErrorLog");
                string ErrorText = $"{ex}";
                if (File.Exists($"Log\\ErrorLog\\Main {DateTime.Now:yyyyMMdd}.txt"))
                    ErrorText = $"{File.ReadAllText($"Log\\ErrorLog\\Main {DateTime.Now:yyyyMMdd}.txt")}\n--------------------------------------------------\nDateTime.Now:HH: mm: ss\n{ex}";
                File.WriteAllText($"Log\\ErrorLog\\Main {DateTime.Now:yyyyMMdd}.txt", ErrorText);
            }
            NoFirst = true;
        }

        private void NowTime_Tick(object sender, EventArgs e)
        {
            NowTime.Text = "現在時刻:" + DateTime.Now.ToString("HH:mm:ss");
        }

        public long LatestTweetID = 0;
        public string LatestEarthquakeID = "";
        public string LatestTime = "";
        public string LatestArea = "";
        private void MapUp_Click(object sender, EventArgs e)
        {
            Map.Location = new System.Drawing.Point(Map.Location.X, Map.Location.Y + 50);
        }

        private void MapDown_Click(object sender, EventArgs e)
        {
            Map.Location = new System.Drawing.Point(Map.Location.X, Map.Location.Y - 50);
        }

        private void MapRight_Click(object sender, EventArgs e)
        {
            Map.Location = new System.Drawing.Point(Map.Location.X - 50, Map.Location.Y);
        }

        private void MapLeft_Click(object sender, EventArgs e)
        {
            Map.Location = new System.Drawing.Point(Map.Location.X + 50, Map.Location.Y);
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            SettingsForm Form2;
            Form2 = new SettingsForm();
            Form2.Show();
        }

        private void Reboot_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BugReportTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/ProjectS31415_1");
        }

        private void SaveImage_Click(object sender, EventArgs e)
        {
            int PointX = Bounds.X;
            int PointY = Bounds.Y;
            Bitmap SaveMapImage = new Bitmap(1080, 720);
            Graphics MapImageGraphics = Graphics.FromImage(SaveMapImage);
            MapImageGraphics.CopyFromScreen(new System.Drawing.Point(PointX, PointY), new System.Drawing.Point(0, 0), SaveMapImage.Size);
            SaveMapImage.Save($"SaveImage\\Latest.png", ImageFormat.Png);
            MapImageGraphics.Dispose();
            SaveMapImage.Dispose();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    UpKey();
                    break;
                case Keys.Down:
                    DownKey();
                    break;
                case Keys.Right:
                    RightKey();
                    break;
                case Keys.Left:
                    LeftKey();
                    break;
            }
        }
        public void UpKey()
        {
            Map.Location = new System.Drawing.Point(Map.Location.X, Map.Location.Y + 10);
        }
        public void DownKey()
        {
            Map.Location = new System.Drawing.Point(Map.Location.X, Map.Location.Y - 10);
        }
        public void RightKey()
        {
            Map.Location = new System.Drawing.Point(Map.Location.X - 10, Map.Location.Y);
        }
        public void LeftKey()
        {
            Map.Location = new System.Drawing.Point(Map.Location.X + 10, Map.Location.Y);
        }

        private void FileOpen_Tick(object sender, EventArgs e)
        {
            Console.WriteLine($"FileOpen_Tick");
            string[] FilePaths = Directory.GetFiles("File", "*", SearchOption.AllDirectories);
            if (NoFirst)
                for (int i = 0; i < FilePaths.Length; i++)
                {
                    Process.Start(FilePaths[i]);
                    Console.WriteLine($"{i + 1}　{FilePaths[i]}");
                }
            FileOpen.Enabled = false;
            Console.WriteLine($"stop");
        }

        private void Zoom25UP_Click(object sender, EventArgs e)
        {
            Map.Size = new Size((int)(Map.Size.Width * 1.25), (int)(Map.Size.Height * 1.25));
            Map.Location = new System.Drawing.Point((int)(Map.Location.X * 1.25 - 90), (int)(Map.Location.Y * 1.25 - 60));
        }

        private void Zoomx075_Click(object sender, EventArgs e)
        {
            Map.Size = new Size((int)(Map.Size.Width * 0.75), (int)(Map.Size.Height * 0.75));
            Map.Location = new System.Drawing.Point((int)(Map.Location.X * 0.75 + 90), (int)(Map.Location.Y * 0.75 + 60));
        }
    }
}
