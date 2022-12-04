using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1v1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static User user1 = new User();
        public static User user2 = new User();

        private void Save_click(object sender, RoutedEventArgs e)
        {
            string t = txtName12.Text;
            CalcParam();
            if (txtName12.Text != null)
            {
                user1 = new User()
                {
                    Lvl = Convert.ToInt32(txtLvl1.Text),
                    Point = Convert.ToInt32(txtPoint1.Text),
                    Strenght = Convert.ToInt32(txtStrenght1.Text),
                    Dexterity = Convert.ToInt32(txtDexterity1.Text),
                    Constitution = Convert.ToInt32(txtConstitution1.Text),
                    Intellengence = Convert.ToInt32(txtIntellengence1.Text),
                    Luck = Convert.ToInt32(txtLuck1.Text),
                    CrtChance = user1.CrtChance,
                    pDamage = user1.pDamage,
                    Evasion = user1.Evasion,
                    MagicDamage = user1.MagicDamage,
                    ManaCost = user1.ManaCost,
                    Damage = user1.Damage,
                    Names = t,
                    Mana = user1.Mana,
                };
                UserData.user1.Add(user1);
                user2 = new User()
                {
                    Names = txtName2.Text,
                    Lvl = Convert.ToInt32(txtLvl2.Text),
                    Point = Convert.ToInt32(txtPoint2.Text),
                    Strenght = Convert.ToInt32(txtStrenght2.Text),
                    Dexterity = Convert.ToInt32(txtDexterity2.Text),
                    Constitution = Convert.ToInt32(txtConstitution2.Text),
                    Intellengence = Convert.ToInt32(txtIntellengence2.Text),
                    Luck = Convert.ToInt32(txtLuck2.Text),
                    CrtChance = user2.CrtChance,
                    pDamage = user2.pDamage,
                    Evasion = user2.Evasion,
                    MagicDamage = user2.MagicDamage,
                    ManaCost = user2.ManaCost,
                    Damage = user2.Damage,
                    Mana = user2.Mana,
                };
                UserData.user2.Add(user2);
                FightWindow fightWindow = new FightWindow();               
                fightWindow.Show();
            }
        }
        void CalcParam()
        {
            // 1 player           
            if(Convert.ToDouble(txtStrenght1.Text) - Convert.ToDouble(txtStrenght2.Text) > 0)
            {
                user1.pDamage = (Convert.ToDouble(txtStrenght1.Text) - Convert.ToDouble(txtStrenght2.Text))* 0.05;
            }
            else
            {
                user1.pDamage = 0;
            }
            if ((Convert.ToDouble(txtDexterity1.Text) - Convert.ToDouble(txtDexterity2.Text)) > 0)
            {
                user1.Evasion = (Convert.ToDouble(txtDexterity1.Text) - Convert.ToDouble(txtDexterity2.Text)) * 0.1;
            }
            else
            {
                user1.Evasion = 0;
            }
            if ((Convert.ToDouble(txtLuck1.Text) - Convert.ToDouble(txtLuck2.Text)) > 0)
            {
                user1.CrtChance = (Convert.ToDouble(txtLuck1.Text) - Convert.ToDouble(txtLuck2.Text)) * 0.1;
            }
            else
            {
                user1.CrtChance = 0;
            }
            if (Convert.ToDouble(txtStrenght1.Text) >= 1)
            {
                user1.Damage = Convert.ToDouble(txtStrenght1.Text) * 1;
            }
            if (Convert.ToDouble(txtConstitution1.Text) >= 1)
            {
                user1.Health = Convert.ToDouble(txtConstitution1.Text) * 5;
            }
            if(Convert.ToDouble(txtIntellengence1.Text) >=1)
            {
                user1.MagicDamage = Convert.ToDouble(txtIntellengence1.Text) * 2;
            }
            if(Convert.ToDouble(txtIntellengence1.Text) >=1)
            {
                user1.Mana = Convert.ToDouble(txtIntellengence1.Text) * 7;
            }
            // 2 player
            if (Convert.ToDouble(txtStrenght2.Text) - Convert.ToDouble(txtStrenght1.Text) > 0)
            {
                user2.pDamage = (Convert.ToDouble(txtStrenght2.Text) - Convert.ToDouble(txtStrenght1.Text)) * 0.05;
            }
            else
            {
                user2.pDamage = 0;
            }
            if ((Convert.ToDouble(txtDexterity2.Text) - Convert.ToDouble(txtDexterity1.Text)) > 0)
            {
                user2.Evasion = (Convert.ToDouble(txtDexterity2.Text) - Convert.ToDouble(txtDexterity1.Text)) * 0.1;
            }
            else
            {
                user2.Evasion = 0;
            }
            if ((Convert.ToDouble(txtLuck2.Text) - Convert.ToDouble(txtLuck1.Text)) > 0)
            {
                user2.CrtChance = (Convert.ToDouble(txtLuck2.Text) - Convert.ToDouble(txtLuck1.Text)) * 0.1;
            }
            else
            {
                user2.CrtChance = 0;
            }
            if (Convert.ToDouble(txtStrenght2.Text) >= 1)
            {
                user2.Damage = Convert.ToDouble(txtStrenght2.Text) * 1;
            }
            if (Convert.ToDouble(txtConstitution2.Text) >= 1)
            {
                user2.Health = Convert.ToDouble(txtConstitution2.Text) * 5;
            }
            if (Convert.ToDouble(txtIntellengence1.Text) >= 1)
            {
                user2.MagicDamage = Convert.ToDouble(txtIntellengence2.Text) * 2;
            }
            if (Convert.ToDouble(txtIntellengence1.Text) >= 1)
            {
                user2.Mana = Convert.ToDouble(txtIntellengence2.Text) * 7;
            }


        }
        private void TextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char inp = e.Text[0];
            if (inp < 'A' || inp > 'Z')
                e.Handled = true;
        }


        private void AddStrenght1_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint1.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtStrenght1.Text);
                s += 1;
                txtStrenght1.Text = s.ToString();
                txtPoint1.Text = a.ToString();
            }
        }

        private void AddConstitutiont1_Click(object sender, RoutedEventArgs e)
        {

            int a = Convert.ToInt32(txtPoint1.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtConstitution1.Text);
                s += 1;
                txtConstitution1.Text = s.ToString();
                txtPoint1.Text = a.ToString();
            }
        }

        private void AddIntellengence1_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint1.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtIntellengence1.Text);
                s += 1;
                txtIntellengence1.Text = s.ToString();
                txtPoint1.Text = a.ToString();
            }
        }

        private void AddDexterityt1_Click(object sender, RoutedEventArgs e)
        {

            int a = Convert.ToInt32(txtPoint1.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtDexterity1.Text);
                s += 1;
                txtDexterity1.Text = s.ToString();
                txtPoint1.Text = a.ToString();
            }
        }

        private void DecreaseStrenght1_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint1.Text);
            int s = Convert.ToInt32(txtStrenght1.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtStrenght1.Text = s.ToString();
                txtPoint1.Text = a.ToString();
            }
            else
            {
                txtStrenght1.Text = s.ToString();
            }
        }

        private void DecreaseConstitution1_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint1.Text);
            int s = Convert.ToInt32(txtConstitution1.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtConstitution1.Text = s.ToString();
                txtPoint1.Text = a.ToString();
            }
            else
            {
                txtConstitution1.Text = s.ToString();
            }
        }

        private void DecreaseIntellengence1_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint1.Text);
            int s = Convert.ToInt32(txtIntellengence1.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtIntellengence1.Text = s.ToString();
                txtPoint1.Text = a.ToString();

            }
            else
            {
                txtIntellengence1.Text = s.ToString();
            }
        }

        private void DecreaseDexterity1_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint1.Text);
            int s = Convert.ToInt32(txtDexterity1.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtDexterity1.Text = s.ToString();
                txtPoint1.Text = a.ToString();
            }
            else
            {
                txtDexterity1.Text = s.ToString();
            }
        }

        private void AddStrenght2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint2.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtStrenght2.Text);
                s += 1;
                txtStrenght2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }
        }

        private void AddConstitutiont2_Click(object sender, RoutedEventArgs e)
        {

            int a = Convert.ToInt32(txtPoint2.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtConstitution2.Text);
                s += 1;
                txtConstitution2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }
        }

        private void AddIntellengence2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint2.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtIntellengence2.Text);
                s += 1;
                txtIntellengence2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }
        }

        private void AddDexterityt2_Click(object sender, RoutedEventArgs e)
        {

            int a = Convert.ToInt32(txtPoint2.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtDexterity2.Text);
                s += 1;
                txtDexterity2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }
        }

        private void DecreaseStrenght2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint2.Text);
            int s = Convert.ToInt32(txtStrenght2.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtStrenght2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }
        }

        private void DecreaseConstitution2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint2.Text);
            int s = Convert.ToInt32(txtConstitution2.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtConstitution2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }
        }

        private void DecreaseIntellengence2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint2.Text);
            int s = Convert.ToInt32(txtIntellengence2.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtIntellengence2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }

        }
        private void AddLuck2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint2.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtLuck2.Text);
                s += 1;
                txtLuck2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }
        }

        private void DecreaseLuck2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint2.Text);
            int s = Convert.ToInt32(txtLuck2.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtLuck2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }
        }
        private void DecreaseDexterity2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint2.Text);
            int s = Convert.ToInt32(txtDexterity2.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtDexterity2.Text = s.ToString();
                txtPoint2.Text = a.ToString();
            }

        }

        private void AddLuck1_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint1.Text);
            if (a > 1)
            {
                a -= 1;
                int s = Convert.ToInt32(txtLuck1.Text);
                s += 1;
                txtLuck1.Text = s.ToString();
                txtPoint1.Text = a.ToString();
            }
        }

        private void DecreaseLuck1_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(txtPoint1.Text);
            int s = Convert.ToInt32(txtLuck1.Text);
            if (s > 1)
            {
                a += 1;
                s -= 1;
                txtLuck1.Text = s.ToString();
                txtPoint1.Text = a.ToString();
            }
        }


    }
}
