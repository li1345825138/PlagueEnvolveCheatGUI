namespace PlagueEnvolveCheatGUI
{
    partial class PlagueEnvolveWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.InputBox = new System.Windows.Forms.TextBox();
            this.ConfirmBtm = new System.Windows.Forms.Button();
            this.UnlimiteCheckBox = new System.Windows.Forms.CheckBox();
            this.readTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.InputBox.Enabled = false;
            this.InputBox.Location = new System.Drawing.Point(13, 38);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(100, 23);
            this.InputBox.TabIndex = 0;
            this.InputBox.WordWrap = false;
            // 
            // ConfirmBtm
            // 
            this.ConfirmBtm.Enabled = false;
            this.ConfirmBtm.Location = new System.Drawing.Point(118, 38);
            this.ConfirmBtm.Name = "ConfirmBtm";
            this.ConfirmBtm.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtm.TabIndex = 1;
            this.ConfirmBtm.TabStop = false;
            this.ConfirmBtm.Text = "写入";
            this.ConfirmBtm.UseVisualStyleBackColor = true;
            this.ConfirmBtm.Click += new System.EventHandler(this.ConfirmBtm_Click);
            // 
            // UnlimiteCheckBox
            // 
            this.UnlimiteCheckBox.AutoSize = true;
            this.UnlimiteCheckBox.Enabled = false;
            this.UnlimiteCheckBox.Location = new System.Drawing.Point(12, 67);
            this.UnlimiteCheckBox.Name = "UnlimiteCheckBox";
            this.UnlimiteCheckBox.Size = new System.Drawing.Size(82, 18);
            this.UnlimiteCheckBox.TabIndex = 2;
            this.UnlimiteCheckBox.Text = "无限点数";
            this.UnlimiteCheckBox.UseVisualStyleBackColor = true;
            this.UnlimiteCheckBox.CheckStateChanged += new System.EventHandler(this.UnlimiteCheckBox_CheckStateChanged);
            // 
            // readTextBox
            // 
            this.readTextBox.Enabled = false;
            this.readTextBox.Location = new System.Drawing.Point(13, 13);
            this.readTextBox.Name = "readTextBox";
            this.readTextBox.Size = new System.Drawing.Size(100, 23);
            this.readTextBox.TabIndex = 3;
            this.readTextBox.Text = "???";
            this.readTextBox.WordWrap = false;
            // 
            // PlagueEnvolveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 97);
            this.Controls.Add(this.readTextBox);
            this.Controls.Add(this.UnlimiteCheckBox);
            this.Controls.Add(this.ConfirmBtm);
            this.Controls.Add(this.InputBox);
            this.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlagueEnvolveWindow";
            this.ShowIcon = false;
            this.Text = "瘟疫公司修改器v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button ConfirmBtm;
        private System.Windows.Forms.CheckBox UnlimiteCheckBox;
        private System.Windows.Forms.TextBox readTextBox;
    }
}

