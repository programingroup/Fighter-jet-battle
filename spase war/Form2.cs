using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Timers;
using NAudio.Wave;
using System.IO;
namespace spase_war
{
    public partial class Form2 : Form
    {
        bool left = false;
        bool right = false;
        bool Show_menu = false;
        bool reset = false;
        int jon = 3;
        bool barkhord = true;
        int score = 0;
        int highscore = 0;
        string highscorepath = "highscore.txt";
        int lastscore = 0;
        int se = 0;
        bool bulletfire = false;
        int bulletspeed = 50;
        bool ghalbo = false;
        bool dotir = false;
        bool dotirPowerActive = false;
        bool doubleShotPowerDisplayed = false;
        bool doubleShotPowerActive = false;
        bool bullet2Fire = false;
        bool ishit1 = false;
        bool ishit5 = false;
        bool ishit6 = false;
        Random rand = new Random();
        bool farman_playe = false;
        bool isghost = false;
        bool isNight = false;

        public Form2(Image player_plane, Image player_tir)
        {
            InitializeComponent();
            this.KeyPreview = true;
            timer1.Start();
            timer2.Start();
            label4.Visible = false;
            bullet.Visible = false;
            bullet2.Visible = false;
            ghalb.Visible = false;
            dotirpow.Visible = false;
            label8.Visible = false;
            player.Image = player_plane;
            player.SizeMode = PictureBoxSizeMode.Zoom;
            bullet.Image = player_tir;
            bullet.SizeMode = PictureBoxSizeMode.Zoom;
            bullet2.Image = player_tir;
            bullet2.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            StartBackgroundMusic();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            farman();
            score = 0;
            if (File.Exists(highscorepath))
            {
                int.TryParse(File.ReadAllText(highscorepath), out highscore);
            }
            else
            {
                File.WriteAllText(highscorepath, "0");
                highscore = 0;
            }
            labelhighscore.Text = highscore.ToString();
            moon.Visible = false;
            star1.Visible = false;
            star2.Visible = false;
            star3.Visible = false;
            star4.Visible = false;
            star5.Visible = false;
            star6.Visible = false;
            star7.Visible = false;
            star8.Visible = false;
            star9.Visible = false;
            star10.Visible = false;
            star11.Visible = false;
            star12.Visible = false;
            star13.Visible = false;
            star14.Visible = false;
            star15.Visible = false;
            star16.Visible = false;
            star17.Visible = false;
            star18.Visible = false;
            star19.Visible = false;
            star20.Visible = false;
            star21.Visible = false;
            star22.Visible = false;
            star23.Visible = false;
        }

        WaveOutEvent backgroundPlayer;
        AudioFileReader backgroundReder;

        private void StartBackgroundMusic()
        {
            backgroundReder = new AudioFileReader("sound/zamine2.mp3");
            backgroundPlayer = new WaveOutEvent();
            backgroundPlayer.Init(backgroundReder);
            backgroundPlayer.PlaybackStopped += (s, e) =>
            {
                backgroundReder.Position = 0;
                backgroundPlayer.Play();
            };
            backgroundPlayer.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (left && player.Left > 0)
            {
                player.Left -= 22;
            }
            if (right && player.Right < this.ClientSize.Width)
            {
                player.Left += 22;
            }
            if (bulletfire)
            {
                bullet.Top -= bulletspeed;

                if (bullet.Top < 0)
                {
                    bulletfire = false;
                    bullet.Visible = false;
                }

                if (bullet.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    HitEnemy(pictureBox1);
                }
                else if (bullet.Bounds.IntersectsWith(pictureBox5.Bounds))
                {
                    HitEnemy(pictureBox5);
                }
                else if (bullet.Bounds.IntersectsWith(pictureBox6.Bounds))
                {
                    HitEnemy(pictureBox6);
                }
            }
            if (bullet2Fire)
            {
                bullet2.Top -= bulletspeed;

                if (bullet2.Top < 0)
                {
                    bullet2Fire = false;
                    bullet2.Visible = false;
                }

                if (bullet2.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    HitEnemy(pictureBox1);
                    bullet2Fire = false;
                    bullet2.Visible = false;
                }
                else if (bullet2.Bounds.IntersectsWith(pictureBox5.Bounds))
                {
                    HitEnemy(pictureBox5);
                    bullet2Fire = false;
                    bullet2.Visible = false;
                }
                else if (bullet2.Bounds.IntersectsWith(pictureBox6.Bounds))
                {
                    HitEnemy(pictureBox6);
                    bullet2Fire = false;
                    bullet2.Visible = false;
                }
            }
            enemy();
            randghalb();
            randdotir();
            move_star();
            move_abr();
        }
        private async void Effect(PictureBox enemy)
        {
            enemy.SizeMode = PictureBoxSizeMode.Zoom;
            enemy.Image = Image.FromFile("fotos/bom.png");
            var reader = new AudioFileReader("sound/bomb.mp3");
            var player = new WaveOutEvent();
            player.Init(reader);
            player.Play();
            player.PlaybackStopped += (s, e) =>
            {
                player.Dispose();
                reader.Dispose();
            };
            await Task.Delay(500);
            enemy.Image = Image.FromFile("fotos/Enemy.png");
        }
        public void KeyDownform2(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Space && !bulletfire)
            {
                bulletfire = true;
                bullet.Location = new Point(player.Left + player.Width / 2 - bullet.Width / 2, player.Top - bullet.Height);
                bullet.Visible = true;

                if (doubleShotPowerActive)
                {
                    bullet2Fire = true;
                    bullet2.Location = new Point(player.Right - 20, player.Top - bullet2.Height);
                    bullet2.Visible = true;
                }
            }
            if (e.KeyCode == Keys.S)
            { 
                    isghost = true;
                    label8.Visible = true;
            }
            else if (e.KeyCode == Keys.A)
            {
                isghost = false;
                label8.Visible = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (!Show_menu)
                {
                    menu.Visible = true;
                    go.Visible = true;
                    Show_menu = true;
                    timer1.Stop();
                    timer2.Stop();
                    btn_show.ForeColor = Color.Red;

                }
                else
                {
                    menu.Visible = false;
                    Show_menu = false;
                    timer1.Start();
                    timer2.Start();
                    btn_show.ForeColor = Color.LawnGreen;

                }
            }
        }
        public void KeyUpform2(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }

