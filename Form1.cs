using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorCSharp
{
    public partial class FrmCalculator : Form
    {
        //Double result = 0;
        //String operatorr = "";
        //String Operator;
        //bool enter_value = false;
        double firstNum, secondNum, result;
        String Operator;
        public FrmCalculator()
        {
            InitializeComponent();
        }
        //xoa 1 ky tu
        private void btnX_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            else if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "0";
            }

        }
        private void NhapSo(string so)
        {
            if (IsTypingNumber)
            {
                txtDisplay.Text = txtDisplay.Text + so;
            }
            else
            {
                txtDisplay.Text = so;
                IsTypingNumber = true;
            }
        }
        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            NhapSo(btn.Text);
            //if(txtDisplay.Text == "0")
            //{
            //    txtDisplay.Text = "";
            //}
            //Button number = (Button)sender;
            //if(number.Text == ".")
            //{
            //    if (!txtDisplay.Text.Contains(".")){
            //        txtDisplay.Text += number.Text.ToString();
            //    }
            //}
            //else
            //{
            //    txtDisplay.Text += number.Text.ToString();
            //}
        }
        //nut cong tru
        double firstNumber, secondNumber;
        private void BtnCongTru_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = ((double.Parse(txtDisplay.Text)) * -1.0).ToString();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text =  "0";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            //txtDisplay.Clear();
            txtDisplay.Text = "0";
        }
        //private void buttonOperator(object sender, EventArgs e)
        //{
            
        //}

        private void bntPI_Click(object sender, EventArgs e)
        {
            double PI = 3.14;
            txtDisplay.Text = PI.ToString();
        }

        private void FrmCalculator_Load(object sender, EventArgs e)
        {
            lblShowOperation.Text = "";
        }
        enum PhepToan{
            Cong, Tru, Nhan, Chia
        };
        bool IsTypingNumber = false;
        PhepToan pheptoan;
        double remember;

        private void btnBinhPhuong_Click(object sender, EventArgs e)
        {
            double a;
            lblShowOperation.Text = txtDisplay.Text + "^2";
            a = Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text);
            txtDisplay.Text = a.ToString();
            //txtDisplay.Text = ((double.Parse(txtDisplay.Text)) * (double.Parse(txtDisplay.Text))).ToString();
        }

        private void btnLapPhuong_Click(object sender, EventArgs e)
        {
            double b;
            lblShowOperation.Text = txtDisplay.Text + "^2";
            b = Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text);
            txtDisplay.Text = b.ToString();
        }

        private void btn1ChiaX_Click(object sender, EventArgs e)
        {
            double c;
            lblShowOperation.Text = "1 / ";
            c = 1 / Convert.ToDouble(txtDisplay.Text);
            txtDisplay.Text = c.ToString();
        }

        private void rdbDegree_CheckedChanged(object sender, EventArgs e)
        {
            lblShowOperation.Text = "D";

        }

        private void rdbRadian_CheckedChanged(object sender, EventArgs e)
        {
            lblShowOperation.Text = "R";
        }

        private void rdbGrads_CheckedChanged(object sender, EventArgs e)
        {
            lblShowOperation.Text = "G";
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+": pheptoan = PhepToan.Cong; break;
                case "-": pheptoan = PhepToan.Tru; break;
                case "*": pheptoan = PhepToan.Nhan; break;
                case "/": pheptoan = PhepToan.Chia; break;
            }
            remember = double.Parse(txtDisplay.Text);
            lblShowOperation.Text = remember.ToString() + " " + btn.Text.ToString();
            txtDisplay.Clear();
            IsTypingNumber = false;
        }
        private void TinhKetQua()
        {
            double secondNum = double.Parse(txtDisplay.Text);
            double result = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: result = remember + secondNum; break;
                case PhepToan.Tru: result = remember - secondNum; break;
                case PhepToan.Nhan: result = remember * secondNum;break;
                case PhepToan.Chia: result = remember / secondNum;break;
            }
            txtDisplay.Text = result.ToString();
        }
        private void btnDauBang_Click(object sender, EventArgs e)
        {
            lblShowOperation.Text = "";
            TinhKetQua();
            IsTypingNumber = false;
        }  
    }
}
