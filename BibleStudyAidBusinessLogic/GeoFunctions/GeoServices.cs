using BibleStudyAidBusinessLogic.Models;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;


namespace BibleStudyAidBusinessLogic.GeoFunctions
{
    public class GeoServices
    {
        //Create Net Topology Suite Geometry
        public Geometry CreateGeometryFromWKT(string wkt)
        {
            var reader = new NetTopologySuite.IO.WKTReader();
            var geom = reader.Read(wkt);
            geom.SRID = 4326;
            return geom;
        }

        //Find Center of Geometry
        public Coordinate FindCenterofGeometry(Geometry geometry)
        {
            var center = NetTopologySuite.Algorithm.Centroid.GetCentroid(geometry);

            return center;
        }

        //Find Perimeter Length of Geometry in feet
        public decimal FindGeometryPerimeterLengthFeet(Geometry geometry, int SRIDTag, string baseUnit)
        {
            if (baseUnit == "meter")
            {
                var newGeom = geometry.ProjectTo(SRIDTag);
                //Result is in meters if SRID is 3857
                var perimeterLength = (decimal)newGeom.Length * 3.28084M;
                return perimeterLength;
            }
            else
            {
                var newGeom = geometry.ProjectTo(SRIDTag);
                //Result is in feet
                var perimeterLength = (decimal)newGeom.Length;
                return perimeterLength;
            }

        }

        //Find Area of Geometry in square feet
        public decimal FindGeometryAreaFeet(Geometry geometry, int SRIDTag, string baseUnit)
        {
            if (baseUnit == "meter")
            {
                var newGeom = geometry.ProjectTo(SRIDTag);
                //Result is in meters if SRID is 3857
                var geomArea = (decimal)newGeom.Area * 10.7639M;
                return geomArea;
            }
            else
            {
                var newGeom = geometry.ProjectTo(SRIDTag);
                //Result is in feet
                var geomArea = (decimal)newGeom.Area;
                return geomArea;
            }

        }

        //Is Geometry Valid
        public bool GeometryIsValid(Geometry geometry)
        {
            return geometry.IsValid;
        }

        //GeoJSON to Model
        public List<WorldMapItemBL> CreateModelsFromGeoJSON(string geoJSONObject)
        {
            GeoJsonReader reader = new GeoJsonReader();
            FeatureCollection collection = reader.Read<FeatureCollection>(geoJSONObject);
            List<WorldMapItemBL> worldMapItems = new List<WorldMapItemBL>();
            foreach(var feature in collection)
            {
                WorldMapItemBL item = new WorldMapItemBL();
                item.GeographyData = feature.Geometry;
                item.GeographyType = feature.Geometry.GeometryType;
                item.Id = Convert.ToInt32(feature.Attributes.GetOptionalValue("Id"));
                item.Title = (string)feature.Attributes.GetOptionalValue("Title");
                item.Color = (string)feature.Attributes.GetOptionalValue("Color");
                item.IsDeleted = (bool)feature.Attributes.GetOptionalValue("IsDeleted");
                item.UpdatedDate = (DateTime)feature.Attributes.GetOptionalValue("UpdatedDate");
                item.FKTableIdandName = (string)feature.Attributes.GetOptionalValue("FKTableIdandName");
                item.Description = (string)feature.Attributes.GetOptionalValue("DescriptionAttribute");
                item.Guid = Guid.Parse(feature.Attributes.GetOptionalValue("Guid").ToString());

                var listofFeatureProperties = item.GetType().GetProperties();
                foreach (var prop in listofFeatureProperties)
                {
                    if(prop.PropertyType.Name != "Geometry" && prop.PropertyType.Name !="GeographyType")
                    {
                        prop.SetValue(feature, feature.Attributes.GetType().GetProperties().Where(p => p.Name == prop.Name).FirstOrDefault().GetValue(feature, null));
                    }
                }
                worldMapItems.Add(item);
            };
            return worldMapItems;
        }

        public NetTopologySuite.Geometries.Geometry CreateNTSGeometryFromGeometryGeoJSONObject<T>(T geometryObject)
        {
            string geoJsonString = System.Text.Json.JsonSerializer.Serialize(geometryObject);

            var geoJsonOptions = new JsonSerializerOptions();
            geoJsonOptions.Converters.Add(new NetTopologySuite.IO.Converters.GeoJsonConverterFactory());
            var serializer = GeoJsonSerializer.Create();
            NetTopologySuite.Geometries.Geometry geoShape;
            using (var stringReader = new StringReader(geoJsonString))
            {
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    geoShape = serializer.Deserialize<NetTopologySuite.Geometries.Geometry>(jsonReader);
                }
            }
            return geoShape;
        }


        //Model to GeoJSON
        public string CreateFeatureCollectionGeoJSONFromModel<T>(List<T> objReferenced)
        {
            FeatureCollection featureCollection = new FeatureCollection();

            foreach (var obj in objReferenced)
            {
                AttributesTable attributes = new AttributesTable();

                var listofObjectProperties = obj.GetType().GetProperties();

                foreach (var prop in listofObjectProperties)
                {
                    if (prop.PropertyType.Name != "Geometry")
                    {
                        attributes.Add(prop.Name, prop.GetValue(obj, null));
                    }

                }

                var geometry = obj.GetType().GetProperties().Where(p => p.PropertyType.Name == "Geometry").FirstOrDefault().GetValue(obj, null);

                IFeature feature = new Feature((Geometry)geometry, attributes);
                featureCollection.Add(feature);
            }
            var geoJsonWriter = new GeoJsonWriter();
            return geoJsonWriter.Write(featureCollection);
        }
    }
}
