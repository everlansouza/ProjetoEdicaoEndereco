using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoEdicaoEndereco.Data;

namespace ProjetoEdicaoEndereco.Migrations
{
    [DbContext(typeof(ProjetoEdicaoEnderecoContext))]
    partial class ProjetoEdicaoEnderecoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IndividuoId")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IndividuoId")
                        .IsUnique();

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EstadosId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EstadosId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.Individuo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Individuo");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.IndividuoContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ddi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IndividuoId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoContato")
                        .HasColumnType("int");

                    b.Property<int>("Whatsapp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IndividuoId")
                        .IsUnique();

                    b.ToTable("IndividuoContato");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.IndividuoEndereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int>("IndividuoId")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("IndividuoId")
                        .IsUnique();

                    b.ToTable("IndividuoEndereco");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.Carro", b =>
                {
                    b.HasOne("SistemaAtulizarEndereco.Models.Individuo", "Individuo")
                        .WithOne("Carro")
                        .HasForeignKey("SistemaAtulizarEndereco.Models.Carro", "IndividuoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individuo");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.Cidade", b =>
                {
                    b.HasOne("SistemaAtulizarEndereco.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.IndividuoContato", b =>
                {
                    b.HasOne("SistemaAtulizarEndereco.Models.Individuo", "Individuo")
                        .WithOne("IndividuoContato")
                        .HasForeignKey("SistemaAtulizarEndereco.Models.IndividuoContato", "IndividuoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individuo");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.IndividuoEndereco", b =>
                {
                    b.HasOne("SistemaAtulizarEndereco.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaAtulizarEndereco.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaAtulizarEndereco.Models.Individuo", "Individuo")
                        .WithOne("IndividuoEndereco")
                        .HasForeignKey("SistemaAtulizarEndereco.Models.IndividuoEndereco", "IndividuoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Estado");

                    b.Navigation("Individuo");
                });

            modelBuilder.Entity("SistemaAtulizarEndereco.Models.Individuo", b =>
                {
                    b.Navigation("Carro")
                        .IsRequired();

                    b.Navigation("IndividuoContato")
                        .IsRequired();

                    b.Navigation("IndividuoEndereco")
                        .IsRequired();
                });
        }
    }
}
