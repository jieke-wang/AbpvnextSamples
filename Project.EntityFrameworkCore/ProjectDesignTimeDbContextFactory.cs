using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Project.EntityFrameworkCore {
    public class ProjectDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext> {
        public ProjectDbContext CreateDbContext (string[] args) {
            DbContextOptionsBuilder<ProjectDbContext> builder = new ();
            builder.UseMySql ("Server=192.168.199.133;port=3306;database=project;uid=projectuser;pwd=projectpwd;", MySqlServerVersion.LatestSupportedServerVersion);
            return new ProjectDbContext (builder.Options);
        }
    }
}