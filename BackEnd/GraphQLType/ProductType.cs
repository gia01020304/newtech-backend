using BackEnd.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.GraphQLType
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of the Product");
            Field(x => x.Name);
            Field(x => x.Image);
            Field(x => x.Price);
            Field(x => x.Describe);
            Field(x => x.ProductType);
        }
    }
}
