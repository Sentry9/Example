public interface IValidator<T>
{
    void Validate(T model);
}