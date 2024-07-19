using AutoMapper;
using TrueCodeTest.Application.Interfaces;

namespace TrueCodeTest.Infrastructure.Web.Base.Mapper
{
    public static class MapperExtensions
    {
        public static void MapId<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression) where TDestination : IWithId
        {
            expression.ForMember(d => d.Id, opt => opt.MapFrom((_, _, _, ctx) => ctx.Items["Id"]));
        }
    }
}
