using AplicacionWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_API.Models;

namespace WebApplication2.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Cuenta> Cuentas { get; set; } //Taula
        public DbSet<Apuesta> Apuestas { get; set; } //Taula
        public DbSet<Evento> Eventos { get; set; } //Taula
        public DbSet<Mercado> Mercados { get; set; } //Taula
        public DbSet<Usuario> Usuarios { get; set; } //Taula

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options)
        : base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=placemybet2;Uid=root;Pwd=''; SslMode = none");//màquina retos

            }
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().HasData(new Evento(1, "Valencia", "Español", "2020/02/20"));
            modelBuilder.Entity<Evento>().HasData(new Evento(2, "Madrid", "Barcelona", "2020/03/30"));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 1.5, 1.9, 1.9, 100, 100, 1));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2, 2.5, 1.9, 1.9, 100, 100, 2));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, 1, "Over", 1.9, 100, "2020/02/20", 1, 1));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(2, 2, "Under", 1.9, 50, "2020/02/20", 1, 2));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(1, "Jesus", "Salvador", 19));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(2, "Pedro", "Gonzalez", 20));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(1, 500, "Bankia", 1));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(2, 500, "Bankia", 2));


        }
    }
}