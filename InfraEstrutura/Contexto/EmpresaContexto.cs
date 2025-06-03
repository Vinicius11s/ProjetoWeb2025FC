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
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Servico> servicos { get; set; }
        public DbSet<TipoEvento> tiposEventos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server Master = DESKTOP-VSA3AAA
            //Server Toledo = LAB10-12
            //localhost\SQLEXPRESS
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;
                DataBase=dbEmpresa2025(2);integrated security=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entidade =>
            {
                entidade.HasKey(e => e.id);
                entidade.Property(e => e.NomeCompleto).HasMaxLength(100);
                entidade.Property(e => e.Endereco).HasMaxLength(200);
                entidade.Property(e => e.DataNascimento).HasColumnType("datetime2(0)");
                entidade.Property(e => e.DataCadastro).HasColumnType("datetime2(0)");
                entidade.Property(e => e.DataNascimento).HasColumnType("date");

            });

            modelBuilder.Entity<Evento>(entidade =>
            {
                entidade.HasKey(e => e.id);
                entidade.Property(e => e.DataEvento).HasColumnType("datetime2(0)");


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

            modelBuilder.Entity<ItemVenda>(entidade =>
            {
                entidade.HasKey(e => e.Id); // Chave primária

                entidade.HasOne(e => e.Evento)
                    .WithMany() 
                    .HasForeignKey(e => e.idEvento)
                    .HasConstraintName("FK_Evento_ItemVenda")
                    .OnDelete(DeleteBehavior.NoAction);

                entidade.HasOne(e => e.Servico)
                    .WithMany() 
                    .HasForeignKey(e => e.idServico)
                    .HasConstraintName("FK_Servico_ItemVenda")
                    .OnDelete(DeleteBehavior.NoAction);

                entidade.HasOne(e => e.Venda)
                    .WithMany(v => v.Itens)
                    .HasForeignKey(e => e.idVenda)
                    .HasConstraintName("FK_Venda_ItemVenda")
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Venda>()
            .HasOne(v => v.FormaPagamento)
            .WithMany() 
            .HasForeignKey(v => v.idFormaPagamento)
            .OnDelete(DeleteBehavior.Restrict);


            //Add-Migration InitialBD -Context InfraEstrutura.Contexto.EmpresaContexto -Project InfraEstrutura
        }
    }
}
