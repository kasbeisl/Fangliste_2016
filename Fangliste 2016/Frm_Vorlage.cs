using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Data.SqlClient;

namespace Fangliste_2016
{
    public partial class Frm_Vorlage : Form
    {
        #region Variablen

        public enum Selection
        {
            Angelplatzbeschreibung,
            Köderbeschreibung
        }

        Selection selected;
        string selectedText;
        string gewässer = "";

        #endregion

        #region Konstruktor

        public Frm_Vorlage(Selection selected)
        {
            InitializeComponent();

            this.selected = selected;
            this.selectedText = "";
        }

        public Frm_Vorlage(Selection selected, string gewässer)
        {
            InitializeComponent();

            this.selected = selected;
            this.selectedText = "";
            this.gewässer = gewässer;
        }

        private void Frm_Vorlage_Load(object sender, EventArgs e)
        {
            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;

            switch (selected)
            {
                case Selection.Angelplatzbeschreibung:

                    try
                    {

                        string strSQL = "SELECT Angelplatz " +
                                        "FROM Fang";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            
                            try
                            {
                                if (reader["Angelplatz"].ToString() != "")
                                {
                                    if (!listBox1.Items.Contains(reader["Angelplatz"]))
                                        listBox1.Items.Add(reader["Angelplatz"]);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        reader.Close();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }


                    /*for (int i = 0; i < this.fangliste.Count; i++)
                    {
                        if (gewässer == "")
                        {
                            if (!listBox1.Items.Contains(this.fangliste[i].Platzbesch))
                                listBox1.Items.Add(this.fangliste[i].Platzbesch);
                        }
                        else
                        {
                            if (this.fangliste[i].Gewässer == gewässer)
                            {
                                if (!listBox1.Items.Contains(this.fangliste[i].Platzbesch))
                                    listBox1.Items.Add(this.fangliste[i].Platzbesch);
                            }
                        }
                    }*/
                    break;
                case Selection.Köderbeschreibung:

                    try
                    {

                        string strSQL = "SELECT Köder " +
                                        "FROM Fang";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            try
                            {
                                if (reader["Köder"].ToString() != "")
                                {
                                    if (!listBox1.Items.Contains(reader["Köder"]))
                                        listBox1.Items.Add(reader["Köder"]);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        reader.Close();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }


                    /*for (int i = 0; i < this.fangliste.Count; i++)
                    {
                        if (!listBox1.Items.Contains(this.fangliste[i].Köderbeschr))
                            listBox1.Items.Add(this.fangliste[i].Köderbeschr);
                    }*/
                    break;
            }
        }

        #endregion

        #region Eigenschaften

        /// <summary>
        /// 
        /// </summary>
        public string GetSelectedText
        {
            get { return this.selectedText; }
        }

        #endregion

        #region Events

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                this.selectedText = listBox1.SelectedItem.ToString();

                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        #endregion

        #region Methoden

        #endregion
    }
}
