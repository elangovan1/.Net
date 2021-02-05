namespace PMS.Domain.Entities
{
    public interface IConvertModel<TSource, TTarget>
    {
        TTarget Convert();
    }

}