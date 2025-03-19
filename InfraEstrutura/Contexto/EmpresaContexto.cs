using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<TipoEventoServico> tiposEventosServicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server Master = DESKTOP-6RMV3GQ
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-6RMV3GQ;
                DataBase=dbEmpresa2025(2);integrated security=true;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entidade =>
            {
                entidade.HasKey(e => e.id);
                entidade.Property(e => e.Nome).HasMaxLength(100);
                entidade.Property(e => e.Endereco).HasMaxLength(200);

            });

            modelBuilder.Entity<Evento>(entidade =>
            {
                entidade.HasKey(e => e.id);
                entidade.Property(e => e.ValorTotal).HasPrecision(8, 2);

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

            modelBuilder.Entity<TipoEventoServico>()
                .HasKey(t => new { t.TipoEventoId, t.ServicoId });

            modelBuilder.Entity<TipoEventoServico>()
                .HasOne(pt => pt.TipoEvento)
                .WithMany(p => p.TipoEventoServicos)
                .HasForeignKey(pt => pt.TipoEventoId);

            modelBuilder.Entity<TipoEventoServico>()
                .HasOne(pt => pt.Servico)
                .WithMany(t => t.TipoEventoServicos)
                .HasForeignKey(pt => pt.ServicoId);
        }
    }
}
