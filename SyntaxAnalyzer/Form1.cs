﻿using SyntaxAnalyzer.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyntaxAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                richTextCode.Clear();

                StreamReader sr = null;

                try
                {
                    sr = File.OpenText(openFileDialog.FileName);
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        richTextCode.AppendText(Environment.NewLine + line);
                    }
                }
                catch (IOException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader arquivo = File.OpenText(openFileDialog.FileName);
            //IfCommand ifCommand = new IfCommand(richTextCode.ToString(), null);
            //validarTokens();
            IfCommand ifCommand = new IfCommand("if(a>b){c = 1;}", null);
            ifCommand.Validate(arquivo);

            ForCommand forCommand = new ForCommand("for(i=0;i<10;i++)", null);
            forCommand.Validate(arquivo);
        }

        private bool validarTokens()
        {
            const int finalArquivo = -1;
            StreamReader arquivo = null;

            int caracter;
            char c;

            arquivo = File.OpenText(openFileDialog.FileName);

            while ((caracter = arquivo.Read()) != finalArquivo){
                c = (char)caracter;
                Console.WriteLine(caracter);
            }

            return true;

        }
    }
}
