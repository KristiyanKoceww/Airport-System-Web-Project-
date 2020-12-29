namespace AirportSystem.Data
{
    using System.ComponentModel.DataAnnotations;

    public enum LuggageType
    {
        [Display(Name = "Carry On Bag")]
        CarryOnBag = 1,
        [Display(Name = "Trolley Bag")]
        TrolleyBag = 2,
        [Display(Name = "Checked In Bag")]
        CheckedInBag = 3,
    }
}
