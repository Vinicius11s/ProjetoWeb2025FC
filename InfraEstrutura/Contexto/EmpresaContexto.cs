using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Contexto
{
    public class EmpresaContexto : DbContext
    {
        public EmpresaContexto(DbContextOptions<EmpresaContexto> options) : base(options)
        {
        }

        protected EmpresaContexto()
        {
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Evento> eventos { get; set; }
        public DbSet<FormaPagamento> formasPagamento { get; set; }
        public DbSet<Login> logins { get; set; }
        public DbSet<Servico> servicos { get; set; }
        public DbSet<TipoEvento> tiposEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server Master = DESKTOP-VSA3AAA 
            //Server Toledo = LAB10-12
            optionsBuilder.UseSqlServer(@"Server=LAB10-12;
                DataBase=dbEmpresa2025(2);integrated security=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entidade =>
            {
                entidade.HasKey(e => e.id);
                entidade.Property(e => e.NomeCompleto).HasMaxLength(100);
                entidade.Property(e => e.Endereco).HasMaxLength(200);

            });

            modelBuilder.Entity<Evento>(entidade =>
            {
                entidade.HasKey(e => e.id);

                entidade.HasOne(e => e.Cliente)
                    .WithMany(c => c.Eventos)
                    .HasForeignKey(e => e.idCliente)
                    .HasConstraintName("FK_Cliente_Eventos")
                    .OnDelete(DeleteBehavior.NoAction);

                entidade.HasOne(e => e.TipoEvento)
                    .WithMany(t => t.Eventos)
                    .HasForeignKey(e => e.idTipoEvento)
                    .HasConstraintName("FK_TipoEvento_Evento")
                    .OnDelete(DeleteBehavior.NoAction);

                entidade.HasOne(e => e.FormaPagamento)
                    .WithMany(f => f.Eventos)
                    .HasForeignKey(e => e.idFormaPagamento)
                    .HasConstraintName("FK_FormaPagamento_Evento")
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<FormaPagamento>(entidade =>
            {
                entidade.HasKey(e => e.id);
            });

            //Add-Migration AtualizandoBD -Context InfraEstrutura.Contexto.EmpresaContexto -Project InfraEstrutura
        }
    }
}
