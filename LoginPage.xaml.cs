using System;

namespace SistemaCalificaciones
{
    public partial class LoginPage : ContentPage
    {
        // 2 vectores solicitados
        private readonly string[] usuarios = { "Carlos", "Ana", "Jose" };
        private readonly string[] passwords = { "carlos123", "ana123", "jose123" };

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnIngresarClicked(object? sender, EventArgs e)
        {
            string username = txtUsuario.Text?.Trim() ?? "";
            string password = txtPassword.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Por favor, ingrese sus credenciales.", "OK");
                return;
            }

            bool accesoConcedido = false;
            string usuarioValidado = "";

            // Validar recorriendo los vectores
            for (int i = 0; i < usuarios.Length; i++)
            {
                if (usuarios[i].Equals(username, StringComparison.OrdinalIgnoreCase) && passwords[i] == password)
                {
                    accesoConcedido = true;
                    usuarioValidado = usuarios[i]; // Mantiene la mayúscula original
                    break;
                }
            }

            if (accesoConcedido)
            {
                // Si el login es correcto, navegamos a la pantalla principal
                await Navigation.PushAsync(new MainPage(usuarioValidado));
            }
            else
            {
                await DisplayAlert("Acceso Denegado", "Usuario o contraseña incorrectos.", "OK");
            }
        }
    }
}
