using System;
using System.ComponentModel.DataAnnotations;

namespace wydarzenia.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa wydarzenia jest wymagana.")]
        public string Name { get; set; }

        [Display(Name = "Data wydarzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Data wydarzenia jest wymagana.")]
        public DateTime Date { get; set; }

        [Display(Name = "Liczba dostępnych miejsc")]
        [Range(0, int.MaxValue, ErrorMessage = "Liczba dostępnych miejsc musi być liczbą nieujemną.")]
        public int AvailableSeats { get; set; }

        [Display(Name = "Opis wydarzenia")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool AreSeatsAvailable(int requestedSeats)
        {
            return requestedSeats <= AvailableSeats;
        }

        public bool ReserveSeats(int requestedSeats)
        {
            if (AreSeatsAvailable(requestedSeats))
            {
                AvailableSeats -= requestedSeats;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
