using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace XAXB00
{
    public partial class MainForm : Form
    {
        private XaXbEngine xaxb;
        private int counter;
        // AgainButton Click 事件
        private void AgainButton_Click(object sender, EventArgs e)
        {
            // 重新初始化遊戲
            ResultLabel.Text = "";
            xaxb.GenerateLuckyNumber();
            counter = 0;
            GuessButton.Enabled = true;
            AgainButton.Enabled = false;
            RestartButton.Enabled = false;
        }

        // RestartButton Click 事件
        private void RestartButton_Click(object sender, EventArgs e)
        {
            // 重新開始遊戲
            ResultLabel.Text = "";
            UserNumberTextBox.Text = "";
            counter = 0;
            GuessButton.Enabled = true;
            AgainButton.Enabled = false;
            RestartButton.Enabled = false;
        }
        public MainForm()
        {
            InitializeComponent();
            xaxb = new XaXbEngine();
            counter = 0;
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            string userNum = UserNumberTextBox.Text;
            if (xaxb.IsLegal(userNum))
            {
                counter++;
                string result = xaxb.GetResult(userNum);
                ResultLabel.Text += $"{userNum} : {result}, 猜測次數 : {counter}\n";
                if (result == "3 A 0 B")
                {
                    // 清空 ResultLabel 並設置為 "恭喜你，猜對了!"，而不是追加
                    ResultLabel.Text = $"恭喜你，猜對了!  猜測次數：{counter}";
                    GuessButton.Enabled = false;
                    AgainButton.Enabled = true; // 啟用 "再玩一次" 按鈕
                    RestartButton.Enabled = true; // 啟用 "重來" 按鈕
                    return; // 終止事件的執行
                }
            }
            else
            {
                ResultLabel.Text = "輸入的資料重複或長度不對，請重新輸入\n";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }

    internal class XaXbEngine
    {
        private string luckyNumber;

        public XaXbEngine()
        {
            GenerateLuckyNumber();
        }

        public void GenerateLuckyNumber()
        {
            Random random = new Random();
            int[] temp = new int[3];
            temp[0] = random.Next(0, 9);
            temp[1] = random.Next(0, 9);
            temp[2] = random.Next(0, 9);

            // Ensure no duplicate digits
            while (temp[0] == temp[1] || temp[0] == temp[2] || temp[1] == temp[2])
            {
                temp[1] = random.Next(0, 9);
                temp[2] = random.Next(0, 9);
            }

            luckyNumber = $"{temp[0]}{temp[1]}{temp[2]}";
        }

        public bool IsLegal(string input)
        {
            if (input.Length != 3)
                return false;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                        return false;
                }
            }
            return true;
        }

        public string GetResult(string userNumber)
        {
            int a = 0;
            int b = 0;
            for (int i = 0; i < userNumber.Length; i++)
            {
                if (userNumber[i] == luckyNumber[i])
                    a++;
                else if (luckyNumber.Contains(userNumber[i].ToString()))
                    b++;
            }
            return $"{a} A {b} B";
        }

    }
}

