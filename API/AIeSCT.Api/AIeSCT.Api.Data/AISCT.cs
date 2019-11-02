namespace AIeSCT.Api.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class AISCT : DbContext
    {
        // Your context has been configured to use a 'AISCT' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AIeSCT.Api.Data.AISCT' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AISCT' 
        // connection string in the application configuration file.
        public AISCT()
            : base("name=AISCT")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<ParkingPlace> ParkingPlaces { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    [Table("ParkingPlace")]
    public class ParkingPlace
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Availability")]
        public bool Availability { get; set; }
    }
}