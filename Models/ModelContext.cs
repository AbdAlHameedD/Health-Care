using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Health_Care_V1._2.Models;

#nullable disable

namespace Health_Care_V1._2.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountAddress> AccountAddresses { get; set; }
        public virtual DbSet<AccountPhoneNumber> AccountPhoneNumbers { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<ClinicAddress> ClinicAddresses { get; set; }
        public virtual DbSet<ClinicPhoneNumber> ClinicPhoneNumbers { get; set; }
        public virtual DbSet<ClinicRate> ClinicRates { get; set; }
        public virtual DbSet<ContactUsCard> ContactUsCards { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DoctorRate> DoctorRates { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FooterClinc> FooterClincs { get; set; }
        public virtual DbSet<FooterQuickLink> FooterQuickLinks { get; set; }
        public virtual DbSet<FooterService> FooterServices { get; set; }
        public virtual DbSet<HeaderLink> HeaderLinks { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Main> Mains { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH13_User41;PASSWORD=dalgamouni;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH13_USER41")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.HasIndex(e => e.Username, "SYS_C00190705")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "SYS_C00190706")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Bod)
                    .HasColumnType("DATE")
                    .HasColumnName("BOD");

                entity.Property(e => e.CreationDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENDER")
                    .IsFixedLength(true);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MNAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("PERMISSION");

                entity.Property(e => e.ProfilePicture)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PROFILE_PICTURE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<AccountAddress>(entity =>
            {
                entity.ToTable("ACCOUNT_ADDRESS");

                entity.HasIndex(e => e.AccountId, "SYS_C00198002")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.City)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.AccountAddress)
                    .HasForeignKey<AccountAddress>(d => d.AccountId)
                    .HasConstraintName("ACCOUNT_TO_ACCOUNT_ADDRESS_FK");
            });

            modelBuilder.Entity<AccountPhoneNumber>(entity =>
            {
                entity.ToTable("ACCOUNT_PHONE_NUMBER");

                entity.HasIndex(e => e.PhoneNumber, "SYS_C00190728")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE_NUMBER");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountPhoneNumbers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("ACCOUNT_TO_ACCOUNT_PHONE_NUMBER_FK");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CreationDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.DoctorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.FromDate)
                    .HasPrecision(6)
                    .HasColumnName("FROM_DATE");

                entity.Property(e => e.PatientId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.ToDate)
                    .HasPrecision(6)
                    .HasColumnName("TO_DATE");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("EMPLOYEE_TO_APPOINTMENT_FK");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ACCOUNT_TO_APPOINTMENT_FK");
            });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.ToTable("CLINIC");

                entity.HasIndex(e => e.ClinicName, "SYS_C00190711")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AdditionDate)
                    .HasPrecision(6)
                    .HasColumnName("ADDITION_DATE");

                entity.Property(e => e.ClinicLogo)
                    .HasColumnType("LONG")
                    .HasColumnName("CLINIC_LOGO");

                entity.Property(e => e.ClinicName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CLINIC_NAME");
            });

            modelBuilder.Entity<ClinicAddress>(entity =>
            {
                entity.ToTable("CLINIC_ADDRESS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.BuildingNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUILDING_NUMBER");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.ClinicId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLINIC_ID");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Street)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STREET");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.ClinicAddresses)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("CLINIC_TO_CLINICADDRESS_FK");
            });

            modelBuilder.Entity<ClinicPhoneNumber>(entity =>
            {
                entity.ToTable("CLINIC_PHONE_NUMBER");

                entity.HasIndex(e => e.PhoneNumber, "SYS_C00190762")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ClinicId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLINIC_ID");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE_NUMBER");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.ClinicPhoneNumbers)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("CLINIC_TO_CLINIC_PHONE_NUMBER_FK");
            });

            modelBuilder.Entity<ClinicRate>(entity =>
            {
                entity.ToTable("CLINIC_RATE");

                entity.HasIndex(e => new { e.ClinicId, e.PatientId }, "UNIQUE_CLINIC_ID_AND_ACCOUNT_ID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ClinicId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLINIC_ID");

                entity.Property(e => e.CreationDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.PatientId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.Rate)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RATE");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.ClinicRates)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CLINIC_TO_CLINIC_RATE_FK");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ClinicRates)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ACCOUNT_TO_CLINIC_RATE_FK");
            });

            modelBuilder.Entity<ContactUsCard>(entity =>
            {
                entity.ToTable("CONTACT_US_CARDS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ContactContent)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_CONTENT");

                entity.Property(e => e.ContactTitle)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_TITLE");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ICON");

                entity.Property(e => e.Link)
                    .HasColumnType("LONG")
                    .HasColumnName("LINK");
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable("CREDIT_CARD");

                entity.HasIndex(e => e.CardNumber, "SYS_C00191844")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CARD_NUMBER");

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CARD_TYPE");

                entity.Property(e => e.ExpMonth)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EXP_MONTH");

                entity.Property(e => e.ExpYear)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EXP_YEAR");

                entity.Property(e => e.ModifiedDate)
                    .HasPrecision(6)
                    .HasColumnName("MODIFIED_DATE");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PATIENT_TO_CREDIT_CARD_FK");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnType("LONG")
                    .HasColumnName("ICON");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<DoctorRate>(entity =>
            {
                entity.ToTable("DOCTOR_RATE");

                entity.HasIndex(e => new { e.PatientId, e.DoctorId }, "PATIENT_ID_AND_ACCOUNT_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CreationDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.DoctorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.PatientId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.Rate)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RATE");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorRates)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("DOCTOR_TO_DOCTOR_RATE_FK");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DoctorRates)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ACCOUNT_TO_DOCTOR_RATE_FK");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.HasIndex(e => e.AccountId, "SYS_C00190714")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.ClinicId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLINIC_ID");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ACCOUNT_TO_DOCTOR_FK");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CLINIC_TO_DOCTOR_FK");
            });

            modelBuilder.Entity<FooterClinc>(entity =>
            {
                entity.ToTable("FOOTER_CLINCS");

                entity.HasIndex(e => e.Nickname, "SYS_C00191288")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnType("LONG")
                    .HasColumnName("LINK");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NICKNAME");
            });

            modelBuilder.Entity<FooterQuickLink>(entity =>
            {
                entity.ToTable("FOOTER_QUICK_LINKS");

                entity.HasIndex(e => e.Nickname, "SYS_C00191283")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnType("LONG")
                    .HasColumnName("LINK");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NICKNAME");
            });

            modelBuilder.Entity<FooterService>(entity =>
            {
                entity.ToTable("FOOTER_SERVICES");

                entity.HasIndex(e => e.Nickname, "SYS_C00191293")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnType("LONG")
                    .HasColumnName("LINK");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NICKNAME");
            });

            modelBuilder.Entity<HeaderLink>(entity =>
            {
                entity.ToTable("HEADER_LINKS");

                entity.HasIndex(e => e.Nickname, "SYS_C00191373")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnType("LONG")
                    .HasColumnName("LINK");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NICKNAME");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("INVOICE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ClinicId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLINIC_ID");

                entity.Property(e => e.CreationDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.DoctorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.AppointmentId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("APPOINTMENT_ID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("NOTES");

                entity.Property(e => e.PatientId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("CLINIC_TO_INVOICE_FK");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("DOCTOR_TO_INVOICE_FK");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("APPOINTMENT_TO_INVOICE_FK");
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.ToTable("INVOICE_ITEM");

                entity.HasIndex(e => new { e.InvoiceId, e.ItemName }, "INVOICE_ID_AND_ITEM_NAME_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InvoiceId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INVOICE_ID");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_DESCRIPTION");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ITEM_NAME");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUANTITY")
                    .HasDefaultValueSql("1 ");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("INVOICE_TO_INVOICE_ITEM_FK");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("LOG");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.LoginDate)
                    .HasPrecision(6)
                    .HasColumnName("LOGIN_DATE");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("ACCOUNT_TO_USER_LOGIN_FK");
            });

            modelBuilder.Entity<Main>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MAIN");

                entity.Property(e => e.AboutBackgroundImage)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_BACKGROUND_IMAGE");

                entity.Property(e => e.AboutButton01)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_BUTTON_01");

                entity.Property(e => e.AboutButton02)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_BUTTON_02");

                entity.Property(e => e.AboutButton03)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_BUTTON_03");

                entity.Property(e => e.AboutContent01)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_CONTENT_01");

                entity.Property(e => e.AboutContent02)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_CONTENT_02");

                entity.Property(e => e.AboutImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_IMAGE");

                entity.Property(e => e.AboutTitle01)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_TITLE_01");

                entity.Property(e => e.AboutTitle02)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_TITLE_02");

                entity.Property(e => e.AboutTitle03)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ABOUT_TITLE_03");

                entity.Property(e => e.ClinicContent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLINIC_CONTENT");

                entity.Property(e => e.ClinicTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLINIC_TITLE");

                entity.Property(e => e.ContactContent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_CONTENT");

                entity.Property(e => e.ContactTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_TITLE");

                entity.Property(e => e.CopyrightContent)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COPYRIGHT_CONTENT");

                entity.Property(e => e.DepartmentImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_IMAGE");

                entity.Property(e => e.DoctorContent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_CONTENT");

                entity.Property(e => e.DoctorTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_TITLE");

                entity.Property(e => e.FooterAttributeAddress05)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_ATTRIBUTE_ADDRESS_05");

                entity.Property(e => e.FooterAttributeContent01)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_ATTRIBUTE_CONTENT_01");

                entity.Property(e => e.FooterBg)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_BG");

                entity.Property(e => e.FooterTitleAttribute01)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_TITLE_ATTRIBUTE_01");

                entity.Property(e => e.FooterTitleAttribute02)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_TITLE_ATTRIBUTE_02");

                entity.Property(e => e.FooterTitleAttribute03)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_TITLE_ATTRIBUTE_03");

                entity.Property(e => e.FooterTitleAttribute04)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_TITLE_ATTRIBUTE_04");

                entity.Property(e => e.FooterTitleAttribute05)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FOOTER_TITLE_ATTRIBUTE_05");

                entity.Property(e => e.HomeBackgroundImage)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOME_BACKGROUND_IMAGE");

                entity.Property(e => e.HomeButton)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOME_BUTTON");

                entity.Property(e => e.HomeContent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOME_CONTENT");

                entity.Property(e => e.HomeGreet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOME_GREET");

                entity.Property(e => e.HomeTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HOME_TITLE");

                entity.Property(e => e.LoginBackgroundImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN_BACKGROUND_IMAGE");

                entity.Property(e => e.LogoPath)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_PATH");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.RegisterBackgroundImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTER_BACKGROUND_IMAGE");

                entity.Property(e => e.StatisticsButton)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATISTICS_BUTTON");

                entity.Property(e => e.StatisticsSubtitle)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("STATISTICS_SUBTITLE");

                entity.Property(e => e.StatisticsTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATISTICS_TITLE");

                entity.Property(e => e.TestimonialBackgroundImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIAL_BACKGROUND_IMAGE");

                entity.Property(e => e.TestimonialContent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIAL_CONTENT");

                entity.Property(e => e.TestimonialTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIAL_TITLE");

                entity.Property(e => e.WebsiteCreationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("WEBSITE_CREATION_DATE");

                entity.Property(e => e.WebsiteEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_EMAIL");

                entity.Property(e => e.WebsiteName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_NAME");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("SERVICE");

                entity.HasIndex(e => e.Title, "SYS_C00191379")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnType("LONG")
                    .HasColumnName("ICON");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.HasIndex(e => e.AccountId, "SYS_C00190741")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.PublishDate)
                    .HasPrecision(6)
                    .HasColumnName("PUBLISH_DATE");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Testimonial)
                    .HasForeignKey<Testimonial>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ACCOUNT_TO_TESTIMONIAL_FK");
            });

            modelBuilder.HasSequence("DEPARTMENT_2_SEQUENCE");

            modelBuilder.HasSequence("DEPARTMENT_SEQUENCE");

            modelBuilder.HasSequence("SEQ");

            modelBuilder.HasSequence("SEQ_EMP_ADMIN");

            modelBuilder.HasSequence("SUPPLIER_SEQ");

            modelBuilder.HasSequence("SUPPLIER_SEQ1").IncrementsBy(10);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Health_Care_V1._2.Models.AppointemtJoin> AppointemtJoin { get; set; }
    }
}
