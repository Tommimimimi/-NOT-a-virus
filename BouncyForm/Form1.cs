using System.Diagnostics;
using System.Drawing;

namespace BouncyForm
{
    public partial class Form1 : Form
    {
        int xPos = 500,
            yPos = 500,
            currentForms = 0,
            xMove = 1,
            yMove = 1;

        bool randDirection = false;

        public static Array values = Enum.GetValues(typeof(KnownColor));

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(3, 3);
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            xPos = random.Next(100, Screen.PrimaryScreen.WorkingArea.Width - 100);
            yPos = random.Next(100, Screen.PrimaryScreen.WorkingArea.Height - 100);
            xMove = random.Next(-4, 4);
            yMove = random.Next(-4, 4);
            timer1.Interval = 10;
            this.DoubleBuffered = true;
        }
        private void MoveForm()
        {
            this.Location = new Point(xPos, yPos);
            if (xPos + this.Width >= Screen.PrimaryScreen.WorkingArea.Width || xPos <= 0)
            {
                if (++currentForms < 3)
                {
                    Form1 newForm = new Form1();
                    newForm.Show();
                }
                xMove = -xMove;
            }
            if (yPos + this.Height >= Screen.PrimaryScreen.WorkingArea.Height || yPos <= 0)
            {
                if (++currentForms < 2)
                {
                    Form1 newForm = new Form1();
                    newForm.Show();
                }
                yMove = -yMove;
            }
            xPos += xMove;
            yPos += yMove;

            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveForm();
            this.TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(random.Next(1, 100), random.Next(1, 100));
            KnownColor kc = (KnownColor)values.GetValue(random.Next(28,167));
            this.BackColor = Color.FromKnownColor(kc);
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Close();
        }
    }
}