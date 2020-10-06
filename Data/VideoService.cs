using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDapperCRUD.Data
{
    public class VideoService : IVideoService
    {
        //Database connection
        private readonly SqlConnectionConfiguration _configuration;
        public VideoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Add (create) a video table row (SQL Insert)
        public async Task<bool> VideoInsert(Video video)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Title", video.Title, DbType.String);
                parameters.Add("DatePublished", video.DatePublished, DbType.Date);
                parameters.Add("isActive", video.isActive, DbType.Boolean);
                //Raw SQL Method
                const string query = @"INSERT INTO Video (Title, DatePublished, isActive) VALUES (@Title, @DatePublished, @isActive)";
                await conn.ExecuteAsync(query, new { video.Title, video.DatePublished, video.isActive }, commandType: CommandType.Text);
            }

            return true;
        }
    }
}
