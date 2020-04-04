using System;
using System.Drawing;
using System.Windows.Forms;

namespace TIC_TAC_TOE
{
    public partial class Game : Form
    {
        private string userToken = string.Empty;
        private string userClicked = "";
        private string pcClicked = "";
        public Game()
        {
            InitializeComponent2();
            textBox1.Focus();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("X");
            comboBox1.Items.Add("O");
            comboBox1.SelectedIndex = 0;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            StartGame("0", "0");
        }

        private void ButtonA_Click(object sender, EventArgs e)
        {
            UpdateUserButtonDetails(buttonA, "A");
        }

        private void ButtonB_Click(object sender, EventArgs e)
        {
            UpdateUserButtonDetails(buttonB, "B");
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            UpdateUserButtonDetails(buttonC, "C");
        }

        private void ButtonD_Click(object sender, EventArgs e)
        {
            UpdateUserButtonDetails(buttonD, "D");
        }

        private void ButtonE_Click(object sender, EventArgs e)
        {
            UpdateUserButtonDetails(buttonE, "E");
        }

        private void ButtonF_Click(object sender, EventArgs e)
        {
            UpdateUserButtonDetails(buttonF, "F");
        }

        private void ButtonG_Click(object sender, EventArgs e)
        {
            UpdateUserButtonDetails(buttonG, "G");
        }

        private void ButtonH_Click(object sender, EventArgs e)
        {
            UpdateUserButtonDetails(buttonH, "H");
        }

        private void ButtonI_Click(object sender, EventArgs e)
        {
            UpdateUserButtonDetails(buttonI, "I");
        }

        private void UpdateUserButtonDetails(Button button, string selectedButton)
        {
            button.BackColor = Color.GreenYellow;
            button.FlatStyle = FlatStyle.Flat;
            button.Text = userToken;
            button.Enabled = false;
            userClicked += selectedButton;
            ComputerTurn();
        }

        private string getPCToken()
        {
            return ("XO").Replace(userToken, "");
        }

        private void ComputerTurn()
        {
            CheckScore(userClicked, true);
            {
                if (CheckForPcWinChance(pcClicked, false) == false)
                    CheckForPcWinChance(userClicked, true);
            }
        }

        public bool SelectToken(string token)
        {
            if (SelectableTokenForPc(token) == false)
            {
                return false;
            }
            else
            {
                if (CheckForPcWinChance(pcClicked, false) == false)
                    SelectButton(token);
                return true;
            }
        }

        private bool CheckForPcWinChance(string pcClick, bool check)
        {
            bool flag = true;
            for (int i = 0; i < Token.PossibleMoves.Length; i++)
            {
                string key = Token.PossibleMoves[i];
                flag = true;
                for (int j = 0; j < key.Length; j++)
                {
                    if (!(pcClick.IndexOf(key[j]) >= 0))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    if (SelectableTokenForPc(Token.RemainingMoves[i]) == false)
                        continue;
                    else
                    {
                        SelectButton(Token.RemainingMoves[i]);
                        return true;
                    }
                }
            }
            if (!flag && check)
            {
                string allToken = "ABCDEFGHI";
                Random r = new Random();
                while (true)
                {
                    int index = r.Next(0, 9);
                    if (SelectToken(allToken[index].ToString()) == false)
                        continue;
                    else
                        break;
                }
            }
            return false;
        }

        private void SelectButton(string selectedButton)
        {
            switch (selectedButton)
            {
                case "A":
                    {
                        UpdatePcButtonDetails(buttonA, selectedButton);
                    }
                    break;
                case "B":
                    {
                        UpdatePcButtonDetails(buttonB, selectedButton);
                    }
                    break;
                case "C":
                    {
                        UpdatePcButtonDetails(buttonC, selectedButton);
                    }
                    break;
                case "D":
                    {
                        UpdatePcButtonDetails(buttonD, selectedButton);
                    }
                    break;
                case "E":
                    {
                        UpdatePcButtonDetails(buttonE, selectedButton);
                    }
                    break;
                case "F":
                    {
                        UpdatePcButtonDetails(buttonF, selectedButton);
                    }
                    break;
                case "G":
                    {
                        UpdatePcButtonDetails(buttonG, selectedButton);
                    }
                    break;
                case "H":
                    {
                        UpdatePcButtonDetails(buttonH, selectedButton);
                    }
                    break;
                case "I":
                    {
                        UpdatePcButtonDetails(buttonI, selectedButton);
                    }
                    break;

            }
            CheckScore(pcClicked, false);
        }

        private void UpdatePcButtonDetails(Button button, string selectedButton)
        {
            button.BackColor = Color.Red;
            button.FlatStyle = FlatStyle.Flat;
            button.Text = getPCToken();
            pcClicked += selectedButton;
            button.Enabled = false;
        }

        private void CheckScore(string token, bool user)
        {
            foreach (string s in Token.Strike)
            {
                bool flag = true;
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(token.IndexOf(s[i]) >= 0))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    if (user)
                    {
                        label5.Text = ((Convert.ToInt32(label5.Text)) + 10) + "";
                        MessageBox.Show(label1.Text + " WON", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        label8.Text = ((Convert.ToInt32(label8.Text)) + 10) + "";
                        MessageBox.Show("PC WON", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    StartGame(label8.Text, label5.Text);
                    break;
                }
                if (userClicked.Length + pcClicked.Length == 9)
                {
                    MessageBox.Show("Game Draw", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartGame(label8.Text, label5.Text);
                    break;
                }
            }
        }

        private bool SelectableTokenForPc(string newToken)
        {
            if (userClicked.IndexOf(newToken) >= 0)
            {
                return false;
            }
            if (pcClicked.IndexOf(newToken) >= 0)
            {
                return false;
            }
            return true;
        }

        private void StartGame(string pcScore, string userScore)
        {
            string name = textBox1.Text;
            name = name.Trim();
            if (name.Equals(""))
            {
                return;
            }
            userClicked = "";
            pcClicked = "";
            userToken = comboBox1.SelectedItem.ToString();
            this.Controls.Clear();
            InitializeComponent();
            label1.Text = name;
            label4.Text = "Pc : ";
            label5.Text = userScore;
            label8.Text = pcScore;
        }

        private void ReStartGameButton_Click(object sender, EventArgs e)
        {
            StartGame("0", "0");
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            StartGame(label8.Text, label5.Text);
        }
    }
}
