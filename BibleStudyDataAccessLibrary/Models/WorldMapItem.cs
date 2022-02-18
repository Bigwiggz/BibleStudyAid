using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleStudyDataAccessLibrary.Models
{
    public class WorldMapItem
    {
        public  int Id { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string GeographyType { get; set; }
        public Geometry GeographyData { get; set; }
        public string FKTableIdandName { get; set; }
        public Guid Guid { get; set; }
    }
}
