namespace DriversManagement.API
{
    public class DriverFilter
    {
        public string? SearchContext { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? LicenseNumber { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }
    }
}
