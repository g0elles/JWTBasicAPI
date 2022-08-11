using System;
using System.ComponentModel.DataAnnotations;

namespace BasicAPI.Models.Requests;

public class CreateWorkerRequest
{

    [Required, MaxLength(20)]
    public string FirstName { get; set; }

    [MaxLength(20)]
    public string MiddleName { get; set; }

    [Required, MaxLength(20)]
    public string Surname { get; set; }

    [MaxLength(20)]
    public string SecondSurname { get; set; }

    [Required, MaxLength(150)]
    public string Country { get; set; }

    [Required, MaxLength(20)]
    public string IdentificationType { get; set; }

    [Required, MaxLength(20)]
    public string Identification { get; set; }

    [Required, MaxLength(300)]
    public string Email { get; set; }

    [Required, MaxLength(50)]
    public string Area { get; set; }

    [Required]
    public bool Status { get; set; }

    public DateTime RegistryDate { get; set; }

}