using NAudio.Wave;
using System;
using System.Diagnostics;
using System.IO;

namespace PlayVideoInConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine("|                   Video Player               |");
            Console.WriteLine("|                  Create by Rimi              |");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
            Console.WindowWidth = 120;
            Console.WindowHeight = 50;
            Console.CursorVisible = false;
            Mp3FileReader mp3Reader = new Mp3FileReader(@".\IYE\IYE.mp3");
            WaveOutEvent waveOut = new WaveOutEvent();
            waveOut.Init(mp3Reader);
            waveOut.Play();
            int i = 0, frame = 0;
            double tpf = 0;
            double count_t = 0;
            Stopwatch st = new Stopwatch();
            st.Start();
            Console.SetCursorPosition(0, 1);
            while (i <= 14427)
            {
                tpf = 16.666666666666;
                frame++;
                if (st.ElapsedMilliseconds - count_t >= tpf)
                {
                    Console.WriteLine(File.ReadAllText(@".\IYE\ASCII-IYE" + i + ".txt"));
                    Console.WriteLine("\n-------------------------\n");
                    Console.WriteLine("Frame: " + i);
                    Console.WriteLine("FPS: " + Math.Round((decimal)1000 / (decimal)tpf));
                    frame = 0;
                    Console.WriteLine("TPF: " + tpf);
                    int Min = st.Elapsed.Minutes;
                    int sec = st.Elapsed.Seconds;
                    string min = string.Empty;
                    string Sec = string.Empty;
                    min = "0" + Min;
                    if (sec < 10)
                    {
                        Sec = "0" + sec;
                    }
                    else
                    {
                        Sec = sec.ToString();
                    }
                    Console.WriteLine("Time Elapsed: {0}:{1}", min, Sec);
                    Console.WriteLine("\n-------------------------\n");
                    Console.SetCursorPosition(0, 1);
                    i++;
                    count_t += tpf;
                }
            }
            Console.Clear();
            Console.WriteLine("END.");
            st.Stop();
            Console.CursorVisible = true;
            Console.ReadLine();
        }
    }
}
