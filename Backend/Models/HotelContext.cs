using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelBackend.Models;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<Huespede> Huespedes { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TiposHabitacion> TiposHabitacions { get; set; }
    public virtual DbSet<ContactoServicio> ContactosServicios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__empleado__88B51394BCA0203E");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.Usuario, "UQ__empleado__9AFF8FC6B217E441").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__empleados__id_ro__3A81B327");
        });

        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__habitaci__773F28F33F31E3B2");

            entity.ToTable("habitaciones");

            entity.HasIndex(e => e.NumeroHabitacion, "UQ__habitaci__DC3F4DB414D77B95").IsUnique();

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.NumeroHabitacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numero_habitacion");
            entity.Property(e => e.Piso).HasColumnName("piso");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__habitacio__id_ti__4316F928");
        });

        modelBuilder.Entity<Huespede>(entity =>
        {
            entity.HasKey(e => e.IdHuesped).HasName("PK__huespede__55CED1052431E45A");

            entity.ToTable("huespedes");

            entity.HasIndex(e => e.DocumentoIdentidad, "UQ__huespede__1A03B13F1ED52CA1").IsUnique();

            entity.Property(e => e.IdHuesped).HasColumnName("id_huesped");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.DocumentoIdentidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documento_identidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__reservas__423CBE5D60F5F526");

            entity.ToTable("reservas");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.CantidadPersonas).HasColumnName("cantidad_personas");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaHoraCheckin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora_checkin");
            entity.Property(e => e.FechaHoraCheckout)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora_checkout");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaSalida).HasColumnName("fecha_salida");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.IdHuesped).HasColumnName("id_huesped");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__reservas__id_hab__47DBAE45");

            entity.HasOne(d => d.IdHuespedNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHuesped)
                .HasConstraintName("FK__reservas__id_hue__46E78A0C");
        });
        modelBuilder.Entity<ContactoServicio>(entity =>
        {
            entity.HasKey(e => e.IdContacto);
            entity.ToTable("contactos_servicio");
            entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
            entity.Property(e => e.NombreServicio).HasMaxLength(100).HasColumnName("nombre_servicio");
            entity.Property(e => e.Encargado).HasMaxLength(100).HasColumnName("encargado");
            entity.Property(e => e.Telefono).HasMaxLength(20).HasColumnName("telefono");
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__6ABCB5E0C0493C41");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<TiposHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__tipos_ha__CF901089FFE6CA8F");

            entity.ToTable("tipos_habitacion");

            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.CapacidadMaxima).HasColumnName("capacidad_maxima");
            entity.Property(e => e.Denominacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("denominacion");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
