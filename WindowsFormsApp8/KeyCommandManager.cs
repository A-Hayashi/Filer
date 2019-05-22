using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp8.Action
{
    public class KeyCommandManager
    {
        static KeyCommandManager instance = new KeyCommandManager();
        private System.Collections.Hashtable valid_keys = new System.Collections.Hashtable();
        private System.Collections.Hashtable action_list = new System.Collections.Hashtable();

        static public KeyCommandManager Instance
        {
            get { return instance; }
        }

        private KeyCommandManager()
        {
            registValidKeys();
        }

        public void registAction(string key_command, Action action)
        {
            action_list.Add(key_command, action);
        }

        public bool executeAction(bool control, bool alt, bool shift, Keys key)
        {
            string str = getCommandString(control, alt, shift, key);

            if (str == "")
            {
                return false;
            }
            Action action = (Action)action_list[str];
            if (action == null)
            {
                return false;
            }
            action.execute();
            return true;
        }

        public string getCommandString(bool control, bool alt, bool shift, Keys key)
        {
            if (!valid_keys.Contains(key))
            {
                return "";
            }
            string command_str = "";
            if (control)
            {
                command_str += "ctrl";
            }
            if (alt)
            {
                command_str += "alt";
            }
            if (shift)
            {
                command_str += "shift";
            }
            command_str += valid_keys[key];
            return command_str;
        }

        private void registValidKeys()
        {
            valid_keys.Add(Keys.Enter, "Enter");
            valid_keys.Add(Keys.Escape, "Escape");
            valid_keys.Add(Keys.Space, "Space");
			valid_keys.Add(Keys.Back, "Back");
            valid_keys.Add(Keys.Delete, "Del");
            valid_keys.Add(Keys.Oem5, "\\");
		    valid_keys.Add(Keys.Left,"Left");
		    valid_keys.Add(Keys.Right,"Right");
            valid_keys.Add(Keys.F1, "F1");
            valid_keys.Add(Keys.F2, "F2");
            valid_keys.Add(Keys.F3, "F3");
            valid_keys.Add(Keys.F4, "F4");
            valid_keys.Add(Keys.F5, "F5");
            valid_keys.Add(Keys.F6, "F6");
            valid_keys.Add(Keys.F7, "F7");
            valid_keys.Add(Keys.F8, "F8");
            valid_keys.Add(Keys.F9, "F9");
            valid_keys.Add(Keys.F10, "F10");
            valid_keys.Add(Keys.F11, "F11");
            valid_keys.Add(Keys.F12, "F12");
            valid_keys.Add(Keys.A, "A");
            valid_keys.Add(Keys.B, "B");
            valid_keys.Add(Keys.C, "C");
            valid_keys.Add(Keys.D, "D");
            valid_keys.Add(Keys.E, "E");
            valid_keys.Add(Keys.F, "F");
            valid_keys.Add(Keys.G, "G");
            valid_keys.Add(Keys.H, "H");
            valid_keys.Add(Keys.I, "I");
            valid_keys.Add(Keys.J, "J");
            valid_keys.Add(Keys.K, "K");
            valid_keys.Add(Keys.L, "L");
            valid_keys.Add(Keys.M, "M");
            valid_keys.Add(Keys.N, "N");
            valid_keys.Add(Keys.O, "O");
            valid_keys.Add(Keys.P, "P");
            valid_keys.Add(Keys.Q, "Q");
            valid_keys.Add(Keys.R, "R");
            valid_keys.Add(Keys.S, "S");
            valid_keys.Add(Keys.T, "T");
            valid_keys.Add(Keys.U, "U");
            valid_keys.Add(Keys.V, "V");
            valid_keys.Add(Keys.W, "W");
            valid_keys.Add(Keys.X, "X");
            valid_keys.Add(Keys.Y, "Y");
            valid_keys.Add(Keys.Z, "Z");
        }


    }
}