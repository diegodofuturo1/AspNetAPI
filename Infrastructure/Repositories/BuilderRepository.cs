using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
		public class BuilderRepository : BaseRepository<Builder>, IBuilderRepository
		{
				public BuilderRepository()
				{
				}

				//public new async Task<Builder> InsertAsync(Builder builder)
				//{
				//    using var connection = GetConnection();

    //        const string sql = "INSERT INTO Builder (Name, About, Cnpj, Segment, FoundationDate) VALUES (@Name, @About, @Cnpj, @Segment, @FoundationDate);"; 

    //        var id = await connection.ExecuteAsync(sql, builder);

    //        return builder.SetId(id);
				//}
	}
}
