using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaSqlInjection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {

                Login();
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Login()
        {
            try
            {
                DataTable dt = new DataTable();
                string conectionString = "Server=localhost;Database=UnikinoDB;TrustServerCertificate=True;User ID=sa;Password=123456789";
                using (SqlConnection con = new SqlConnection(conectionString))
                {
                    //string query = "Select * from usuarios";
                    //query += " where usuario = '" + txtUsuario.Text + "'";
                    //query += " and contrasena = '" + txtContrasena.Text + "'";

                    string query = "select * from usuarios where Usuario = @usuario and contrasena = @contrasena";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                        cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(dt);

                    }
                }

                dgvDatos.DataSource = dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
