using System;
using System.Globalization;
using System.Linq;

namespace Defibrilateur
{
    class Solution
    {
        static void Main(string[] args)
        {

            var format = new NumberFormatInfo { NumberDecimalSeparator = "," };
            var LON = double.Parse(Console.ReadLine(), format);
            var LAT = double.Parse(Console.ReadLine(), format);
            int N = int.Parse(Console.ReadLine());

            Console.WriteLine(
              Enumerable.Range(0, N).Select(i => Console.ReadLine())
              .Select(line =>
              {
                  var data = line.Split(new string[] { ";" }, StringSplitOptions.None);
                  return new Defibrilateur { Id = int.Parse(data[0]), Name = data[1].Trim(), Address = data[2].Trim(), Longitude = double.Parse(data[4], format), Latitude = double.Parse(data[5], format) };
              })
              .OrderBy(d => d.ToDistance(LAT, LON))
              .First().Name);
        }

    }

    public static class DefibrilateurHelper
    {
        public static double ToDistance(this Defibrilateur a, double lat, double longitude)
        {
            var b = new { lat, longitude };
            var x = (b.longitude - a.Longitude) * Math.Cos((a.Latitude + b.lat) / 2);
            var y = b.lat - a.Latitude;
            var d = Math.Sqrt((Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371);
            return d;
        }
    }


    public class Defibrilateur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }



}
