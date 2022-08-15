using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoostProjeKaloriTakipProgrami
{
    public partial class RegisterForm : Form
    {
        Classes.UygulamaDbContext db = new Classes.UygulamaDbContext();

        public RegisterForm()
        {
            InitializeComponent();
        }
    }
}
