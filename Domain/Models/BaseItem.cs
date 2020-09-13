namespace Domain.Models
{
    public class BaseItem : BaseModel
    {
        public int? LabelId { get; set; }
        public int? UserId { get; set; }
    }
}
