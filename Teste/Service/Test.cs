using Domain.Entities;
using Infrastructure.Migrations;
using Infrastructure.Repositories;
using System;
using System.Linq;
using Xunit;

namespace Teste.Service
{
		public class Test
		{
				[Fact]
				public void RunTest()
				{
						var repository = new BuilderRepository();

            Builder entity = new()
						{
							  About = "Detalhes sobre a empresa",
                Active = true,
                Cnpj = "123.456.789-10",
                FoundationDate= DateTime.Now,
                Name = "Nome da empresa",
                Segment = "Segmento da empresa",
						};

						var inserted = repository.InsertAsync(entity).Result;

            Assert.NotNull(inserted);
            Assert.True(inserted.Id > 0);
            Assert.Equal(inserted.About, entity.About);
            Assert.Equal(inserted.Active, entity.Active);
            Assert.Equal(inserted.Cnpj, entity.Cnpj);
            Assert.Equal(inserted.FoundationDate, entity.FoundationDate);
            Assert.Equal(inserted.Name, entity.Name);
            Assert.Equal(inserted.Segment, entity.Segment);

            var list = repository.SelectAllAsync().Result;
            var selected = list.FirstOrDefault(x => x.Id == inserted.Id);

            Assert.NotNull(list);
            Assert.NotNull(selected);
            Assert.True(list.Count > 0);
            Assert.Equal(selected.Id, inserted.Id);
            Assert.Equal(selected.About, entity.About);
            Assert.Equal(selected.Active, entity.Active);
            Assert.Equal(selected.Cnpj, entity.Cnpj);
            Assert.Equal(selected.FoundationDate, entity.FoundationDate);
            Assert.Equal(selected.Name, entity.Name);
            Assert.Equal(selected.Segment, entity.Segment);

            selected = repository.SelectAsync(inserted.Id).Result;

            Assert.NotNull(selected);
            Assert.Equal(selected.About, entity.About);
            Assert.Equal(selected.Active, entity.Active);
            Assert.Equal(selected.Cnpj, entity.Cnpj);
            Assert.Equal(selected.FoundationDate, entity.FoundationDate);
            Assert.Equal(selected.Name, entity.Name);
            Assert.Equal(selected.Segment, entity.Segment);

            Builder update = new()
            {
                Id = inserted.Id,
                About = "Detalhes sobre a empresa alterado",
                Active = true,
                Cnpj = "999.999.999-99",
                FoundationDate = DateTime.Now,
                Name = "Outro Nome da empresa",
                Segment = "Novo Segmento da empresa",
            };

            var updated = repository.UpdateAsync(update).Result;

            Assert.NotNull(selected);
            Assert.Equal(updated.Id, inserted.Id);
            Assert.NotEqual(updated.About, entity.About);
            Assert.NotEqual(updated.Cnpj, entity.Cnpj);
            Assert.NotEqual(updated.FoundationDate, entity.FoundationDate);
            Assert.NotEqual(updated.Name, entity.Name);
            Assert.NotEqual(updated.Segment, entity.Segment);

            selected = repository.SelectAsync(inserted.Id).Result;

            Assert.NotNull(selected);
            Assert.Equal(selected.About, updated.About);
            Assert.Equal(selected.Active, updated.Active);
            Assert.Equal(selected.Cnpj, updated.Cnpj);
            Assert.Equal(selected.FoundationDate, updated.FoundationDate);
            Assert.Equal(selected.Name, updated.Name);
            Assert.Equal(selected.Segment, updated.Segment);
      
            var deleted = repository.DeleteAsync(entity).Result;

            Assert.NotNull(deleted);
      
            selected = repository.SelectAsync(inserted.Id).Result;

            Assert.Null(selected); 
        }
		}
}
