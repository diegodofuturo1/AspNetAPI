using Dapper;
using System;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;
using System.Reflection;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T: Base
    {
        Type Type => typeof(T);
        String Table => Type.Name;
        List<PropertyInfo> Properties => Type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name != "Errors" && x.Name != "IsValid" && x.Name != "Id").ToList();
        String Columns => String.Join(", ", Properties.Select(p => p.Name));
        String Values => String.Join(", ", Properties.Select(p => $"@{p.Name}"));
        String Sets => String.Join(", ", Properties.Select(p => $"{p.Name} = @{p.Name}"));

        SQLiteConnection GetConnection() => new("Data Source=C:\\Projects\\databases\\fatecapicontext.db");

         public virtual async Task<T> DeleteAsync(T entity)
        {
            using var connection = GetConnection();

            string query = $"UPDATE {Table} SET Active = 0 WHERE Id = @Id";

            await connection.ExecuteAsync(query, entity);

            return entity;
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            using var connection = GetConnection();
    
            string query = $"INSERT INTO {Table} ({Columns}) VALUES ({Values})";

            await connection.ExecuteAsync(query, entity);

            var id = await connection.QueryFirstAsync<long>($"SELECT MAX(Id) FROM {Table}");   

            return entity.SetId(id);
        }

        public virtual Task<IList<T>> SearchAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true)
        {
          throw new NotImplementedException();
        }

        public async Task<List<T>> SelectAllAsync()
        {
            using var connection = GetConnection();

            string query = $"SELECT * FROM {Table} WHERE Active = 1";

            var entities = await connection.QueryAsync<T>(query);

            return entities.ToList();
        }

        public virtual async Task<T> SelectAsync(long id)
        {
            try
            {
                using var connection = GetConnection();

                string query = $"SELECT * FROM {Table} WHERE Id = @Id AND Active = 1";

                var entity = await connection.QueryFirstAsync<T>(query, new { Id = id });

                return entity;
            }
            catch
            {
                return null;
            }
        }

        public virtual Task<T> SelectAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true)
        {
          throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            using var connection = GetConnection();

            string query = $"UPDATE {Table} SET {Sets} WHERE Id = @Id";

            await connection.ExecuteAsync(query, entity);

            return entity;
        }
    }
}
