namespace AdminRole.Dtos
{
    public class AdminDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
