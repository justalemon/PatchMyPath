using NLog;
using NLog.Targets;
using System;
using System.Windows.Forms;

namespace PatchMyPath
{
    /// <summary>
    /// Target for writing log messages into WinForms TextBox objects.
    /// </summary>
    [Target("TextBox")]
    public class TextBoxTarget : TargetWithContext
    {
        /// <summary>
        /// The TextBox that this Target uses.
        /// </summary>
        public TextBox TextBox { get; }

        public TextBoxTarget(TextBox textBox) : base()
        {
            // Just save the text box for later use
            TextBox = textBox;
        }

        /// <summary>
        /// Appends the help message into the TextBox.
        /// </summary>
        /// <param name="LogEvent">The log information.</param>
        protected override void Write(LogEventInfo LogEvent)
        {
            // If the form does not has a handle
            if (!TextBox.IsHandleCreated)
            {
                // Get the handle with or without invoking
                if (TextBox.InvokeRequired)
                {
                    TextBox.Invoke(new Action(() => { IntPtr pointer = TextBox.Handle; }));
                }
                else
                {
                    // Get the handle to make sure that is available
                    IntPtr pointer = TextBox.Handle;
                }
            }

            // And add the text via Invoke
            TextBox.Invoke(new Action(() => TextBox.AppendText(Layout.Render(LogEvent) + Environment.NewLine)));
        }
    }
}
