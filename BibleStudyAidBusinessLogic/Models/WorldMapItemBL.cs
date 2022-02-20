using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyAidBusinessLogic.Models
{
    public class WorldMapItemBL
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string GeographyType { get; set; }
        public Geometry GeographyData { get; set; }
        public string FKTableIdandName { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
    }
}
