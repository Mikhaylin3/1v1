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
                user2.Exp= b.Exp;
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
                user1.Exp = t.Exp;
                Health1.Text = user1.Health.ToString();
                txtMana1.Text = user1.Mana.ToString();
                prbHealth1.Maximum = user1.Health;
                prbHealth1.Value = user1.Health;
                prbMana1.Maximum = user1.Mana;
                prbMana1.Value = user1.Mana;
            }
                btnHeal2.Visibility= Visibility.Hidden;
                Exit.Visibility = Visibility.Hidden;
                Body1.Visibility = Visibility.Hidden;
                Head1.Visibility = Visibility.Hidden;
                Legs1.Visibility = Visibility.Hidden;
                Arms1.Visibility = Visibility.Hidden;
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
            if (YouHead2.IsChecked == true || YouBody2.IsChecked == true || YouArms2.IsChecked == true || YouLegs2.IsChecked == true )
            {
                if (Def2.Text == "Head" || Def2.Text == "Body" || Def2.Text == "Arms" || Def2.Text == "Legs" && Def1.Text == "Head" || Def1.Text == "Body" || Def1.Text == "Arms" || Def1.Text == "Legs")
                {
                    
                    if (pD1 >= p1)
                        {
                        YouBody2.Visibility = Visibility.Hidden;
                        YouHead2.Visibility = Visibility.Hidden;
                        YouLegs2.Visibility = Visibility.Hidden;
                        YouArms2.Visibility = Visibility.Hidden;
                        btnHeal1.Visibility = Visibility.Hidden;

                        Body1.Visibility = Visibility.Visible;
                        Head1.Visibility = Visibility.Visible;
                        Legs1.Visibility = Visibility.Visible;
                        Arms1.Visibility = Visibility.Visible;
                        btnHeal2.Visibility = Visibility.Visible;

                        YouBody2.IsChecked = false;
                        YouHead2.IsChecked = false;
                        YouArms2.IsChecked = false;
                        YouLegs2.IsChecked = false;
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
                                        if (user2.Health <= 0)
                                        {
                                            exp1 += t;
                                            lvlUP1();
                                         MessageBox.Show("Умер");
                                            return;
                                        }
                                        exp1 += user1.Damage;
                                        lvlUP1();
                                    }
                                    else
                                    {
                                        double t = user2.Health;
                                        user2.Health -= user1.Damage;
                                        if (user2.Health <= 0)
                                        {
                                            exp1 += t;
                                            lvlUP1();
                                            MessageBox.Show("Умер");
                                        return;
                                        }
                                        exp1 += user1.Damage;
                                        lvlUP1();
                                    }
                                }
                            }
                            else
                            {
                                if (cR1 >= cr1)
                                {
                                    double t = user2.Health;
                                    user2.Health -= user1.Damage * 2;
                                    if (user2.Health <= 0)
                                    {
                                        exp1 += t;
                                        lvlUP1();
                                        MessageBox.Show("Умер");
                                        return;
                                    }
                                    exp1 += user1.Damage;
                                    lvlUP1();
                                }
                                else
                                {
                                    double t = user2.Health;
                                    user2.Health -= user1.Damage;
                                    if (user2.Health <= 0)
                                    {
                                        exp1 += t;
                                        lvlUP1();
                                        MessageBox.Show("Умер");
                                        return;
                                    }
                                    exp1 += user1.Damage;
                                    lvlUP1();
                                }
                        }
                        }
                        else
                        {
                        YouBody2.Visibility = Visibility.Hidden;
                        YouHead2.Visibility = Visibility.Hidden;
                        YouLegs2.Visibility = Visibility.Hidden;
                        YouArms2.Visibility = Visibility.Hidden;
                        btnHeal1.Visibility = Visibility.Hidden;

                        Body1.Visibility = Visibility.Visible;
                        Head1.Visibility = Visibility.Visible;
                        Legs1.Visibility = Visibility.Visible;
                        Arms1.Visibility = Visibility.Visible;
                        btnHeal2.Visibility = Visibility.Visible;

                        YouBody2.IsChecked = false;
                        YouHead2.IsChecked = false;
                        YouArms2.IsChecked = false;
                        YouLegs2.IsChecked = false;
                        if (cR1 >= cr1)
                            {
                                double t = user2.Health;
                                user2.Health -= user1.Damage * 2;                               
                                if (user2.Health <= 0)
                                {
                                    exp1 += t;
                                    lvlUP1();
                                    MessageBox.Show("Умер");
                                return;
                                }
                                exp1 += user1.Damage;
                                lvlUP1();
                            }
                            else
                            {
                                double t = user2.Health;
                                user2.Health -= user1.Damage;                                
                                if (user2.Health <= 0)
                                {
                                    exp1 += t;
                                    lvlUP1();
                                    MessageBox.Show("Умер");
                                    return;
                                }
                                exp1 += user1.Damage;
                                lvlUP1();
                            }
                        }
                    }
                else
                {
                    MessageBox.Show("Выберите часть тела для защиты или для атаки");
                }
            }
            // 2 player
            else if (Head1.IsChecked == true || Body1.IsChecked == true || Arms1.IsChecked == true || Legs1.IsChecked == true )
            {
                if (Def1.Text == "Head" || Def1.Text == "Body" || Def1.Text == "Arms" || Def1.Text == "Legs" && Def2.Text == "Head" || Def2.Text == "Body" || Def2.Text == "Arms" || Def2.Text == "Legs")
                {                    
                    if (pD2 >= p2)
                    {
                        YouBody2.Visibility = Visibility.Visible;
                        YouHead2.Visibility = Visibility.Visible;
                        YouLegs2.Visibility = Visibility.Visible;
                        YouArms2.Visibility = Visibility.Visible;

                        Body1.Visibility = Visibility.Hidden;
                        Head1.Visibility = Visibility.Hidden;
                        Legs1.Visibility = Visibility.Hidden;
                        Arms1.Visibility = Visibility.Hidden;

                        Body1.IsChecked = false;
                        Head1.IsChecked = false;
                        Legs1.IsChecked = false;
                        Arms1.IsChecked = false;
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
                                    if (user1.Health <= 0)
                                    {
                                        lvlUP2();
                                        exp2 += t;
                                        MessageBox.Show("Умер");
                                        return;
                                    }
                                    lvlUP2();
                                    exp2 += user2.Damage;
                                }
                                else
                                {
                                    double t = user1.Health;
                                    user1.Health -= user2.Damage;
                                    
                                    if (user1.Health <= 0)
                                    {
                                        lvlUP2();
                                        exp2 += t;
                                        MessageBox.Show("Умер");
                                        return;
                                    }
                                    lvlUP2();
                                    exp2 += user2.Damage;
                                }
                            }
                        }
                        else
                        {
                            if (cR1 >= cr1)
                            {
                                double t = user1.Health;
                                user1.Health -= user2.Damage * 2;
                                if (user1.Health <= 0)
                                {
                                    lvlUP2();
                                    exp2 += t;
                                    MessageBox.Show("Умер");
                                    return;
                                }
                                exp2 += user2.Damage;
                                lvlUP2();
                            }
                            else
                            {
                                double t = user1.Health;
                                user1.Health -= user2.Damage;
                                if (user1.Health <= 0)
                                {
                                    lvlUP2();
                                    exp2 += t;
                                    MessageBox.Show("Умер");
                                    return;
                                }
                                exp2 += user2.Damage;
                                lvlUP2();
                            }
                        }
                    }
                    else
                    {
                        YouBody2.Visibility = Visibility.Visible;
                        YouHead2.Visibility = Visibility.Visible;
                        YouLegs2.Visibility = Visibility.Visible;
                        YouArms2.Visibility = Visibility.Visible;

                        Body1.Visibility = Visibility.Hidden;
                        Head1.Visibility = Visibility.Hidden;
                        Legs1.Visibility = Visibility.Hidden;
                        Arms1.Visibility = Visibility.Hidden;

                        Body1.IsChecked = false;
                        Head1.IsChecked = false;
                        Legs1.IsChecked = false;
                        Arms1.IsChecked = false;
                        if (cR1 >= cr1)
                        {
                            double t = user1.Health;
                            user1.Health -= user2.Damage * 2;
                            exp2 += user2.Damage;
                            if (user1.Health <= 0)
                            {
                                exp2 += t;
                                lvlUP2();
                                MessageBox.Show("Умер");
                                return;
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
                                lvlUP2();
                                MessageBox.Show("Умер");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите часть тела для защиты или для атаки");
                }
            }
            else
            {
                MessageBox.Show("Выберите атаку ");
            }
            prbHealth1.Value = user1.Health;
            prbHealth2.Value = user2.Health;
            prbMana1.Value = user1.Mana;
            prbMana2.Value = user2.Mana;


        }
        int lvl2 = 2;
        int lvl3 = 3;
        int lvl4 = 4;
        int lvl5 = 5;
        double r = 300;
        double e = 800;
        double k = 1800;
        double p = 3000;


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
            if (YouHead2.IsChecked == true || YouBody2.IsChecked == true || YouArms2.IsChecked == true || YouLegs2.IsChecked == true )
            {
                if (Def1.Text == "Head" || Def1.Text == "Body" || Def1.Text == "Arms" || Def1.Text == "Legs" && Def2.Text == "Head" || Def2.Text == "Body" || Def2.Text == "Arms" || Def2.Text == "Legs")
                {
                    
                    if(user1.Mana- user1.ManaCost > 0) 
                    {
                        YouBody2.Visibility = Visibility.Hidden;
                        YouHead2.Visibility = Visibility.Hidden;
                        YouLegs2.Visibility = Visibility.Hidden;
                        YouArms2.Visibility = Visibility.Hidden;
                        btnHeal1.Visibility = Visibility.Hidden;

                        Body1.Visibility = Visibility.Visible;
                        Head1.Visibility = Visibility.Visible;
                        Legs1.Visibility = Visibility.Visible;
                        Arms1.Visibility = Visibility.Visible;
                        btnHeal2.Visibility = Visibility.Visible;

                        YouBody2.IsChecked = false;
                        YouHead2.IsChecked = false;
                        YouArms2.IsChecked = false;
                        YouLegs2.IsChecked = false;
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
                                user1.Mana -= user1.ManaCost;
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
                        MessageBox.Show("Вам не хватает маны(поменяйте атаку)");
                    }

                }
                else
                {
                    MessageBox.Show("Выберите часть тела для защиты или для атаки");
                }
            }

            // 2 player
            else if (Head1.IsChecked == true || Body1.IsChecked == true || Arms1.IsChecked == true || Legs1.IsChecked == true )
            {
                if (Def1.Text == "Head" || Def1.Text == "Body" || Def1.Text == "Arms" || Def1.Text == "Legs" && Def2.Text == "Head" || Def2.Text == "Body" || Def2.Text == "Arms" || Def2.Text == "Legs")
                {
                    if (user2.Mana - user2.ManaCost > 0)
                    {
                        YouBody2.Visibility = Visibility.Visible;
                        YouHead2.Visibility = Visibility.Visible;
                        YouLegs2.Visibility = Visibility.Visible;
                        YouArms2.Visibility = Visibility.Visible;
                        btnHeal1.Visibility = Visibility.Visible;

                        Body1.Visibility = Visibility.Hidden;
                        Head1.Visibility = Visibility.Hidden;
                        Legs1.Visibility = Visibility.Hidden;
                        Arms1.Visibility = Visibility.Hidden;
                        btnHeal2.Visibility = Visibility.Hidden;

                        Body1.IsChecked = false;
                        Head1.IsChecked = false;
                        Legs1.IsChecked = false;
                        Arms1.IsChecked = false;

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
                                            Final();
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
                                user2.Mana -= user2.ManaCost;
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
                                user2.Mana -= user2.ManaCost;
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
                        MessageBox.Show("Вам не хватает маны(поменяйте атаку)");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите часть тела для защиты или для атаки");
                }

            }
            else
            {
                MessageBox.Show("Выберите атаку ");
            }
            prbHealth1.Value = user1.Health;
            prbHealth2.Value = user2.Health;
            prbMana1.Value = user1.Mana;
            prbMana2.Value = user2.Mana;
        }
        void lvlUP1()
        {
            
            if(lvl2 > user1.Lvl)
            {
                user1.Exp = exp2;
                if(user1.Exp >= r) 
                {
                    user1.Point += 2;
                    user1.Lvl += 1;
                    user1.Exp = exp2;
                    user1.Exp -= r;
                }
            }
            else if (lvl3 > user1.Lvl) 
            {
                user1.Exp = exp2;
                if (user1.Exp >= e)
                {
                    user1.Point += 3;
                    user1.Lvl += 1;
                    user1.Exp = exp2;
                    user1.Exp -= e;
                }
            }
            else if (lvl4 > user1.Lvl)
            {
                user1.Exp = exp2;
                if (user1.Exp >= k)
                {
                    user1.Point += 2;
                    user1.Lvl += 1;
                    user1.Exp = exp2;
                    user1.Exp -= k;
                }
            }
            else if( lvl5 > user1.Lvl)
            {
                user1.Exp = exp2;
                if (user1.Exp >= p)
                {
                    user1.Point += 5;
                    user1.Exp = exp2;
                }
            }                                     
        }
        void lvlUP2()
        {

            if (lvl2 > user2.Lvl)
            {
                user2.Exp = exp2;
                if (user2.Exp >= r)
                {
                    user2.Point += 2;
                    user2.Lvl += 1;
                    user2.Exp = exp2;
                    user2.Exp -= r;
                }
            }
            else if (lvl3 > user2.Lvl)
            {
                user2.Exp = exp2;
                if (user2.Exp >= e)
                {
                    user2.Point += 3;
                    user2.Lvl += 1;
                    user2.Exp = exp2;
                    user2.Exp -= e;
                }
            }
            else if (lvl4 > user2.Lvl)
            {
                user2.Exp = exp2;
                if (user2.Exp >= k)
                {
                    user2.Point += 2;
                    user2.Lvl += 1;
                    user2.Exp = exp2;
                    user2.Exp -= k;
                }
            }
            else if (lvl5 > user2.Lvl)
            {
                user2.Exp = exp2;
                if (user2.Exp >= p)
                {
                    user2.Point += 5;
                    user2.Exp = exp2;
                }
            }
        }

        private void btnHeal1_Click(object sender, RoutedEventArgs e)
        {
            if(user1.Mana - user1.ManaCost > 0)
            {
                YouBody2.Visibility = Visibility.Hidden;
                YouHead2.Visibility = Visibility.Hidden;
                YouLegs2.Visibility = Visibility.Hidden;
                YouArms2.Visibility = Visibility.Hidden;
                btnHeal1.Visibility = Visibility.Hidden;

                Body1.Visibility = Visibility.Visible;
                Head1.Visibility = Visibility.Visible;
                Legs1.Visibility = Visibility.Visible;
                Arms1.Visibility = Visibility.Visible;
                btnHeal2.Visibility = Visibility.Visible;

                YouBody2.IsChecked = false;
                YouHead2.IsChecked = false;
                YouArms2.IsChecked = false;
                YouLegs2.IsChecked = false;
                double l = user1.Mana;
                double h = l % user1.ManaCost;
                user1.Health += user1.ManaCost * h;
                user1.Mana -= user1.ManaCost * h;
            }
            else
            {
                MessageBox.Show("Не хватает маны");
            }
            prbHealth1.Value = user1.Health;
            prbHealth2.Value = user2.Health;
            prbMana1.Value = user1.Mana;
            prbMana2.Value = user2.Mana;
        }

        private void btnHeal2_Click(object sender, RoutedEventArgs e)
        {
            if (user2.Mana - user2.ManaCost > 0)
            {
                YouBody2.Visibility = Visibility.Visible;
                YouHead2.Visibility = Visibility.Visible;
                YouLegs2.Visibility = Visibility.Visible;
                YouArms2.Visibility = Visibility.Visible;
                btnHeal1.Visibility= Visibility.Visible;

                Body1.Visibility = Visibility.Hidden;
                Head1.Visibility = Visibility.Hidden;
                Legs1.Visibility = Visibility.Hidden;
                Arms1.Visibility = Visibility.Hidden;
                btnHeal2.Visibility= Visibility.Hidden;

                Body1.IsChecked = false;
                Head1.IsChecked = false;
                Legs1.IsChecked = false;
                Arms1.IsChecked = false;

                double l = user2.Mana;
                double h = l % user2.ManaCost;
                user2.Health += user2.ManaCost * h;
                user2.Mana -= user2.ManaCost * h;
            }
            else
            {
                MessageBox.Show("Не хватает маны");
            }
            prbHealth1.Value = user1.Health;
            prbHealth2.Value = user2.Health;
            prbMana1.Value = user1.Mana;
            prbMana2.Value = user2.Mana;
        }

        void Final()
        {
            Exit.Visibility = Visibility.Visible;
            Body1.Visibility = Visibility.Hidden;
            Head1.Visibility = Visibility.Hidden;
            Legs1.Visibility = Visibility.Hidden;
            Arms1.Visibility = Visibility.Hidden;
            btnHeal2.Visibility = Visibility.Hidden;
            YouBody2.Visibility = Visibility.Hidden;
            YouHead2.Visibility = Visibility.Hidden;
            YouLegs2.Visibility = Visibility.Hidden;
            YouArms2.Visibility = Visibility.Hidden;
            btnHeal1.Visibility = Visibility.Hidden;
            btnAttack.Visibility = Visibility.Hidden;
            btnMagicAttack.Visibility = Visibility.Hidden;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
        
    


