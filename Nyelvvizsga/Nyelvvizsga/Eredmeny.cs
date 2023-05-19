using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyelvvizsga
{
    public class Eredmeny
    {
        string nyelv;
        List<int> eredmenyekEvSzerint = new List<int>();

        public Eredmeny(string csvSor)
        {
            string[] temp = csvSor.Split(';');
            this.nyelv = temp[0];
            for (int i = 1; i < temp.Length; i++)
            {
                eredmenyekEvSzerint.Add(int.Parse(temp[i]));
            }
        }
        public string Nyelv { get { return nyelv; } }
        public List<int> Eredmenyek { get { return eredmenyekEvSzerint; } }
    }
}
