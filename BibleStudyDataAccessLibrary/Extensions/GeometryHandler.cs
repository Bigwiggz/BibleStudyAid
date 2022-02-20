using Dapper;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BibleStudyDataAccessLibrary.Extensions
{
    //Call .Serialize() method on any read action for Sql Server Geography
    public class GeometryHandler<T> : SqlMapper.TypeHandler<T>
    where T : Geometry
    {
        readonly bool _geography;
        readonly SqlServerBytesWriter _writer;
        readonly SqlServerBytesReader _reader;

        public GeometryHandler(bool geography = false)
        {
            _geography = geography;
            _writer = new SqlServerBytesWriter { IsGeography = geography };
            _reader = new SqlServerBytesReader { IsGeography = geography };
        }

        public override T Parse(object value)
            => (T)_reader.Read((byte[])value);

        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = _writer.Write(value);

            ((SqlParameter)parameter).SqlDbType = SqlDbType.Udt;
            ((SqlParameter)parameter).UdtTypeName = _geography ? "geography" : "geometry";
        }
    }
}
