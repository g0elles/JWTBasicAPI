namespace BasicAPI.DTOs;

public class WorkerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string Surname { get; set; }

    public string? SecondSurname { get; set; }

    public string Country { get; set; }

    public string IdentificationType { get; set; }

    public string Identification { get; set; }

    public string Email { get; set; }

    public string Area { get; set; }

    public bool Status { get; set; }

    public DateTime? RegistryDate { get; set; }
}