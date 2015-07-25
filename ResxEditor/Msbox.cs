using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ResxEditor
{
    public class Msbox
    {
        /// <summary>
        /// MsBox Icon style
        /// </summary>
        public enum MsBoxIcon
        {
            /// <summary>
            /// Show information icon
            /// </summary>
            Information,

            /// <summary>
            /// Show warning icon
            /// </summary>
            Warning,

            /// <summary>
            /// Show error icon
            /// </summary>
            Error,

            /// <summary>
            /// This icon is only compatible the windows vista and later, and this icon will be replaced with information if the Windows version is XP
            /// </summary>
            Sheild
        }

        public enum MsBoxButtons
        {
            Ok,
            Cancel,
            Yes,
            No,
            Close,
            Retry,

            /// <summary>
            /// Only supported in new message box
            /// </summary>
            None,

            /// <summary>
            /// Supported only in old message box
            /// </summary>
            Abort,

            /// <summary>
            /// Supported only in old message box
            /// </summary>
            Ignore
        };

        public enum MsBoxReturn
        {
            Ok,
            Cancel,
            Yes,
            No,
            Close,
            Retry,

            /// <summary>
            /// Only supported in new message box
            /// </summary>
            None,

            /// <summary>
            /// Supported only in old message box
            /// </summary>
            Abort,

            /// <summary>
            /// Supported only in old message box
            /// </summary>
            Ignore
        };

        public static MsBoxReturn ShowMessage(IWin32Window owner, string Text, string Title, MsBoxIcon icon, MsBoxButtons buttons)
        {
            if (TaskDialog.IsPlatformSupported)
            {
                TaskDialog dlg = new TaskDialog();
                dlg.InstructionText = Title;
                dlg.Text = Text;
                dlg.OwnerWindowHandle = owner.Handle;
                switch (icon)
                {
                    case MsBoxIcon.Information:
                        dlg.Icon = TaskDialogStandardIcon.Information;
                        break;

                    case MsBoxIcon.Warning:
                        dlg.Icon = TaskDialogStandardIcon.Warning;
                        break;

                    case MsBoxIcon.Error:
                        dlg.Icon = TaskDialogStandardIcon.Error;
                        break;

                    case MsBoxIcon.Sheild:
                        dlg.Icon = TaskDialogStandardIcon.Shield;
                        break;

                    default:
                        break;
                }
                dlg.FooterIcon = dlg.Icon;
                if (buttons == MsBoxButtons.Cancel)
                {
                    dlg.StandardButtons |= TaskDialogStandardButtons.Cancel;
                }
                if (buttons == MsBoxButtons.Close)
                {
                    dlg.StandardButtons |= TaskDialogStandardButtons.Close;
                }
                if (buttons == MsBoxButtons.No)
                {
                    dlg.StandardButtons |= TaskDialogStandardButtons.No;
                }
                if (buttons == MsBoxButtons.Ok)
                {
                    dlg.StandardButtons |= TaskDialogStandardButtons.Ok;
                }
                if (buttons == MsBoxButtons.Retry)
                {
                    dlg.StandardButtons |= TaskDialogStandardButtons.Retry;
                }
                if (buttons == MsBoxButtons.Yes)
                {
                    dlg.StandardButtons |= TaskDialogStandardButtons.Yes;
                }
                if (buttons == MsBoxButtons.None)
                {
                    dlg.StandardButtons = TaskDialogStandardButtons.None;
                }
                var re = dlg.Show();
                switch (re)
                {
                    case TaskDialogResult.Cancel:
                        return MsBoxReturn.Cancel;

                    case TaskDialogResult.Close:
                        return MsBoxReturn.Close;

                    case TaskDialogResult.No:

                        return MsBoxReturn.No;

                    case TaskDialogResult.None:
                        return MsBoxReturn.None;

                    case TaskDialogResult.Ok:
                        return MsBoxReturn.Ok;

                    case TaskDialogResult.Retry:
                        return MsBoxReturn.Retry;

                    case TaskDialogResult.Yes:
                        return MsBoxReturn.Yes;

                    default:
                        return MsBoxReturn.None;
                }
            }
            else
            {
                MessageBoxButtons btns = MessageBoxButtons.OK;
                if (buttons == (MsBoxButtons.Yes | MsBoxButtons.No))
                {
                    btns = MessageBoxButtons.YesNo;
                }
                else if (buttons == (MsBoxButtons.Yes | MsBoxButtons.No | MsBoxButtons.Cancel))
                {
                    btns = MessageBoxButtons.YesNoCancel;
                }
                else if (buttons == (MsBoxButtons.Retry | MsBoxButtons.Cancel))
                {
                    btns = MessageBoxButtons.RetryCancel;
                }
                else if (buttons == (MsBoxButtons.Ok | MsBoxButtons.Cancel))
                {
                    btns = MessageBoxButtons.OKCancel;
                }
                else if (buttons == (MsBoxButtons.Ok))
                {
                    btns = MessageBoxButtons.OK;
                }
                else if (buttons == (MsBoxButtons.Retry | MsBoxButtons.Ignore | MsBoxButtons.Abort))
                {
                    btns = MessageBoxButtons.AbortRetryIgnore;
                }
                MessageBoxIcon ic;
                switch (icon)
                {
                    case MsBoxIcon.Information:
                        ic = MessageBoxIcon.Information;
                        break;

                    case MsBoxIcon.Warning:
                        ic = MessageBoxIcon.Warning;
                        break;

                    case MsBoxIcon.Error:

                        ic = MessageBoxIcon.Error;
                        break;

                    case MsBoxIcon.Sheild:

                        ic = MessageBoxIcon.Question;
                        break;

                    default:
                        ic = MessageBoxIcon.Information;
                        break;
                }
                var res = MessageBox.Show(owner, Text, Title, btns, ic);
                switch (res)
                {
                    case DialogResult.Abort:
                        return MsBoxReturn.Abort;

                    case DialogResult.Cancel:
                        return MsBoxReturn.Cancel;

                    case DialogResult.Ignore:
                        return MsBoxReturn.Ignore;

                    case DialogResult.No:
                        return MsBoxReturn.No;

                    case DialogResult.None:
                        return MsBoxReturn.None;

                    case DialogResult.OK:
                        return MsBoxReturn.Ok;

                    case DialogResult.Retry:
                        return MsBoxReturn.Retry;

                    case DialogResult.Yes:
                        return MsBoxReturn.Yes;

                    default:
                        return MsBoxReturn.None;
                }
            }
        }
    }
}