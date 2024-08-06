using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public partial class DrugstoreModel : DbContext
    {
        public DrugstoreModel()
            : base("name=DrugstoreModel")
        {
        }

        public virtual DbSet<Artikl> Artikl { get; set; }
        public virtual DbSet<Dobavljac> Dobavljac { get; set; }
        public virtual DbSet<Farmaceut> Farmaceut { get; set; }
        public virtual DbSet<JedinicaMjere> JedinicaMjere { get; set; }
        public virtual DbSet<Lijecnik> Lijecnik { get; set; }
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<Pacijent> Pacijent { get; set; }
        public virtual DbSet<Primka> Primka { get; set; }
        public virtual DbSet<Racun> Racun { get; set; }
        public virtual DbSet<Recept> Recept { get; set; }
        public virtual DbSet<StatusNarudzbe> StatusNarudzbe { get; set; }
        public virtual DbSet<StavkeNarudzbe> StavkeNarudzbe { get; set; }
        public virtual DbSet<StavkePrimke> StavkePrimke { get; set; }
        public virtual DbSet<StavkeRacuna> StavkeRacuna { get; set; }
        public virtual DbSet<StavkeRecepta> StavkeRecepta { get; set; }
        public virtual DbSet<Ustanova> Ustanova { get; set; }
        public virtual DbSet<Podaci> Podaci { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikl>()
                .Property(e => e.Naziv)
                .IsFixedLength();

            modelBuilder.Entity<Artikl>()
                .Property(e => e.JedinicaMjereID)
                .IsFixedLength();

            modelBuilder.Entity<Artikl>()
                .HasMany(e => e.StavkeNarudzbe)
                .WithRequired(e => e.Artikl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artikl>()
                .HasMany(e => e.StavkePrimke)
                .WithRequired(e => e.Artikl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artikl>()
                .HasMany(e => e.StavkeRacuna)
                .WithRequired(e => e.Artikl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artikl>()
                .HasMany(e => e.StavkeRecepta)
                .WithRequired(e => e.Artikl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.OIB)
                .IsFixedLength();

            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.Naziv)
                .IsFixedLength();

            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.IBAN)
                .IsFixedLength();

            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.Adresa)
                .IsFixedLength();

            modelBuilder.Entity<Dobavljac>()
                .HasMany(e => e.Narudzba)
                .WithRequired(e => e.Dobavljac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dobavljac>()
                .HasMany(e => e.Primka)
                .WithRequired(e => e.Dobavljac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Farmaceut>()
                .Property(e => e.Ime)
                .IsFixedLength();

            modelBuilder.Entity<Farmaceut>()
                .Property(e => e.Prezime)
                .IsFixedLength();

            modelBuilder.Entity<Farmaceut>()
                .Property(e => e.Korime)
                .IsFixedLength();

            modelBuilder.Entity<Farmaceut>()
                .Property(e => e.Lozinka)
                .IsFixedLength();

            modelBuilder.Entity<Farmaceut>()
                .Property(e => e.Adresa)
                .IsFixedLength();

            modelBuilder.Entity<Farmaceut>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Farmaceut>()
                .HasMany(e => e.Narudzba)
                .WithRequired(e => e.Farmaceut)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Farmaceut>()
                .HasMany(e => e.Primka)
                .WithRequired(e => e.Farmaceut)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Farmaceut>()
                .HasMany(e => e.Racun)
                .WithRequired(e => e.Farmaceut)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JedinicaMjere>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<JedinicaMjere>()
                .Property(e => e.Naziv)
                .IsFixedLength();

            modelBuilder.Entity<JedinicaMjere>()
                .HasMany(e => e.Artikl)
                .WithRequired(e => e.JedinicaMjere)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lijecnik>()
                .Property(e => e.Ime)
                .IsFixedLength();

            modelBuilder.Entity<Lijecnik>()
                .Property(e => e.Prezime)
                .IsFixedLength();

            modelBuilder.Entity<Lijecnik>()
                .Property(e => e.Adresa)
                .IsFixedLength();

            modelBuilder.Entity<Lijecnik>()
                .Property(e => e.Telefon)
                .IsFixedLength();

            modelBuilder.Entity<Lijecnik>()
                .HasMany(e => e.Recept)
                .WithRequired(e => e.Lijecnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Narudzba>()
                .HasMany(e => e.StavkeNarudzbe)
                .WithRequired(e => e.Narudzba)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pacijent>()
                .Property(e => e.MBO)
                .IsFixedLength();

            modelBuilder.Entity<Pacijent>()
                .Property(e => e.Ime)
                .IsFixedLength();

            modelBuilder.Entity<Pacijent>()
                .Property(e => e.Prezime)
                .IsFixedLength();

            modelBuilder.Entity<Pacijent>()
                .Property(e => e.Adresa)
                .IsFixedLength();

            modelBuilder.Entity<Pacijent>()
                .HasMany(e => e.Recept)
                .WithRequired(e => e.Pacijent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Primka>()
                .HasMany(e => e.StavkePrimke)
                .WithRequired(e => e.Primka)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Racun>()
                .HasMany(e => e.StavkeRacuna)
                .WithRequired(e => e.Racun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recept>()
                .HasMany(e => e.StavkeRecepta)
                .WithRequired(e => e.Recept)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusNarudzbe>()
                .Property(e => e.Naziv)
                .IsFixedLength();

            modelBuilder.Entity<StatusNarudzbe>()
                .HasMany(e => e.Narudzba)
                .WithRequired(e => e.StatusNarudzbe)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ustanova>()
                .Property(e => e.Naziv)
                .IsFixedLength();

            modelBuilder.Entity<Ustanova>()
                .Property(e => e.Adresa)
                .IsFixedLength();

            modelBuilder.Entity<Ustanova>()
                .HasMany(e => e.Lijecnik)
                .WithRequired(e => e.Ustanova)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Podaci>()
                .Property(e => e.Naziv)
                .IsFixedLength();

            modelBuilder.Entity<Podaci>()
                .Property(e => e.Adresa)
                .IsFixedLength();

            modelBuilder.Entity<Podaci>()
                .Property(e => e.OIB)
                .IsFixedLength();

            modelBuilder.Entity<Podaci>()
                .Property(e => e.Telefon)
                .IsFixedLength();
        }
    }
}
