#region Using Normal
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
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.CodeDom;
using System.Collections;
using System.Configuration;
using System.Deployment;
using System.Dynamic;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Resources;
using System.Runtime;
using System.Security;
using System.Timers;
using System.Web;
using System.Windows;
using System.Xml;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.DesignerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Hosting;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Windows.Markup;
using System.Windows.Input;
using System.Net.Cache;
using System.Net.Sockets;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO.Compression;
#endregion
using MinecraftKnockbackModifier;
using MinecraftKnockbackModifier.Properties;
using geckou;
//using DiscordRpcDemo;
/*using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;*/

namespace MinecraftKnockbackModifier
{
    public partial class Form1 : Form
    {
        #region Private
        bool CT = true;
        public static GeckoUCore GeckoU;
        public static GeckoUConnect GeckoUConnection;
        public static GeckoUDump GeckoUDump;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Installation
            if (!Directory.Exists(@"C:/Users/" + Environment.UserName + "/AppData/Local/nt games Company"))
            {
                Directory.CreateDirectory(@"C:/Users/" + Environment.UserName + "/AppData/Local/nt games Company");
            }
            if (!Directory.Exists(@"C:/Users/" + Environment.UserName + "/AppData/Local/nt games Company/Minecraft Knockback Modifier"))
            {
                Directory.CreateDirectory(@"C:/Users/" + Environment.UserName + "/AppData/Local/nt games Company/Minecraft Knockback Modifier");

                StreamWriter streamWriterIP = new StreamWriter(@"C:/Users/" + Environment.UserName + @"/AppData/Local/nt games Company/Minecraft Knockback Modifier/IP.txt");
                streamWriterIP.Write("192.168.");
                streamWriterIP.Close();
            }
            #endregion

            ipText.Text = File.ReadAllText(@"C:/Users/" + Environment.UserName + @"/AppData/Local/nt games Company/Minecraft Knockback Modifier/IP.txt");
        }

        #region Connection
        #region Text
        public static bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
                return false;

            if (ipString == "127.0.0.1")
                return false;

            string[] splitValues = ipString.Split('.');

            if (splitValues.Length != 4)
                return false;

