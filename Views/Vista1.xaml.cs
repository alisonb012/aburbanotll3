using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aburbanotll3.Views;

public partial class Vista1 : ContentPage
{
	public Vista1()
	{
		InitializeComponent();
	}

    private async void btnCalcular_Clicked(object sender, EventArgs e)
	{
		string identificacion = pkIdentidad.SelectedIndex.ToString();
		string identificaciont = txtIdentidad.Text;
		string nombres = txtNombres.Text;
		string apellidos = txtApellidos.Text;
		string correo = txtCorreo.Text;
		string correoconf = txtCorreoConf.Text;
		string salario = txtSalario.Text;


            if (string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(correo)
                || string.IsNullOrEmpty(correoconf) || string.IsNullOrEmpty(salario) || string.IsNullOrEmpty(identificaciont))
            {
                  await DisplayAlert("Error", " Complete todos los campos", "OK");
                return;
            }

            if (pkIdentidad.SelectedIndex == 0)
            {
                if (!Regex.IsMatch(identificaciont, @"^\d{10}$"))
                {
                    lblIdentidad.Text = "La cedula debe tener exactamente 10 dígitos";

                }
            }
            else if (pkIdentidad.SelectedIndex == 1)
            {
                if (!Regex.IsMatch(identificaciont, @"^\d{13}$"))
                {
                    lblIdentidad.Text = "El RUC debe tener exactamente 13 dígitos";

                }

            }
            else if (pkIdentidad.SelectedIndex == 2)
            {
                if (identificaciont == null)
                {
                    lblIdentidad.Text = "Por favor ingrese el pasaporte";
                }
            }
            else
            {
                lblIdentidad.Text = "Por favor elija una opcion";

            }

            if (!Regex.IsMatch(nombres ?? "", @"[a-zA-Z]\s") || !Regex.IsMatch(apellidos ?? "", @"[a-zA-Z]\s"))
            {
                lblLetras.Text = "Por favor ingrese solo letras";
            }

            if (correo != correoconf)
            {
                lblCorreos.Text = "Los correos no coinciden";
                return;
            }

            if (!double.TryParse(salario, out double salarios) || salarios <= 0)
            {
                lblSalario.Text = "Ingrese un salario válido";
                return;
            }

        await Navigation.PushAsync( new Vista2(nombres, apellidos,  correo, salarios));

    }

}