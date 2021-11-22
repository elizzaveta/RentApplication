namespace RentApplication.BLL.Interfaces
{
    public interface IPropertySpecification
    {
        bool IsSatisfiedBy(object candidate);
        IPropertySpecification And(IPropertySpecification other);
        IPropertySpecification Or(IPropertySpecification other);
        IPropertySpecification Not();
    }
}