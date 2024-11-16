using System;
using System.ComponentModel;
using Avalonia.Controls;
using DIAEFACLIENT.Utils;

namespace DIAEFACLIENT.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //Data conterxto ya lo hace el app
    }
    //Con el singleton matamos el resto
    protected override void OnClosed(EventArgs e)
    {
        // Cerrar todas las vistas activas al cerrar la ventana principal
        VistaSingleton.CerrarVistas();
    }
}