using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCIFinalProject.Models
{
    public class MainDB
    {
        private string lowpr;
        private string upppr;
        private string wFtMin;
        private string wInMin;
        private string wFtMax;
        private string wInMax;
        private string hMin;
        private string hMax;
        private string depthMin;
        private string depthMax;
        private string numLites;
        private string numPanel;

        public MainDB()
        {
        }


        public MainDB(string searchTags, string pr, string d1, string d2, string n)
        {
            var tags = searchTags.Split(':');
            var priceRange = pr.Split('-');
            var dim1 = d1.Split(':');
            var dim2 = d2.Split(':');
            var num = n.Split(':');
            lowpr = priceRange[0];
            upppr = priceRange[1];
            wFtMin = dim1[0];
            wInMin = dim1[1];
            wFtMax = dim1[2];
            wInMax = dim1[3];
            hMin = dim1[4];
            hMax = dim1[5];
            depthMin = dim2[0];
            depthMax = dim2[1];
            numLites = num[0];
            numPanel = num[1];
        }

        public List<Main> GetMainData()
        {
            List<Main> ml = new List<Main>();
            for (int i = 0; i < 25; i++)
                ml.Add(new Main(i.ToString()));
            return ml;
        }
    }
}