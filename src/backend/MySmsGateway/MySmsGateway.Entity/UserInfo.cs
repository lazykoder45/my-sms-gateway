namespace MySmsGateway.Entity
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public bool IsEmailVerified { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid PasswordResetToken { get; set; }
        public Guid VerificationToken { get; set; }
        public DateTime? PasswordResetTokenExpiry { get; set; }
        public DateTime? VerificationTokenExpiry { get; set; }
    }
}
