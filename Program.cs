using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.Threading;
using System.Runtime.CompilerServices;

namespace rhythm_games_to_bemani
{
    public class Program
    {
        public static string AskSource()
        {
            Console.WriteLine(" Which game do you want to search through for BEMANI songs?");
            Console.WriteLine(" 1. osu!\n 2. Stepmania\n 3. Clone Hero");
            Console.Write(" ");
            string gameSelection = Console.ReadLine();
            if (gameSelection.Length >= 2)
            {
                Console.WriteLine(" Error: Only type one option.");
                return AskSource();
            }
            else if (!gameSelection.Contains("1") && !gameSelection.Contains("2") && !gameSelection.Contains("3"))
            {
                Console.WriteLine(" Error: You didn't select an option.");
                return AskSource();
            }
            else if (gameSelection.Contains("1"))
            {
                Console.WriteLine(" Searching for osu! songs...");
                string game = "1";
                return game;
            }
            else if (gameSelection.Contains("2"))
            {
                Console.WriteLine(" Searching for Stepmania songs...");
                string game = "2";
                return game;
            }
            else
            {
                Console.WriteLine(" Searching for Clone Hero songs...");
                string game = "3";
                return game;
            }
        }
        public static string AskDirectory()
        {
            string gameDir = AskSource();
            if (gameDir == "1")
            {
                string osuDirectory = OsuDirectory();
                return osuDirectory;
            }
            else if (gameDir == "2")
            {
                string stepmaniaDirectory = StepmaniaDirectory();
                return stepmaniaDirectory;
            }
            else
            {
                string cloneHeroDirectory = CloneHeroDirectory();
                return cloneHeroDirectory;
            }          
        }
        public static string OsuDirectory()
        {
            Console.Write(" Enter the directory for your osu! songs folder: ");
            string osuSongDirectory = Console.ReadLine();
            if (File.Exists(osuSongDirectory))
            {
                Console.WriteLine(" Error: That directory is a file, not a folder.");
                return OsuDirectory();
            }
            else if (Directory.Exists(osuSongDirectory))
            {
                Console.WriteLine(" Using the specified directory: " + osuSongDirectory);
                return osuSongDirectory;
            }
            else
            {
                Console.WriteLine(" Error: That is not a valid directory.");
                return OsuDirectory();
            }
        }
        public static string StepmaniaDirectory()
        {
            Console.Write(" Enter the directory of your Stepmania songs folder: ");
            string stepmaniaSongDirectory = Console.ReadLine();
            if (File.Exists(stepmaniaSongDirectory))
            {
                Console.WriteLine(" Error: That directory is a file, not a folder.");
                return StepmaniaDirectory();
            }
            else if (Directory.Exists(stepmaniaSongDirectory))
            {
                Console.WriteLine(" Using the specified directory: " + stepmaniaSongDirectory);
                return stepmaniaSongDirectory;
            }
            else
            {
                Console.WriteLine(" Error: That is not a valid directory.");
                return StepmaniaDirectory();
            }
        }
        public static string CloneHeroDirectory()
        {
            Console.Write(" Enter the directory of your Clone Hero songs folder: ");
            string cloneHeroSongDirectory = Console.ReadLine();
            if (File.Exists(cloneHeroSongDirectory))
            {
                Console.WriteLine(" Error: That directory is a file, not a folder.");
                return CloneHeroDirectory();
            }
            else if (Directory.Exists(cloneHeroSongDirectory))
            {
                Console.WriteLine(" Using the specified directory: " + cloneHeroSongDirectory);
                return cloneHeroSongDirectory;
            }
            else
            {
                Console.WriteLine(" Error: That is not a valid directory.");
                return CloneHeroDirectory();
            }
        }
        public static string Selection()
        {
            Console.WriteLine(" Rhythm Games to Bemani converter v2.0.0 by @suprnova123 - Last built on August 26th, 2020");
            Console.WriteLine("\n Which Bemani games do you want to search for songs in?");
            Console.WriteLine(" 1. beatmania IIDX 27 \n 2. pop'n'music peace \n 3. DanceDanceRevolution A20 \n 4. GITADORA NEX+AGE \n 5. jubeat festo \n 6. REFLEC BEAT 悠久のリフレシア \n 7. Sound Voltex Vivid Wave \n 8. Nostalgia Op.3 \n 9. Dancerush Stardom \n 0. MUSECA");
            Console.WriteLine(" You can combine every game into one message by typing multiple numbers \n (i.e. 157 for beatmania, jubeat, and SDVX or 1234567890 for every game)");
			Console.Write(" Please make your selection: ");
            string selection = Console.ReadLine().Trim();
            if (selection.Length <= 0)
            {
                Console.WriteLine(" Error: Selection cannot be blank");
                return Selection();
            }
            foreach (char c in selection)
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine(" Error: Wrong format, only use digits");
                    return Selection();
                }
            }
            return selection;
        }
        public static bool FileOption()
        {
            Console.Write(" Do you want to save your results to a file? (y) (n): ");
            string selectionFile = Console.ReadLine().Trim();
            if (selectionFile.Length <= 0)
            {
                Console.WriteLine(" Error: This is not a yes or no answer.");
                return FileOption();
            }
            if (selectionFile.Contains("y") && selectionFile.Contains("n"))
            {
                Console.WriteLine(" You cannot select both yes and no.");
                return FileOption();
            }
            if (selectionFile.Contains("y"))
            {
                bool useFile = true;
                return useFile;
            }
            else if (selectionFile.Contains("n"))
            {
                bool useFile = false;
                return useFile;
            }
            else
            {
                return FileOption();
            }
        }
        static void Main()
        {
            string input = Selection();
            bool filebool = FileOption();
            string IIDXPage = "empty";
            string IIDXPage2 = "empty";
            string pmPage = "empty";
            string pmPage2 = "empty";
            string DDRPage = "empty";
            string DDRPage2 = "empty";
            string GDPage = "empty";
            string GDPage2 = "empty";
            string GDPage3 = "empty";
            string jubeatPage = "empty";
            string jubeatPage2 = "empty";
            string reflectPage = "empty";
            string reflectPage2 = "empty";
            string SDVXPage = "empty";
            string SDVXPage2 = "empty";
            string nostalgiaPage = "empty";
            string nostalgiaPage2 = "empty";
            string DRSDPage = "empty";
            string MUSECAPage = "empty";
			Console.WriteLine(" Please note that, depending on your location, this process might take a while. \n This is because the song lists used are from bemaniwiki.com, \n which is a website hosted in Japan that is pretty slow to begin with");
            // what is a switch statement
            if (input.Contains("1"))
            {
                Console.WriteLine(" Requesting beatmania IIDX song lists...");
                HttpWebRequest IIDXReq = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?beatmania%20IIDX%2027%20HEROIC%20VERSE/%BF%B7%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse IIDXres = (HttpWebResponse)IIDXReq.GetResponse();
                using (StreamReader sr = new StreamReader(IIDXres.GetResponseStream()))
                {
                    IIDXPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
                HttpWebRequest IIDXReq2 = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?beatmania%20IIDX%2027%20HEROIC%20VERSE/%B5%EC%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse IIDXres2 = (HttpWebResponse)IIDXReq2.GetResponse();
                using (StreamReader sr2 = new StreamReader(IIDXres2.GetResponseStream()))
                {
                    IIDXPage2 = sr2.ReadToEnd();
                }
                Console.WriteLine(" Page Two: Success!");
            }
            if (input.Contains("2"))
            {
                Console.WriteLine(" Requesting pop'n'music song lists...");
                HttpWebRequest pmReq = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?pop%27n%20music%20peace/%BF%B7%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse pmres = (HttpWebResponse)pmReq.GetResponse();
                using (StreamReader sr = new StreamReader(pmres.GetResponseStream()))
                {
                    pmPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
                HttpWebRequest pmReq2 = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?pop%27n%20music%20peace/%B5%EC%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse pmres2 = (HttpWebResponse)pmReq2.GetResponse();
                using (StreamReader sr2 = new StreamReader(pmres2.GetResponseStream()))
                {
                    pmPage2 = sr2.ReadToEnd();
                }
                Console.WriteLine(" Page Two: Success!");
            }
            if (input.Contains("3"))
            {
                Console.WriteLine(" Requesting Dance Dance Revolution song lists...");
                HttpWebRequest ddrReq = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?DanceDanceRevolution%20A20/%BF%B7%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse ddrres = (HttpWebResponse)ddrReq.GetResponse();
                using (StreamReader sr = new StreamReader(ddrres.GetResponseStream()))
                {
                    DDRPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
                HttpWebRequest ddrReq2 = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?DanceDanceRevolution%20A20/%B5%EC%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse ddrres2 = (HttpWebResponse)ddrReq2.GetResponse();
                using (StreamReader sr2 = new StreamReader(ddrres2.GetResponseStream()))
                {
                    DDRPage2 = sr2.ReadToEnd();
                }
                Console.WriteLine(" Page Two: Success!");
            }
            if (input.Contains("4"))
            {
                Console.WriteLine(" Requesting GITADORA song lists...");
                HttpWebRequest gdReq = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?GITADORA%20NEX%2BAGE/%BF%B7%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse gdres = (HttpWebResponse)gdReq.GetResponse();
                using (StreamReader sr = new StreamReader(gdres.GetResponseStream()))
                {
                    GDPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
                HttpWebRequest gdReq2 = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?GITADORA%20NEX%2BAGE/%B5%EC%B6%CA%A5%EA%A5%B9%A5%C8%28%A1%C1XG3%29");
                HttpWebResponse gdres2 = (HttpWebResponse)gdReq2.GetResponse();
                using (StreamReader sr2 = new StreamReader(gdres2.GetResponseStream()))
                {
                    GDPage2 = sr2.ReadToEnd();
                }
                Console.WriteLine(" Page Two: Success!");
                HttpWebRequest gdReq3 = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?GITADORA%20NEX%2BAGE/%B5%EC%B6%CA%A5%EA%A5%B9%A5%C8%28GITADORA%A1%C1%29");
                HttpWebResponse gdres3 = (HttpWebResponse)gdReq3.GetResponse();
                using (StreamReader sr3 = new StreamReader(gdres3.GetResponseStream()))
                {
                    GDPage3 = sr3.ReadToEnd();
                }
                Console.WriteLine(" Page Three: Success!");
            }
            if (input.Contains("5"))
            {
                Console.WriteLine(" Requesting jubeat song lists...");
                HttpWebRequest jubeatReq = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?jubeat%20festo/%BF%B7%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse jubeatres = (HttpWebResponse)jubeatReq.GetResponse();
                using (StreamReader sr = new StreamReader(jubeatres.GetResponseStream()))
                {
                    jubeatPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
                HttpWebRequest jubeatReq2 = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?jubeat%20festo/%B5%EC%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse jubeatres2 = (HttpWebResponse)jubeatReq2.GetResponse();
                using (StreamReader sr2 = new StreamReader(jubeatres2.GetResponseStream()))
                {
                    jubeatPage2 = sr2.ReadToEnd();
                }
                Console.WriteLine(" Page Two: Success!");
            }
            if (input.Contains("6"))
            {
                Console.WriteLine(" Requesting Reflec Beat song lists...");
                HttpWebRequest rbReq = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?REFLEC%20BEAT%20%CD%AA%B5%D7%A4%CE%A5%EA%A5%D5%A5%EC%A5%B7%A5%A2/%BF%B7%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse rbres = (HttpWebResponse)rbReq.GetResponse();
                using (StreamReader sr = new StreamReader(rbres.GetResponseStream()))
                {
                    reflectPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
                HttpWebRequest rbReq2 = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?REFLEC%20BEAT%20%CD%AA%B5%D7%A4%CE%A5%EA%A5%D5%A5%EC%A5%B7%A5%A2/%A5%EA%A5%E1%A5%A4%A5%AF%C9%E8%CC%CC%A5%EA%A5%B9%A5%C8");
                HttpWebResponse rbres2 = (HttpWebResponse)rbReq2.GetResponse();
                using (StreamReader sr2 = new StreamReader(rbres2.GetResponseStream()))
                {
                    reflectPage2 = sr2.ReadToEnd();
                }
                Console.WriteLine(" Page Two: Success!");
            }
            if (input.Contains("7"))
            {
                Console.WriteLine(" Requesting Sound Voltex song lists...");
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?SOUND%20VOLTEX%20VIVID%20WAVE/%B5%EC%B6%CA/%B3%DA%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();
                using (StreamReader sr = new StreamReader(myres.GetResponseStream()))
                {
                    SDVXPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
                HttpWebRequest myReq2 = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?SOUND%20VOLTEX%20VIVID%20WAVE/%BF%B7%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse myres2 = (HttpWebResponse)myReq2.GetResponse();
                using (StreamReader sr2 = new StreamReader(myres2.GetResponseStream()))
                {
                    SDVXPage2 = sr2.ReadToEnd();
                }
                Console.WriteLine(" Page Two: Success!");
            }
            if (input.Contains("8"))
            {
                Console.WriteLine(" Requesting Nostalgia song lists...");
                HttpWebRequest nostReq = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?%A5%CE%A5%B9%A5%BF%A5%EB%A5%B8%A5%A2%20Op.3/%BF%B7%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse nostres = (HttpWebResponse)nostReq.GetResponse();
                using (StreamReader sr = new StreamReader(nostres.GetResponseStream()))
                {
                    nostalgiaPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
                HttpWebRequest nostReq2 = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?%A5%CE%A5%B9%A5%BF%A5%EB%A5%B8%A5%A2%20Op.3/%B5%EC%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse nostres2 = (HttpWebResponse)nostReq2.GetResponse();
                using (StreamReader sr2 = new StreamReader(nostres2.GetResponseStream()))
                {
                    nostalgiaPage2 = sr2.ReadToEnd();
                }
                Console.WriteLine(" Page Two: Success!");
            }
            if (input.Contains("9"))
            {
                Console.WriteLine(" Requesting Dancerush Stardom song list...");
                HttpWebRequest drsdReq = (HttpWebRequest)WebRequest.Create("https://bemaniwiki.com/index.php?DANCERUSH%20STARDOM/%BC%FD%CF%BF%B6%CA%A5%EA%A5%B9%A5%C8");
                HttpWebResponse drsdres = (HttpWebResponse)drsdReq.GetResponse();
                using (StreamReader sr = new StreamReader(drsdres.GetResponseStream()))
                {
                    DRSDPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
            }
            if (input.Contains("0"))
            {
                Console.WriteLine(" Requesting MUSECA song list...");
                HttpWebRequest drsdReq = (HttpWebRequest)WebRequest.Create("https://remywiki.com/index.php?title=Category:MUSECA_Songs&pageuntil=Yukiiro+sakura#mw-pages");
                HttpWebResponse drsdres = (HttpWebResponse)drsdReq.GetResponse();
                using (StreamReader sr = new StreamReader(drsdres.GetResponseStream()))
                {
                    MUSECAPage = sr.ReadToEnd();
                }
                Console.WriteLine(" Page One: Success!");
            }
            string IIDXPageUpper = IIDXPage.ToUpper();
            string IIDXPageUpper2 = IIDXPage2.ToUpper();
            string pmPageUpper = pmPage.ToUpper();;
            string pmPageUpper2 = pmPage2.ToUpper();;
            string DDRPageUpper = DDRPage.ToUpper();;
            string DDRPageUpper2 = DDRPage2.ToUpper();;
            string GDPageUpper = GDPage.ToUpper();;
            string GDPageUpper2 = GDPage2.ToUpper();;
            string GDPageUpper3 = GDPage3.ToUpper();;
            string jubeatPageUpper = jubeatPage.ToUpper();;
            string jubeatPageUpper2 = jubeatPage2.ToUpper();;
            string reflectPageUpper = reflectPage.ToUpper();;
            string reflectPageUpper2 = reflectPage2.ToUpper();;
            string SDVXPageUpper = SDVXPage.ToUpper();;
            string SDVXPageUpper2 = SDVXPage2.ToUpper();;
            string nostalgiaPageUpper = nostalgiaPage.ToUpper();;
            string nostalgiaPageUpper2 = nostalgiaPage2.ToUpper();;
            string DRSDPageUpper = DRSDPage.ToUpper();;
            string MUSECAPageUpper = MUSECAPage.ToUpper();;
            int i = 0;
            string[] matchesIIDX = new string[100000];
            string[] matchesPM = new string[100000];
            string[] matchesDDR = new string[100000];
            string[] matchesGD = new string[100000];
            string[] matchesjubeat = new string[100000];
            string[] matchesreflect = new string[100000];
            string[] matchesSDVX = new string[100000];
            string[] matchesnostalgia = new string[100000];
            string[] matchesDRSD = new string[100000];
            string[] matchesMUSECA = new string[100000];
            string directory = AskDirectory();
            Console.WriteLine(" Searching Bemaniwiki...");
            string[] files = Directory.GetFiles(directory, "*.osu", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                files = Directory.GetFiles(directory, "*.sm", SearchOption.AllDirectories);
                if (files.Length == 0)
                {
                    files = Directory.GetFiles(directory, "*.ini", SearchOption.AllDirectories);
                    if (files.Length == 0)
                    {
                        Console.WriteLine(" Error: No files found!");
                        Console.WriteLine(" Press Enter to exit this window.");
                    }
                }
            }
            string[] matched = new string[100000];
            foreach (string file in files)
            {
                string result = String.Empty;
                string resultUni = String.Empty;
                string path = file.Replace("\\", "\\\\");
                if (file.Contains(".osu")) // osu
                {
                    result = string.Empty;
                    resultUni = string.Empty;
                    var lines = File.ReadAllLines(path);
                    foreach (var line in lines)
                    {
                        if (line.Contains("Title:")) // title saved
                        {
                            var text = line.Replace("Title:", "");
                            var text2 = text;
                            if (text.Contains("(TV Size)"))
                            {
                                text2 = text.Replace("(TV Size)", "");
                            }
                            result = text2.Trim();
                            if (matched.Contains(result))
                            {
                                goto theend;
                            }
                        }
                        else if (line.Contains("TitleUnicode:")) // unicode title saved
                        {
                            var textUni = line.Replace("TitleUnicode:", "");
                            var textUni2 = textUni;
                            if (textUni.Contains("(TV Size)"))
                            {
                                textUni2 = textUni.Replace("(TV Size)", "");
                            }
                            result = textUni2.Trim();
                            if (resultUni == "")
                            {
                                resultUni = "N/A";
                            }
                        }
                        else if (!String.IsNullOrWhiteSpace(result) && !String.IsNullOrWhiteSpace(resultUni)) //title and unicode title filled, move on
                        {
                            goto search;
                        }
                        //no match, next line
                    }
                }
                else if (file.Contains(".sm")) // stepmania
                {
                    result = string.Empty;
                    var lines = File.ReadAllLines(path);
                    foreach (var line in lines)
                    {
                        if (line.Contains("#TITLE:")) // title saved
                        {
                            var text = line.Replace("#TITLE:", "");
                            result = text.Trim(';');
                            if (matched.Contains(result))
                            {
                                goto theend;
                            }
                            goto search;
                        }
                    } // no match, move on
                }
                else if (file.Contains(".ini")) // clone hero
                {

                    result = string.Empty;
                    var lines = File.ReadAllLines(path);
                    foreach (var line in lines)
                    {
                        if (line.Contains("name")) // title saved
                        {
                            var text = line.Replace("name", "");
                            var text2 = text.Replace("=", "");
                            result = text2.Trim();
                            if (matched.Contains(result))
                            {
                                goto theend;
                            }
                            goto search;
                        }
                    } // no match, move on
                }
            search:
                string songBracket = ">" + result.ToUpper() + "<";
                string songBracketUnicode = ">" + resultUni.ToUpper() + "<";
                bool containsUnicode = songBracketUnicode.Contains(">N/A<");
                matched[i] = result;
                i++;
                if (input.Contains("1"))
                {
                    if (IIDXPageUpper.Contains(songBracket) || IIDXPageUpper2.Contains(songBracket))
                    {
                        matchesIIDX[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (IIDXPageUpper.Contains(songBracketUnicode) || IIDXPageUpper2.Contains(songBracketUnicode))
                        {
                            matchesIIDX[i] = resultUni;
                            i++;
                        }
                    }
                }
                if (input.Contains("2"))
                {
                    if (pmPageUpper.Contains(songBracket) || pmPageUpper2.Contains(songBracket))
                    {
                        matchesPM[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (pmPageUpper.Contains(songBracketUnicode) || pmPageUpper2.Contains(songBracketUnicode))
                        {
                            matchesPM[i] = resultUni;
                            i++;
                        }
                    }
                }
                if (input.Contains("3"))
                {
                    if (DDRPageUpper.Contains(songBracket) || DDRPageUpper2.Contains(songBracket))
                    {
                        matchesDDR[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (DDRPageUpper.Contains(songBracketUnicode) || DDRPageUpper2.Contains(songBracketUnicode))
                        {
                            matchesDDR[i] = resultUni;
                            i++;
                        }
                    }
                }
                if (input.Contains("4"))
                {
                    if (GDPageUpper.Contains(songBracket) || GDPageUpper2.Contains(songBracket) || (GDPageUpper3.Contains(songBracket)))
                    {
                        matchesGD[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (GDPageUpper.Contains(songBracketUnicode) || GDPageUpper2.Contains(songBracketUnicode) || (GDPageUpper3.Contains(songBracket)))
                        {
                            matchesGD[i] = resultUni;
                            i++;
                        }
                    }
                }
                if (input.Contains("5"))
                {
                    if (jubeatPageUpper.Contains(songBracket) || jubeatPageUpper2.Contains(songBracket))
                    {
                        matchesjubeat[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (jubeatPageUpper.Contains(songBracketUnicode) || jubeatPageUpper2.Contains(songBracketUnicode))
                        {
                            matchesjubeat[i] = resultUni;
                            i++;
                        }
                    }
                }
                if (input.Contains("6"))
                {
                    if (reflectPageUpper.Contains(songBracket) || reflectPageUpper2.Contains(songBracket))
                    {
                        matchesreflect[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (reflectPageUpper.Contains(songBracketUnicode) || reflectPageUpper2.Contains(songBracketUnicode))
                        {
                            matchesreflect[i] = resultUni;
                            i++;
                        }
                    }
                }
                if (input.Contains("7"))
                {
                    if (SDVXPageUpper.Contains(songBracket) || SDVXPageUpper2.Contains(songBracket))
                    {
                        matchesSDVX[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (SDVXPageUpper.Contains(songBracketUnicode) || SDVXPageUpper2.Contains(songBracketUnicode))
                        {
                            matchesSDVX[i] = resultUni;
                            i++;
                        }
                    }
                }
                if (input.Contains("8"))
                {
                    if (nostalgiaPageUpper.Contains(songBracket) || nostalgiaPageUpper2.Contains(songBracket))
                    {
                        matchesnostalgia[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (nostalgiaPageUpper.Contains(songBracketUnicode) || nostalgiaPageUpper2.Contains(songBracketUnicode))
                        {
                            matchesnostalgia[i] = resultUni;
                            i++;
                        }
                    }
                }
                if (input.Contains("9"))
                {
                    if (DRSDPageUpper.Contains(songBracket))
                    {
                        matchesDRSD[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (DRSDPageUpper.Contains(songBracketUnicode))
                        {
                            matchesDRSD[i] = resultUni;
                            i++;
                        }
                    }
                }
                if (input.Contains("0"))
                {
                    if (MUSECAPageUpper.Contains(songBracket))
                    {
                        matchesMUSECA[i] = result;
                        i++;
                    }
                    else if (containsUnicode == true)
                    {
                        if (MUSECAPageUpper.Contains(songBracketUnicode))
                        {
                            matchesMUSECA[i] = resultUni;
                            i++;
                        }
                    }
                }
            theend:
                Console.Write("");
            }
            Console.WriteLine("\n Here is every osu! song you have that matches the name of a song from the Bemani wiki. \n This might not necessarily mean that the songs are the same, as they might share the same name but be different songs.");
            var distinctmatchesIIDX = matchesIIDX.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distinctmatchesPM = matchesPM.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distinctmatchesDDR = matchesDDR.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distinctmatchesGD = matchesGD.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distinctmatchesjubeat = matchesjubeat.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distinctmatchesreflect = matchesreflect.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distinctmatchesSDVX = matchesSDVX.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distinctmatchesnostalgia = matchesnostalgia.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distinctmatchesDRSD = matchesDRSD.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distinctmatchesMUSECA = matchesMUSECA.Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string applicationPath = Path.GetDirectoryName(Application.ExecutablePath);
            string textFilePath = Path.Combine(applicationPath, "matches.txt");
            if (filebool == true)
            {
                try
                {
                    File.Create("matches.txt").Dispose();
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine(" I don't have permission to create a file! Move this executable somewhere else.");
                    filebool = false;
                }
                catch (PathTooLongException)
                {
                    Console.WriteLine(" I can't create a file here. Move this executable somewhere with a shorter directory name.");
                    filebool = false;
                }
                catch (IOException)
                {
                    Console.WriteLine("There seems to already be a matches.txt file. Should it be deleted? (y) (n)");
                    Console.Write("");
                    string deleting = Console.ReadLine();
                    if (deleting.Length <= 0)
                    {
                        Console.WriteLine(" Error: This is not a yes or no answer. The file will not be deleted.");
                        filebool = false;
                    }
                    if (deleting.Contains("y") && deleting.Contains("n"))
                    {
                        Console.WriteLine(" You cannot select both yes and no. The file will not be deleted.");
                        filebool = false;
                    }
                    if (deleting.Contains("y"))
                    {
                        File.Delete(textFilePath);
                        try
                        {
                            File.Create("matches.txt").Dispose();
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine(" I don't have permission to create a file! Move this executable somewhere else.");
                            filebool = false;
                        }
                        catch (PathTooLongException)
                        {
                            Console.WriteLine(" I can't create a file here. Move this executable somewhere with a shorter directory name.");
                            filebool = false;
                        }
                        catch
                        {
                            Console.WriteLine(" Error creating file.");
                        }
                    }
                    else if (deleting.Contains("n"))
                    {
                        filebool = false;
                    }
                    else
                    {
                        filebool = false;
                    }
                }
                catch
                {
                    Console.WriteLine(" Error creating file.");
                }
            }
            if (input.Contains("1"))
            {
                Console.WriteLine("\n beatmania IIDX:");
                File.AppendAllText(textFilePath, "beatmania IIDX:" + Environment.NewLine);
                foreach (var match in distinctmatchesIIDX)
                {
                    if (match == null || String.IsNullOrWhiteSpace(match) == true)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (input.Contains("2"))
            {
                Console.WriteLine("\n pop'n'music:");
                if (filebool == true)
                {
                    File.AppendAllText(textFilePath, "pop'n'music:" + Environment.NewLine);
                }
                foreach (var match in distinctmatchesPM)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (input.Contains("3"))
            {
                Console.WriteLine("\n Dance Dance Revolution:");
                if (filebool == true)
                {
                    File.AppendAllText(textFilePath, "Dance Dance Revolution:" + Environment.NewLine);
                }
                foreach (var match in distinctmatchesDDR)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (input.Contains("4"))
            {
                Console.WriteLine("\n Gitadora:");
                    if (filebool == true)
                    {
                        File.AppendAllText(textFilePath, "Gitadora:" + Environment.NewLine);
                    }
                foreach (var match in distinctmatchesGD)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (input.Contains("5"))
            {
                Console.WriteLine("\n jubeat:");
                if (filebool == true)
                {
                    File.AppendAllText(textFilePath, "jubeat:" + Environment.NewLine);
                }
                foreach (var match in distinctmatchesjubeat)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (input.Contains("6"))
            {
                Console.WriteLine("\n Reflec Beat:");
                if (filebool == true)
                {
                    File.AppendAllText(textFilePath, "Reflec Beat:" + Environment.NewLine);
                }
                foreach (var match in distinctmatchesreflect)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (input.Contains("7"))
            {
                Console.WriteLine("\n Sound Voltex:");
                if (filebool == true)
                {
                    File.AppendAllText(textFilePath, "Sound Voltex:" + Environment.NewLine);
                }
                foreach (var match in distinctmatchesSDVX)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (input.Contains("8"))
            {
                Console.WriteLine("\n Nostalgia:");
                if (filebool == true)
                {
                    File.AppendAllText(textFilePath, "Nostalgia:" + Environment.NewLine);
                }
                foreach (var match in distinctmatchesnostalgia)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (input.Contains("9"))
            {
                Console.WriteLine("\n Dancerush Stardom:");
                if (filebool == true)
                {
                    File.AppendAllText(textFilePath, "Dancerush Stardom:" + Environment.NewLine);
                }
                foreach (var match in distinctmatchesDRSD)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (input.Contains("0"))
            {
                Console.WriteLine("\n MUSECA:");
                if (filebool == true)
                {
                    File.AppendAllText(textFilePath, "MUSECA:" + Environment.NewLine);
                }
                    foreach (var match in distinctmatchesMUSECA)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(" " + match.ToString());
                        if (filebool == true)
                        {
                            File.AppendAllText(textFilePath, match.ToString() + Environment.NewLine);
                        }
                    }
                }
            }
            if (filebool == true)
            {
                Console.WriteLine("\n File containing all of this information saved to " + textFilePath);
            }
            else
            {
                Console.WriteLine("\n Make sure to copy this information somewhere safe so that you can refer to it later.");
            }
            Console.WriteLine(" Press Enter when you're finished to close this window.");
            Console.ReadLine();
        }
    }
}
