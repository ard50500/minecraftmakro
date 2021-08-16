﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastPot
{
    class ThrowPot
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        public KeyboardHook.VKeys KeyBind { get; set; } = KeyboardHook.VKeys.KEY_Z;
        public KeyboardHook.VKeys ThrowPotKey { get; set; } = KeyboardHook.VKeys.KEY_F;
        public KeyboardHook.VKeys InventoryKey { get; set; } = KeyboardHook.VKeys.KEY_E;
        public KeyboardHook.VKeys FirstPot { get; set; } = KeyboardHook.VKeys.KEY_3;
        public KeyboardHook.VKeys LastPot { get; set; } = KeyboardHook.VKeys.KEY_1;
        public KeyboardHook.VKeys Sword { get; set; } = KeyboardHook.VKeys.KEY_1;
        public int CurrentPotSlot { get; set; } = 3;
        public int SwordSlot { get; set; } = 1;
        public bool IsToggled { get; set; }
        public bool IsReadyToPot { get; set; }

        public uint MOUSEEVENTF_RIGHTUP = 0x0010;
        public uint MOUSEEVENTF_RIGHTDOWN = 0x0008;

        KeyboardHook keyboardHook = new KeyboardHook();
        Random rnd = new Random();
        Thread sendKeys;

        public ThrowPot()
        {
            sendKeys = new Thread(ThrowPotion);
            keyboardHook.KeyUp += KeyboardHook_KeyUp;
            keyboardHook.Install();
        }

        void KeyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            if (key == KeyBind || key == KeyboardHook.VKeys.SHIFT)
            {
                IsToggled = !IsToggled;
                MainForm.MainFr.label1.Text = IsToggled ? "HİLE KAPALIMI: EVET" : "HİLE KAPALIMI: HAYIR";
            }

            if (key == ThrowPotKey && !IsReadyToPot && IsToggled)
            {
                if (CurrentPotSlot > (int)LastPot - 48) CurrentPotSlot = (int)FirstPot - 48;
                if (!sendKeys.IsAlive)
                {
                    sendKeys = new Thread(ThrowPotion);
                    sendKeys.Start();
                }
                else
                {
                    sendKeys.Abort();
                }
            }
            if (key == InventoryKey) CurrentPotSlot = (int)FirstPot - 48;
        }

        void ThrowPotion()
        {
            IsReadyToPot = true;
            SendKeys.SendWait("{" + CurrentPotSlot.ToString() + "}");
            Thread.Sleep(int.Parse(MainForm.MainFr.textBox1.Text));
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, MOUSEEVENTF_RIGHTDOWN, 0);
            Thread.Sleep(rnd.Next(1, 20));
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, MOUSEEVENTF_RIGHTUP, 0);
            Thread.Sleep(50);
            SwordSlot = (int)Sword - 48;
            SendKeys.SendWait("{"+ SwordSlot.ToString()+"}");
            IsReadyToPot = false;
            CurrentPotSlot++;
        }
    }
}
