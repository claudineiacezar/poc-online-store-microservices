using ProductService.Models;

namespace ProductService.Data
{
    public static class PrepDB
    {
        public static void Prepopulation(IApplicationBuilder app)
        {
             using( var serviceScope = app.ApplicationServices.CreateScope())
            {
               var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
               if (context != null){
                   SeedData(context);
               }
                
            }

        }
        private static void SeedData (AppDbContext context)
        {
            if (context.Products != null && !context.Products.Any())
            {
                  Console.WriteLine("--> Seeding Data ...");
                  context.Products.AddRange(
                      new Product() {Name="	Kit Comigo Ninguem Pode Lola Cosmetics - Condicionador Limpante + Spray BFF Kit", Publisher ="Lola Cosmetics", Price= 49.90}, 
                      new Product() {Name="	Manteiga Hidratante Lola Cosmetics - Segura essa Marimba Carvão Ativado 230g", Publisher ="Lola Cosmetics", Price= 32.90},
                      new Product() {Name="CHAPÉU COUNTRY MODELO GUSTTAVO MARROM CAFÉ UNISSEX ABA 8CM CURVADA", Publisher ="Chapéu Premiun", Price= 89.90},
                      new Product() {Name="	Batom Tracta Líquido Matte Tons Variados 33 - Bonita", Publisher ="Tracta", Price= 18.53},
                      new Product() {Name="Delineador líquido 2,5ml", Publisher ="Quem disse Berenice", Price= 19.95},
                      new Product() {Name="Sombra Refil Cintilante Roseirinha 1,5g", Publisher ="Quem disse Berenice", Price= 9.99},
                      new Product() {Name="Espelho de Mesa", Publisher ="Quem disse Berenice", Price= 14.76}
                  );
                  context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We alredy have data");
            }
        }
    }

}