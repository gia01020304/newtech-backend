using BackEnd.Data;
using BackEnd.GraphQLType;
using BackEnd.Model;
using BackEnd.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Mutation
{
    public class ProductMutation : ObjectGraphType
    {


        public ProductMutation(ProductRepository productRepository)
        {
            Field<ProductType>(
            "createProduct",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductTypeInput>> { Name = "product" }),
                resolve: context =>
                {
                    var product = context.GetArgument<Product>("product");
                    return productRepository.AddProduct(product);
                }
            );

            Field<ProductType>(
            "updateProduct",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductTypeInput>> { Name = "product" },
                                           new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "productId" }),
                resolve: context =>
                {
                    var product = context.GetArgument<Product>("product");
                    var productId = context.GetArgument<int>("productId");
                    var productById = productRepository.GetById(productId);
                    if (productById != null)
                    {
                        return productRepository.UpdateProduct(product, productById);
                    }
                    return null;
                   
                }
            );

            Field<StringGraphType>(
            "deleteProduct",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "productId" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("productId");
                    var productById = productRepository.GetById(productId);
                    if (productById != null)
                    {
                        productRepository.DeleteProduct(productById);
                        return $"The product with the id: {productId} has been successfully deleted from db.";
                    }
                    return null;
                }
            );

        }
    }
}
