using MovieStore.Domain.Enums;

namespace MovieStore.Domain.Entities
{
    public interface IBaseEntity
    {
        public Status Statu{ get; set; }
    }
}
