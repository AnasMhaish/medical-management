public readonly record struct PatientId(Guid value)
{
    public override string ToString() => value.ToString();
}

public class Patient
{
    public PatientId Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Archived { get; set; }
}