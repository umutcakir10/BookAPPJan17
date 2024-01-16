using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookAPP.Models
{
    public partial class Book : ObservableObject
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;

        public double Amount => CartQuantity * Price;

        public Book Clone() => MemberwiseClone() as Book;
    }
}