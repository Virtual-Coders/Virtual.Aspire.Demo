var builder = DistributedApplication.CreateBuilder(args);

var cartService = builder.AddProject<Projects.Virtual_Aspire_CartService>("cartservice");
var productService = builder.AddProject<Projects.Virtual_Aspire_ProductService>("productservice");
var orderService = builder.AddProject<Projects.Virtual_Aspire_OrderService>("orderservice");
var userService = builder.AddProject<Projects.Virtual_Aspire_UserService>("userservice");

builder.AddProject<Projects.Virtual_Aspire_Cart_Web>("cartweb")
    .WithExternalHttpEndpoints()
    .WithReference(cartService);

builder.AddProject<Projects.Virtual_Aspire_Product_Web>("productweb")
    .WithExternalHttpEndpoints()
    .WithReference(productService);

builder.AddProject<Projects.Virtual_Aspire_Order_Web>("orderweb")
    .WithExternalHttpEndpoints()
    .WithReference(orderService);

builder.AddProject<Projects.Virtual_Aspire_User_Web>("userweb")
    .WithExternalHttpEndpoints()
    .WithReference(userService);

builder.Build().Run();
