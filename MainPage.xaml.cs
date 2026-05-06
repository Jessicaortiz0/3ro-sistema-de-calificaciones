using System;

namespace SistemaCalificaciones
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalcularClicked(object? sender, EventArgs e)
        {
            // Validaciones Estudiante
            if (pckEstudiante.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Por favor, seleccione un estudiante.", "OK");
                return;
            }

            string nombre = pckEstudiante.SelectedItem?.ToString() ?? "Desconocido";
            string fecha = $"{dtpFecha.Date:dd/MM/yyyy}";

            // Validaciones e ingreso de datos Parcial 1
            if (!double.TryParse(txtSeguimiento1.Text, out double seguimiento1) || seguimiento1 < 0 || seguimiento1 > 10)
            {
                await DisplayAlert("Error", "La Nota de Seguimiento 1 debe ser un valor numérico entre 0 y 10.", "OK");
                return;
            }

            if (!double.TryParse(txtExamen1.Text, out double examen1) || examen1 < 0 || examen1 > 10)
            {
                await DisplayAlert("Error", "La Nota del Examen 1 debe ser un valor numérico entre 0 y 10.", "OK");
                return;
            }

            // Validaciones e ingreso de datos Parcial 2
            if (!double.TryParse(txtSeguimiento2.Text, out double seguimiento2) || seguimiento2 < 0 || seguimiento2 > 10)
            {
                await DisplayAlert("Error", "La Nota de Seguimiento 2 debe ser un valor numérico entre 0 y 10.", "OK");
                return;
            }

            if (!double.TryParse(txtExamen2.Text, out double examen2) || examen2 < 0 || examen2 > 10)
            {
                await DisplayAlert("Error", "La Nota del Examen 2 debe ser un valor numérico entre 0 y 10.", "OK");
                return;
            }

            // Cálculos
            double notaParcial1 = (seguimiento1 * 0.3) + (examen1 * 0.2);
            double notaParcial2 = (seguimiento2 * 0.3) + (examen2 * 0.2);
            double notaFinal = notaParcial1 + notaParcial2;

            string estado = "";
            if (notaFinal >= 7)
            {
                estado = "Aprobado";
            }
            else if (notaFinal >= 5 && notaFinal < 7) 
            {
                estado = "Complementario";
            }
            else
            {
                estado = "REPROBADO";
            }

            // Imprimir Display Alert
            string mensaje = $"Nombre: {nombre}\n" +
                             $"Fecha: {fecha}\n" +
                             $"Nota Parcial 1: {notaParcial1:F2}\n" +
                             $"Nota Parcial 2: {notaParcial2:F2}\n" +
                             $"Nota Final: {notaFinal:F2}\n" +
                             $"Estado: {estado}";

            await DisplayAlert("Resultado", mensaje, "OK");
        }

        private void OnLimpiarClicked(object? sender, EventArgs e)
        {
            pckEstudiante.SelectedIndex = -1;
            dtpFecha.Date = DateTime.Today;
            
            txtSeguimiento1.Text = string.Empty;
            txtExamen1.Text = string.Empty;
            
            txtSeguimiento2.Text = string.Empty;
            txtExamen2.Text = string.Empty;
        }
    }
}
