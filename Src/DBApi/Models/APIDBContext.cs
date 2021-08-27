using Microsoft.EntityFrameworkCore;

public class APIDBContext : DbContext
{
    public APIDBContext(DbContextOptions options) : base(options)
    {
        
    }
}