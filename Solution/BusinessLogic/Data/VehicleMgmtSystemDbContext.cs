using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data;

public class VehicleMgmtSystemDbContext(DbContextOptions options) : DataAccess.Data.AppDbContext(options)
{
}
