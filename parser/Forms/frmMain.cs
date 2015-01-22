using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using DB;

namespace parser
{
    public partial class frmMain : Form
    {
        protected string fileName = string.Empty;
        protected int idDat = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML Files|*.xml";
            fileDialog.Title = "Select a XML File";
            fileDialog.InitialDirectory = System.Environment.CurrentDirectory;

            idDat = 0;
            GetXmlData();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = Path.GetFileName(fileDialog.FileName);
                fileName = fileDialog.FileName;
            }
            else
            {
                txtFile.Text = string.Empty;
                fileName = string.Empty;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (fileName.Length == 0) return;
            if (idDat > 0) return;

            idDat = DB.DB.InsertXmlHead(Path.GetFileName(fileName), XmlRead(fileName, Encoding.UTF8));

            if (idDat == 0) return;

            Cursor.Current = Cursors.WaitCursor;

            XmlDocument doc = new XmlDocument();
            string s = string.Empty;

            int SportID = 0;
            string Sport = string.Empty;
            int CategoryID = 0;
            string Category = string.Empty;
            int TournamentID = 0;
            string Tournament = string.Empty;
            int MatchID = 0;
            List<string> Competitors = new List<string>();

            doc.Load(fileName);

            XmlNode SportNode = doc.DocumentElement.SelectSingleNode("Sports");

            foreach (XmlNode node in SportNode)
            {
                SportID = Int32.Parse(node.Attributes["BetradarSportID"].Value);
                Sport = node.SelectSingleNode("Texts//Text[@Language='BET']").InnerText;

                XmlNodeList catnode = node.SelectNodes("Category");
                foreach (XmlNode catchild in catnode)
                {
                    CategoryID = Int32.Parse(catchild.Attributes["BetradarCategoryID"].Value);
                    Category = catchild.SelectSingleNode("Texts//Text[@Language='BET']").InnerText;

                    XmlNode TournamentNode = catchild.SelectSingleNode("Tournament");
                    TournamentID = Int32.Parse(TournamentNode.Attributes["BetradarTournamentID"].Value);
                    Tournament = TournamentNode.SelectSingleNode("Texts/Text[@Language='BET']").InnerText;

                    XmlNodeList MatchNode = catchild.SelectNodes("Tournament//Match");
                    foreach (XmlNode matchild in MatchNode)
                    {
                        MatchID = Int32.Parse(matchild.Attributes["BetradarMatchID"].Value);

                        Competitors.Clear();
                        XmlNodeList CompetitorsNode = matchild.SelectNodes("Fixture/Competitors//Texts");
                        foreach (XmlNode compchild in CompetitorsNode)
                        {
                            Competitors.Add(compchild.SelectSingleNode("Text//Text[@Language='BET']").InnerText);
                        }
                        DB.DB.InsertXmlData(idDat, SportID, Sport, CategoryID, Category, TournamentID, Tournament, MatchID, Competitors[0], Competitors[1]);
                    }
                }
            }

            Cursor.Current = Cursors.Default;

            GetXmlData();
        }

        private string XmlRead(string path, Encoding encoding)
        {
            string result;
            using (StreamReader streamReader = new StreamReader(path, encoding))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        private void GetXmlData()
        {
            dgv.DataSource = DB.DB.GetXmlData(idDat);
        }
    }
}
