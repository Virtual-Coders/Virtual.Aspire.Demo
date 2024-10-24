﻿using Microsoft.EntityFrameworkCore;

namespace Virtual.Aspire.ProductService.Entities;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
}
