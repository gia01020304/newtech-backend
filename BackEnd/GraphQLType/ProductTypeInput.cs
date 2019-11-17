using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.GraphQLType
{
    public class ProductTypeInput : InputObjectGraphType
    {

        public ProductTypeInput()
        {
            Name = "productInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("describe");
            Field<NonNullGraphType<StringGraphType>>("image");
            Field<NonNullGraphType<StringGraphType>>("productType");
            Field<NonNullGraphType<IntGraphType>>("price");
        }
    }
}
