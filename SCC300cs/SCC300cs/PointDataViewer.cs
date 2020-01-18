using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaderSharp;

namespace SCC300cs
{
    public partial class PointDataViewer : Form
    {
        public PointDataViewer(List<string> sents, List<SentimentAnalysisResults> resultsList)
        {
            InitializeComponent();
            for (int i = 0; i < resultsList.Count; i++)
            {
                dgvSenti.Rows.Add(i, resultsList[i].Compound, sents[i]);
            }
        }
    }
}
