using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;


//TODO temporary implementation of ViewModelBase, will have add messages like in cockmagasine
namespace project.App.ViewModels;


public abstract class ViewModelBase : ObservableObject//INotifyPropertyChanged
{
    //public event PropertyChangedEventHandler? PropertyChanged;
    //protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
    //}

    private bool _isRefreshRequired = true;

    public async Task OnAppearingAsync()
    {
        if (_isRefreshRequired)
        {
            await LoadDataAsync();

            _isRefreshRequired = false;
        }
    }

    protected virtual Task LoadDataAsync()
        => Task.CompletedTask;
}

