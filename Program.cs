using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.Threading;
using System.Runtime.CompilerServices;

namespace osu_to_bemani_tool
{
    public class Program
    {
        public static string AskDirectory()
        {
            Console.Write(" Enter the directory for your osu! songs folder: ");
            string directory = Console.ReadLine();
            if (File.Exists(directory))
            {
                Console.WriteLine(" Error: That directory is a file, not a folder.");
                return AskDirectory();
            }
            else if (Directory.Exists(directory))
            {
                Console.WriteLine(" Using the specified directory: " + directory);
                return directory;
            }
            else
            {
                Console.WriteLine(" Error: That is not a valid directory.");
                return AskDirectory();
            }
        }
        public static string Selection()
        {
            Console.WriteLine(" osu! to Bemani converter by @suprnova123 - Last built on July 19th, 2020, v1.1");
            Console.WriteLine("\n Which Bemani games do you want to search for songs in?");
            Console.WriteLine(" 1. beatmania IIDX 27 \n 2. pop'n'music peace \n 3. DanceDanceRevolution A20 \n 4. GITADORA NEX+AGE \n 5. jubeat festo \n 6. REFLEC BEAT 悠久のリフレシア \n 7. Sound Voltex Vivid Wave \n 8. Nostalgia Op.3 \n 9. Dancerush Stardom \n 0. MUSECA");
            Console.WriteLine(" You can combine every game into one message by typing multiple numbers (i.e. 157 for beatmania, jubeat, and SDVX or 1234567890 for every game)");
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
        static void Main(string[] args)
        {
            string input = Selection();
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
			Console.WriteLine(" Please note that, depending on your location, this proces might take a while. \n This is because the song lists used are from bemaniwiki.com, which is a website hosted in Japan that is pretty slow to begin with");
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
            string[] matchesIIDX = new string[1600];
            string[] matchesPM = new string[1600];
            string[] matchesDDR = new string[1600];
            string[] matchesGD = new string[1600];
            string[] matchesjubeat = new string[1600];
            string[] matchesreflect = new string[1600];
            string[] matchesSDVX = new string[1600];
            string[] matchesnostalgia = new string[1600];
            string[] matchesDRSD = new string[1600];
            string[] matchesMUSECA = new string[1600];
            string directory = AskDirectory();
            string[] folders = Directory.GetDirectories(directory);
            Console.WriteLine(" Searching Bemaniwiki...");
            char[] parenthesis = { '（', '(' };
            foreach (string song in folders)
            {
                if (song != null)
                {
                    string songShort = null;
                    string songShortTemp = song.Substring(song.IndexOf(" - ") + 3).Trim();
                    string songShortTemp3 = songShortTemp.Substring(songShortTemp.IndexOf(" (") + 1);
                    string songShortTemp2 = "empty";
                    if (songShortTemp3.Length == songShortTemp.Length)
                    {
                        songShortTemp2 = songShortTemp3.Substring(songShortTemp3.IndexOfAny(parenthesis) + 1);
                    }
                    else
                    {
                        songShortTemp2 = songShortTemp3;
                    }
                    
                    if (songShortTemp.Length != songShortTemp2.Length)
                    {
                        songShort = songShortTemp.Remove((songShortTemp.Length - songShortTemp2.Length)).Trim();
                    }
                    else
                    {
                        songShort = songShortTemp;
                    }
                    string[] files = System.IO.Directory.GetFiles(song, "*.osu");
                    string chungus = files.FirstOrDefault();
                    if (chungus == null)
                    {
                        break;
                    }
                    chungus = chungus.Replace("\\", "\\\\");
                    string line = null;
                    bool containsUnicode = false;
                    const string TitleUnicode = "TitleUnicode:";
                    using (StreamReader sr3 = new StreamReader(chungus))
                    {
                        line = sr3.ReadToEnd();
                        containsUnicode = line.Contains(TitleUnicode);
                    }
                    string unicodeFinal = null;
                    if (containsUnicode == true)
                    {
                        string unicodeSong = line.Substring(line.IndexOf(TitleUnicode));
                        string unicodeSongTrimmed = unicodeSong.Substring(0, unicodeSong.IndexOf("Artist")).Trim();
                        string unicodeSongTrimmed4 = unicodeSongTrimmed.Substring(unicodeSongTrimmed.IndexOf(" (") + 1);
                        string unicodeSongTrimmed2 = "empty";
                        if (unicodeSongTrimmed4.Length == unicodeSongTrimmed.Length)
                        {
                            unicodeSongTrimmed2 = unicodeSongTrimmed4.Substring(unicodeSongTrimmed.IndexOfAny(parenthesis) + 1).Trim();
                        }
                        else
                        {
                            unicodeSongTrimmed2 = unicodeSongTrimmed4;
                        }
                        string unicodeSongTrimmed3 = "empty";
                        if (unicodeSongTrimmed.Length != unicodeSongTrimmed2.Length)
                        {
                            unicodeSongTrimmed3 = unicodeSongTrimmed.Remove((unicodeSongTrimmed.Length - unicodeSongTrimmed2.Length - 1)).Trim();
                        }
                        else
                        {
                            unicodeSongTrimmed3 = unicodeSongTrimmed2;
                        }
                        unicodeFinal = unicodeSongTrimmed3.Remove(0, TitleUnicode.Length).Trim();
                        containsUnicode = (unicodeFinal.Length > 0);
                    }
                    if ((string.IsNullOrWhiteSpace(songShort) == false) || (string.IsNullOrWhiteSpace(unicodeFinal) == false))
                    {
                        string songBracket = ">" + songShort + "<";
                        string songBracketUnicode = ">" + unicodeFinal + "<";
                        string songBracketUpper = songBracket.ToUpper();
                        string songBracketUnicodeUpper = songBracketUnicode.ToUpper();
                        if (input.Contains("1"))
                        {
                            if (IIDXPageUpper.Contains(songBracketUpper) || IIDXPageUpper2.Contains(songBracketUpper))
                            {
                                matchesIIDX[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (IIDXPageUpper.Contains(songBracketUnicodeUpper) || IIDXPageUpper2.Contains(songBracketUnicodeUpper))
                                {
                                    matchesIIDX[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                        if (input.Contains("2"))
                        {
                            if (pmPageUpper.Contains(songBracketUpper) || pmPageUpper2.Contains(songBracketUpper))
                            {
                                matchesPM[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (pmPageUpper.Contains(songBracketUnicodeUpper) || pmPageUpper2.Contains(songBracketUnicodeUpper))
                                {
                                    matchesPM[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                        if (input.Contains("3"))
                        {
                            if (DDRPageUpper.Contains(songBracketUpper) || DDRPageUpper2.Contains(songBracketUpper))
                            {
                                matchesDDR[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (DDRPageUpper.Contains(songBracketUnicodeUpper) || DDRPageUpper2.Contains(songBracketUnicodeUpper))
                                {
                                    matchesDDR[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                        if (input.Contains("4"))
                        {
                            if (GDPageUpper.Contains(songBracketUpper) || GDPageUpper2.Contains(songBracketUpper) || (GDPageUpper.Contains(songBracketUpper)))
                            {
                                matchesGD[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (GDPageUpper.Contains(songBracketUnicodeUpper) || GDPageUpper2.Contains(songBracketUnicodeUpper) || (GDPageUpper.Contains(songBracketUpper)))
                                {
                                    matchesGD[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                        if (input.Contains("5"))
                        {
                            if (jubeatPageUpper.Contains(songBracketUpper) || jubeatPageUpper2.Contains(songBracketUpper))
                            {
                                matchesjubeat[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (jubeatPageUpper.Contains(songBracketUnicodeUpper) || jubeatPageUpper2.Contains(songBracketUnicodeUpper))
                                {
                                    matchesjubeat[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                        if (input.Contains("6"))
                        {
                            if (reflectPageUpper.Contains(songBracketUpper) || reflectPageUpper2.Contains(songBracketUpper))
                            {
                                matchesreflect[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (reflectPageUpper.Contains(songBracketUnicodeUpper) || reflectPageUpper2.Contains(songBracketUnicodeUpper))
                                {
                                    matchesreflect[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                        if (input.Contains("7"))
                        {
                            if (SDVXPageUpper.Contains(songBracketUpper) || SDVXPageUpper2.Contains(songBracketUpper))
                            {
                                matchesSDVX[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (SDVXPageUpper.Contains(songBracketUnicodeUpper) || SDVXPageUpper2.Contains(songBracketUnicodeUpper))
                                {
                                    matchesSDVX[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                        if (input.Contains("8"))
                        {
                            if (nostalgiaPageUpper.Contains(songBracketUpper) || nostalgiaPageUpper2.Contains(songBracketUpper))
                            {
                                matchesnostalgia[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (nostalgiaPageUpper.Contains(songBracketUnicodeUpper) || nostalgiaPageUpper2.Contains(songBracketUnicodeUpper))
                                {
                                    matchesnostalgia[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                        if (input.Contains("9"))
                        {
                            if (DRSDPageUpper.Contains(songBracketUpper))
                            {
                                matchesDRSD[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (DRSDPageUpper.Contains(songBracketUnicodeUpper))
                                {
                                    matchesDRSD[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                        if (input.Contains("0"))
                        {
                            if (MUSECAPageUpper.Contains(songBracketUpper))
                            {
                                matchesMUSECA[i] = songShort;
                                i++;
                            }
                            else if (containsUnicode == true)
                            {
                                if (MUSECAPageUpper.Contains(songBracketUnicodeUpper))
                                {
                                    matchesMUSECA[i] = unicodeFinal;
                                    i++;
                                }
                            }
                        }
                    }           
                }
                else
                {

                }
                
            }
            Console.WriteLine("\n Here is every osu! song you have that matches the name of a song from the Bemani wiki. This might not necessarily mean that the songs are the same, as they might share the same name but be different songs.");
            var distinctmatchesIIDX = matchesIIDX.Distinct().ToArray();
            var distinctmatchesPM = matchesPM.Distinct().ToArray();
            var distinctmatchesDDR = matchesDDR.Distinct().ToArray();
            var distinctmatchesGD = matchesGD.Distinct().ToArray();
            var distinctmatchesjubeat = matchesjubeat.Distinct().ToArray();
            var distinctmatchesreflect = matchesreflect.Distinct().ToArray();
            var distinctmatchesSDVX = matchesSDVX.Distinct().ToArray();
            var distinctmatchesnostalgia = matchesnostalgia.Distinct().ToArray();
            var distinctmatchesDRSD = matchesDRSD.Distinct().ToArray();
            var distinctmatchesMUSECA = matchesMUSECA.Distinct().ToArray();
            if (input.Contains("1"))
            {
                Console.WriteLine("\n IIDX:");
                foreach (var match in distinctmatchesIIDX)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            if (input.Contains("2"))
            {
                Console.WriteLine("\n pop'n'music:");
                foreach (var match in distinctmatchesPM)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            if (input.Contains("3"))
            {
                Console.WriteLine("\n Dance Dance Revolution:");
                foreach (var match in distinctmatchesDDR)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            if (input.Contains("4"))
            {
                Console.WriteLine("\n Gitadora:");
                foreach (var match in distinctmatchesGD)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            if (input.Contains("5"))
            {
                Console.WriteLine("\n jubeat:");
                foreach (var match in distinctmatchesjubeat)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            if (input.Contains("6"))
            {
                Console.WriteLine("\n Reflec Beat:");
                foreach (var match in distinctmatchesreflect)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            if (input.Contains("7"))
            {
                Console.WriteLine("\n Sound Voltex:");
                foreach (var match in distinctmatchesSDVX)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            if (input.Contains("8"))
            {
                Console.WriteLine("\n Nostalgia:");
                foreach (var match in distinctmatchesnostalgia)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            if (input.Contains("9"))
            {
                Console.WriteLine("\n Dancerush Stardom:");
                foreach (var match in distinctmatchesDRSD)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            if (input.Contains("0"))
            {
                Console.WriteLine("\n MUSECA:");
                foreach (var match in distinctmatchesMUSECA)
                {
                    if (match == null)
                    {

                    }
                    else
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }

            Console.WriteLine("\n Make sure to copy this information somewhere safe so that you can refer to it later.");
            Console.WriteLine(" Press Enter when you're finished to close this window.");
            Console.ReadLine();

        }

    }
}
