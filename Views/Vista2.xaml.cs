

namespace aburbanotll3.Views;

public partial class Vista2 : ContentPage
{
	public Vista2(string nombres, string apellidos,DateTime fecha, string correo, double salario)
	{
		InitializeComponent();

        lblNombres.Text = nombres;
        lblApellidos.Text = apellidos;
        lblFecha.Text = fecha.ToString();
        lblCorreo.Text = correo;
        lblSalario.Text = "Su salario es: $" + salario;
        double aporte = salario * 0.0945;
        lblAporte.Text = $"Aporte al IESS: {aporte:C}";
    }

    private void btnExportar_Clicked(object sender, EventArgs e)
    {

        string contenido = $"Nombres: {lblNombres.Text}\n" +
                               $"Apellidos: {lblApellidos.Text}\n" +
                               $"Fecha: {lblFecha.Text}\n" +
                               $"Correo: {lblCorreo.Text}\n" +
                               $"{lblSalario.Text}\n" +
                               $"{lblAporte.Text}";
        try
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Datos.txt");
            File.AppendAllText(ruta, contenido); 
            DisplayAlert("Éxito", "Datos guardados en archivo TXT.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }

    }
}