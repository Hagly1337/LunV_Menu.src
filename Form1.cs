using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using Guna.UI2.WinForms;
using Memory;
using LUNYNE;
using System.Diagnostics;

namespace LUNYNE
{
    public partial class Form1 : Form
    {
        private wtr wtr;
        public static bool IsOpen { get; private set; } = false;
        public string FlySearch3 = "AC C5 27 37 B0 B5 0C 46 06 49 05 46 E0 69 79 44";
        public string FlyOff3 = "9.999999747E-6";
        public string FlySign3 = "9.999999747E-6";
        public string FlyAdr3;
        public int FlyCont3 = 0;
        public string freezeoff = "33 33 73 3F 00 00 00 00 01 00 00 ??";
        public string freezeon = "-66";
        public string vSRecContSearch = "AC C5 27 37 35 FA";
        public string vSRecContSignOff = "9.999999747E-6";
        public string vSRecContSign = "9.999999747E-6";
        public string vSRecContAdr;
        public int vSRecCont = 0;

        public string AspectSearch = "00 00 80 3F 19 0A 06 00 0A 92";
        public string AspectOff = "1";
        public string AspectSign = "1";
        public string AspectAdr;
        public int AspectCont = 0;

        public string FlySearch = "33 33 73 3F 00 00 00 00 01 00 00 00 00";
        public string FlyOff = "0.9499999881";
        public string FlySign = "0.9499999881";
        public string FlyAdr;
        public int FlyCont = 0;
        public List<string> AspectAddresses = new List<string>();
        public List<string> FlyAddresses = new List<string>();
        public List<string> FlyAddresses3 = new List<string>();
        public async void WriteMemory(string address, string type, string value)
        {
            long addr = Convert.ToInt64(address, 16); // Преобразуем адрес из шестнадцатеричного формата

            // Логика записи в память в зависимости от типа
            if (type == "bytes")
            {
                byte[] bytes = StringToByteArray(value);
                await Task.Run(() => WriteProcessMemory(processHandle, addr, bytes, bytes.Length, out _));
            }
            // Добавьте другие типы по необходимости
        }

        private void WriteProcessMemory(object processHandle, long addr, byte[] bytes, int length, out object _)
        {
            throw new NotImplementedException();
        }

        private byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public async Task WriteMemoryAsync(string address, string type, string value)
        {
            await Task.Run(() =>
            {
                WriteMemory(address, type, value);
            });
        }
        public Mem m = new Mem();
        private object processHandle;
        private List<Snowflake> snowflakes = new List<Snowflake>();
        private System.Timers.Timer timer;
        private bool isSnowing = false;
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            Process.Start("https://t.me/wluny");
            wtr = new wtr();
            label8.Click += label8_Click;
            int PID1 = m.GetProcIdFromName("HD-Player.exe");
            m.OpenProcess(PID1);
            ProcOpen = m.OpenProcess("HD-Player");
            if (!ProcOpen)
            {
                ProcOpen = m.OpenProcess("LdVBoxHeadless");
                ProcOpen = m.OpenProcess("Ld9BoxHeadless");
                if (ProcOpen)
                {
                    ldplayer = true;
                }
            }
            Thread.Sleep(1000);

        }
        bool ldplayer = false;

        string unfinished_skins = "01 00 00 00 ?? 00 00 ??";

        string unfinished_sticker = "00 00 00 00 00 00 00 00 00 01";

        string graffiti = "1E";

        int idrep;

        int idnew;

        bool ProcOpen = false;

        string sig;
        string sig02;
        string graf;
        byte[] sig021;
        string failsave;

        byte[] unsig;
        byte[] unsig02;
        byte[] siggraf;


        long address;
        int tip = 1;
        bool error02 = false;
        int error01 = 0;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        

        
        private void label8_Click(object sender, EventArgs e)
        {
            MSG.Show("RAGE доступен в премиум версии");
            // Проверяем, является ли цвет label8 белым
            if (label8.ForeColor == Color.White)
            {
                // Если да, то возвращаем цвет label7 и label5 обратно
                label7.ForeColor = Color.FromArgb(65, 65, 65);
                label6.ForeColor = Color.FromArgb(65, 65, 65);
                label8.ForeColor = Color.White; // Или любой другой цвет, который вам нужен
            }
            else
            {
                // Если нет, то меняем цвет label8 на белый
                label7.ForeColor = Color.FromArgb(65, 65, 65);
                label6.ForeColor = Color.FromArgb(65, 65, 65);
                label8.ForeColor = Color.White;
            }
        }


