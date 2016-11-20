using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace Aresv2
{
  public partial class frmhtmlEditor : DevExpress.XtraEditors.XtraForm
  {
    public frmhtmlEditor()
    {
      InitializeComponent();
    }

    private void XtraForm1_Load(object sender, EventArgs e)
    {
      richTextBox1.DataBindings.Add("Text", richEditControl1, "HtmlText", false, DataSourceUpdateMode.OnPropertyChanged);
      //richEditControl1.DataBindings.Add("HtmlText", richTextBox1.e)
      
      
    }

    private void richEditControl1_Click(object sender, EventArgs e)
    {

    }

    private void simpleButton2_Click(object sender, EventArgs e)
    {
      textEdit1.Text = richEditControl1.HtmlText;
      richTextBox1.Text = richEditControl1.HtmlText;
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      richEditControl1.HtmlText = textEdit1.Text;
    }

    private void simpleButton3_Click(object sender, EventArgs e)
    {
      webBrowser1.DocumentText = richEditControl1.HtmlText;
    }
  }
}