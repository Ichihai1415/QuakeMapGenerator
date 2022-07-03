using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuakeMapGenerator
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Hypocenter
    {
        public int Depth { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Magnitude { get; set; }
        public string Name { get; set; }
    }

    public class Earthquake
    {
        public string DomesticTsunami { get; set; }
        public string ForeignTsunami { get; set; }
        public Hypocenter Hypocenter { get; set; }
        public int MaxScale { get; set; }
        public string Time { get; set; }
    }

    public class Issue
    {
        public string Correct { get; set; }
        public string Source { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
    }

    public class Point
    {
        public string Addr { get; set; }
        public bool IsArea { get; set; }
        public string Pref { get; set; }
        public int Scale { get; set; }
    }

    public class Json
    {
        public int Code { get; set; }
        public string Created_at { get; set; }
        public Earthquake Earthquake { get; set; }
        public string Id { get; set; }
        public Issue Issue { get; set; }
        public List<Point> Points { get; set; }
        public string Time { get; set; }
    }
    public class Tokens_JSON
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecret { get; set; }
    }
}
