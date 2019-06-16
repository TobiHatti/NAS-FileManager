using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBCPlus_Host
{
    public enum LogType
    {
        Error,
        Info,
        Warning,
        Setup,
        Load,
        Blank
    }

    class RBCP_Log
    {
        private static TextBox compactTB;
        private static RichTextBox richTB;

        public static TextBox CompactLog
        {
            get => compactTB;
            set => compactTB = value;
        }

        public static RichTextBox RichLog
        {
            get => richTB;
            set => richTB = value;
        }

        public static void AddMessage(LogType type, string message)
        {
            string date = "[" + DateTime.Now + "] ";
            string rType = "";
            string rFull;
            Color rTypeColor = Color.White;
            Color rMsgColor = Color.White;


            /*
            try
            {
                RichLog.AppendText(date);
                RichLog.SelectionColor = Color.LightGray;
            }
            catch (Exception e) { }
            */
            

            switch (type)
            {
                case LogType.Error:
                    CompactLog.AppendText("[ERROR]\t");
                    rType = "[ERROR]\t   ";
                    rTypeColor = Color.Red;
                    rMsgColor = Color.Red;
                    break;

                case LogType.Info:
                    CompactLog.AppendText("[INFO]\t");
                    rType = "[INFO]\t   ";
                    rTypeColor = Color.Gold;
                    break;

                case LogType.Warning:
                    CompactLog.AppendText("[WARNING]\t");
                    rType = "[WARNING]  ";
                    rTypeColor = Color.Orange;
                    break;

                case LogType.Setup:
                    CompactLog.AppendText("[SETUP]\t");
                    rType = "[SETUP]\t   ";
                    rTypeColor = Color.Purple;
                    break;

                case LogType.Load:
                    CompactLog.AppendText("[LOAD]\t");
                    rType = "[LOAD]\t   ";
                    rTypeColor = Color.Lime;
                    break;

                case LogType.Blank:
                    CompactLog.AppendText("\t");
                    rType = "\t\t   ";
                    break;
            }

            CompactLog.AppendText(message + "\r\n");

            rFull = date + rType + message;

            int lineStartIndex;
            int lineLength;

            try
            {
                RichLog.AppendText(rFull + "\r\n");

                lineStartIndex = RichLog.Text.IndexOf(rFull);
                lineLength = rFull.Length;

                RichLog.Select(lineStartIndex, date.Length);
                RichLog.SelectionColor = Color.LightGray;

                RichLog.Select(lineStartIndex + date.Length, rType.Length);
                RichLog.SelectionColor = rTypeColor;

                RichLog.Select(lineStartIndex + date.Length + rType.Length, message.Length);
                RichLog.SelectionColor = rMsgColor;

                RichLog.ScrollToCaret();
            }
            catch (Exception e) { }
            
        }
    }
}
