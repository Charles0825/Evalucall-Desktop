using System;
using System.Drawing;
using System.Windows.Forms;

public class NotificationManager
{
    private Label lblMessage;
    private Timer timer;

    public NotificationManager(Label label)
    {
        lblMessage = label;
        timer = new Timer();
        timer.Interval = 5000;
        timer.Tick += Timer_Tick;
    }

    public void DisplayNotification(string message, NType type = NType.Default )
    {
        lblMessage.Text = message;
        lblMessage.TextAlign = ContentAlignment.MiddleCenter;

        switch (type)
        {
            case NType.Error:
                lblMessage.ForeColor = Color.Red;
                break;
            case NType.Success:
                lblMessage.ForeColor = Color.Green;
                break;
            default:
                lblMessage.ForeColor = SystemColors.ControlText;
                break;
        }
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblMessage.ForeColor = SystemColors.ControlText;
        timer.Stop();
    }

    public enum NType
    {
        Error,
        Success,
        Default
    }
}
