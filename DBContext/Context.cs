using Domian;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace DbContextL
{
    public class Context:IdentityDbContext<User,Role,int>
    {
      


        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserToken");

            // Configure the Question-Answer relationship
                 builder.Entity<QuestionAnswer>()
                .HasOne(q => q.Response)
                .WithMany(r => r.QuestionAnswers)
                .HasForeignKey(q => q.ResponseId)
                .OnDelete(DeleteBehavior.SetNull);
                 builder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.SetNull);
                 builder.Entity<Response>()
                .HasOne(r => r.Bransh)
                .WithMany(b => b.Responses)
                .HasForeignKey(r => r.braId)
                .OnDelete(DeleteBehavior.SetNull);

                 builder.Entity<Response>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Responses)
                .HasForeignKey(r => r.EmpId)
                .OnDelete(DeleteBehavior.SetNull);


            //

            builder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Entity<UserAddress>()
                .HasOne(ua => ua.Address)
                .WithMany(a => a.UserAddresses)
                .HasForeignKey(ua => ua.AddressId)
                .OnDelete(DeleteBehavior.SetNull);



            // Configure one-to-many relationship
            builder.Entity<PurseOrderHomalla>()
                .HasMany(p => p.kemiaOrders)
                .WithOne(k => k.PurshesOrder)
                .HasForeignKey(k => k.mizeNum)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure one-to-one relationship
            builder.Entity<PurseOrderHomalla>()
                .HasOne(p => p.DependHomolla)
                .WithOne(d => d.PurseOrder)
                .HasForeignKey<DependHomolla>(d => d.PrId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);


            // Configure one-to-many relationship
            builder.Entity<PurseOrder>()
                .HasMany(p => p.kemiaOrders)
                .WithOne(k => k.PurshesOrder)
                .HasForeignKey(k => k.mizeNum)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure one-to-one relationship
            builder.Entity<PurseOrder>()
                .HasOne(p => p.Depend)
                .WithOne(d => d.PurseOrder)
                .HasForeignKey<Depend>(d => d.PrId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

        // public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<UserPaymetMethod> UserPaymetMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingMethod> ShoppingMethods { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<WishList> WishLists { get; set; }
        public DbSet<AppointmentReversion> appointmentReversions { get; set; }

        public DbSet<Bransh> branshes { get; set; }

        public DbSet<PurseOrder> mizePurs { get; set; }
        public DbSet<KemiaOrder> kemies { get; set; }
        public DbSet<moward> mowards { get; set; }

   //     public DbSet<reservationBransh> reservationBranshes { get; set; }

     //   public  DbSet<resravtionuser> resravtionusers { get; set; }

        public DbSet<Artical> articals { get; set; }    

        public DbSet<Comment> comments { get; set; }

        public DbSet<CuponCode> cuponCodes { get; set; }


        public DbSet<BranchService> branchServices { get; set; }
        public DbSet<Depend> depends { get; set; }

        public DbSet<Points> Points { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Madina> Madinas { get; set; }

        public DbSet<CarModelss> CarModelsses { get; set; }


        public DbSet<CarNamesh> carNameshes { get; set; }


        public DbSet<CarService> carServices { get; set; }

        public DbSet<ModelYearCar> modelYearCars{ get; set; }

        public DbSet<DisstanceService> DisstanceServices { get; set; }

        public DbSet<EngineType> engineTypes { get; set; }

        public DbSet<ConfirmSangan> confirmSangans { get; set; }


        public DbSet<ServiceConfirmSangan> serviceConfirmSangans { get; set; }

        public DbSet<PriceConfirmShangan> priceConfirmShangans { get; set; }

        public DbSet<Manteka> manteka { get; set; }

        public DbSet<ReferalUserCode> referalUserCodes { get; set; }

        public DbSet<Signage> signages { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Response> Responses { get; set; }

        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        public DbSet<Employee> Employees { get; set; }


        ////حموله
        public DbSet<PurseOrderHomalla> mizePursHomolla { get; set; }
        public DbSet<KemiaOrderHomolla> kemiesHomolla { get; set; }
        public DbSet<DependHomolla> dependsHomolla { get; set; }

        public DbSet<Homollamoward> mowardsHomolaa { get; set; }

    }
}
