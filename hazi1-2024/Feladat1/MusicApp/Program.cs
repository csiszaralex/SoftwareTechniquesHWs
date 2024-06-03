namespace MusicApp;

public class Program
{
    public static void Main(string[] args)
    {
        List<Song> songs = new List<Song>();

        StreamReader sr = null;
        try
        {
            sr = new StreamReader(@"music.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] lineItems = line.Split(';');

                string artist = lineItems[0].Trim();

                for (int i = 1; i < lineItems.Length; i++)
                {
                    Song song = new Song(artist, lineItems[i].Trim());
                    songs.Add(song);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("A fájl feldolgozása sikertelen.");
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (sr != null)
                sr.Close();
        }

        foreach (Song song in songs)
            Console.WriteLine(song.ToString());
    }
}
