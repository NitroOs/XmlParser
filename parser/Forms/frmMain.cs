﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace parser
{
    public partial class frmMain : Form
    {
        protected string fileName = string.Empty;

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

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = Path.GetFileName(fileDialog.FileName);
                fileName = fileDialog.FileName;
            }
            else
            {
                fileName = string.Empty;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (fileName.Length == 0) return;

            XmlDocument doc = new XmlDocument();
            string s = string.Empty;
            int i = 0;

            string SportID = string.Empty;
            string Sport = string.Empty;
            string CategoryID = string.Empty;
            string Category = string.Empty;
            string TournamentID = string.Empty;
            string Tournament = string.Empty;
            string MatchID = string.Empty;
            List<string> Competitors = new List<string>();

            doc.Load(fileName);

            XmlNode SportNode = doc.DocumentElement.SelectSingleNode("Sports");

            foreach (XmlNode node in SportNode)
            {
                SportID = node.Attributes["BetradarSportID"].Value;
                Sport = node.SelectSingleNode("Texts//Text[@Language='BET']").InnerText;

                XmlNodeList catnode = node.SelectNodes("Category");
                foreach (XmlNode catchild in catnode)
                {
                    CategoryID = catchild.Attributes["BetradarCategoryID"].Value;
                    Category = catchild.SelectSingleNode("Texts//Text[@Language='BET']").InnerText;

                    XmlNode TournamentNode = catchild.SelectSingleNode("Tournament");
                    TournamentID = TournamentNode.Attributes["BetradarTournamentID"].Value;
                    Tournament = TournamentNode.SelectSingleNode("Texts/Text[@Language='BET']").InnerText;

                    XmlNode MatchNode = catchild.SelectSingleNode("Tournament//Match");
                    MatchID = MatchNode.Attributes["BetradarMatchID"].Value;

                    Competitors.Clear();
                    XmlNodeList CompetitorsNode = catchild.SelectNodes("Tournament/Match/Fixture/Competitors//Texts");
                    foreach (XmlNode compchild in CompetitorsNode)
                    {
                        Competitors.Add(compchild.SelectSingleNode("Text//Text[@Language='BET']").InnerText);
                    }
                    i++;
                }
            }         
        }
    }
}