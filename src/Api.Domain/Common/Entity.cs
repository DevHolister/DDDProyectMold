namespace Api.Domain.Common;

public abstract class Entity
{
    public bool Visible { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Guid ModifiedBy { get; set; }
    public bool SpecifyCreatedBy { get; set; }

    protected Entity()
    {
        Visible = true;
    }

    public void SoftRemove()
    {
        Visible = false;
    }
}
