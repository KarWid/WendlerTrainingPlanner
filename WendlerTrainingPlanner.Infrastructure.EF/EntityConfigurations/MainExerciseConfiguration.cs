namespace WendlerTrainingPlanner.Infrastructure.EF.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using WendlerTrainingPlanner.Domain.Entities;

    public class MainExerciseConfiguration : IEntityTypeConfiguration<MainExercise>
    {
        public void Configure(EntityTypeBuilder<MainExercise> builder)
        {
            builder.ToTable(nameof(MainExercise), WendlerTrainingPlannerDbContext.DEFAULT_SCHEMA);

            builder.HasKey(mainExercise => mainExercise.Id);

            builder
                .Property<string>("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            //config.HasIndex("Name", "IX_MainExercise_Name").IsUnique();

            //config.ToTable("MainExercises", WendlerTrainingPlannerDbContext.DEFAULT_SCHEMA);

            //config
            //    .OwnsOne(e => e.Id)
            //    .Property(id => id.Value)
            //    .HasColumnName("Id")
            //    .UseHiLo("mainexerciseseq", WendlerTrainingPlannerDbContext.DEFAULT_SCHEMA)
            //    .IsRequired();

            //config.HasKey("Id");

            //config
            //    .Property<string>("_name")
            //    .UsePropertyAccessMode(PropertyAccessMode.Field)
            //    .HasColumnName("Name")
            //    .HasMaxLength(100)
            //    .IsRequired();

            //config.HasIndex("Name", "IX_MainExercise_Name").IsUnique();
            //throw new NotImplementedException();
        }
    }
}
