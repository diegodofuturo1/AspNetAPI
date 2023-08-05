using Domain.Entities;

namespace Service.Dtos
{
    public class BaseDto<T> where T : Base, new()
    {
        public T Value { get; set; }

        public BaseDto()
        {
            Value = new();
        }

        public BaseDto(T value)
        {
            Value = value;
        }

        public static implicit operator T(BaseDto<T> wrapper)
        {
            return wrapper.Value;
        }

        public static implicit operator BaseDto<T>(T value)
        {
            return new BaseDto<T>(value);
        }
    }
}
