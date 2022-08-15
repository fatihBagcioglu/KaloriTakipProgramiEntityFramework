using BoostProjeKaloriTakipProgrami.Classes;
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
    public partial class LoginForm : Form
    {
        Classes.UygulamaDbContext db = new Classes.UygulamaDbContext();

        public LoginForm()
        {
            InitializeComponent();
        }

        public void ChangeLanguage()
        {
            if (btnLang.Text == "TR")
            {
                lblGreeting.Text = "Karşılama Mesajı";
                lblDesc.Text = "Açıklama";
                lblEmail.Text = "Email";
                lblPass.Text = "Şifre";
                btnLogin.Text = "Giriş Yap";
                btnForget.Text = "Şifremi Unuttum";
                btnRegister.Text = "Kayıt Ol";

                btnLang.Text = "EN";
            }
            else
            {
                lblGreeting.Text = "Greeting Message";
                lblDesc.Text = "Description";
                lblEmail.Text = "Email";
                lblPass.Text = "Password";
                btnLogin.Text = "Login";
                btnForget.Text = "Forgot My Password!";
                btnRegister.Text = "Register Now!";

                btnLang.Text = "TR";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckData();
        }

        private void CheckData()
        {
            SHA sha = new SHA();
            string email = txtEmail.Text.Trim();
            string password = txtPass.Text.Trim();
            password = sha.Sha256_Hash(password);

            if (email == "" || password == "")
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş geçilemez.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                MainForm frm = new MainForm();
                frm.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Böyle bir kullanıcı bulunamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearTextBoxes();
                return;
            }
        }

        private void ClearTextBoxes()
        {
            txtEmail.Clear();
            txtPass.Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            RegisterForm frm = new RegisterForm();
            frm.ShowDialog();
            this.Hide();
        }

        private void btnLang_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeLanguage();
        }
    }
}
