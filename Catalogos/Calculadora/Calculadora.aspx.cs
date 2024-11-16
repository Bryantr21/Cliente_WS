using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cliente_WS.Calculadora_Service;

namespace Cliente_WS.Catalogos.Calculadora
{
    public partial class Calculadora : System.Web.UI.Page
    {
        calculadora_ServiceSoapClient clientes_WS;
        protected void Page_Load(object sender, EventArgs e)
        {
            clientes_WS =new calculadora_ServiceSoapClient();
        }

        protected void btnsumar_Click(object sender, EventArgs e)
        {
            double a = double.Parse(txta.Text);
            double b = double.Parse(txtb.Text);

            double resultado = clientes_WS.Suma(a,b);
            lblResultado.Text = resultado.ToString();

        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            double a = double.Parse(txta.Text);
            double b = double.Parse(txtb.Text);

            double resultado = clientes_WS.Resta(a, b);
            lblResultado.Text = resultado.ToString();
        }

        protected void btnMultiplicar_Click(object sender, EventArgs e)
        {

            double a = double.Parse(txta.Text);
            double b = double.Parse(txtb.Text);

            double resultado = clientes_WS.Multiplicar(a, b);
            lblResultado.Text = resultado.ToString();
        }

        protected void btnDividir_Click(object sender, EventArgs e)
        {

            double a = double.Parse(txta.Text);
            double b = double.Parse(txtb.Text);

            double resultado = clientes_WS.Resta(a, b);
            lblResultado.Text = resultado.ToString();
        }
    }
}