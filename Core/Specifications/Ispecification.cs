using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface Ispecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; }
        List<Expression<Func<T, object>>> Includes {get; }
        Expression<Func<T, object>> Orderby {get; }
        Expression<Func<T, object>> OrderbyDescending {get; }

        int Take {get; }
        int Skip {get; }
        bool IsPaginateEnabled {get; }

    }
}