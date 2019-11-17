using BackEnd.GraphQLType;
using BackEnd.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Query
{
    public class ProductQuery : ObjectGraphType
    {
        private readonly ProductRepository productRepository;

        public ProductQuery(ProductRepository productRepository)
        {
            Field<ListGraphType<ProductType>>("productions",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                     new QueryArgument<IdGraphType>
                    {
                        Name = "id"
                    },
                      new QueryArgument<StringGraphType>
                    {
                        Name = "name"
                    },
                       new QueryArgument<StringGraphType>
                    {
                        Name = "describe"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "productType"
                    },
                    new QueryArgument<IntGraphType>
                    {
                        Name = "price"
                    },
                     new QueryArgument<StringGraphType>
                    {
                        Name = "image"
                    },
                }), resolve: context =>
                {
                    var query = productRepository.GetQuery();
                    var id = context.GetArgument<int?>("id");
                    if (id.HasValue)
                    {
                        return productRepository.GetQuery().Where(r => r.Id == id.Value);
                    }

                    var name = context.GetArgument<string>("name");
                    if (!string.IsNullOrEmpty(name))
                    {
                        return productRepository.GetQuery().Where(r => r.Name == name);
                    }

                    var describe = context.GetArgument<string>("describe");
                    if (!string.IsNullOrEmpty(describe))
                    {
                        return productRepository.GetQuery().Where(r => r.Describe == describe);
                    }

                    var price = context.GetArgument<int?>("price");
                    if (price.HasValue)
                    {
                        return productRepository.GetQuery().Where(r => r.Price == price.Value);
                    }


                    var productType = context.GetArgument<string>("productType");
                    if (!string.IsNullOrEmpty(productType))
                    {
                        return productRepository.GetQuery().Where(r => r.ProductType == productType);
                    }

                    return query.ToList();
                });
            this.productRepository = productRepository;
        }
    }
}
