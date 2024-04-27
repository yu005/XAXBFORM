using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace XAXB00
{
    public partial class MainForm : Form
    {
        // 宣告私有變數，用於儲存猜數字遊戲的引擎和猜測次數
        private XaXbEngine xaxb;
        private int counter;
        // AgainButton Click 事件
        private void AgainButton_Click(object sender, EventArgs e)
        {
            // 重新初始化遊戲
            ResultLabel.Text = "";// 清空結果標籤
            xaxb.GenerateLuckyNumber();// 生成新的幸運數字
            counter = 0;// 重置猜測次數
            GuessButton.Enabled = true;// 啟用猜按鈕
            AgainButton.Enabled = false; // 禁用再玩一次按鈕
            RestartButton.Enabled = false;// 禁用重來按鈕
        }

        // RestartButton Click 事件
        private void RestartButton_Click(object sender, EventArgs e)
        {
            // 重新開始遊戲
            ResultLabel.Text = "";// 清空結果標籤
            UserNumberTextBox.Text = "";// 清空用戶輸入文本框
            counter = 0;// 重置猜測次數
            GuessButton.Enabled = true;// 啟用猜按鈕
            AgainButton.Enabled = false;// 禁用再玩一次按鈕
            RestartButton.Enabled = false;// 禁用重來按鈕
        }
        public MainForm()
        {
            InitializeComponent();// 初始化窗口元素
            xaxb = new XaXbEngine();// 初始化遊戲引擎
            counter = 0;// 初始化猜測次數
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            string userNum = UserNumberTextBox.Text;// 獲取用戶輸入的數字
            if (xaxb.IsLegal(userNum))// 檢查用戶輸入是否合法
            {
                counter++; // 增加猜測次數
                string result = xaxb.GetResult(userNum);// 獲取猜測結果
                ResultLabel.Text += $"{userNum} : {result}, 猜測次數 : {counter}\n";// 顯示猜測結果和次數
                if (result == "3 A 0 B")// 如果猜對了
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
                ResultLabel.Text = "輸入的資料重複或長度不對，請重新輸入\n";// 如果輸入不合法，顯示錯誤消息
            }
        }

        // MainForm 加載事件處理方法
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
    // 定義猜數字遊戲的引擎類
    internal class XaXbEngine
    {
        private string luckyNumber;// 保存幸運數字
        // 引擎的構造函數，生成幸運數字
        public XaXbEngine()
        {
            GenerateLuckyNumber();
        }

        
        // 生成幸運數字的方法
        public void GenerateLuckyNumber()
        {
            Random random = new Random(); // 創建一個隨機數對象
            int[] temp = new int[3];// 創建一個長度為3的數組，用於存儲幸運數字的每一位
            temp[0] = random.Next(0, 9);// 生成第一位數字
            temp[1] = random.Next(0, 9);// 生成第二位數字
            temp[2] = random.Next(0, 9);// 生成第三位數字

            // 確保每位數字都不重複
            while (temp[0] == temp[1] || temp[0] == temp[2] || temp[1] == temp[2])
            {
                temp[1] = random.Next(0, 9);
                temp[2] = random.Next(0, 9);
            }

            luckyNumber = $"{temp[0]}{temp[1]}{temp[2]}";// 構造幸運數字字符串
        }
        // 判斷用戶輸入是否合法的方法
        public bool IsLegal(string input)
        {
            if (input.Length != 3)// 如果用戶輸入的長度不為3，則不合法
                return false;

            for (int i = 0; i < input.Length; i++)// 遍歷用戶輸入的每個字符
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])// 如果有字符重複，則不合法
                        return false;
                }
            }
            return true;
        }

        public string GetResult(string userNumber)
        {
            int a = 0;
            int b = 0;
            for (int i = 0; i < userNumber.Length; i++)// 確認用戶輸入的每個數字
            {
                if (userNumber[i] == luckyNumber[i])// 如果用戶輸入的數字和幸運數字的對應位相同
                    a++;// 將 a 加一，表示正確的數字和位置都對
                else if (luckyNumber.Contains(userNumber[i].ToString()))
                    b++;// 將 b 加一，表示正確的數字但位置不對
            }
            return $"{a} A {b} B";
        }

    }
}