        private void label7_Click(object sender, EventArgs e)
        {
            MISC.SendToBack();
            VISUALS.BringToFront();
            // Проверяем, является ли цвет label8 белым
            if (label8.ForeColor == Color.White)
            {
                // Если да, то возвращаем цвет label7 и label5 обратно
                label7.ForeColor = Color.White;
                label6.ForeColor = Color.FromArgb(65, 65, 65);
                label8.ForeColor = Color.FromArgb(65, 65, 65); ; // Или любой другой цвет, который вам нужен
            }
            else
            {
                // Если нет, то меняем цвет label8 на белый
                label7.ForeColor = Color.White;
                label6.ForeColor = Color.FromArgb(65, 65, 65);
                label8.ForeColor = Color.FromArgb(65, 65, 65);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MISC.BringToFront();
            VISUALS.SendToBack();
            // Проверяем, является ли цвет label8 белым
            if (label8.ForeColor == Color.White)
            {
                // Если да, то возвращаем цвет label7 и label5 обратно
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.FromArgb(65, 65, 65);
                label8.ForeColor = Color.FromArgb(65, 65, 65); ; // Или любой другой цвет, который вам нужен
            }
            else
            {
                // Если нет, то меняем цвет label8 на белый
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.FromArgb(65, 65, 65);
                label8.ForeColor = Color.FromArgb(65, 65, 65);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MISC.Visible = false;
            VISUALS.Visible = false;
            // Проверяем, является ли цвет label8 белым
            if (label8.ForeColor == Color.White)
            {
                // Если да, то возвращаем цвет label7 и label5 обратно
                label7.ForeColor = Color.FromArgb(65, 65, 65);
                label6.ForeColor = Color.FromArgb(65, 65, 65);
                label8.ForeColor = Color.FromArgb(65, 65, 65); ; // Или любой другой цвет, который вам нужен
            }
            else
            {
                // Если нет, то меняем цвет label8 на белый
                label7.ForeColor = Color.FromArgb(65, 65, 65);
                label6.ForeColor = Color.FromArgb(65, 65, 65);
                label8.ForeColor = Color.FromArgb(65, 65, 65);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // Проверяем, открыта ли форма
            if (wtr.Visible)
            {
                wtr.Hide(); // Скрываем форму, если она уже открыта
            }
            else
            {
                wtr.Show(); // Показываем форму, если она закрыта
            }
        }

        private void VISUALS_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void sToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            {
                {
                    try
                    {
                        IEnumerable<long> scanResults = await m.AoBScan("AC C5 27 B7 AC C5 27 37 10 B5 DD E9", true, true);

                        if (scanResults == null || !scanResults.Any())
                        {
                            MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                            return;
                        }

                        foreach (long address in scanResults)
                        {
                            string addressHex = address.ToString("X");
                            // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                            m.WriteMemory(addressHex, "bytes", "0C 02 00 00 00 E8 50 E8 A2 FF 8D 4D");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    }
                }
            }
        }

        private async void sToggleButton2_CheckedChanged(object sender, EventArgs e)
        {
            {
                {
                    try
                    {
                        IEnumerable<long> scanResults = await m.AoBScan("00 00 20 42 05 00 00 00 01 01 00 00", true, true);

                        if (scanResults == null || !scanResults.Any())
                        {
                            MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                            return;
                        }

                        foreach (long address in scanResults)
                        {
                            string addressHex = address.ToString("X");
                            // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                            m.WriteMemory(addressHex, "bytes", "0F 07 02 E3 1E FF 2F E1 01 01 00 00");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    }
                }
            }
        }

        private async void sToggleButton3_CheckedChanged(object sender, EventArgs e)
        {
            {
                try
                {
                    IEnumerable<long> scanResults = await m.AoBScan("CD CC A0 41 00 00 00 00 05 00 00 00", true, true);

                    if (scanResults == null || !scanResults.Any())
                    {
                        MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                        return;
                    }

                    foreach (long address in scanResults)
                    {
                        string addressHex = address.ToString("X");
                        // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                        m.WriteMemory(addressHex, "bytes", "1E FF 2F E1 00 00 00 00 05 00 00 00");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        private async void sToggleButton6_CheckedChanged(object sender, EventArgs e)
        {
            {
                {
                    try
                    {
                        IEnumerable<long> scanResults = await m.AoBScan("CD CC 4C 3E 08 00 00 00", true, true);

                        if (scanResults == null || !scanResults.Any())
                        {
                            MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                            return;
                        }

                        foreach (long address in scanResults)
                        {
                            string addressHex = address.ToString("X");
                            // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                            m.WriteMemory(addressHex, "bytes", "00 00 FF FF 00 00 00 00");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    }
                }
            }
        }

        private async void sToggleButton5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<long> scanResults = await m.AoBScan("6B 32 23 BF 7F F4 24 3F 9F E3 D4 BE", true, true);

                if (scanResults == null || !scanResults.Any())
                {
                    MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                    return;
                }

                foreach (long address in scanResults)
                {
                    string addressHex = address.ToString("X");
                    // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                    m.WriteMemory(addressHex, "bytes", "6B 32 23 BF 7F F4 24 1F 5F E4 99 BE");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private async void sToggleButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<long> scanResults = await m.AoBScan("AA E1 24 3F 0C 37 23 BF 96 6C 99 BD", true, true);

                if (scanResults == null || !scanResults.Any())
                {
                    MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                    return;
                }

                foreach (long address in scanResults)
                {
                    string addressHex = address.ToString("X");
                    // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                    m.WriteMemory(addressHex, "bytes", "00 00 00 00 0C 55 55 55 05 6C 99 BD");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void sToggleButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (sToggleButton7.Checked)
            {
                IEnumerable<long> result = m.AoBScan(vSRecContSearch, true, true, "").Result;

                if (result == null || !result.Any())
                {
                    MessageBox.Show("");
                    return;
                }
                vSRecContAdr = result.First().ToString("X");

                MSG.Show($"Функция включена");
                guna2TrackBar2.Enabled = true;
            }
            else
            {
                guna2TrackBar2.Value = 0;
                guna2TrackBar2.Enabled = false;

                if (!string.IsNullOrEmpty(vSRecContAdr))
                {
                    m.WriteMemory(vSRecContAdr, "float", vSRecContSignOff);
                    MessageBox.Show("Функция выключена");
                }
            }
        }

        private void guna2TrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            switch (guna2TrackBar2.Value)
            {
                case 0:
                    vSRecContSign = "9.999999747E-6";
                    break;
                case 1:
                    vSRecContSign = "100.0";
                    break;
                case 2:
                    vSRecContSign = "150.0";
                    break;
                case 3:
                    vSRecContSign = "200.0";
                    break;
                case 4:
                    vSRecContSign = "250.0";
                    break;
                case 5:
                    vSRecContSign = "300.0";
                    break;
                case 6:
                    vSRecContSign = "350.0";
                    break;
                case 7:
                    vSRecContSign = "400.0";
                    break;
                case 8:
                    vSRecContSign = "450.0";
                    break;
                case 9:
                    vSRecContSign = "500.0";
                    break;
                case 10:
                    vSRecContSign = "550.0";
                    break;
                case 11:
                    vSRecContSign = "900.0";
                    break;
            }

            if (!string.IsNullOrEmpty(vSRecContAdr))
            {
                m.WriteMemory(vSRecContAdr, "float", vSRecContSign);
            }

            label15.Text = $"{vSRecContSign}";
        }

        private void sToggleButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (sToggleButton8.Checked)
            {
                IEnumerable<long> result = m.AoBScan(AspectSearch, true, true, "").Result;

                if (result == null || !result.Any())
                {
                    MessageBox.Show("Запустите с правами администратора.");
                    return;
                }
                AspectAddresses = result.Select(addr => addr.ToString("X")).ToList();

                MessageBox.Show($"Аспект включен");
                guna2TrackBar4.Enabled = true;
            }
            else
            {
                guna2TrackBar4.Value = 0;
                guna2TrackBar4.Enabled = false;

                foreach (var address in AspectAddresses)
                {
                    m.WriteMemory(address, "float", AspectOff);
                }

                MSG.Show("Аспект выключен.");
            }
        }

        private void guna2TrackBar4_Scroll(object sender, ScrollEventArgs e)
        {
            switch (guna2TrackBar4.Value)
            {
                case 0:
                    AspectSign = "1";
                    break;
                case 1:
                    AspectSign = "1.5";
                    break;
                case 2:
                    AspectSign = "2";
                    break;
                case 3:
                    AspectSign = "2.5";
                    break;
                case 4:
                    AspectSign = "3";
                    break;
                case 5:
                    AspectSign = "3.5";
                    break;
                case 6:
                    AspectSign = "4";
                    break;
                case 7:
                    AspectSign = "4.5";
                    break;
                case 8:
                    AspectSign = "10";
                    break;
            }
            foreach (var address in AspectAddresses)
            {
                m.WriteMemory(address, "float", AspectSign);
            }
            label13.Text = $"{AspectSign}";
        }

        private async void sToggleButton16_CheckedChanged(object sender, EventArgs e)
        {
            {
                try
                {
                    IEnumerable<long> scanResults = await m.AoBScan("06 00 00 00 02 00 00 00 06 00 00 00 03 00 00 00 07 00 00 00 07 00 00 00 05 00 00 00 06 00 00 00 05 00 00 00 07 00 00 00 04 00 00 00 04 00 00 00 01 00 00 00 05 00 00 00 01 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 07 00 00 00 03 00 00 00 07 00 00 00 00 00 00 00 04 00 00 00 02 00 00 00 05 00 00 00 01 00 00 00 05 00 00 00 02 00 00 00", true, true);

                    if (scanResults == null || !scanResults.Any())
                    {
                        MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                        return;
                    }

                    foreach (long address in scanResults)
                    {
                        string addressHex = address.ToString("X");
                        // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                        m.WriteMemory(addressHex, "bytes", "00");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        private async void sToggleButton15_CheckedChanged(object sender, EventArgs e)
        {
            {
                try
                {
                    IEnumerable<long> scanResults = await m.AoBScan("30 00 90 E5 1E FF 2F E1 30 00 90 E5 1E FF 2F E1", true, true);

                    if (scanResults == null || !scanResults.Any())
                    {
                        MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                        return;
                    }

                    foreach (long address in scanResults)
                    {
                        string addressHex = address.ToString("X");
                        // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                        m.WriteMemory(addressHex, "bytes", "1E FF 2F E1");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        private async void sToggleButton14_CheckedChanged(object sender, EventArgs e)
        {
            IEnumerable<long> Scan = m.AoBScan("80 3F 00 00 00 00 00 00 00 00 0? ?? 00 00 FE FF FF 7F ?? ?? ?? 00 ?? ?? ?? 00 64 00 00 00 64 00 00", true, true).Result;
            if (Scan == null || !Scan.Any())
            {
                MessageBox.Show("Не удалось включить функцию...");
            }
            else if (Scan.Any())
            {
                int INDEX = 0;
                foreach (long addresses in Scan)
                {
                    string adr = addresses.ToString("X");
                    m.WriteMemory(adr, "bytes", "1E FF 2F E1 1E FF 2F E1");
                    INDEX++;
                }
                MessageBox.Show($"Функция включена!");
            }
        }

        private async void sToggleButton13_CheckedChanged(object sender, EventArgs e)
        {
            {
                {
                    try
                    {
                        IEnumerable<long> scanResults = await m.AoBScan("F0 48 2D E9 10 D0 4D E2 04 51 9F E5 00 40 A0 E1 05 50 8F E0 00 00 D5 E5 00 00", true, true);

                        if (scanResults == null || !scanResults.Any())
                        {
                            MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                            return;
                        }

                        foreach (long address in scanResults)
                        {
                            string addressHex = address.ToString("X");
                            // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                            m.WriteMemory(addressHex, "bytes", "88 08 00 E3 1E FF 2F E1 04 51 9F E5 00 40 A0 E1 05 50 8F E0 00 00 D5 E5 00 00");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    }
                }
            }
        }

        private async void sToggleButton12_CheckedChanged(object sender, EventArgs e)
        {
            {
                {
                    try
                    {
                        IEnumerable<long> scanResults = await m.AoBScan("00 00 B4 43 DB 0F 49 40 B0 B5 84 B0 6D", true, true);

                        if (scanResults == null || !scanResults.Any())
                        {
                            MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                            return;
                        }

                        foreach (long address in scanResults)
                        {
                            string addressHex = address.ToString("X");
                            // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                            m.WriteMemory(addressHex, "bytes", "00 40 4E 45 DB 0F 49 40 B0 B5 84 B0 6D");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    }
                }
            }
        }

        private async void sToggleButton11_CheckedChanged(object sender, EventArgs e)
        {
            {
                try
                {
                    IEnumerable<long> scanResults = await m.AoBScan("F0 41 2D E9 10 D0 4D E2 E4 60 9F E5 00 40 A0 E1 01 50 A0 E1 06 60 8F E0 00 00 D6 E5 00 00 50 E3 0D 00 00 1A CC 00 9F E5 00 00 9F E7 90 46 E4 EB", true, true);

                    if (scanResults == null || !scanResults.Any())
                    {
                        MessageBox.Show("Не удалось включить функцию: адреса не найдены.");
                        return;
                    }

                    foreach (long address in scanResults)
                    {
                        string addressHex = address.ToString("X");
                        // Используем существующий метод WriteMemory вместо WriteMemoryAsync
                        m.WriteMemory(addressHex, "bytes", "1E FF 2F E1 10 D0 4D E2 E4 60 9F E5 00 40 A0 E1 01 50 A0 E1 06 60 8F E0 00 00 D6 E5 00 00 50 E3 0D 00 00 1A CC 00 9F E5 00 00 9F E7 90 46 E4 EB");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        private void sButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sButton3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void sButton4_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/wluny/102");
        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            wtr wtr = new wtr();
            wtr.Show();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

            // Переключение свойства TopMost
            this.TopMost = !this.TopMost;

            // Изменение текста кнопки в зависимости от состояния
            if (this.TopMost)
            {
                MSG.Show("PINNED");
            }
            else
            {
                MSG.Show("UNPINNED");
            }
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/wluny");
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/wluny/102");
        }
    }
}

