
namespace advent24
{
    public class FileReaderUtil
    {
        public static List<string> ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);

            var lines = File.ReadAllLines(path);


            return new List<string>(lines);
        }
    }
}
