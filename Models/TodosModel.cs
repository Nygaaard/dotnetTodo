using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetTodo.Models;

//Model för en Todo
public class TodoModel
{
    //Properties
    [Required(ErrorMessage = "Ange en korrekt titel...")] // Ändrar error-meddelande
    [MinLength(3, ErrorMessage = "Titeln måste vara minst 3 tecken...")] //Minst 3 tecken
    [Display(Name = "Titel:")] //Rendera Titel
    public required string Title { get; set; }
    [Required(ErrorMessage = "Ange en korrekt beskrivning...")] // Ändrar error-meddelande
    [MinLength(5, ErrorMessage = "Beskrivningen måste vara minst 5 tecken...")] //Minst 5 tecken
    [Display(Name = "Beskrivning:")] //Rendera Beskrivning
    public required string Description { get; set; }
    [Required(ErrorMessage = "Ange korrekt status")] // Ändrar error-meddelande
    [Display(Name = "Status:")] //Rendera Status
    public required string Status { get; set; }
}