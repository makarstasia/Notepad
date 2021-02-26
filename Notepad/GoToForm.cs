using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class GoToForm : Form
    {
        public GoToForm()
        {
            InitializeComponent();
        }
        private void butGo_Click(object sender, EventArgs e) // Кнопка "Перейти к строке"
        {
            NotepadForm main = this.Owner as NotepadForm;
            if (main != null)
            {
                int lineNumber = Convert.ToInt32(tbLineNum.Text);
                if (lineNumber > 0 && lineNumber <= main.maintextBox.Lines.Count())
                {
                    main.maintextBox.SelectionStart = main.maintextBox.GetFirstCharIndexFromLine(Convert.ToInt32(tbLineNum.Text) - 1);
                    main.maintextBox.ScrollToCaret();
                    this.Close();
                }
            }
        }

        private void butCancel_Click(object sender, EventArgs e) // Кнопка "Отменить"
        {
            this.Close();
        }



    }
}
