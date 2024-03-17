using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace project.BL.Models
{
    public abstract record ModelBase : INotifyPropertyChanged, IModel
    {
        public Guid Id { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        //TODO: Idk, jestli to zde bude, protože se nepoužívá, ale bylo to v kuchařce
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
