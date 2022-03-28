using BibleStudyDataAccessLibrary.Models;
using NetTopologySuite.Geometries;

namespace BibleStudyAidBusinessLogic.GeoFunctions
{
    public interface IGeoServices
    {
        string CreateFeatureCollectionGeoJSONFromModel<T>(List<T> objReferenced);
        Geometry CreateGeometryFromWKT(string wkt);
        List<WorldMapItem> CreateModelsFromGeoJSON(string geoJSONObject);
        Geometry CreateNTSGeometryFromGeometryGeoJSONObject<T>(T geometryObject);
        Coordinate FindCenterofGeometry(Geometry geometry);
        decimal FindGeometryAreaFeet(Geometry geometry, int SRIDTag, string baseUnit);
        decimal FindGeometryPerimeterLengthFeet(Geometry geometry, int SRIDTag, string baseUnit);
        bool GeometryIsValid(Geometry geometry);
    }
}