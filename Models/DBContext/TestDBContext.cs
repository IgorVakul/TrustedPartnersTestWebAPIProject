using Microsoft.EntityFrameworkCore;
using Models.Classes;

namespace Models
{
    public partial class TestDBContext : DbContext
    {
        #region Properties       

        public virtual DbSet<Agent> Agents { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        
        public virtual DbSet<AgentCodeSPResult> AgentCodeSPResults { get; set; }
        public virtual DbSet<AgentsListSPResult> AgentsListSPResults { get; set; }

        #endregion Properties

        #region Constructors

        public TestDBContext()
        {
        }

        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }

        #endregion Constructors

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CS_AS");            

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("AGENTS");

                entity.Property(e => e.AGENT_CODE)
                    .HasColumnName("AGENT_CODE")
                    .HasColumnType("char(6)")
                    .IsRequired()
                    .HasMaxLength(6); ;

                entity.Property(e => e.AGENT_NAME)
                    .HasColumnName("AGENT_NAME")
                    .HasColumnType("char(40)")
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.WORKING_AREA)
                    .HasColumnName("WORKING_AREA")
                    .HasColumnType("char(35)")
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.COMMISSION)
                    .HasColumnName("COMMISSION")
                    .HasColumnType("int")
                    .HasDefaultValueSql("(0)");
                    //.IsRequired();

                entity.Property(e => e.PHONE_NO)
                    .HasColumnName("PHONE_NO")
                    .HasColumnType("char(15)")
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.COUNTRY)
                  .HasColumnName("COUNTRY")
                  .HasColumnType("varchar(25)")
                  .IsRequired()
                  .HasMaxLength(25);

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.ORD_NUM)
                    .IsRequired()
                    .HasColumnName("ORD_NUM")
                    .HasColumnType("int");

                entity.Property(e => e.ORD_AMOUNT)
                    .HasColumnName("ORD_AMOUNT")
                    .HasColumnType("float")
                    .HasDefaultValueSql("(0)")
                    .IsRequired();

                entity.Property(e => e.ADVANCE_AMOUNT)
                    .HasColumnName("ADVANCE_AMOUNT")
                    .HasColumnType("float")
                    .HasDefaultValueSql("(0)")
                    .IsRequired();

                entity.Property(e => e.ORD_DATE)
                    .HasColumnName("ORD_DATE")
                    .HasColumnType("datetime")
                    .IsRequired()
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CUST_CODE)
                    .HasColumnName("CUST_CODE")
                    .HasColumnType("varchar(6)")
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.AGENT_CODE)
                    .HasColumnName("AGENT_CODE")
                    .HasColumnType("char(6)")
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ORD_DESCRIPTION)
                    .HasColumnName("ORD_DESCRIPTION")
                    .HasColumnType("varchar(60)")
                    .IsRequired()
                    .HasMaxLength(60);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #endregion Methods
    }
}
