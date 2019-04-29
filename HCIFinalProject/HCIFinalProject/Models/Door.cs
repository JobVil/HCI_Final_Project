using System;
namespace HCIFinalProject.Models
{
    public class Door
    {
		public string doorID;
		public string description;
		public int numPanels;
		public string type;
		public int numLights;
		public double height;
		public double width;
		public double thickness;
		public string[] filterTags;
        
		public Door() {

		}

		public Door(string id, string desc, int panels, string type, int lights, double height, double width, double thickness, string[] tags)
        {
			doorID = id;
			description = desc;
			numPanels = panels;
			this.type = type;
			numLights = lights;
			this.height = height;
			this.width = width;
			this.thickness = thickness;
			filterTags = tags;
        }
    }
}
