public readonly record struct MedicineId(Guid value)
{
    public override string ToString() => value.ToString();
}

public class Medicine
{
    public MedicineId Id { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public decimal Price { get; set; }
    public DateTime ExpiryDate { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Archived { get; set; }
}

