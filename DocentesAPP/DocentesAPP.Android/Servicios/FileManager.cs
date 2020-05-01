using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Runtime;
using RestSharp;
using DocentesApp.Interfaces;
using System;
using Xamarin.Forms;
using Environment = System.Environment;
using System.IO;
using DocentesAPP.Droid;

[assembly : Dependency(typeof(FileManager))]
namespace DocentesAPP.Droid
{
    public class FileManager : IFileManager
    {
        public bool SaveText(string filename, string text, bool overWrite = true)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            if (!overWrite) if (System.IO.File.Exists(filePath)) return false;
            System.IO.File.WriteAllText(filePath, text);
            return true;
        }
        public string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }
        public Stream LoadFile(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            try { return System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read); }
            catch (Exception e)
            {
                Console.WriteLine("FileIO Error: " + e.Message);
            }
            return null;
        }

        public bool exist(string filename, string path = "")
        {
            var filePath = "";
            if (path == "")
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                filePath = Path.Combine(documentsPath, filename);
            } 
            else
            {
                filePath = Path.Combine(path, filename);
            }
            return System.IO.File.Exists(filePath);
        }

        public bool delete(string filename, string documentsPath = "")
        {
            string filePath;
            if (documentsPath == "")
            {
                documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                filePath = Path.Combine(documentsPath, filename);
            }
            else
            {
                filePath = Path.Combine(documentsPath, filename);
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        public string getFullPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
    }
}