using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace BLODfix
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to BLODfixer!");
            Console.WriteLine("Made by @XCnathan32");
            Console.WriteLine("Would you like to fix your phone? y/n");
            string entry = Console.ReadLine();
            if (entry == "y")
            {
                Console.WriteLine("Checking for fastboot in System32...");
                if (File.Exists(@"C:\Windows\System32\fastboot.exe"))
                {
                    Console.WriteLine("Fastboot found in System32");
                    Console.WriteLine("Checking for adb in System32...");
                    if (File.Exists(@"C:\Windows\System32\adb.exe"))
                    {
                        Console.WriteLine("adb found in System32");
                    }
                    else
                    {
                        Console.WriteLine("adb not detected");
                        Console.WriteLine("Would you like to install it systemwide? y/n");
                        string adbinstall = Console.ReadLine();
                        if (adbinstall == "y")
                        {
                            Console.WriteLine("Installing adb systemwide...");
                            var currentDirectory = Directory.GetCurrentDirectory();
                            string adbsrc = Path.Combine(currentDirectory, "adb.exe");
                            File.Copy(adbsrc, @"C:\Windows\System32\adb.exe");
                            if (File.Exists(@"C:\Windows\System32\adb.exe"))
                            {
                                Console.WriteLine("adb installed systemwide");
                                goto startflash;
                            }
                            else
                            {
                                Console.WriteLine("adb installation failed");
                                Console.WriteLine("BLODfixer cannot continue without adb");
                                Console.WriteLine("Try running this program as Administrator");
                                Console.WriteLine("Press any key to exit...");
                                Console.ReadKey();
                                Environment.Exit(1);
                            }
                        }
                        else
                        {
                            Console.WriteLine("BLODfixer cannot continue without adb");
                            Console.WriteLine("Please install adb to System32");
                            Console.WriteLine("Press any key to exit...");
                            Console.ReadKey();
                            Environment.Exit(1);

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Fastboot not detected in System32");
                    Console.WriteLine("Would you like to install it systemwide? y/n");
                    string fastbootinstall = Console.ReadLine();
                    if (fastbootinstall == "y")
                    {
                        var currentDirectory = Directory.GetCurrentDirectory();
                        string fastbootsrc2 = Path.Combine(currentDirectory, "fastboot.exe");
                        File.Copy(fastbootsrc2, @"C:\Windows\System32\fastboot.exe");
                        if (File.Exists(@"C:\Windows\System32\fastboot.exe"))
                        {
                            Console.WriteLine("Fastboot installed systemwide");
                            Console.WriteLine("Checking if adb is installed to System32...");
                            if (File.Exists(@"C:\Windows\System32\adb.exe"))
                            {
                                Console.WriteLine("adb detected in System32");
                                goto startflash;
                            }
                            else
                            {
                                Console.WriteLine("adb not detected in System32");
                                Console.WriteLine("Would you like to install adb systemwide? y/n");
                                string adbinstall = Console.ReadLine();
                                if (adbinstall == "y")
                                {
                                    Console.WriteLine("Installing adb systemwide...");
                                    string adbsrc2 = Path.Combine(currentDirectory, "adb.exe");
                                    File.Copy(adbsrc2, @"C:\Windows\System32\adb.exe");
                                    if (File.Exists(@"C:\Windows\System32\adb.exe"))
                                    {
                                        Console.WriteLine("adb installed systemwide");
                                        goto startflash;
                                    }
                                    else
                                    {
                                        Console.WriteLine("adb did not install succesfully");
                                        Console.WriteLine("Run this program as Administrator and try again");
                                        Console.WriteLine("Press any key to exit...");
                                        Console.ReadKey();
                                        Environment.Exit(1);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("BLODfixer needs adb to continue");
                                    Console.WriteLine("Please install adb to System32");
                                    Console.WriteLine("Press any key to exit...");
                                    Console.ReadKey();
                                    Environment.Exit(1);
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Fastboot installation failed");
                            Console.WriteLine("BLODfixer cannot continue without fastboot");
                            Console.WriteLine("Try running this program as Administrator");
                            Console.WriteLine("Press any key to exit...");
                            Console.ReadKey();
                            Environment.Exit(1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("BLODfixer cannot continue without fastboot");
                        Console.WriteLine("Please install fastboot to System32");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                }
            }
            else
            {
                Environment.Exit(1);
            }
            startflash:
            Console.WriteLine("yay it made it this far!");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

