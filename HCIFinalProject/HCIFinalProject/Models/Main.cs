using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCIFinalProject.Models
{
    public class Main
    {
        public string ItemID { get; private set; }
        public string ItemHeight { get; private set; }
        public string ItemMaterial { get; private set; }
        public string ItemWidth { get; private set; }
        public string ItemPrice { get; private set; }
        public string ItemDepth { get; private set; }
        public string ItemDescription { get; private set; }

        public Main()
        {
            this.ItemID = "52";
            this.ItemHeight = "6'8\"";
            this.ItemMaterial = "BMT (Bellville Mahogany)";
            this.ItemWidth = "3'0\"";
            this.ItemPrice = "$199.99";
            this.ItemDepth = "1-3/4";
            this.ItemDescription = "3'0x6'8 BMT MAHOG 6 PANEL NBNH";
        }

        public Main(string ItemID)
        {
            this.ItemID = ItemID;
            this.ItemHeight = "6'8\"";
            this.ItemMaterial = "BMT (Bellville Mahogany)";
            this.ItemWidth = "3'0\"";
            this.ItemPrice = "$199.99";
            this.ItemDepth = "1-3/4";
            this.ItemDescription = "3'0x6'8 BMT MAHOG 6 PANEL NBNH";
        }
    }
}