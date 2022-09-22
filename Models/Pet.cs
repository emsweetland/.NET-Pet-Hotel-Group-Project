using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType {
        Cat,
        Dog,
        Snake,
        Rat
    }
    public enum PetColorType {
        Black,
        White,
        Pink,
        Orange
    }
    public class Pet {
        public int id {get; set;}
        [Required]
        public string name {get; set;}
        [JsonConverter (typeof(JsonStringEnumConverter))]
        [Required]
        public PetBreedType breed {get; set;}
        [Required]
        public PetColorType color {get; set;}
        [NotMapped]
        public DateTime checkedInAt {get; set;}

[ForeignKey("petOwner")]
    [Required]
    public int petOwnerid {get; set;}
    
    public PetOwner petOwner {get; set;}
    }
}
