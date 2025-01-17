﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProductiviesApp.ViewModels;

//I'm going to be real and say that I copied this and don't fully understand how the code works
//It is needed if you want the stuff in ViewModel to be updated in real time tho so here we are
//-Lilith
public class ViewModelBase : INotifyPropertyChanged
{
    /// <summary>
    /// Multicast event for property change notifications.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Checks if a property already matches the desired value.  Sets the property and
    /// notifies listeners only when necessary.
    /// </summary>
    /// <typeparam name="T">Type of the property.</typeparam>
    /// <param name="storage">Reference to a property with both getter and setter.</param>
    /// <param name="value">Desired value for the property.</param>
    /// <param name="propertyName">Name of the property used to notify listeners.This
    /// value is optional and can be provided automatically when invoked from compilers that
    /// support CallerMemberName.</param>
    /// <returns>True if the value was changed, false if the existing value matched the
    /// desired value.</returns>
    protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(storage, value))
        {
            return false;
        }

        storage = value;
        // Log.DebugFormat("{0}.{1} = {2}", this.GetType().Name, propertyName, storage);
        OnPropertyChanged(propertyName);
        return true;
    }

    /// <summary>
    /// Notifies listeners that a property value has changed.
    /// </summary>
    /// <param name="propertyName">Name of the property used to notify listeners.  This
    /// value is optional and can be provided automatically when invoked from compilers
    /// that support <see cref="CallerMemberNameAttribute"/>.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
