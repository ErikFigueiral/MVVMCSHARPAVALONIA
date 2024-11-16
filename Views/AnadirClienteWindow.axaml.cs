using Avalonia.Controls;
using DIAEFACLIENT.ViewModels;

namespace DIAEFACLIENT.Views;

public partial class AnadirClienteWindow : Window
{
    public AnadirClienteWindow()
    {
        InitializeComponent();
        DataContext = new AnadirClienteViewModel();
    }
}