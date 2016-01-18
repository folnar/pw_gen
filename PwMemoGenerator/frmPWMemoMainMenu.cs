using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;

namespace PwMemoGenerator
{
    public partial class frmPWMemoMainMenu : Form
    {
        public frmPWMemoMainMenu()
        {
            InitializeComponent();
        }

        Microsoft.Office.Interop.Word.Application app;
        Document doc;
        object missing = Type.Missing;
            
        private void btnGenerateNewPWs_Click(object sender, EventArgs e)
        {
            //killprocess("winword");
            app = new Microsoft.Office.Interop.Word.Application { Visible = false };
            
            System.Data.DataTable dt = new System.Data.DataTable();
            string qry = "SELECT * FROM ibis_pw_userlist WHERE ibis_pw_userlist_active = 1 AND ibis_pw_userlist_id > 1";
            //string qry = "SELECT * FROM ibis_pw_userlist WHERE ibis_pw_userlist_active = 1";

            Random randnum = new Random();
            int _min4 = 0;
            int _max4 = 9999;
            int _min6 = 0;
            int _max6 = 999999;

            using (MySqlConnection dbh = new MySqlConnection(Properties.Resources.DB_CONNSTR_HES))
            {
                dbh.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(qry, dbh))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        doc = app.Documents.Add(@"C:\Users\dc1_000\Documents\HoldenEngineering\pw_memo_template.docx");
                        doc.Activate();

                        string newpw;
                        if (row["ibis_pw_userlist_un"].ToString().Equals("dholden"))
                        {
                            newpw = String.Format("{0:000000}", randnum.Next(_min6, _max6));
                        }
                        else
                        {
                            // HERE IS WHERE ONE COULD RANDOMIZE THE PLACEMENT OF
                            // THE ABBREVIATION RELATIVE TO THE FOUR-DIGIT NUMBER

                            newpw = row["ibis_pw_userlist_abbr"].ToString() + String.Format("{0:0000}", randnum.Next(_min4, _max4));
                        }

                        doc.Bookmarks["bmNameLbl"].Range.Text = row["ibis_pw_userlist_label"].ToString();
                        doc.Bookmarks["bmGenPW"].Range.Text = newpw;
                        doc.Bookmarks["bmUserName"].Range.Text = row["ibis_pw_userlist_un"].ToString();
                        doc.Bookmarks["bmOldPW"].Range.Text = row["ibis_pw_userlist_currpw"].ToString();
                        doc.Bookmarks["bmNewPW"].Range.Text = newpw;
                        doc.Bookmarks["bmNewPW2"].Range.Text = newpw;

                        doc.PrintOut();
                        ((Microsoft.Office.Interop.Word._Document)doc).Close(false, ref missing, ref missing);

                        try
                        {
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = dbh;

                            cmd.CommandText = "UPDATE ibis_pw_userlist SET ibis_pw_userlist_currpw = @npw, ibis_pw_userlist_prevpw = @opw WHERE ibis_pw_userlist_id = @uid";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@npw", newpw);
                            cmd.Parameters.AddWithValue("@opw", row["ibis_pw_userlist_currpw"].ToString());
                            cmd.Parameters.AddWithValue("@uid", row["ibis_pw_userlist_id"].ToString());

                            cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException mysqle)
                        {
                            MessageBox.Show("mysql ERROR: " + mysqle.ToString());
                            return;
                        }
                        catch (Exception m1ex)
                        {
                            MessageBox.Show("M1_ERROR: " + m1ex.ToString());
                            return;
                        }
                    }
                }
                dbh.Close();
            }
        }

        private void btnCloseAndExit_Click(object sender, EventArgs e)
        {
            ((Microsoft.Office.Interop.Word._Application)app).Quit(false, ref missing, ref missing);
            System.Windows.Forms.Application.Exit();
        }

        private void btnPrintPWMemos_Click(object sender, EventArgs e)
        {
            app = new Microsoft.Office.Interop.Word.Application { Visible = false };

            System.Data.DataTable dt = new System.Data.DataTable();
            string qry = "SELECT * FROM ibis_pw_userlist WHERE ibis_pw_userlist_active = 1";

            using (MySqlConnection dbh = new MySqlConnection(Properties.Resources.DB_CONNSTR_HES))
            {
                dbh.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(qry, dbh))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        doc = app.Documents.Add(@"C:\Users\dc1_000\Documents\HoldenEngineering\pw_memo_template.docx");
                        doc.Activate();

                        doc.Bookmarks["bmNameLbl"].Range.Text = row["ibis_pw_userlist_label"].ToString();
                        doc.Bookmarks["bmGenPW"].Range.Text = row["ibis_pw_userlist_currpw"].ToString();
                        doc.Bookmarks["bmUserName"].Range.Text = row["ibis_pw_userlist_un"].ToString();
                        doc.Bookmarks["bmOldPW"].Range.Text = row["ibis_pw_userlist_prevpw"].ToString();
                        doc.Bookmarks["bmNewPW"].Range.Text = row["ibis_pw_userlist_currpw"].ToString();
                        doc.Bookmarks["bmNewPW2"].Range.Text = row["ibis_pw_userlist_currpw"].ToString();

                        doc.PrintOut();
                        ((Microsoft.Office.Interop.Word._Document)doc).Close(false, ref missing, ref missing);
                    }
                }
                dbh.Close();
            }

        }
    }
}
