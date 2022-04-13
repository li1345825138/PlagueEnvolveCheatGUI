using System;
using System.Threading;
using System.Windows.Forms;

namespace PlagueEnvolveCheatGUI
{

    public partial class PlagueEnvolveWindow : Form
    {
        private ulong m_beforeUnlimiteValue = 0;
        private Thread m_memoryCheckThread = null;
        private Thread m_UnlimitePointThread = null;
        private bool m_memoryCheck = false;
        private ulong m_currentValue = 0;
        public PlagueEnvolveWindow()
        {
            InitializeComponent();
            this.beginCheckMemory();
        }

        private void ConfirmBtm_Click(object sender, EventArgs e)
        {
            string strValue = this.InputBox.Text;
            if (strValue == "" || strValue == null)
            {
                MessageBox.Show("文本内容不能为空", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ulong newValue = Convert.ToUInt64(strValue);
            NativeMethod.modifyValue(ref newValue);
        }

        private void setUnlimitedPoint(ulong value)
        {
            this.m_beforeUnlimiteValue = NativeMethod.getCurrentValue();
            while (true)
            {
                NativeMethod.modifyValue(ref value);
                Thread.Sleep(500);
            }
        }

        // This Method only run once
        private void beginCheckMemory()
        {
            do
            {
                this.m_memoryCheck = NativeMethod.readProcessMemoryStatus();
                if (this.m_memoryCheck)
                {
                    this.m_currentValue = NativeMethod.getCurrentValue();
                    this.readTextBox.Text = Convert.ToString(this.m_currentValue);
                    this.InputBox.Enabled = true;
                    this.ConfirmBtm.Enabled = true;
                    this.UnlimiteCheckBox.Enabled = true;
                    break;
                }
                Thread.Sleep(500);
            } while (true);
            if (this.m_memoryCheckThread == null)
            {
                this.m_memoryCheckThread = new Thread(() => { this.checkMemoryStatus(); });
                this.m_memoryCheckThread.Start();
            }
        }

        private void checkMemoryStatus()
        {
            do
            {
                this.m_memoryCheck = NativeMethod.readProcessMemoryStatus();
                this.m_currentValue = NativeMethod.getCurrentValue();
                if (this.m_memoryCheck)
                    this.readTextBox.Text = Convert.ToString(this.m_currentValue);
                Thread.Sleep(500);
            } while (true);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.m_memoryCheckThread != null)
                this.m_memoryCheckThread.Abort();
            this.m_memoryCheckThread = null;
            NativeMethod.emptyMemory();
            base.OnFormClosing(e);
        }

        private void UnlimiteCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.UnlimiteCheckBox.CheckState == CheckState.Checked)
            {
                this.InputBox.Enabled = false;
                this.ConfirmBtm.Enabled = false;
                if (this.m_UnlimitePointThread == null)
                {
                    this.m_UnlimitePointThread = new Thread(() => { setUnlimitedPoint(9999L); });
                    this.m_UnlimitePointThread.Start();
                }
            }
            else if (this.UnlimiteCheckBox.CheckState == CheckState.Unchecked)
            {
                this.InputBox.Enabled = true;
                this.ConfirmBtm.Enabled = true;
                if (this.m_UnlimitePointThread != null)
                {
                    this.m_UnlimitePointThread.Abort();
                    this.m_UnlimitePointThread = null;
                    NativeMethod.modifyValue(ref this.m_beforeUnlimiteValue);
                }
            }
        }
    }
}
