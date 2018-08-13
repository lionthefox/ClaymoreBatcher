using System;
using System.IO;
using System.Windows.Forms;

namespace ClaymoreBatcher
{
    public class FileCreator
    {
        public string Path { get; }
        public string NewPath { get; }
        public string DesktopPath { get; }
        public string SourceFile { get; }
        public string DestFile { get; }
        public ListView ListView { get; }

        public FileCreator(string path, string newPath, ListView listView1)
        {
            Path = path;
            NewPath = newPath;
            DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SourceFile = System.IO.Path.Combine(NewPath ?? Path, "StartMiner.bat");
            DestFile = System.IO.Path.Combine(DesktopPath, "StartMiner.bat");
            ListView = listView1;
        }

        public void CreateFile()
        {
            const string exe = "EthDcrMiner64.exe";
            const string header = "Batch file created!";
            const string msg = "The batch file (and a shortcut on your desktop) have been created.";
            string[] settings = new string[]
            {
                "setx GPU_FORCE_64BIT_PTR 0", "setx GPU_MAX_HEAP_SIZE 100", "setx GPU_USE_SYNC_OBJECTS 1",
                "setx GPU_MAX_ALLOC_PERCENT 100", "setx GPU_SINGLE_ALLOC_PERCENT 100"
            };
            var fs = new FileStream(NewPath == null ? Path + @"\StartMiner.bat" : NewPath + @"\StartMiner.bat",
                FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(fs);
            try
            {
                foreach (var s in settings)
                {
                    sw.WriteLine(s);
                }

                sw.WriteLine(exe);
                for (var i = 0; i < ListView.Items.Count; i++)
                {
                    sw.WriteLine("-" + ListView.Items[i].Text + " " + ListView.Items[i].SubItems[1].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                File.Copy(SourceFile, DestFile, true);
                MessageBox.Show(msg, header);
            }
        }
    }
}
