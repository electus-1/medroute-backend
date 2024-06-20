namespace MedRouter.Core.Entities;

public class BaseEntity
{
    public virtual int Id { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateUpdated { get; set; }
    public string? CreatedBy { get; set; }
    public string? LastModifiedBy { get; set; }
}