            if (jon == 0)
            {
                if (e.KeyCode == Keys.Enter)
                {

                    foreach (Control control in this.Controls)
                    {
                        control.Enabled = true;
                    }
                    reset = false;
                    jon = 3;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    bullet.Visible = false;
                    bullet.Location = new Point(437, 389);
                    label4.Visible = false;
                    label1.Text = "0";
                    label2.Text = "0";
                    pictureBox1.Location = new Point(-90, 463);
                    pictureBox5.Location = new Point(322, 463);
                    pictureBox6.Location = new Point(918, 463);
                    timer1.Start();
                    timer2.Start();
                    label6.Text = "0";
                    score = 0;
                    dotir = false;
                    bullet2.Visible = false;
                    bullet2.Location = new Point(479, 389);
                    dotir = false;
                    doubleShotPowerDisplayed = false;
                    doubleShotPowerActive = false;
                    bullet2Fire = false;
                    dotirpow.Visible = false;
                    backgroundPlayer.Play();
                    game_overPlayer.Pause();



                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int s = int.Parse(label1.Text);
            int m = int.Parse(label2.Text);
            s++;
            se++;
            if (se >= 3)
            {
                score++;
                if (score / 20 != lastscore / 20)
                {
                    Day_and_Hight();
                    lastscore = score;
                }
                se = 0;
                label6.Text = score.ToString();
            }
            if (s == 60)
            {
                m++;
                label2.Text = m.ToString();
                s = 0;
                label1.Text = s.ToString();
            }
            label1.Text = s.ToString();
            farman();
        }

        //public void setfocus()
        //{
        //    this.Focus();
        //    this.ActiveControl = null;
        //}

        private void Day_and_Hight()
        {

            if (isNight)
            {
                this.BackColor = Color.SkyBlue;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                labelhighscore.ForeColor = Color.Black;
                btn_show.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label8.ForeColor = Color.Black;
                sun.Visible = true;
                abr1.Visible = true;
                abr2.Visible = true;
                abr3.Visible = true;
                abr4.Visible = true;
                abr5.Visible = true;
                abr6.Visible = true;
                abr7.Visible = true;
                moon.Visible = false;
                star1.Visible = false;
                star2.Visible = false;
                star3.Visible = false;
                star4.Visible = false;
                star5.Visible = false;
                star6.Visible = false;
                star7.Visible = false;
                star8.Visible = false;
                star9.Visible = false;
                star10.Visible = false;
                star11.Visible = false;
                star12.Visible = false;
                star13.Visible = false;
                star14.Visible = false;
                star15.Visible = false;
                star16.Visible = false;
                star17.Visible = false;
                star18.Visible = false;
                star19.Visible = false;
                star20.Visible = false;
                star21.Visible = false;
                star22.Visible = false;
                star23.Visible = false;

                isNight = false;
            }
            else
            {
                this.BackColor = Color.Black;
                label5.ForeColor = Color.LawnGreen;
                label6.ForeColor = Color.LawnGreen;
                label7.ForeColor = Color.LawnGreen;
                labelhighscore.ForeColor = Color.LawnGreen;
                btn_show.ForeColor = Color.LawnGreen;
                label4.ForeColor = Color.Red;
                label8.ForeColor = Color.Red;
                moon.Visible = true;
                star1.Visible = true;
                star2.Visible = true;
                star3.Visible = true;
                star4.Visible = true;
                star5.Visible = true;
                star6.Visible = true;
                star7.Visible = true;
                star8.Visible = true;
                star9.Visible = true;
                star10.Visible = true;
                star11.Visible = true;
                star12.Visible = true;
                star13.Visible = true;
                star14.Visible = true;
                star15.Visible = true;
                star16.Visible = true;
                star17.Visible = true;
                star18.Visible = true;
                star19.Visible = true;
                star20.Visible = true;
                star21.Visible = true;
                star22.Visible = true;
                star23.Visible = true;

                sun.Visible = false;
                abr1.Visible = false;
                abr2.Visible = false;
                abr3.Visible = false;
                abr4.Visible = false;
                abr5.Visible = false;
                abr6.Visible = false;
                abr7.Visible = false;
                isNight = true;
            }

        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void go_Click(object sender, EventArgs e)
        {
            Form1 newmaine = new Form1();
            newmaine.Show();
            this.Close();
            backgroundPlayer.Pause();
            if (score > highscore)
            {
                highscore = score;
                File.WriteAllText(highscorepath, highscore.ToString());
            }
        }

        private async void enemy()
        {
            if (jon > 0)
            {
                pictureBox1.Top += 8;
                pictureBox5.Top += 8;
                pictureBox6.Top += 8;
       

                if (!isghost && pictureBox1.Bounds.IntersectsWith(player.Bounds) && !ishit1)
                {
                    ishit1 = true;
                    barkhord = false;
                    jon -= 1;
                    Effect(pictureBox1);
                    await Task.Delay(500);
                    pictureBox1.Top = rand.Next(-110, -75);
                    pictureBox1.Left = rand.Next(10, 207);
                    ishit1 = false;
                    damage();
                }
                if (!isghost && pictureBox5.Bounds.IntersectsWith(player.Bounds) && !ishit5)
                {
                    ishit5 = true;
                    barkhord = false;
                    jon -= 1;
                    Effect(pictureBox5);
                    await Task.Delay(500);
                    pictureBox5.Top = rand.Next(-110, -75);
                    pictureBox5.Left = rand.Next(217, 520);
                    ishit5 = false;

                    damage();
                }
                if (!isghost && pictureBox6.Bounds.IntersectsWith(player.Bounds) && !ishit6)
                {
                    ishit6 = true;
                    barkhord = false;
                    jon -= 1;
                    Effect(pictureBox6);
                    await Task.Delay(500);
                    pictureBox6.Top = rand.Next(-110, -75);
                    pictureBox6.Left = rand.Next(530, 920);
                    ishit6 = false;
                    damage();
                }
                if (Convert.ToInt32(label1.Text) % 5 == 0 || score % 5 == 0)
                {
                    pictureBox1.Top += 1;
                    pictureBox5.Top += 1;
                    pictureBox6.Top += 1;
                }
                CheckEnemyPassed(pictureBox1, 10, 207);
                CheckEnemyPassed(pictureBox5, 217, 520);
                CheckEnemyPassed(pictureBox6, 530, 920);
           
            }
            else
            {
                btn_show.Enabled = true;
            }
        }
        WaveOutEvent game_overPlayer;
        AudioFileReader game_overReader;
        private void damage()
        {
            if (jon == 2)
            {
                if (pictureBox2 != null)
                {
                    pictureBox2.Visible = false;
                }
            }
            if (jon == 1)
            {
                if (pictureBox3 != null)
                {
                    pictureBox3.Visible = false;
                }
            }
            if (jon == 0)
            {
                if (pictureBox4 != null)
                {
                    pictureBox4.Visible = false;
                }
                try
                {
                    backgroundPlayer.Pause();

                    var game_overReader = new AudioFileReader("sound/game-over.mp3");
                    game_overPlayer = new WaveOutEvent();
                    game_overPlayer.Init(game_overReader);
                    game_overPlayer.Play();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Audio playback error");
                }

                label4.Visible = true;
                timer1.Stop();
                timer2.Stop();
                reset = true;
                barkhord = true;
                label4.Text = Environment.NewLine + "_____ Game Over _____" + Environment.NewLine + "press enter ro start over";
            }
        }
        private async void HitEnemy(PictureBox enemy)
        {
            bulletfire = false;
            bullet.Visible = false;
            if (doubleShotPowerActive)
            {
                bullet2Fire = false;
                bullet2.Visible = false;
            }

            if ((enemy == pictureBox1) && !ishit1)
            {
                ishit1 = true;
                Effect(pictureBox1);
                await Task.Delay(500);
                enemy.Left = rand.Next(10, 207);
            }
            else if ((enemy == pictureBox5) && !ishit5)
            {
                ishit5 = true;
                Effect(pictureBox5);
                await Task.Delay(500);
                enemy.Left = rand.Next(217, 520);
            }
            else if ((enemy == pictureBox6) && !ishit6)
            {
                ishit6 = true;
                Effect(pictureBox6);
                await Task.Delay(500);
                enemy.Left = rand.Next(530, 920);
            }
            enemy.Top = 0;
            ishit1 = false;
            ishit5 = false;
            ishit6 = false;

            score += 2;
            label6.Text = score.ToString();
        }

        private void CheckEnemyPassed(PictureBox enemy, int leftMin, int leftMax)
        {
            if (enemy.Top > this.ClientSize.Height)
            {
                score++;
                label6.Text = score.ToString();
                enemy.Top = 0;
                enemy.Left = rand.Next(leftMin, leftMax);
            }
        }
        private void randghalb()
        {
            int w = Convert.ToInt32(label1.Text);

            if (w % 50 == 0 && w!= 00)
            {
                ghalb.Visible = true;
                ghalb.Top = 0;
                ghalb.Left = rand.Next(20, this.ClientSize.Width - ghalb.Width);
                ghalbo = true;
            }

            if (ghalb.Visible)
            {
                ghalb.Top += 10;
                if (ghalb.Bounds.IntersectsWith(player.Bounds))
                {
                    if (jon == 3)
                    {
                        jon = 3;
                        ghalb.Visible = false;
                    }
                    if (jon == 2)
                    {
                        ghalb.Visible = false;
                        jon += 1;
                        pictureBox2.Visible = true;
                    }
                    if (jon == 1)
                    {
                        ghalb.Visible = false;
                        jon += 1;
                        pictureBox3.Visible = true;
                    }
                }
                if (ghalb.Top > this.ClientSize.Height)
                {
                    ghalb.Visible = false;
                }
            }
        }
        private void randdotir()
        {
            int t = Convert.ToInt32(label1.Text);
            int e = Convert.ToInt32(label2.Text);

            if (e == 1 && t == 20 && !doubleShotPowerDisplayed)
            {
                dotirpow.Visible = true;
                dotirpow.Top = 0;
                dotirpow.Left = rand.Next(20, this.ClientSize.Width - dotirpow.Width);
                doubleShotPowerDisplayed = true;
            }

            if (dotirpow.Visible)
            {
                dotirpow.Top += 10;

                if (dotirpow.Bounds.IntersectsWith(player.Bounds))
                {
                    doubleShotPowerActive = true;
                    dotirpow.Visible = false;
                }

                if (dotirpow.Top > this.ClientSize.Height)
                {
                    dotirpow.Visible = false;
                }
            }

        }
        WaveOutEvent outputDevice;
        AudioFileReader audioFile;
        int dor = 1;
        private void farman()
        {

            int w = Convert.ToInt32(label1.Text);

            if (w == 50)
            {
                dor++;
                if (dor % 2 == 0)
                {
                    if (!farman_playe)
                    {
                        if (outputDevice != null)
                        {
                            outputDevice.Stop();
                            outputDevice.Dispose();
                            audioFile.Dispose();
                        }
                        audioFile = new AudioFileReader("C:\\Fighter jet battle\\Fighter jet battle\\spase war\\sound\\dastor.mp3");
                        outputDevice = new WaveOutEvent();
                        outputDevice.Init(audioFile);
                        outputDevice.Play();
                        farman_playe = true;
                    }
                    else
                    {
                        farman_playe = false;
                    }
                }
            }
        }
        private void move_star()
        {
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox && ctrl.Tag?.ToString() == "start")
                {
                    ctrl.Top += 10;
                    if (ctrl.Top > this.Height)
                    {
                        ctrl.Top = ctrl.Height;
                    }
                }
            }
        }
        private void move_abr()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox && ctrl.Tag?.ToString() == "abr")
                {
                    ctrl.Top += 7;
                    if (ctrl.Top > this.Height)
                    {
                        ctrl.Top = ctrl.Height;
                    }
                }
            }
            //foreach (Control ctrl in this.Controls)
            //{
            //    if (ctrl is PictureBox)
            //    {
            //        if (ctrl.Tag?.ToString()== "abr_L")
            //        {
            //            ctrl.Left -= 7;
            //            if (ctrl.Right < 0)
            //            {
            //                ctrl.Left = this.Width;
            //            }
            //        }
            //        else if (ctrl.Tag?.ToString() == "abr_R")
            //        {
            //            ctrl.Left += 7;
            //            if (ctrl.Left > this.Width)
            //            {
            //                ctrl.Left = -ctrl.Width;
            //            }
            //        }
            //    }

            //}
        }
      
    }
}