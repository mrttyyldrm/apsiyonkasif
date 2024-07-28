namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record AdvertInfoDto
    {
        public string AdvertNumber { get; set; }
        public string AdvertDate { get; set; }
        public string NetArea { get; set; }
        public string RoomCount { get; set; }
        public int NumberOfFloor { get; set; }
        public int BuildingAge { get; set; }
        public int BathroomCount { get; set; }
        public string AdvertType { get; set; }
        public string Floor { get; set; }
        public bool HasFurnished { get; set; }
        public string HeatingType { get; set; }
        public string IsInSite { get; set; }
    }
}
