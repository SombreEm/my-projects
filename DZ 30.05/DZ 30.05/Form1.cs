using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_30._05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            int shift = 3;
            string encryptedText = EncryptCaesarCipher(inputText, shift);
            textBox2.Text = encryptedText;
        }
        private string EncryptCaesarCipher(string input, int shift)
        {
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsUpper(letter))
                {
                    letter = (char)(letter + shift);
                    if (letter > 'Z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'A')
                    {
                        letter = (char)(letter + 26);
                    }
                }
                else if (char.IsLower(letter))
                {
                    letter = (char)(letter + shift);
                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }
                }
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }
}
