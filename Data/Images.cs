using System.IO;
namespace BlazorServerApp.Data
{
    public class ImageProcessing
    {

        public string pathToImgs { get; set; } = Directory.GetCurrentDirectory() + "/wwwroot/images/";

        public List<string> GetImages()
        {
		List<string> images = new List<string>();
            	int i = 0;
            	string path = pathToImgs + i + ".png"; 
            	while (File.Exists(path))
            	{
                	string pathSrc = "/images/" + i + ".png";
                	images.Add(pathSrc);
                	i++;
                	path = pathToImgs + i + ".png";
           	 }
            	images.Reverse();
            	return images;
        }
        public System.Diagnostics.Process MakeImage(string path)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.UseShellExecute = true;
            startInfo.FileName = "/bin/bash";
            startInfo.Arguments = "/home/pi/print.sh raspistill -hf -w 1800 -h 1200 -o " + path;
            process.StartInfo = startInfo;
            process.Start();
            //process.WaitForExit();
            return process;
        }

        public string CreateLinkForSrc(string index)
        {

            return "/images/" + index + ".png";

        }
        public string CreateLinkForPrint(string index)
        {
            return index + ".png";
        }
        public string CreateFullLink(string index)
        {
            string path = pathToImgs + index + ".png";
            if (!File.Exists(path))
            {
                return path;

            }
            return null;
        }
        public int CountFiles()
        {

            DirectoryInfo path = new DirectoryInfo(Directory.GetCurrentDirectory() + "/wwwroot/images/");

            int fileLength = path.GetFiles().Length;

            return fileLength;

        }
    }
}
