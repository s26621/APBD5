using System.ComponentModel.DataAnnotations;

namespace zadanie.Models;

public class Visit
{
    [Required]
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    [Required]
    public double Price { get; set; }

    public Visit(DateTime date, string? description, double price)
    {
        Date = date;
        Description = description;
        Price = price;
    }
}