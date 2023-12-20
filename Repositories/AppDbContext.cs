using ApiTransacoesBancarias.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTransacoesBancarias
{
    public class AppDbContext : DbContext
{

    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Transacao> Transacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transacao>(entity =>
        {

            modelBuilder.Entity<Transacao>()
                .Property(t => t.DataHora)
                .HasColumnType("date");

            modelBuilder.Entity<Transacao>()
                .Property(t => t.ModoTransacao)
                .HasConversion<string>();

            modelBuilder.Entity<Transacao>()
                .Property(t => t.ModoTransacao)
                .HasMaxLength(20)
                .IsRequired();

                

            entity.ToTable("transacoes"); 
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.DataHora).HasColumnName("DataHora");
            entity.Property(e => e.ModoTransacao).HasColumnName("ModoTransacao");
            entity.Property(e => e.Categoria).HasColumnName("Categoria");
            entity.Property(e => e.NotaObservacao).HasColumnName("NotaObservacao");
            entity.Property(e => e.Valor).HasColumnName("Valor");
            entity.Property(e => e.TipoTransacao).HasColumnName("TipoTransacao");

            base.OnModelCreating(modelBuilder);

        });

    }
}


}