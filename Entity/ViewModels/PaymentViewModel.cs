using System.ComponentModel.DataAnnotations;

public class PaymentViewModel
{
    public int ReservationId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string Phone { get; set; }

    [Required]
    public string CardHolderName { get; set; }

    [Required]
    [CreditCard]
    public string CardNumber { get; set; }

    [Required]
    public string ExpirationDate { get; set; }

    [Required]
    public string CVV { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string TCKimlikNo { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public string PaymentMethod { get; set; }
}
