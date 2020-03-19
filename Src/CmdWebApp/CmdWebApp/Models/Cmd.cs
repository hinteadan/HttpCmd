namespace CmdWebApp.Models
{
    public class Cmd
    {
        public string Path { get; set; }
        public string Args { get; set; }
        public int ResponseWaitTimeoutInSeconds { get; set; } = 30;
    }
}