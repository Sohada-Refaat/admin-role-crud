namespace AdminRole.Dtos
{
    public class UpdateAdminDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public Guid? RoleId { get; set; }
    }
}
