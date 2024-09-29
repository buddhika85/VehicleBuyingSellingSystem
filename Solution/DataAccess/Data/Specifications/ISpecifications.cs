using System.Linq.Expressions;

namespace DataAccess.Data.Specifications;

// https://www.udemy.com/course/learn-to-build-an-e-commerce-app-with-net-core-and-angular/learn/lecture/18137172#overview
// https://lesjackson.net/path-player?courseid=dotnet-developer-toolkit&unit=62b1833033987a66877e3d3bUnit
internal interface ISpecifications<T>
{
    Expression<Func<T, bool>> Criteria { get; }             // Where
    List<Expression<Func<T, Object>>> Includes { get;}
}
