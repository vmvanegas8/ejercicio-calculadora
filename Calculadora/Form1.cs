using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmcalculadora : Form
    {
        public frmcalculadora()
        {
            InitializeComponent();
        }

        double numA, numB, result;
        string operation = "";
        bool operationSelected = false;

        private void btn1_Click(object sender, EventArgs e)
        {
            addNumber(btn1.Text);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            addNumber(btn2.Text);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            addNumber(btn3.Text);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            addNumber(btn4.Text);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            addNumber(btn5.Text);
        }

        private void btn6_Click(object sender, EventArgs e)
        {           
            addNumber(btn6.Text);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            addNumber(btn7.Text);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            addNumber(btn8.Text);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            addNumber(btn9.Text);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            addNumber(btn0.Text);
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            addNumber(btndot.Text);
        }
        private void btnmore_Click(object sender, EventArgs e)
        {
            lbloperationtype.Text = "+";
            operation = "suma";

            if (lblresult.Text != "")
            {
                txta.Text = lblresult.Text;
                txtb.Clear();
                lblresult.Text = "";
            }
            else
            {
                operationSelected = true;
            }
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            lbloperationtype.Text = "/";
            operation = "divi";

            if (lblresult.Text != "")
            {
                txta.Text = lblresult.Text;
                txtb.Clear();
                lblresult.Text = "";
            }
            else
            {
                operationSelected = true;
            }
        }

        private void btnless_Click(object sender, EventArgs e)
        {
            lbloperationtype.Text = "-";
            operation = "resta";

            if (lblresult.Text != "")
            {
                txta.Text = lblresult.Text;
                txtb.Clear();
                lblresult.Text = "";
            }
            else
            {
                operationSelected = true;
            }
        }

        private void btnmulti_Click(object sender, EventArgs e)
        {
            lbloperationtype.Text = "x";
            operation = "multi";
            if (lblresult.Text != "")
            {
                txta.Text = lblresult.Text;
                txtb.Clear();
                lblresult.Text = "";
            }
            else
            {
                operationSelected = true;
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            lbloperationtype.Text = "%";
            operation = "mod";
            if (lblresult.Text != "")
            {
                txta.Text = lblresult.Text;
                txtb.Clear();
                lblresult.Text = "";
            }
            else
            {
                operationSelected = true;
            }
        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        void Calcular()
        {
            Operaciones operaciones = new Operaciones();

            if(txta.Text == "")
            {
                errorProvider1.SetError(txta, "Debes ingresar un numero");
            } else if (txtb.Text == "")
            {
                errorProvider1.SetError(txtb, "Debes ingresar un numero");
            } else
            {
                numA = double.Parse(txta.Text);
                numB = double.Parse(txtb.Text);


                switch (operation)
                {
                    case "suma":
                        result = operaciones.Suma(numA, numB);
                        break;
                    case "resta":
                        result = operaciones.Resta(numA, numB);
                        break;
                    case "divi":
                        result = operaciones.Divi(numA, numB);
                        break;
                    case "multi":
                        result = operaciones.Multi(numA, numB);
                        break;
                    case "mod":
                        result = operaciones.Module(numA, numB);
                        break;
                    default:
                        MessageBox.Show("Ha ocurrido un error");
                        break;
                }

                lblresult.Text = result.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void lbloperationtype_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debes ingresar un numero A, una operacion y un numero B", "Info ",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmcalculadora_Load(object sender, EventArgs e)
        {
            txta.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(22, 22, 22);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(230, 0 ,0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Gray;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(22, 22, 22);
        }

        void Reset()
        {
            txta.Clear();
            txtb.Clear();
            lblresult.Text = "";
            operationSelected = false;
            lbloperationtype.Text = "?";
        }

        void addNumber(string num)
        {
            errorProvider1.Clear();
            if (!operationSelected)
            {
                txta.Text += num;
            }
            else
            {
                txtb.Text += num;
            }
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frmcalculadora_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

    }
}
