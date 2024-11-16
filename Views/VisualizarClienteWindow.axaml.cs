using Avalonia.Controls;
using DIAEFACLIENT.ViewModels;

namespace DIAEFACLIENT.Views;

public partial class VisualizarClienteWindow : Window
{
    public VisualizarClienteWindow()
    {
        InitializeComponent();
        DataContext = new VisualizarClienteViewModel();
    }
}