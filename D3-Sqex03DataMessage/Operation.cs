using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace D3_Sqex03DataMessage
{
    class Operation
    {
        public static void ProgressBar(ProgressBar progressBar, int percent)
        {
            progressBar.BeginInvoke((MethodInvoker)delegate
            {
                progressBar.Value = percent > 100 ? 100 : percent;
            });

        }

        public static List<DataMessage> Decrypt(string appDir, string gameDir, ProgressBar progressBar)
        {
            
            List<DataMessage> result = new List<DataMessage>();
            double percent = 0;
            ProgressBar(progressBar, (int)percent);
            string[] archives = Directory.GetFiles(gameDir, "*.XXX", SearchOption.AllDirectories)
                    .Where(file => ArchiveConfig.ArchiveName.Contains(Path.GetFileName(file))).ToArray();
            if (archives.Length > 0)
            {
                foreach (string archive in archives)
                {
                    List<DataMessage> messages = Sqex03DataMessage.Decrypt(File.ReadAllBytes(archive));
                    foreach(DataMessage message in messages)
                    {
                        if (!result.Any(item => item.Name == message.Name)) result.Add(message);
                    }
                    percent += 100.0 / archives.Length;
                    ProgressBar(progressBar, (int)percent);
                }
            }
            ProgressBar(progressBar, 100);
            return result;
        }
        public static void ExportAll(string fileName, List<DataMessage> dataMessage, ProgressBar progressBar)
        {
            double percent = 100.0 / dataMessage.Count;
            string exportDir = Path.GetDirectoryName(fileName);
            Dictionary<string, int> json = new Dictionary<string, int>();
            List<string> content = new List<string>();
            foreach (DataMessage data in dataMessage)
            {
                List<string> messages = new List<string>();
                if (data.Speakers == null)
                {
                    messages = data.Strings;
                }
                else
                {
                    for (int i = 0; i < data.Strings.Count; i++)
                    {
                        messages.Add($"{data.Strings[i]}{(char)123}#Name={(char)34}{data.Speakers[i].Name}{(char)34}{(char)125}");
                    }
                }
                string dataStrings = String.Join("\r\n", messages.ToArray());
                content.Add(dataStrings);
                json.Add(data.Name, data.Strings.Count);
                percent += 100.0 / dataMessage.Count;
                ProgressBar(progressBar, (int)percent);

            }
            File.WriteAllText(fileName, String.Join("\r\n", content.ToArray()));
            string jsonSerializer = new JavaScriptSerializer().Serialize(json);
            File.WriteAllText(Path.Combine(exportDir, "export.json"), jsonSerializer);
            ProgressBar(progressBar, 100);
        }
        public static void ExportAllDirectory(string folderName, List<DataMessage> dataMessage, ProgressBar progressBar)
        {
            double percent = 100.0 / dataMessage.Count;
            foreach (DataMessage data in dataMessage)
            {
                string file = $"{data.Name}.txt";
                string filePath = Path.Combine(folderName, file);
                List<string> messages = new List<string>();
                if (data.Speakers == null)
                {
                    messages = data.Strings;
                }
                else
                {
                    for (int i = 0; i < data.Strings.Count; i++)
                    {
                        messages.Add($"{data.Strings[i]}{(char)123}#Name={(char)34}{data.Speakers[i].Name}{(char)34}{(char)125}");
                    }
                }
                string content = String.Join("\r\n", messages.ToArray());
                File.WriteAllText(filePath, content);
                percent += 100.0 / dataMessage.Count;
                ProgressBar(progressBar, (int)percent);
            }
            ProgressBar(progressBar, 100);
        }
        public static void Export(DataMessage dataMessage)
        {
            List<string> messages = new List<string>();
            if (dataMessage.Speakers == null)
            {
                messages = dataMessage.Strings;
            }
            else
            {
                for (int i = 0; i < dataMessage.Strings.Count; i++)
                {
                    messages.Add($"{dataMessage.Strings[i]}{(char)123}#Name={(char)34}{dataMessage.Speakers[i].Name}{(char)34}{(char)125}");
                }
            }
            byte[] data = Encoding.UTF8.GetBytes(String.Join("\r\n", messages.ToArray()));
            Thread newThread = new Thread(new ThreadStart(() =>
            {
                string fileName = DiaglogManager.SaveFile($"{dataMessage.Name}", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
                if (!string.IsNullOrEmpty(fileName))
                {
                    File.WriteAllBytes(fileName, data);
                }
            }));
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
            newThread.Join();
        }

        public static void ImportJSON(string jsonFile, ProgressBar progressBar)
        {
            Dictionary<string, string> exportJson = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(File.ReadAllText(jsonFile));
            double percent = 100.0 / jsonFile.Length;

            string[] strings = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(jsonFile), "Sqex03DataMessage.txt"));
            int line = 0;
            foreach (KeyValuePair<string, string> entry in exportJson)
            {
                DataMessage data = MainUI._DataMessage.Find(e => e.Name == entry.Key);
                int start = line;
                int index = 0;
                line += int.Parse($"{entry.Value}");
                for (int i = start; i < line; i++, index++)
                {
                    if (strings[i].Contains("{#Name=")) strings[i] = strings[i].Split(new string[] { "{#Name=" }, StringSplitOptions.None).First();
                    data.Strings[index] = strings[i];
                }
                percent += 100.0 / jsonFile.Length;
                ProgressBar(progressBar, (int)percent);
            }
            ProgressBar(progressBar, 100);
        }
        public static void ImportDirectory(string dir, ProgressBar progressBar)
        {
            string[] files = Directory.GetFiles(dir, "*.txt", SearchOption.TopDirectoryOnly);
            double percent = 100.0 / MainUI._DataMessage.Count;
            ProgressBar(progressBar, (int)percent);
            foreach (DataMessage data in MainUI._DataMessage)
            {
                string file = Array.Find(files, element => string.Equals(Path.GetFileNameWithoutExtension(element), data.Name, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrEmpty(file))
                {
                    string[] strings = File.ReadAllLines(file);
                    int count = Math.Min(data.Strings.Count, strings.Length);
                    for (int i = 0; i < count; i++)
                    {
                        string line = strings[i];
                        if (line.Contains("{#Name=")) line = line.Split(new string[] { "{#Name=" }, StringSplitOptions.None).First();
                        data.Strings[i] = line;
                    }
                }
                percent += 100.0 / MainUI._DataMessage.Count;
                ProgressBar(progressBar, (int)percent);
            }
            ProgressBar(progressBar, 100);
        }
        public static void Repack(string app_dir, string game_dir, List<DataMessage> data, ProgressBar progressBar)
        {
            List<string> archives = Directory.GetFiles(game_dir, "*.XXX", SearchOption.AllDirectories)
                    .Where(file => ArchiveConfig.ArchiveName.Contains(Path.GetFileName(file))).ToList();
            List<string> tocs = Directory.GetFiles(game_dir, "*.txt", SearchOption.AllDirectories)
                    .Where(file => ArchiveConfig.TOCName.Contains(Path.GetFileName(file))).ToList();
            if (archives.Count < 0) return;
            double percent = 0;
            Dictionary<string, string[]> tocContent = new Dictionary<string, string[]>();
            foreach (string toc in tocs)
            {
                tocContent.Add(Path.GetFileName(toc), File.ReadAllLines(toc));
            }
            foreach (string archive in archives)
            {
                byte[] bytes = Sqex03DataMessage.ReImport(data, archive);
                File.WriteAllBytes(archive, bytes);
                foreach (KeyValuePair<string, string[]> entry in tocContent)
                {
                    for (int i = 0; i < entry.Value.Length; i++)
                    {
                        string[] col = entry.Value[i].Split((char)32);
                        if (col.Length > 2 && col[2].Split((char)92).LastOrDefault().ToLower() == Path.GetFileName(archive).ToLower())
                        {
                            col[0] = $"{bytes.Length}";
                            entry.Value[i] = String.Join(" ", col);
                        }
                    }
                }
                percent += 100.0 / archives.Count;
                ProgressBar(progressBar, (int)percent);
            }
            foreach (string toc in tocs)
            {
                string[] content;
                if (tocContent.TryGetValue(Path.GetFileName(toc), out content)) 
                    File.WriteAllLines(toc, content);
            }
            ProgressBar(progressBar, 100);
        }
    }
}
