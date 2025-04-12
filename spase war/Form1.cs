using NAudio.Wave;

namespace spase_war
{
    public partial class Form1 : Form
    {
        bool show_menu = false;
        private Form2 gameform;
        private Image player_plane;
        private Image player_tir;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            pic_player1.Image = Image.FromFile("fotos/plane1.png");
            pic_player2.Image = Image.FromFile("fotos/plane.png");
            pic_player3.Image = Image.FromFile("fotos/plane2.png");
            pic_player4.Image = Image.FromFile("fotos/plane6.png");
            pic_player5.Image = Image.FromFile("fotos/plane4.png");
            pic_tir1.Image = Image.FromFile("fotos/tir1.png");
            pic_tir2.Image = Image.FromFile("fotos/tir2.png");
            pic_tir3.Image = Image.FromFile("fotos/tir3.png");
            pic_tir4.Image = Image.FromFile("fotos/tir4.png");

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            StartBackgroundMusic();
            this.KeyPreview = true;

            panel1.Visible = false;
            pic_player1.Visible = false;
            pic_player2.Visible = false;
            pic_player3.Visible = false;
            pic_player4.Visible = false;
            pic_player5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            btnPlane1.Visible = false;
            btnPlan2.Visible = false;
            btnPlan3.Visible = false;
            btnPlan4.Visible = false;
            btnPlan5.Visible = false;
            pic_tir1.Visible = false;
            pic_tir2.Visible = false;
            pic_tir3.Visible = false;
            pic_tir4.Visible = false;
            selectTir1.Visible = false;
            selectTir2.Visible = false;
            selectTir3.Visible = false;
            selectTir4.Visible = false;

        }
        WaveOutEvent backgroundPlayer;
        AudioFileReader backgroundReder;

        private void StartBackgroundMusic()
        {
            backgroundReder = new AudioFileReader("sound/zamine1.mp3");
            backgroundPlayer = new WaveOutEvent();
            backgroundPlayer.Init(backgroundReder);
            backgroundPlayer.PlaybackStopped += (s, e) =>
            {
                backgroundReder.Position = 0;
                backgroundPlayer.Play();
            };
            backgroundPlayer.Play();
        }
        private void LoadGameForm()
        {
            gameform = new Form2(player_plane, player_tir);
            gameform.TopLevel = false;
            gameform.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Clear();
            pnl.Controls.Add(gameform);
            this.ActiveControl = null;
            this.Focus();
            gameform.Show();
            pnl.Visible = true;
        }

        private void btn1_clik(object sender, EventArgs e)
        {
            if ((player_plane != null) && (player_tir != null))
            {
                LoadGameForm();
            }
            else if (player_plane == null)
            {
                MessageBox.Show("Choose a fighter plane.");
                //backgroundPlayer.Pause();
            }

            else if (player_tir == null)
            {
                MessageBox.Show("Choose a rocket.");
                //backgroundPlayer.Play();
            }
            backgroundPlayer.Pause();
            hamlePlay.Pause();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            gameform?.KeyDownform2(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            gameform?.KeyUpform2(e);
        }

        private void btn1_MouseHover(object sender, EventArgs e)
        {
            btn1.BackColor = Color.Black;
            btn1.ForeColor = Color.LawnGreen;
        }

        private void btn1_MouseLeave(object sender, EventArgs e)
        {
            btn1.BackColor = Color.Black;
            btn1.ForeColor = Color.Red;
        }
        WaveOutEvent hamlePlay;
        AudioFileReader hamleRaeder;
        private void hamle()
        {
            hamleRaeder = new AudioFileReader("sound/Hamle.mp3");
            hamlePlay = new WaveOutEvent();
            hamlePlay.Init(hamleRaeder);
            hamlePlay.PlaybackStopped += (s, e) =>
            {
                hamleRaeder.Position = 0;
                hamlePlay.Play();
            };
            hamlePlay.Play();
        }
        private void azam_Click(object sender, EventArgs e)
        {
            if (!show_menu)
            {
                hamle();

                panel1.Visible = true;
                pic_player1.Visible = true;
                pic_player2.Visible = true;
                pic_player3.Visible = true;
                pic_player4.Visible = true;
                pic_player5.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                btnPlane1.Visible = true;
                btnPlan2.Visible = true;
                btnPlan3.Visible = true;
                btnPlan4.Visible = true;
                btnPlan5.Visible = true;
                pic_tir1.Visible = true;
                pic_tir2.Visible = true;
                pic_tir3.Visible = true;
                pic_tir4.Visible = true;
                selectTir1.Visible = true;
                selectTir2.Visible = true;
                selectTir3.Visible = true;
                selectTir4.Visible = true;
                show_menu = true;
            }
            else
            {
                hamlePlay.Pause();
                panel1.Visible = false;
                pic_player1.Visible = false;
                pic_player2.Visible = false;
                pic_player3.Visible = false;
                pic_player4.Visible = false;
                pic_player5.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                btnPlane1.Visible = false;
                btnPlan2.Visible = false;
                btnPlan3.Visible = false;
                btnPlan4.Visible = false;
                btnPlan5.Visible = false;
                pic_tir1.Visible = false;
                pic_tir2.Visible = false;
                pic_tir3.Visible = false;
                pic_tir4.Visible = false;
                selectTir1.Visible = false;
                selectTir2.Visible = false;
                selectTir3.Visible = false;
                selectTir4.Visible = false;
                show_menu = false;
            }

        }

        private void btnPlane1_Click(object sender, EventArgs e)
        {
            player_plane = pic_player1.Image;
        }

        private void btnPlan2_Click(object sender, EventArgs e)
        {
            player_plane = pic_player2.Image;

        }

        private void btnPlan3_Click(object sender, EventArgs e)
        {
            player_plane = pic_player3.Image;

        }

        private void btnPlan4_Click(object sender, EventArgs e)
        {
            player_plane = pic_player4.Image;

        }

        private void btnPlan5_Click(object sender, EventArgs e)
        {
            player_plane = pic_player5.Image;

        }

        private void selectTir1_Click(object sender, EventArgs e)
        {
            player_tir = pic_tir1.Image;
        }

        private void selectTir2_Click(object sender, EventArgs e)
        {
            player_tir = pic_tir2.Image;

        }

        private void selectTir3_Click(object sender, EventArgs e)
        {
            player_tir = pic_tir3.Image;

        }

        private void selectTir4_Click(object sender, EventArgs e)
        {
            player_tir = pic_tir4.Image;

        }


        private void Exit_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("are you sure? ", "exit?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                hamlePlay.Pause();
                backgroundPlayer.Pause();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void Exit_MouseHover(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.Red;

        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.LawnGreen;

        }
    }
}