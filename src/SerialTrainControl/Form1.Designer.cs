namespace SerialTrainControl
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.numberComboBox = new System.Windows.Forms.ComboBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.baudComboBox = new System.Windows.Forms.ComboBox();
            this.baudLabel = new System.Windows.Forms.Label();
            this.configGroup = new System.Windows.Forms.GroupBox();
            this.textGroup = new System.Windows.Forms.GroupBox();
            this.receiveText = new System.Windows.Forms.TextBox();
            this.sendText = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.flash = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.configGroup.SuspendLayout();
            this.textGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flash)).BeginInit();
            this.SuspendLayout();
            // 
            // serial
            // 
            this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(695, 12);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "切断(&D)";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(614, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "接続(&C)";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // numberComboBox
            // 
            this.numberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberComboBox.FormattingEnabled = true;
            this.numberComboBox.Location = new System.Drawing.Point(89, 14);
            this.numberComboBox.Name = "numberComboBox";
            this.numberComboBox.Size = new System.Drawing.Size(287, 20);
            this.numberComboBox.TabIndex = 1;
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(10, 17);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(73, 12);
            this.numberLabel.TabIndex = 0;
            this.numberLabel.Text = "ポート番号(&N)";
            // 
            // baudComboBox
            // 
            this.baudComboBox.FormattingEnabled = true;
            this.baudComboBox.Location = new System.Drawing.Point(487, 14);
            this.baudComboBox.Name = "baudComboBox";
            this.baudComboBox.Size = new System.Drawing.Size(121, 20);
            this.baudComboBox.TabIndex = 3;
            // 
            // baudLabel
            // 
            this.baudLabel.AutoSize = true;
            this.baudLabel.Location = new System.Drawing.Point(382, 17);
            this.baudLabel.Name = "baudLabel";
            this.baudLabel.Size = new System.Drawing.Size(99, 12);
            this.baudLabel.TabIndex = 2;
            this.baudLabel.Text = "通信速度(bps) (&B)";
            // 
            // configGroup
            // 
            this.configGroup.Controls.Add(this.baudLabel);
            this.configGroup.Controls.Add(this.baudComboBox);
            this.configGroup.Controls.Add(this.numberLabel);
            this.configGroup.Controls.Add(this.numberComboBox);
            this.configGroup.Controls.Add(this.connectButton);
            this.configGroup.Controls.Add(this.disconnectButton);
            this.configGroup.Location = new System.Drawing.Point(2, 0);
            this.configGroup.Name = "configGroup";
            this.configGroup.Size = new System.Drawing.Size(780, 45);
            this.configGroup.TabIndex = 0;
            this.configGroup.TabStop = false;
            this.configGroup.Text = "シリアルポート設定";
            // 
            // textGroup
            // 
            this.textGroup.Controls.Add(this.receiveText);
            this.textGroup.Controls.Add(this.sendText);
            this.textGroup.Controls.Add(this.sendButton);
            this.textGroup.Location = new System.Drawing.Point(2, 360);
            this.textGroup.Name = "textGroup";
            this.textGroup.Size = new System.Drawing.Size(780, 200);
            this.textGroup.TabIndex = 2;
            this.textGroup.TabStop = false;
            this.textGroup.Text = "送受信データ";
            // 
            // receiveText
            // 
            this.receiveText.Location = new System.Drawing.Point(6, 45);
            this.receiveText.Multiline = true;
            this.receiveText.Name = "receiveText";
            this.receiveText.ReadOnly = true;
            this.receiveText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receiveText.Size = new System.Drawing.Size(768, 149);
            this.receiveText.TabIndex = 2;
            // 
            // sendText
            // 
            this.sendText.Location = new System.Drawing.Point(6, 20);
            this.sendText.Name = "sendText";
            this.sendText.Size = new System.Drawing.Size(687, 19);
            this.sendText.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(699, 18);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "送信(&S)";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // flash
            // 
            this.flash.Enabled = true;
            this.flash.Location = new System.Drawing.Point(2, 51);
            this.flash.Name = "flash";
            this.flash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flash.OcxState")));
            this.flash.Size = new System.Drawing.Size(780, 300);
            this.flash.TabIndex = 1;
            this.flash.Enter += new System.EventHandler(this.flash_Enter);
            // 
            // MainForm
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.flash);
            this.Controls.Add(this.textGroup);
            this.Controls.Add(this.configGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SerialTrainControl";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.configGroup.ResumeLayout(false);
            this.configGroup.PerformLayout();
            this.textGroup.ResumeLayout(false);
            this.textGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox numberComboBox;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.ComboBox baudComboBox;
        private System.Windows.Forms.Label baudLabel;
        private System.Windows.Forms.GroupBox configGroup;
        private System.Windows.Forms.GroupBox textGroup;
        private System.Windows.Forms.TextBox receiveText;
        private System.Windows.Forms.TextBox sendText;
        private System.Windows.Forms.Button sendButton;
        private AxShockwaveFlashObjects.AxShockwaveFlash flash;
    }
}

