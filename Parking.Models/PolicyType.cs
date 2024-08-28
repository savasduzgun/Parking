namespace Parking.Models
{
    public class PolicyType : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
