using System.ComponentModel.DataAnnotations;

namespace zadanie.Models;

public class Animal
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public double Weight { get; set; }
    [Required]
    public string FurColor { get; set; }
    
    public List<Visit> Visits { get; set; }
    
    public Animal(int id, string name, string category, double weight, string furColor)
    {
        Id = id;
        Name = name;
        Category = category;
        Weight = weight;
        FurColor = furColor;
        Visits = new List<Visit>();
    }

    public Animal(int id, string name, string category, double weight, string furColor, List<Visit> visits)
    {
        Id = id;
        Name = name;
        Category = category;
        Weight = weight;
        FurColor = furColor;
        Visits = visits;
    }
}