﻿using ProductManagementSystem.Application.CQRS;
using ProductManagementSystem.Domain.Models;

namespace ProductManagementSystem.Application.Products.Queries.GetProducts;

// TODO : implement pagination
public record GetProductsQuery(string? Filter) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);
