using System.Linq.Expressions;

namespace DataAccess.Data.Specifications;

public class BaseSpecifications<T> : ISpecification<T>
{
    public BaseSpecifications(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; } = null!;

    public List<Expression<Func<T, object>>> Includes { get; }  = new List<Expression<Func<T, object>>>();

    protected void AddInclude(Expression<Func<T, object>> expressionToInclude)
    {
        Includes.Add(expressionToInclude);
    }
}
