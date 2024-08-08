public readonly record struct ReceiptId(Guid value)
{
    public override string ToString() => value.ToString();
}

public class Receipt
{
    public ReceiptId Id { get; set; }
    public DateTime Date { get; set; }
    public PatientId PatientId { get; set; }
    public Patient Patient { get; private set; } = null!;
    public DoctorId DoctorId { get; set; }
    public Doctor Doctor { get; private set; } = null!;
    public ICollection<Medicine> Medicines { get; set; }
    public decimal Total { get; set; }
}
