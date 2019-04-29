using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Npgsql;

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
        private string numLights;
        private string numPanel;
        private string[] tags;
        private bool tagsSearch;
        private List<Door> doors;

        public MainDB()
        {
        }


        public MainDB(string searchTags, string pr, string d1, string d2, string n)
        {
            tags = searchTags.Split(':');
            var priceRange = pr.Split('-');
            var dim1 = d1.Split(':');
            var dim2 = d2.Split(':');
            var num = n.Split(':');
            lowpr = priceRange[0];
            upppr = priceRange[1];
            wFtMin = dim1[1];
            wInMin = dim1[2];
            wFtMax = dim1[3];
            wInMax = dim1[4];
            hMin = dim1[5];
            hMax = dim1[6];
            depthMin = dim2[1];
            depthMax = dim2[2];
            numLights = num[1];
            numPanel = num[2];
            for (int i = 0; i < tags.Length; i++)
            {
                if (i != tags.Length - 1) {
                    tags[i] = tags[i + 1];
                }
                else {
                    tags[i] = null;
                }
            }
            wInMin = (int.Parse(wFtMin) * 12) + "";
            wInMax = (int.Parse(wFtMax) * 12) + "";
        }

        public List<Door> GetMainData()
        {
            if (tagsSearch) {
                spGrabTags();
            }
            else {
                spGrabWithoutTags();
            }
            return doors;
        }

        private Door loadDoor(Object[] line) {
            Door ret = new Door();

            ret.doorID = line[0].ToString();
            ret.description = line[1].ToString();
            ret.numLights = int.Parse(line[2].ToString());
            ret.type = line[3].ToString();
            string filter1 = line[4].ToString();
            ret.height = double.Parse(line[5].ToString());
            ret.width = double.Parse(line[6].ToString());
            ret.thickness = double.Parse(line[7].ToString());
            int intExtID = int.Parse(line[8].ToString());
            string filter2 = line[9].ToString();
            ret.filterTags = new string[5];
            ret.filterTags[0] = filter1;
            if (intExtID == 1)
            {
                ret.filterTags[1] = "Interior";
            }
            else
            {
                ret.filterTags[1] = "Exterior";
            }
            String[] tagsAry = filter2.Split(' ');
            int i = 2;
            foreach (String tag in tagsAry) {
                ret.filterTags[i] = tag;
                i++;
            }
            return ret;
        }

        private void spGrabTags() {
            string connString = "Host={PostgreSQL 11};Username=postgres;Password=password;Database=hci_final";
            string queryString = "SELECT Doors.DoorID, Doors.Description, DoorLights.NumLights, DoorTypes.TypeName, " + 
                "DoorTypes.FilterTag, Doors.Height, Doors.Width, Doors.Thickness, Doors.InteriorExteriorID, Doors.FilterTag " +
                "FROM Doors, DoorLights, DoorTypes " + "WHERE Doors.LightsID = DoorLights.LightsID AND Doors.TypeID = DoorTypes.TypeID " +
                "AND Doors.Width >= " + wInMin + " AND Doors.Width <= " + wInMax + " AND Doors.Height >= "
                + hMin + " AND Doors.Height <= " + hMax + " AND DoorLights.NumLights == " + numLights;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                try
                {
                    var cmd = new NpgsqlCommand(queryString, conn);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read()) {
                            object[] temp = new object[10];
                            reader.GetValues(temp);
                            doors.Add(loadDoor(temp));

                        }
                }
                catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private void spGrabWithoutTags() {
            string connString = "Server={PostgreSQL 11};Port=5433;Database=hci_final;Uid = postgres; Pwd = password;";
            string queryString = "SELECT Doors.DoorID, Doors.Description, DoorLights.NumLights, DoorTypes.TypeName, " +
                "DoorTypes.FilterTag, Doors.Height, Doors.Width, Doors.Thickness, Doors.InteriorExteriorID, Doors.FilterTag " +
                "FROM Doors, DoorLights, DoorTypes " + "WHERE Doors.LightsID = DoorLights.LightsID AND Doors.TypeID = DoorTypes.TypeID " +
                "AND Doors.Width >= " + wInMin + " AND Doors.Width <= " + wInMax + " AND Doors.Height >= "
                + hMin + " AND Doors.Height <= " + hMax + " AND DoorLights.NumLights == " + numLights;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                try
                {
                    var cmd = new NpgsqlCommand(queryString, conn);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            object[] temp = new object[10];
                            reader.GetValues(temp);
                            doors.Add(loadDoor(temp));

                        }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}