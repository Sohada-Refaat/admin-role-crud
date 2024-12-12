namespace AdminRole.Dtos
{
    public class CreateAdminDto
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public Guid? RoleId { get; set; }
    }
}
