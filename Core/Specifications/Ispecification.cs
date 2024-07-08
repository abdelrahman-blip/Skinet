using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface Ispecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; }
        List<Expression<Func<T, object>>> Includes {get; }
    }
}