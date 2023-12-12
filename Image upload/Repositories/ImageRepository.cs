using Dapper;
using Image_upload.Interfaces;
using Image_upload.Modals;
using Npgsql;
using System.Data;
using System.Data.Common;

namespace Image_upload.Repositories
{
    public class ImageRepository : IImageRepositoryInterface
    {
        private readonly IDbConnection _connection;
        public ImageRepository(IDbConnection connection)
        {
            _connection = connection;

        }

        public byte[] getImage(int id)
        {
            string selectQuery = "SELECT ImageData FROM Images WHERE Id = @Id";
            byte[] imageData = _connection.QueryFirstOrDefault<byte[]>(selectQuery, new { Id = id });

            return imageData;
        }

        public int UploadImage(byte [] imageData)
        {

            var sql = "INSERT INTO Images (ImageData) VALUES (@ImageData) RETURNING Id";
            var result = _connection.ExecuteScalar<int>(sql, new { ImageData = imageData });

            return result;
        }
    }
}
