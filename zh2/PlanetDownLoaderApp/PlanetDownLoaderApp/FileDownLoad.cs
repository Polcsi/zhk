using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace PlanetDownLoaderApp
{
    public class FileDownLoad
    {
        public bool StartDownLoad(string url, string localFilePath)
        {
            try
            {
                if (Directory.Exists("images"))
                {
                    Console.WriteLine("That path already exists.");
                } else
                {
                    Directory.CreateDirectory("images");
                    Console.WriteLine("The image directory created successfully");
                }

                Console.WriteLine($"Start: {url}");
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(url);
                Bitmap bitmap; bitmap = new Bitmap(stream);

                if (bitmap != null)
                {
                    bitmap.Save(localFilePath, ImageFormat.Jpeg);
                    Console.WriteLine("Download finished!");
                    return true;
                }

                stream.Flush();
                stream.Close();
                client.Dispose();

            }
            catch(WebException e)
            {
                Console.WriteLine("Done Success - False");
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Done Success - False");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;

        }
        private void webClientCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // nothing
        }
        private void webClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // nothing
        }
    }
}
