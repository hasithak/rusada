using Data.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.DBContexts
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<User>
    {
        public DbSet<AircraftSighting> AircraftSightings { get; set; }
        public DbSet<Media> Medias { get; set; }

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }
    }
}