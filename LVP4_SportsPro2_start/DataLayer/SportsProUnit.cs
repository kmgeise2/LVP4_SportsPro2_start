
namespace LVP4_SportsPro2_start.Models
{
    public class SportsProUnit : ISportsProUnit
    {
        // ** Update this section **
        private SportsProContext context { get; set; }
        public SportsProUnit(SportsProContext ctx) => context = ctx;

        // Repository for Products
        
        // Repository for Technicians
        
        // Repository for Customers
        
        // Repository for Countries
        
        // Repository for Incidents
        
        // Repository for Registrations
        
        // Save using context SaveChanges
        public void Save() => context.SaveChanges();
    }
}