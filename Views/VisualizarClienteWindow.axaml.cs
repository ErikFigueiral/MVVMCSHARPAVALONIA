using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using DIAEFACLIENT.Models;
using DIAEFACLIENT.Utils;
using DIAEFACLIENT.ViewModels;

namespace DIAEFACLIENT.Views;

public partial class VisualizarClienteWindow : Window
{
    public VisualizarClienteWindow()
    {
        InitializeComponent();
        var viewModel = new VisualizarClienteViewModel();
        DataContext = viewModel;
        var actionsColumn = new DataGridTemplateColumn
        {
            Header = "Acciones",
            CellTemplate = new FuncDataTemplate<Cliente>((cliente, _) =>
            {
                var button = new Button
                {
                    Content = "Eliminar",
                    Command = viewModel.EliminarClienteCommand,
                    CommandParameter = cliente
                };
                return button;
            })
        };
        MyDataGrid.Columns.Add(actionsColumn);
        var messenger = Messenger.GetInstance;
        messenger.Register<CloseWindowMessage>(message => Close());
    }
    protected override void OnClosed(EventArgs e)
    {
        var messenger = Messenger.GetInstance;
        Console.WriteLine("CerrandoView Visualizar");
        messenger.Unregister<CloseWindowMessage>(message => Close());  // Desregistrarse
        base.OnClosed(e);
    }
}