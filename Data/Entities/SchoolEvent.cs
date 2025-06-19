namespace SchoolManagement.Data.Entities
{
    public class SchoolEvent : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string EventType { get; set; }
        public int? ClassId { get; set; }
        public Class Class { get; set; }
    }
}
