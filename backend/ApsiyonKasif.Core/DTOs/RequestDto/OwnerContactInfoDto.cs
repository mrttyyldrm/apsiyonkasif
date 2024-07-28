namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record OwnerContactInfoDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Image { get; set; }
        public bool IsOwner { get; set; }
    }
}
