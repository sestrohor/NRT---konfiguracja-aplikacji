using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WawelApp

{
    public partial class NRTKonfiguracjaAplikacji : Form
    {


        public NRTKonfiguracjaAplikacji()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            Console.WriteLine("Kod: "+AppDomain.CurrentDomain.BaseDirectory);
            string username = Environment.UserName;
            string path1 = $@"C:\Users\{username}\Desktop\VisuaTicketTest\config.json";
            string path2 = $@"C:\Users\{username}\Desktop\VisuaTicketTest\wytyczne.txt";
            string pathName = $@"{AppDomain.CurrentDomain.BaseDirectory}logs\log_{DateTime.Now.ToString("yyyyMMdd")}.txt";

            //Sprawdź datę i stwórz plik log
            if (File.Exists(pathName))
            {
                Console.WriteLine("File is created.");
            }
            else
            {
                File.Create(pathName);
            }
            File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] Automatyczne uruchomienie porgramu", Environment.NewLine));


            //Pobranie i deserializacja "lokalnego" JSONA 
            if (File.Exists(path1))
            {
                string jsonString = File.ReadAllText(path1);
                JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
                //Odczytanie daty modyfikacji plików
                FileInfo fi = new FileInfo(path1);
                var lastmodifiedLocal = fi.LastWriteTime;
                FileInfo fi2 = new FileInfo(path2);
                var lastmodifiedServer = fi2.LastWriteTime;
                //Jeśli data serwerowa jest nowsza to:
                if (lastmodifiedServer > lastmodifiedLocal)
                {
                    //Pobranie danych konfiguracyjnych => odczytanie pliku linijka po linijce i zapis do tablicy wytycznych
                    string[] list = File.ReadLines(path2).ToArray();
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                        //Rozbijamy każdy element tablicy na poszczególne polecenia                
                        string[] words = item.Split('|');
                        string[] helpArray = new string[] {};
                        foreach (var word in words)
                        {
                            helpArray = helpArray.Append(String.Join(Environment.NewLine, word)).ToArray();
                        }
                        //Sprawdzamy czy jest podane id
                        if (helpArray[2] != "")
                        {
                            Console.WriteLine("Ala");
                            //Jeśli tak to sprawdzamy czy nasz json ma to samo id
                            string id = jObject.SelectToken("app.cashbox.location_hash").ToString();
                            if(helpArray[2] == id)
                            {
                                //Jeśli tak wykonujemy resztę programu
                                //Gdzie zmieniamy wartość:
                                var jToken = jObject.SelectToken(helpArray[0]);
                                Console.WriteLine("JToken = " + jToken);
                                //Zmieniamy wartość czy usuwamy pole:                              
                                if (helpArray[3] == "\"delete\"")
                                {
                                    Console.WriteLine("Usuwanie pola");
                                    //Przed usunięciem kopia zapasowa:
                                    string destinationFile = path1 + $".{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}.backup";
                                    File.Copy(path1, destinationFile, true);
                                    try
                                    {
                                        jToken.Parent.Remove();
                                    }
                                    catch (Exception ex)
                                    {
                                        File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] {ex}", Environment.NewLine));
                                    }
                                    string updatedJsonString = jObject.ToString();
                                    File.WriteAllText(path1, updatedJsonString);
                                }
                                else
                                {
                                    Console.WriteLine("Nowa wartość pola ");
                                    //Przed zmianą kopia zapasowa
                                    string destinationFile = path1 + $".{DateTime.Now.ToString("yyyyMMddHHmmss")}.backup";
                                    Console.WriteLine(destinationFile);
                                    File.Copy(path1, destinationFile, true);
                                    //Jaką nową wartość przypisujemy
                                    try
                                    {
                                        jToken.Replace(helpArray[1]);
                                    }
                                    catch (Exception ex)
                                    {
                                        File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] {ex}", Environment.NewLine));
                                    }
                                    //Sprawdzamy czy to jest string 
                                    string updatedJsonString = jObject.ToString();
                                    File.WriteAllText(path1, updatedJsonString);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Różne id");
                            }
                        }
                        //Jeśli nie wykonujemy resztę programu
                        else
                        {
                            //Teraz podmieniamy jsona w odpowiedniej części
                            //Gdzie zmieniamy wartość:
                            JToken jToken = jObject.SelectToken(helpArray[0]);
                            //Jaką nową wartość przypisujemy
                            try
                            {
                                jToken.Replace(helpArray[1]);
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] {ex}", Environment.NewLine));
                            }

                            string updatedJsonString = jObject.ToString();
                            File.WriteAllText(path1, updatedJsonString);
                        }
    

                    }
                }
                //Jeśli data serwerowa jest starsza to:
                else
                {
                    File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] Lokalny plik nowszy od serwera", Environment.NewLine));
                }
            }
            else
            {
                File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt ")}] Plik nie istnieje", Environment.NewLine));
            }


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Bsave_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            string username = Environment.UserName;
            string path1 = $@"C:\Users\{username}\Desktop\VisuaTicketTest\config.json";
            string path2 = $@"C:\Users\{username}\Desktop\VisuaTicketTest\wytyczne.txt";
            string pathName = $@"C:\Users\Filip\source\repos\WawelApp\WawelApp\logs\log_{DateTime.Now.ToString("yyyyMMdd")}.txt";
            //Pobieramy wartość textboxa
            path1 = Bsave.Text;
            //Check date and create log file
            if (File.Exists(pathName))
            {
                Console.WriteLine("File is created.");
            }
            else
            {
                File.Create(pathName);
            }
            File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] Ręczne uruchomienie porgramu", Environment.NewLine));


            //Pobranie i deserializacja "lokalnego" JSONA 
            if (File.Exists(path1))
            {
                string jsonString = File.ReadAllText(path1);
                JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as JObject;
                //Odczytanie daty modyfikacji plików
                FileInfo fi = new FileInfo(path1);
                var lastmodifiedLocal = fi.LastWriteTime;
                FileInfo fi2 = new FileInfo(path2);
                var lastmodifiedServer = fi2.LastWriteTime;
                //Jeśli data serwerowa jest nowsza to:
                if (lastmodifiedServer > lastmodifiedLocal)
                {
                    //Pobranie danych konfiguracyjnych(na razie lokalnie) => odczytanie pliku linijka po linijce i zapis do tablicy wytycznych
                    string[] list = File.ReadLines(path2).ToArray();
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                        //Rozbijamy każdy element tablicy na poszczególne polecenia                
                        string[] words = item.Split('|');
                        string[] helpArray = new string[] { };
                        foreach (var word in words)
                        {
                            helpArray = helpArray.Append(String.Join(Environment.NewLine, word)).ToArray();
                        }
                        //Sprawdzamy czy jest podane id
                        if (helpArray[2] != "")
                        {
                            Console.WriteLine("Ala");
                            //Jeśli tak to sprawdzamy czy nasz json ma to samo id
                            string id = jObject.SelectToken("app.cashbox.location_hash").ToString();
                            if (helpArray[2] == id)
                            {

                                //Jeśli tak wykonujemy resztę programu

                                //Gdzie zmieniamy wartość:
                                var jToken = jObject.SelectToken(helpArray[0]);
                                Console.WriteLine("JToken = " + jToken);
                                //Zmieniamy wartość czy usuwamy pole:                              
                                if (helpArray[3] == "\"delete\"")
                                {
                                    Console.WriteLine("Usuwanie pola");
                                    //Przed usunięciem kopia zapasowa:
                                    string destinationFile = path1 + $".{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}.backup";
                                    File.Copy(path1, destinationFile, true);
                                    try
                                    {
                                        jToken.Parent.Remove();
                                    }
                                    catch (Exception ex)
                                    {
                                        File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt ")}] {ex}", Environment.NewLine));
                                    }
                                    string updatedJsonString = jObject.ToString();
                                    File.WriteAllText(path1, updatedJsonString);
                                }
                                else
                                {
                                    Console.WriteLine("Nowa wartość pola ");
                                    //Przed zmianą kopia zapasowa
                                    string destinationFile = path1 + $".{DateTime.Now.ToString("yyyyMMddHHmmss")}.backup";
                                    Console.WriteLine(destinationFile);
                                    File.Copy(path1, destinationFile, true);
                                    //Jaką nową wartość przypisujemy
                                    try
                                    {
                                        jToken.Replace(helpArray[1]);
                                    }
                                    catch (Exception ex)
                                    {
                                        File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] {ex}", Environment.NewLine));
                                    }
                                    //Sprawdzamy czy to jest string 
                                    string updatedJsonString = jObject.ToString();
                                    File.WriteAllText(path1, updatedJsonString);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Różne id");
                            }
                        }
                        //Jeśli nie wykonujemy resztę programu
                        else
                        {
                            //Teraz podmieniamy jsona w odpowiedniej części
                            //Gdzie zmieniamy wartość:
                            JToken jToken = jObject.SelectToken(helpArray[0]);
                            //Jaką nową wartość przypisujemy
                            try
                            {
                                jToken.Replace(helpArray[1]);
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] {ex}", Environment.NewLine));
                            }

                            string updatedJsonString = jObject.ToString();
                            File.WriteAllText(path1, updatedJsonString);
                        }


                    }
                }
                //Jeśli data serwerowa jest starsza to:
                else
                {
                    File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] Lokalny plik nowszy od serwera", Environment.NewLine));
                }
            }
            else
            {
                File.AppendAllText(pathName, string.Format("{0}{1}", $"[{DateTime.Now.ToString("yyyy-MM-dd h:mm tt")}] Plik nie istnieje", Environment.NewLine));
            }

        }
    }
}
