using Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ContextoEmpresaFactory : IDesignTimeDbContextFactory<EmpresaContexto>
{
    public EmpresaContexto CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EmpresaContexto>();

        // Defina a string de conexão de forma que o EF possa usar durante o processo de migração.
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-6RMV3GQ;
                DataBase=dbEmpresa2025;integrated security=true;TrustServerCertificate=True;");
        return new EmpresaContexto(optionsBuilder.Options);
    }
}
