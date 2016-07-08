using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FanglisteLibrary;

namespace Fangliste_2016
{
    public partial class Frm_NeuerFotoOrdner : Form
    {
        public Frm_NeuerFotoOrdner()
        {
            InitializeComponent();
        }

        private void Frm_NeuerFotoOrdner_Load(object sender, EventArgs e)
        {

        }

        private void btn_neu_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (!SQLCollection.OrdnerExist(textBox1.Text))
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = SQLCollection.GetConnectionString();

                    try
                    {
                        con.Open();
                        SqlCommand insertCommand = new SqlCommand(
                    "Insert into Ordner (Name) Values ('" + textBox1.Text + "')", con);
                        int queryResult = insertCommand.ExecuteNonQuery();
                        if (queryResult == 1)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            //Console.WriteLine("Erfolgreich aktualisiert.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to connect to data source" + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Es existiert bereits ein Ordner mit dem selben Namen '{0}'.\nBitte versuchen Sie einen anderen Namen.", textBox1.Text), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
