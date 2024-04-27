using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace XAXB00
{
    public partial class MainForm : Form
    {
        // �ŧi�p���ܼơA�Ω��x�s�q�Ʀr�C���������M�q������
        private XaXbEngine xaxb;
        private int counter;
        // AgainButton Click �ƥ�
        private void AgainButton_Click(object sender, EventArgs e)
        {
            // ���s��l�ƹC��
            ResultLabel.Text = "";// �M�ŵ��G����
            xaxb.GenerateLuckyNumber();// �ͦ��s�����B�Ʀr
            counter = 0;// ���m�q������
            GuessButton.Enabled = true;// �ҥβq���s
            AgainButton.Enabled = false; // �T�ΦA���@�����s
            RestartButton.Enabled = false;// �T�έ��ӫ��s
        }

        // RestartButton Click �ƥ�
        private void RestartButton_Click(object sender, EventArgs e)
        {
            // ���s�}�l�C��
            ResultLabel.Text = "";// �M�ŵ��G����
            UserNumberTextBox.Text = "";// �M�ťΤ��J�奻��
            counter = 0;// ���m�q������
            GuessButton.Enabled = true;// �ҥβq���s
            AgainButton.Enabled = false;// �T�ΦA���@�����s
            RestartButton.Enabled = false;// �T�έ��ӫ��s
        }
        public MainForm()
        {
            InitializeComponent();// ��l�Ƶ��f����
            xaxb = new XaXbEngine();// ��l�ƹC������
            counter = 0;// ��l�Ʋq������
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            string userNum = UserNumberTextBox.Text;// ����Τ��J���Ʀr
            if (xaxb.IsLegal(userNum))// �ˬd�Τ��J�O�_�X�k
            {
                counter++; // �W�[�q������
                string result = xaxb.GetResult(userNum);// ����q�����G
                ResultLabel.Text += $"{userNum} : {result}, �q������ : {counter}\n";// ��ܲq�����G�M����
                if (result == "3 A 0 B")// �p�G�q��F
                {
                    // �M�� ResultLabel �ó]�m�� "���ߧA�A�q��F!"�A�Ӥ��O�l�[
                    ResultLabel.Text = $"���ߧA�A�q��F!  �q�����ơG{counter}";
                    GuessButton.Enabled = false;
                    AgainButton.Enabled = true; // �ҥ� "�A���@��" ���s
                    RestartButton.Enabled = true; // �ҥ� "����" ���s
                    return; // �פ�ƥ󪺰���
                }
            }
            else
            {
                ResultLabel.Text = "��J����ƭ��ƩΪ��פ���A�Э��s��J\n";// �p�G��J���X�k�A��ܿ��~����
            }
        }

        // MainForm �[���ƥ�B�z��k
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
    // �w�q�q�Ʀr�C����������
    internal class XaXbEngine
    {
        private string luckyNumber;// �O�s���B�Ʀr
        // �������c�y��ơA�ͦ����B�Ʀr
        public XaXbEngine()
        {
            GenerateLuckyNumber();
        }

        
        // �ͦ����B�Ʀr����k
        public void GenerateLuckyNumber()
        {
            Random random = new Random(); // �Ыؤ@���H���ƹ�H
            int[] temp = new int[3];// �Ыؤ@�Ӫ��׬�3���ƲաA�Ω�s�x���B�Ʀr���C�@��
            temp[0] = random.Next(0, 9);// �ͦ��Ĥ@��Ʀr
            temp[1] = random.Next(0, 9);// �ͦ��ĤG��Ʀr
            temp[2] = random.Next(0, 9);// �ͦ��ĤT��Ʀr

            // �T�O�C��Ʀr��������
            while (temp[0] == temp[1] || temp[0] == temp[2] || temp[1] == temp[2])
            {
                temp[1] = random.Next(0, 9);
                temp[2] = random.Next(0, 9);
            }

            luckyNumber = $"{temp[0]}{temp[1]}{temp[2]}";// �c�y���B�Ʀr�r�Ŧ�
        }
        // �P�_�Τ��J�O�_�X�k����k
        public bool IsLegal(string input)
        {
            if (input.Length != 3)// �p�G�Τ��J�����פ���3�A�h���X�k
                return false;

            for (int i = 0; i < input.Length; i++)// �M���Τ��J���C�Ӧr��
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])// �p�G���r�ŭ��ơA�h���X�k
                        return false;
                }
            }
            return true;
        }

        public string GetResult(string userNumber)
        {
            int a = 0;
            int b = 0;
            for (int i = 0; i < userNumber.Length; i++)// �T�{�Τ��J���C�ӼƦr
            {
                if (userNumber[i] == luckyNumber[i])// �p�G�Τ��J���Ʀr�M���B�Ʀr��������ۦP
                    a++;// �N a �[�@�A��ܥ��T���Ʀr�M��m����
                else if (luckyNumber.Contains(userNumber[i].ToString()))
                    b++;// �N b �[�@�A��ܥ��T���Ʀr����m����
            }
            return $"{a} A {b} B";
        }

    }
}

