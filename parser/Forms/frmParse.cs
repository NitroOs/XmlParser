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

namespace Parser.Forms
{
    public partial class frmParse : Form
    {
        protected string fileName = string.Empty;
        protected string filePath = string.Empty;
        protected byte[] xmlFile = null;
        protected int idDat = 0;
        protected string CRC = string.Empty;
        //protected ValidationEventHandler veh;

        public frmParse()
        {
            InitializeComponent();

            //veh = ValidationEventHandler;
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
                filePath = fileDialog.FileName;
                fileName = Path.GetFileName(filePath);
                txtFile.Text = fileName;
                xmlFile = System.IO.File.ReadAllBytes(filePath);
                CRC = FN.FN.GetCRC(ref xmlFile);
            }
            else
            {
                filePath = string.Empty;
                fileName = string.Empty;
                txtFile.Text = string.Empty;
                xmlFile = null;
                CRC = string.Empty;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            int err = 0;

            if (xmlFile == null) return;
            if (idDat > 0) return;

            idDat = DB.InsertXmlHead(fileName, CRC, ref err);

            switch (err)
            {
                case 0: // Sve OK
                    break;
                case 1: // Datoteka s tim nazivom već postoji
                    MessageBox.Show("Datoteka s tim nazivom već postoji");
                    return;
                case 2: // Datoteka s tim CRC-om već postoji
                    MessageBox.Show("Datoteka s tim CRC-om već postoji");
                    return;
            }

            //FN.FN.XmlValidate(fileName, "D:\\Moji Dokumenti\\DOKUMENTI\\PROJEKTI\\bttradar\\xml\\xml-LCoO.xsd", "http://www.w3.org/2001/XMLSchema", ref veh);

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

            try
            {
                doc.Load(new MemoryStream(xmlFile));
            }
            catch
            {
                idDat = 0;
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

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
                        DB.InsertXmlData(idDat, SportID, Sport, CategoryID, Category, TournamentID, Tournament, MatchID, Competitors[0], Competitors[1]);
                    }
                }
            }

            DB.UpdateXmlData(idDat, 1);
            
            Cursor.Current = Cursors.Default;

            GetXmlData();
        }

        private void GetXmlData()
        {
            dgv.DataSource = DB.GetXmlData(idDat);
        }

        //static void ValidationEventHandler(object sender, ValidationEventArgs e)
        //{
        //    switch (e.Severity)
        //    {
        //        case XmlSeverityType.Error:
        //            Console.WriteLine("Error: {0}", e.Message);
        //            break;
        //        case XmlSeverityType.Warning:
        //            Console.WriteLine("Warning {0}", e.Message);
        //            break;
        //    }

        //}
    }
}
