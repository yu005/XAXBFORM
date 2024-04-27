using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace XAXB00
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button AgainButton;
        private Button RestartButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            UserNumberLabel = new Label();
            UserNumberTextBox = new TextBox();
            GuessButton = new Button();
            ResultLabel = new Label();
            AgainButton = new Button();
            RestartButton = new Button();
            SuspendLayout();
            // 
            // UserNumberLabel
            // 
            UserNumberLabel.AutoSize = true;
            UserNumberLabel.Location = new Point(10, 17);
            UserNumberLabel.Margin = new Padding(2, 0, 2, 0);
            UserNumberLabel.Name = "UserNumberLabel";
            UserNumberLabel.Size = new Size(87, 19);
            UserNumberLabel.TabIndex = 0;
            UserNumberLabel.Text = "請輸入數字:";
            // 
            // UserNumberTextBox
            // 
            UserNumberTextBox.Location = new Point(115, 14);
            UserNumberTextBox.Margin = new Padding(2);
            UserNumberTextBox.Name = "UserNumberTextBox";
            UserNumberTextBox.Size = new Size(123, 27);
            UserNumberTextBox.TabIndex = 1;
            // 
            // GuessButton
            // 
            GuessButton.Location = new Point(242, 14);
            GuessButton.Margin = new Padding(2);
            GuessButton.Name = "GuessButton";
            GuessButton.Size = new Size(77, 28);
            GuessButton.TabIndex = 2;
            GuessButton.Text = "猜!";
            GuessButton.UseVisualStyleBackColor = true;
            GuessButton.Click += GuessButton_Click;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(10, 54);
            ResultLabel.Margin = new Padding(2, 0, 2, 0);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(0, 19);
            ResultLabel.TabIndex = 3;
            // 
            // AgainButton
            // 
            this.AgainButton.Location = new System.Drawing.Point(330, 14);
            this.AgainButton.Name = "AgainButton";
            this.AgainButton.Size = new System.Drawing.Size(100, 30);
            this.AgainButton.TabIndex = 4;
            this.AgainButton.Text = "再玩一次";
            this.AgainButton.UseVisualStyleBackColor = true;
            this.AgainButton.Click += new System.EventHandler(this.AgainButton_Click);

            this.Controls.Add(AgainButton); // 將 AgainButton 添加到控制項中
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(140, 100);
            this.RestartButton.Location = new System.Drawing.Point(440, 14);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(100, 30);
            this.RestartButton.TabIndex = 5;
            this.RestartButton.Text = "重來";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 378);
            this.Controls.Add(ResultLabel);
            this.Controls.Add(GuessButton);
            this.Controls.Add(UserNumberTextBox);
            this.Controls.Add(UserNumberLabel);
            this.Controls.Add(RestartButton); // 將 RestartButton 添加到控制項中
            this.Margin = new Padding(2);
            this.Name = "MainForm";
            this.Text = "猜數字遊戲";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label UserNumberLabel;
        private System.Windows.Forms.TextBox UserNumberTextBox;
        private System.Windows.Forms.Button GuessButton;
        private System.Windows.Forms.Label ResultLabel;

    }
}

