namespace Final.Models.Entity
{
    public class HomeToProperty:BaseEntity
    {
        public int HomeInfoId { get; set; }
        public virtual HomeInfo HomeInfo { get; set; }

        public int HomePropertyId { get; set; }
        public virtual HomeProperty HomeProperty { get; set; }
    }
}