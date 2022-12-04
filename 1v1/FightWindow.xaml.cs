using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1v1
{
    /// <summary>
    /// Логика взаимодействия для FightWindow.xaml
    /// </summary>
    public partial class FightWindow : Window
    {
        public User user1 = new User();
        public User user2 = new User();
        public List<User> userL1 = new List<User>();
        public List<User> userL2 = new List<User>();
        public FightWindow()
        {
            InitializeComponent();
            foreach (var b in UserData.user2)
            {
                user2.Names = b.Names;
                user2.Intellengence = b.Intellengence;
                user2.Dexterity = b.Dexterity;
                user2.Strenght = b.Strenght;
                user2.Constitution = b.Constitution;
                user2.Lvl = b.Lvl;
                user2.MagicDamage = b.MagicDamage;
                user2.Point = b.Point;
                user2.Luck = b.Luck;
                user2.Mana = b.Mana;
                user2.ManaCost = b.ManaCost;
                user2.Health = b.Health;
                user2.Evasion = b.Evasion;
                user2.CrtChance = b.CrtChance;
                user2.Damage = b.Damage;
                user2.pDamage = b.pDamage;
                txtMana2.Text = user2.Mana.ToString();
                txtHealth2.Text = user2.Health.ToString();
                prbHealth2.Maximum = user2.Health;
                prbHealth2.Value = user2.Health;
                prbMana2.Maximum = user2.Mana;
                prbMana2.Value = user2.Mana;
            }
            foreach (var t in UserData.user1)
            {
                user1.Names = t.Names;
                user1.Intellengence = t.Intellengence;
                user1.Dexterity = t.Dexterity;
                user1.Strenght = t.Strenght;
                user1.Constitution = t.Constitution;
                user1.Point = t.Point;
                user1.Lvl = t.Lvl;
                user1.MagicDamage = t.MagicDamage;
                user1.Luck = t.Luck;
                user1.Mana = t.Mana;
                user1.ManaCost = t.ManaCost;
                user1.Health = t.Health;
                user1.Evasion = t.Evasion;
                user1.CrtChance = t.CrtChance;
                user1.Damage = t.Damage;
                user1.pDamage = t.pDamage;
                Health1.Text = user1.Health.ToString();
                txtMana1.Text = user1.Mana.ToString();
                prbHealth1.Maximum = user1.Health;
                prbHealth1.Value = user1.Health;
                prbMana1.Maximum = user1.Mana;
                prbMana1.Value = user1.Mana;
            }
        }
        double exp1;
        double exp2;
        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            
            Random rnd = new Random();
            double pD1 = user1.pDamage * 100;
            double pE1 = user1.Evasion * 100;
            double pD2 = user2.pDamage * 100;
            double pE2 = user2.Evasion * 100;
            double cR1 = user1.CrtChance * 100;
            double cR2 = user2.CrtChance * 100;
            double p1 = rnd.Next(0, 10001);
            user1.pDamage = pD1 / 100;
            double p2 = rnd.Next(0, 10001);
            user2.pDamage = pD2 / 100;
            double e1 = rnd.Next(0, 10001);
            user1.Evasion = pE1 / 100;
            double e2 = rnd.Next(0, 10001);
            user2.Evasion = pE2 / 100;
            double cr1 = rnd.Next(0, 10001);
            user1.CrtChance = cR1 / 100;
            double cr2 = rnd.Next(0, 10001);
            user2.CrtChance = cR2 / 100;
            //1 player
            if (YouHead2.IsChecked == true || YouBody2.IsChecked == true || YouArms2.IsChecked == true || YouLegs2.IsChecked == true)
            {
                if (Def2.Text == "Head" || Def2.Text == "Body" || Def2.Text == "Arms" || Def2.Text == "Legs")
                {
                    YouBody2.Visibility = Visibility.Hidden;
                    YouHead2.Visibility = Visibility.Hidden;
                    YouLegs2.Visibility = Visibility.Hidden;
                    YouArms2.Visibility = Visibility.Hidden;

                    Body1.Visibility = Visibility.Visible;
                    Head1.Visibility = Visibility.Visible;
                    Legs1.Visibility = Visibility.Visible;
                    Arms1.Visibility = Visibility.Visible;
                    if (pD1 >= p1)
                        {
                            if (pE2 >= e2)
                            {
                                if (user1.pDamage <= user2.Evasion)
                                {
                                    MessageBox.Show("Сработоло уклонение");
                                }
                                else
                                {
                                    if (cR1 >= cr1)
                                    {
                                        double t = user2.Health;
                                        user2.Health -= user1.Damage * 2;
                                        exp1 += user1.Damage;
                                        if (user2.Health <= 0)
                                        {
                                            exp1 += t;
                                            MessageBox.Show("Умер");
                                        }
                                    }
                                    else
                                    {
                                        double t = user2.Health;
                                        user2.Health -= user1.Damage;
                                        exp1 += user1.Damage;
                                        if (user2.Health <= 0)
                                        {
                                            exp1 += t;
                                            MessageBox.Show("Умер");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (cR1 >= cr1)
                                {
                                    double t = user2.Health;
                                    user2.Health -= user1.Damage * 2;
                                    exp1 += user1.Damage;
                                    if (user2.Health <= 0)
                                    {
                                        exp1 += t;
                                        MessageBox.Show("Умер");
                                    }
                                }
                                else
                                {
                                    double t = user2.Health;
                                    user2.Health -= user1.Damage;
                                    exp1 += user1.Damage;
                                    if (user2.Health <= 0)
                                    {
                                        exp1 += t;
                                        MessageBox.Show("Умер");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cR1 >= cr1)
                            {
                                double t = user2.Health;
                                user2.Health -= user1.Damage * 2;
                                exp1 += user1.Damage;
                                if (user2.Health <= 0)
                                {
                                    exp1 += t;
                                    MessageBox.Show("Умер");
                                }
                            }
                            else
                            {
                                double t = user2.Health;
                                user2.Health -= user1.Damage;
                                exp1 += user1.Damage;
                                if (user2.Health <= 0)
                                {
                                    exp1 += t;
                                    MessageBox.Show("Умер");
                                }
                            }
                        }
                    }                                 
            }
            // 2 player
            if (Head1.IsChecked == true || Body1.IsChecked == true || Arms1.IsChecked == true || Legs1.IsChecked == true)
            {
                if (Def1.Text == "Head" || Def1.Text == "Body" || Def1.Text == "Arms" || Def1.Text == "Legs")
                {                    
                    YouBody2.Visibility = Visibility.Visible;
                    YouHead2.Visibility = Visibility.Visible;
                    YouLegs2.Visibility = Visibility.Visible;
                    YouArms2.Visibility = Visibility.Visible;

                    Body1.Visibility = Visibility.Hidden;
                    Head1.Visibility = Visibility.Hidden;
                    Legs1.Visibility = Visibility.Hidden;
                    Arms1.Visibility = Visibility.Hidden;

                    if (pD2 >= p2)
                    {
                        if (pE1 >= e1)
                        {
                            if (user2.pDamage <= user1.Evasion)
                            {
                                MessageBox.Show("Сработоло уклонение");
                            }
                            else
                            {
                                if (cR1 >= cr1)
                                {
                                    double t = user1.Health;
                                    user1.Health -= user2.Damage * 2;
                                    exp2 += user2.Damage;
                                    if (user1.Health <= 0)
                                    {
                                        exp2 += t;
                                        MessageBox.Show("Умер");
                                    }
                                }
                                else
                                {
                                    double t = user1.Health;
                                    user1.Health -= user2.Damage;
                                    exp2 += user2.Damage;
                                    if (user1.Health <= 0)
                                    {
                                        exp2 += t;
                                        MessageBox.Show("Умер");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cR1 >= cr1)
                            {
                                double t = user1.Health;
                                user1.Health -= user2.Damage * 2;
                                exp2 += user2.Damage;
                                if (user1.Health <= 0)
                                {
                                    exp2 += t;
                                    MessageBox.Show("Умер");
                                }
                            }
                            else
                            {
                                double t = user1.Health;
                                user1.Health -= user2.Damage;
                                exp2 += user2.Damage;
                                if (user1.Health <= 0)
                                {
                                    exp2 += t;
                                    MessageBox.Show("Умер");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (cR1 >= cr1)
                        {
                            double t = user1.Health;
                            user1.Health -= user2.Damage * 2;
                            exp2 += user2.Damage;
                            if (user1.Health <= 0)
                            {
                                exp2 += t;
                                MessageBox.Show("Умер");
                            }
                        }
                        else
                        {
                            double t = user1.Health;
                            user1.Health -= user2.Damage;
                            exp2 += user2.Damage;
                            if (user1.Health <= 0)
                            {
                                exp2 += t;
                                MessageBox.Show("Умер");
                            }
                        }
                    }
                }
            }
            if (Head1.IsChecked == true || Body1.IsChecked == true || Arms1.IsChecked == true || Legs1.IsChecked == true || Head1.IsChecked ==false|| Body1.IsChecked == false || Arms1.IsChecked == false || Legs1.IsChecked == false && YouHead2.IsChecked == true || YouBody2.IsChecked == true || YouArms2.IsChecked == true || YouLegs2.IsChecked == true && Def1.Text == string.Empty && Def2.Text == string.Empty)
            {
                MessageBox.Show("Выберите атаку или защиту");
            }
            prbHealth1.Value = user1.Health;
            prbHealth2.Value = user2.Health;
            prbMana1.Value = user1.Mana;
            prbMana2.Value = user2.Mana;


        }


        private void btnMagicAttack_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            double pD1 = user1.pDamage * 100;
            double pE1 = user1.Evasion * 100;
            double pD2 = user2.pDamage * 100;
            double pE2 = user2.Evasion * 100;
            double cR1 = user1.CrtChance * 100;
            double cR2 = user2.CrtChance * 100;
            double p1 = rnd.Next(0, 10001);
            user1.pDamage = pD1 / 100;
            double p2 = rnd.Next(0, 10001);
            user2.pDamage = pD2 / 100;
            double e1 = rnd.Next(0, 10001);
            user1.Evasion = pE1 / 100;
            double e2 = rnd.Next(0, 10001);
            user2.Evasion = pE2 / 100;
            double cr1 = rnd.Next(0, 10001);
            user1.CrtChance = cR1 / 100;
            double cr2 = rnd.Next(0, 10001);
            user2.CrtChance = cR2 / 100;
            //1 player
            if (YouHead2.IsChecked == true || YouBody2.IsChecked == true || YouArms2.IsChecked == true || YouLegs2.IsChecked == true)
            {
                if (Def2.Text == "Head" || Def2.Text == "Body" || Def2.Text == "Arms" || Def2.Text == "Legs")
                {
                    if (pD1 >= p1)
                    {
                        if (pE2 >= e2)
                        {
                            if (user1.pDamage <= user2.Evasion)
                            {
                                MessageBox.Show("Сработоло уклонение");
                            }
                            else
                            {
                                if (cR1 >= cr1)
                                {
                                    double t = user2.Health;
                                    user2.Health -= user1.MagicDamage * 2;
                                    exp1 += user1.Damage;
                                    if (user2.Health <= 0)
                                    {
                                        exp1 += t;
                                        MessageBox.Show("Умер");
                                    }
                                }
                                else
                                {
                                    double t = user1.Health;
                                    user2.Health -= user1.MagicDamage;
                                    exp1 += user1.Damage;
                                    if (user2.Health <= 0)
                                    {
                                        exp1 += t;
                                        MessageBox.Show("Умер");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cR1 >= cr1)
                            {
                                double t = user1.Health;
                                user2.Health -= user1.MagicDamage * 2;
                                exp1 += user1.Damage;
                                if (user2.Health <= 0)
                                {
                                    exp1 += t;
                                    MessageBox.Show("Умер");
                                }
                            }
                            else
                            {
                                double t = user1.Health;
                                user2.Health -= user1.MagicDamage;
                                exp1 += user1.Damage;
                                if (user2.Health <= 0)
                                {
                                    exp1 += t;
                                    MessageBox.Show("Умер");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (cR1 >= cr1)
                        {
                            double t = user1.Health;
                            user2.Health -= user1.MagicDamage * 2;
                            exp1 += user1.Damage;
                            if (user2.Health <= 0)
                            {
                                exp1 += t;
                                MessageBox.Show("Умер");
                            }
                        }
                        else
                        {
                            double t = user1.Health;
                            user2.Health -= user1.MagicDamage;
                            exp1 += user1.Damage;
                            if (user2.Health <= 0)
                            {
                                exp1 += t;
                                MessageBox.Show("Умер");
                            }
                        }
                    }
                }

            }
            // 2 player
            if (Head1.IsChecked == true || Body1.IsChecked == true || Arms1.IsChecked == true || Legs1.IsChecked == true)
            {
                if (Def1.Text == "Head" || Def1.Text == "Body" || Def1.Text == "Arms" || Def1.Text == "Legs")
                {
                    Arms1.IsChecked = false;
                    Body1.IsChecked = false;
                    Head1.IsChecked = false;
                    Legs1.IsChecked = false;

                    YouBody2.Visibility = Visibility.Visible;
                    YouHead2.Visibility = Visibility.Visible;
                    YouLegs2.Visibility = Visibility.Visible;
                    YouArms2.Visibility = Visibility.Visible;

                    Body1.Visibility = Visibility.Hidden;
                    Head1.Visibility = Visibility.Hidden;
                    Legs1.Visibility = Visibility.Hidden;
                    Arms1.Visibility = Visibility.Hidden;
                    if (pD2 >= p2)
                    {
                        if (pE1 >= e1)
                        {
                            if (user2.pDamage <= user1.Evasion)
                            {
                                MessageBox.Show("Сработоло уклонение");
                            }
                            else
                            {
                                if (cR1 >= cr1)
                                {
                                    double t = user1.Health;
                                    user1.Health -= user2.MagicDamage * 2;
                                    exp2 += user2.Damage;
                                    if (user1.Health <= 0)
                                    {
                                        exp2 += t;
                                        MessageBox.Show("Умер");
                                    }
                                }
                                else
                                {
                                    double t = user1.Health;
                                    user1.Health -= user2.MagicDamage;
                                    exp2 += user2.Damage;
                                    if (user1.Health <= 0)
                                    {
                                        exp2 += t;
                                        MessageBox.Show("Умер");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cR1 >= cr1)
                            {
                                double t = user1.Health;
                                user1.Health -= user2.MagicDamage * 2;
                                exp2 += user2.Damage;
                                if (user1.Health <= 0)
                                {
                                    exp2 += t;
                                    MessageBox.Show("Умер");
                                }
                            }
                            else
                            {
                                double t = user1.Health;
                                user1.Health -= user2.MagicDamage;
                                exp2 += user2.Damage;
                                if (user1.Health <= 0)
                                {
                                    exp2 += t;
                                    MessageBox.Show("Умер");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (cR1 >= cr1)
                        {
                            double t = user1.Health;
                            user1.Health -= user2.MagicDamage * 2;
                            exp2 += user2.Damage;
                            if (user1.Health <= 0)
                            {
                                exp2 += t;
                                MessageBox.Show("Умер");
                            }
                        }
                        else
                        {
                            double t = user1.Health;
                            user1.Health -= user2.MagicDamage;
                            exp2 += user2.Damage;
                            if (user1.Health <= 0)
                            {
                                exp2 += t;
                                MessageBox.Show("Умер");
                            }
                        }
                    }
                }

            }
            prbHealth1.Value = user1.Health;
            prbHealth2.Value = user2.Health;
            prbMana1.Value = user1.Health;
            prbMana2.Value = user2.Mana;
        }


    }
}
        
    


