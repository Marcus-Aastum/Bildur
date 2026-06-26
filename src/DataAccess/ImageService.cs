using Dapper;
using Microsoft.Data.SqlClient;

namespace Bildur.DataAccess
{
    public class ImageService(IConfiguration configuration)
    {
        private IConfiguration _configuration = configuration;

        public async  Task<IEnumerable<Image>> GetAllImagesAsync()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Bildur")))
            {
                return await connection.QueryAsync<Image>("SELECT * FROM Images");
            }
        }

        public async Task<IEnumerable<Image>> GetAllImagesForUserAsync(string user)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Bildur")))
            {
                return await connection.QueryAsync<Image>("SELECT * FROM Images WHERE Owner = @user", new { user });
            }
        }

        public async Task<bool> InsertImageAsync(Image image) 
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Bildur")))
            {
                var sql = "INSERT INTO Images (Content, FileName, ImageType, Size, UploadTime, Owner) VALUES (@content, @name, @type, @size, @uploadTime, @owner)";
                var result = await connection.ExecuteAsync(sql, new { content = image.Content, name = image.FileName, type = image.ImageType, size = image.Size, uploadTime = image.UploadTime, owner = image.Owner });
                if (result == 1) return true;
            }
            return false;
        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Bildur")))
            {
                var sql = "DELETE FROM Images WHERE ID = @id";
                var result = await connection.ExecuteAsync(sql, new { id });
                if (result == 1) return true;
            }
            return false;
        }
    }
}
