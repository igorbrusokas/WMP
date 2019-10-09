using System.Collections.Generic;


namespace WebMotorsProject.Domain.Data.Converter.Interface
{
    public interface IConverter<TOrigin, TDestination>
    {
        TDestination Parse(TOrigin origin);

        List<TDestination> ParseList(List<TOrigin> origin);
    }
}
