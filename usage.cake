#r "dist/build/Cake.AutoRest/Cake.AutoRest.dll"

Task("Create-Client")
.Does(() => {
    var settings = new AutoRestSettings {
        Namespace = "Cake",
        Generator = CodeGenerator.AzureCSharp,
        ClientName = "Cake.AutoRest",
        HeaderComment = "Generated by Cake.AutoRest",
        OutputDirectory = "./dist/client"
    };
    AutoRest.Generate("./sample.json", settings);
});

Task("Fluent-Interface")
.Does(() => {
    AutoRest.Generate("./sample.json", settings =>
        settings.UseNamespace("Cake")
            .UseClientName("Cake.AutoRest")
            .AddHeaderComment("Generated by Cake.AutoRest")
            .WithGenerator(CodeGenerator.AzureCSharp)
            .OutputToDirectory("./dist/client"));
});

RunTarget("Create-Client");