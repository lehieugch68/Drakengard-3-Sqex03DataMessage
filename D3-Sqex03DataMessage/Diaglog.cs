﻿using System;
using System.Windows.Forms;
using System.IO;

namespace D3_Sqex03DataMessage
{
    class Diaglog
    {
        public static string FolderBrowser(string filename)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = filename;
            string result = null;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                result = Path.GetDirectoryName(folderBrowser.FileName);
            }
            return result;
        }

        public static void SaveFile(string name, byte[] data, string filter)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = name;
            savefile.Filter = filter;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(savefile.FileName, data);
            }
        }

        public static string FileBrowser(string filename, string filter)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            fileBrowser.Filter = filter;
            fileBrowser.FileName = filename;
            string result = null;
            
            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                result = fileBrowser.FileName;
            }
            return result;
        }
    }
}
