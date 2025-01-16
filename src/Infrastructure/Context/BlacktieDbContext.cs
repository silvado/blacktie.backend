using Domain.Entities.Abstracts;
using Domain.Enums;
using Domain.Interfaces.Helpers;
using Domain.Models;
using Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Context
{
    public partial class BlacktieDbContext : DbContext
    {
        private readonly IUserClaimsHelper? _userClaimsHelper;
        public BlacktieDbContext(DbContextOptions<BlacktieDbContext> options) : base(options)
        {
        }
        public BlacktieDbContext(DbContextOptions<BlacktieDbContext> options, IUserClaimsHelper userClaimsHelper) : base(options)
        {
            _userClaimsHelper = userClaimsHelper;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("blacktie");
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CustomerAddressMap());            
            modelBuilder.ApplyConfiguration(new UserMap());            
            modelBuilder.ApplyConfiguration(new ControlMap());            
            modelBuilder.ApplyConfiguration(new TransportMap());            
            modelBuilder.ApplyConfiguration(new TransportVariationMap());            
            modelBuilder.ApplyConfiguration(new CountryMap());            
            modelBuilder.ApplyConfiguration(new DocumentTypeMap());     
            modelBuilder.ApplyConfiguration(new FromToMap());     
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new PaymentTypeMap());
            modelBuilder.ApplyConfiguration(new ProductPricingMap());
            modelBuilder.ApplyConfiguration(new UnavailableDateMap());
        }

        public async Task<int> SaveChangesAsync()
        {
            var _currentUser = _userClaimsHelper!.GetUserFromClaims();

            foreach (var entry in ChangeTracker.Entries<Entity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedByUserId = (_currentUser?.CodUsu != null) ? _currentUser.CodUsu.ToString() : "sistema_blacktie";
                        break;

                    case EntityState.Modified:
                        if (entry.Entity.IsDeleted)
                        {
                            entry.Entity.DeleteAt = DateTime.Now;
                            entry.Entity.DeletedByUserId = (_currentUser?.CodUsu != null) ? _currentUser.CodUsu.ToString() : "sistema_blacktie";
                        }
                        else
                        {
                            entry.Entity.UpdateAt = DateTime.Now;
                            entry.Entity.UpdatedByUserId = (_currentUser?.CodUsu != null) ? _currentUser.CodUsu.ToString() : "sistema_blacktie";
                        }
                        break;
                }
            }
            //await AuditLogging(_currentUser);

            return await base.SaveChangesAsync();
        }

        private async Task AuditLogging(UserSegWeb? currentUser)
        {

            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Domain.Models.Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                {
                    continue;
                }

                var auditEntry = new AuditEntry(entry)
                {
                    TableName = entry.Entity.GetType().Name,
                    UserId = (currentUser?.CodUsu != null) ? currentUser.CodUsu.ToString() : "sistema_blacktie",
                    UserName = (currentUser?.Nome != null) ? currentUser.Nome.ToString() : "sistema_blacktie",
                };

                auditEntries.Add(auditEntry);
                bool isSoftDeleted = entry.Properties.Any(p => p.Metadata.Name == "IsDeleted" && (bool)p.CurrentValue!);

                foreach (var property in entry.Properties)
                {
                    var propertyName = property.Metadata.Name;

                    if (property.Metadata.IsPrimaryKey())
                    {
                        HandlePrimaryKey(auditEntry, property, entry, propertyName);
                        continue;
                    }

                    if (isSoftDeleted && !Equals(property.OriginalValue, property.CurrentValue))
                    {
                        auditEntry.AuditType = AuditType.Delete;
                        auditEntry.ChangedColumns.Add(propertyName);
                        auditEntry.OldValues[propertyName] = property.OriginalValue!;
                        auditEntry.NewValues[propertyName] = property.CurrentValue!;
                    }
                    else
                    {
                        switch (entry.State)
                        {
                            case EntityState.Modified:
                                if (property.IsModified && !Equals(property.OriginalValue, property.CurrentValue))
                                {
                                    auditEntry.ChangedColumns.Add(propertyName);
                                    auditEntry.AuditType = AuditType.Update;
                                    auditEntry.OldValues[propertyName] = property.OriginalValue!;
                                    auditEntry.NewValues[propertyName] = property.CurrentValue!;
                                }
                                break;
                            case EntityState.Added:
                                auditEntry.AuditType = AuditType.Create;
                                auditEntry.NewValues[propertyName] = property.CurrentValue!;
                                break;
                            case EntityState.Deleted:
                                auditEntry.AuditType = AuditType.Delete;
                                auditEntry.OldValues[propertyName] = property.OriginalValue!;
                                break;
                            default:
                                break;
                        }
                    }

                }


            }
            foreach (var auditEntry in auditEntries)
            {
                await Audits!.AddAsync(auditEntry.ToAudit());
            }
        }

        private void HandlePrimaryKey(AuditEntry auditEntry, PropertyEntry property, EntityEntry entry, string propertyName)
        {
            if (entry.State.Equals(EntityState.Added))
            {
                if (property.CurrentValue is int)
                {
                    auditEntry.KeyValues[propertyName] = 0;
                }
                else if (property.CurrentValue is Guid)
                {
                    auditEntry.KeyValues[propertyName] = property.CurrentValue!.ToString()!;
                }
                else
                {
                    auditEntry.KeyValues[propertyName] = property.CurrentValue ?? "0";
                }
                auditEntry.AuditType = AuditType.Create;
            }
            else
            {
                auditEntry.KeyValues[propertyName] = property.CurrentValue!;
                auditEntry.AuditType = entry.State.Equals(EntityState.Deleted) ? AuditType.Delete : AuditType.Update;

            }
        }
    }
}
