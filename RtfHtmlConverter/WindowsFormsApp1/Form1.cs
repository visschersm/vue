using MarkupConverter;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        IMarkupConverter markupConverter = new MarkupConverter.MarkupConverter();
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            var text = richTextBox1.Rtf;
            var html = markupConverter.ConvertRtfToHtml(text);
            richTextBox2.Text = html;
        }
    }
}