            return splitValues.All(r => byte.TryParse(r, out byte tempForParsing));
        }

        private void ipText_TextChanged(object sender, EventArgs e)
        {
            if (ValidateIPv4(ipText.Text) == true)
            {
                connect.Enabled = true;
            }
            else
            {
                connect.Enabled = false;
            }
        }
        #endregion

        #region Button
        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                GeckoU = new GeckoUCore(ipText.Text);
                GeckoU.GUC.Connect();

                ipText.Enabled = false;
                StreamWriter streamWriterIP = new StreamWriter(@"C:/Users/" + Environment.UserName + @"/AppData/Local/nt games Company/Minecraft Knockback Modifier/IP.txt");
                streamWriterIP.Write(ipText.Text);
                streamWriterIP.Close();
                connect.Enabled = false;
                disconnect.Enabled = true;

                #region Button true
                change0.Enabled = true;
                normal0.Enabled = true;
                change1.Enabled = true;
                normal1.Enabled = true;
                change2.Enabled = true;
                normal2.Enabled = true;
                change3.Enabled = true;
                normal3.Enabled = true;
                change4.Enabled = true;
                normal4.Enabled = true;
                change5.Enabled = true;
                normal5.Enabled = true;
                change6.Enabled = true;
                normal6.Enabled = true;
                change7.Enabled = true;
                normal7.Enabled = true;
                change8.Enabled = true;
                normal8.Enabled = true;
                #endregion

                charger.Enabled = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Minecraft Knockback Modifier");
            }
            catch (System.Net.Sockets.SocketException)
            {
                CT = false;
                MessageBox.Show("Erreur: votre ip n'est pas la bonne ou vous n'êtes pas connécté à internet !", "Minecraft Knockback Modifier");
            }
            catch
            {
                CT = false;
                MessageBox.Show("Une erreur inconnue est survenue !", "Minecraft Knockback Modifier");
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            GeckoU.GUC.Close();

            ipText.Enabled = true;
            connect.Enabled = true;
            disconnect.Enabled = false;

            #region Button false
            change0.Enabled = false;
            normal0.Enabled = false;
            change1.Enabled = false;
            normal1.Enabled = false;
            change2.Enabled = false;
            normal2.Enabled = false;
            change3.Enabled = false;
            normal3.Enabled = false;
            change4.Enabled = false;
            normal4.Enabled = false;
            change5.Enabled = false;
            normal5.Enabled = false;
            change6.Enabled = false;
            normal6.Enabled = false;
            change7.Enabled = false;
            normal7.Enabled = false;
            change8.Enabled = false;
            normal8.Enabled = false;
            #endregion

            charger.Enabled = false;
        }
        #endregion
        #endregion

        #region Knockback
        private void change0_Click(object sender, EventArgs e)
        {
            GeckoU.makeAssembly(0x0257D85C, text0.Text);
        }

        private void normal0_Click(object sender, EventArgs e)
        {
            GeckoU.WriteUInt(0x0257D85C, 0x9421FFA8);
            text0.Text = "9421FFA8";
        }

        private void change1_Click(object sender, EventArgs e)
        {
            GeckoU.makeAssembly(0x0257D980, text1.Text);
        }

        private void normal1_Click(object sender, EventArgs e)
        {
            GeckoU.WriteUInt(0x0257D980, 0xFC006378);
            text1.Text = "FC006378";
        }

        private void change2_Click(object sender, EventArgs e)
        {
            GeckoU.makeAssembly(0x0257D990, text2.Text);
        }

        private void normal2_Click(object sender, EventArgs e)
        {
            GeckoU.WriteUInt(0x0257D990, 0xFD290372);
            text2.Text = "FD290372";
        }

        private void change3_Click(object sender, EventArgs e)
        {
            GeckoU.makeAssembly(0x0257D968, text3.Text);
        }

        private void normal3_Click(object sender, EventArgs e)
        {
            GeckoU.WriteUInt(0x0257D968, 0xFD5DE024);
            text3.Text = "FD5DE024";
        }

        private void change4_Click(object sender, EventArgs e)
        {
            GeckoU.makeAssembly(0x0257D970, text4.Text);
        }

        private void normal4_Click(object sender, EventArgs e)
        {
            GeckoU.WriteUInt(0x0257D970, 0xFD8A07F2);
            text4.Text = "FD8A07F2";
        }

        private void change5_Click(object sender, EventArgs e)
        {
            GeckoU.makeAssembly(0x0257D988, text5.Text);
        }

        private void normal5_Click(object sender, EventArgs e)
        {
            GeckoU.WriteUInt(0x0257D988, 0xFD4807F2);
            text5.Text = "FD4807F2";
        }

        private void change6_Click(object sender, EventArgs e)
        {
            GeckoU.makeAssembly(0x0257D998, text6.Text);
        }

        private void normal6_Click(object sender, EventArgs e)
        {
            GeckoU.WriteUInt(0x0257D998, 0xFD675378);
            text6.Text = "FD675378";
        }

        private void change7_Click(object sender, EventArgs e)
        {
            GeckoU.makeAssembly(0x0257D9B0, text7.Text);
        }

        private void normal7_Click(object sender, EventArgs e)
        {
            GeckoU.WriteUInt(0x0257D9B0, 0xFD09FB7A);
            text7.Text = "FD09FB7A";
        }

        private void change8_Click(object sender, EventArgs e)
        {
            GeckoU.makeAssembly(0x0257D9BC, text8.Text);
        }

        private void normal8_Click(object sender, EventArgs e)
        {
            GeckoU.WriteUInt(0x0257D9BC, 0xFC080000);
            text8.Text = "FC080000";
        }
        #endregion

        #region File
        private void sauvegarder_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Minecraft knockback files (*.mckb)|*.mckb";
            fileDialog.InitialDirectory = Environment.CurrentDirectory;
            fileDialog.FileName = System.IO.Path.GetFileName("default.mckb");
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string kb = text0.Text + //"\r\n" +
                        text1.Text + //"\r\n" +
                        text2.Text + //"\r\n" +
                        text3.Text + //"\r\n" +
                        text4.Text + //"\r\n" +
                        text5.Text + //"\r\n" +
                        text6.Text + //"\r\n" +
                        text7.Text + //"\r\n" +
                        text8.Text;

                    File.WriteAllText(fileDialog.FileName, kb);

                    MessageBox.Show("Knockback sauvegardé !", "Minecraft Knockback Modifier");
                }
                catch
                {
                    MessageBox.Show("Error !", "Minecraft Knockback Modifier");
                }
            }
            fileDialog.Dispose();
        }

        private void charger_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Minecraft knockback files (*.mckb)|*.mckb";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string knockback = File.ReadAllText(fileDialog.FileName);

                text0.Text = knockback.Substring(0, 8);
                text1.Text = knockback.Substring(8,8);
                text2.Text = knockback.Substring(16, 8);
                text3.Text = knockback.Substring(24, 8);
                text4.Text = knockback.Substring(32, 8);
                text5.Text = knockback.Substring(40, 8);
                text6.Text = knockback.Substring(48, 8);
                text7.Text = knockback.Substring(56, 8);
                text8.Text = knockback.Substring(64, 8);

                GeckoU.makeAssembly(0x0257D85C, text0.Text);
                GeckoU.makeAssembly(0x0257D980, text1.Text);
                GeckoU.makeAssembly(0x0257D990, text2.Text);
                GeckoU.makeAssembly(0x0257D968, text3.Text);
                GeckoU.makeAssembly(0x0257D970, text4.Text);
                GeckoU.makeAssembly(0x0257D988, text5.Text);
                GeckoU.makeAssembly(0x0257D998, text6.Text);
                GeckoU.makeAssembly(0x0257D9B0, text7.Text);
                GeckoU.makeAssembly(0x0257D9BC, text8.Text);
            }
        }
        #endregion
    }
}
