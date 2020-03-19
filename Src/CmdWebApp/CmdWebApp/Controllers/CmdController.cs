using CmdWebApp.Models;
using System;
using System.Diagnostics;
using System.Text;
using System.Web.Http;

namespace CmdWebApp.Controllers
{
    public class CmdController : ApiController
    {
        // POST: api/Cmd
        public IHttpActionResult Post(Cmd cmd)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = cmd.Path,
                    Arguments = cmd.Args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            StringBuilder printer = new StringBuilder();

            DateTime startedAt = DateTime.Now;

            try
            {
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    if ((DateTime.Now - startedAt).TotalSeconds > cmd.ResponseWaitTimeoutInSeconds)
                    {
                        proc.Kill();
                        return Ok("Timed out");
                    }

                    printer.AppendLine(proc.StandardOutput.ReadLine());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return Ok(printer.ToString());
        }
    }
}
