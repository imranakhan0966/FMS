using Ozone.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ozone.Infrastructure.Shared.Services
{
    public interface IDataShapeHelper<T>
    {
        IEnumerable<Entity> ShapeData(IEnumerable<T> entities, string fieldsString);
        Task<IEnumerable<Entity>> ShapeDataAsync(IEnumerable<T> entities, string fieldsString);
        Entity ShapeData(T entity, string fieldsString);
    }
}