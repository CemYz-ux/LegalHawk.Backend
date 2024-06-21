namespace LegalHawk.Backend.Models.CreateOptions;

public class LegalContractCreateOptions
{
    /// <summary>
    /// The name of the author of the contract
    /// </summary>
    /// <example>Mr. John Doe</example>
    [Required, MaxLength(128)]
    public required string Author { get; set; }

    /// <summary>
    /// The title of the contract
    /// </summary>
    /// <example>Sale of a car</example>
    [Required, MaxLength(256)]
    public required string Title { get; set; }

    /// <summary>
    /// A short description of the legal contract
    /// </summary>
    /// <example>The contract is about the sale of a car, the car is a 2020 model and has a mileage of 1000km, the car is in good condition.</example>
    [MaxLength(512)]
    public string? Description { get; set; }
}
