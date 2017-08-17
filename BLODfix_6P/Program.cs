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
                Console.Clear();
                Console.WriteLine("Checking for fastboot in System32...");
                var Fbpath = new FileInfo(@"C:\Windows\System32\fastboot.exe");
                var Fblib = new FileInfo(@"C:\Windows\SysWOW64\libwinpthread-1.dll");
                if (Fbpath.Exists && Fblib.Exists)
                {
                    Console.WriteLine("Fastboot found in System32");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Checking for adb in System32...");
                    if (File.Exists(@"C:\Windows\System32\adb.exe"))
                    {
                        Console.WriteLine("adb found in System32");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        goto chkbl;
                    }
                    else
                    {
                        Console.WriteLine("adb not detected");
                        Console.WriteLine("Would you like to install it systemwide? y/n");
                        string adbinstall = Console.ReadLine();
                        if (adbinstall == "y")
                        {
                            Console.Clear();
                            Console.WriteLine("Installing adb systemwide...");
                            var currentDirectory = Directory.GetCurrentDirectory();
                            string adbsrc = Path.Combine(currentDirectory, "adb.exe");
                            File.Copy(adbsrc, @"C:\Windows\System32\adb.exe");
                            if (File.Exists(@"C:\Windows\System32\adb.exe"))
                            {
                                Console.WriteLine("adb installed systemwide");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                goto chkbl;
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
                            Console.Clear();
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
                        Console.Clear();
                        var currentDirectory = Directory.GetCurrentDirectory();
                        string fastbootsrc2 = Path.Combine(currentDirectory, "fastboot.exe");
                        String Fblibsrc2 = Path.Combine(currentDirectory, "libwinpthread-1.dll");
                        File.Copy(fastbootsrc2, @"C:\Windows\System32\fastboot.exe");
                        File.Copy(Fblibsrc2, @"C:\Windows\SysWOW64\libwinpthread-1.dll");
                        var Fbpath2 = new FileInfo(@"C:\Windows\System32\fastboot.exe");
                        var Fblib2 = new FileInfo(@"C:\Windows\SysWOW64\libwinpthread-1.dll");
                        if (Fbpath2.Exists && Fblib2.Exists)
                        {
                            Console.WriteLine("Fastboot installed systemwide");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Checking if adb is installed to System32...");
                            if (File.Exists(@"C:\Windows\System32\adb.exe"))
                            {
                                Console.WriteLine("adb detected in System32");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                goto chkbl;
                            }
                            else
                            {
                                Console.WriteLine("adb not detected in System32");
                                Console.WriteLine("Would you like to install adb systemwide? y/n");
                                string adbinstall = Console.ReadLine();
                                if (adbinstall =="y")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Installing adb systemwide...");
                                    string adbsrc2 = Path.Combine(currentDirectory, "adb.exe");
                                    File.Copy(adbsrc2, @"C:\Windows\System32\adb.exe");
                                    if (File.Exists(@"C:\Windows\System32\adb.exe"))
                                    {
                                        Console.WriteLine("adb installed systemwide");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        goto chkbl;
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
                                    Console.Clear();
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
                        Console.Clear();
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
            chkbl:
            Console.Clear();
            Console.WriteLine("Now we will check to see if your bootloader is unlocked");
            Console.WriteLine("Now reboot your phone into bootloader");
            Console.WriteLine("To do this, hold the power and volume buttons at the same time");
            Console.WriteLine("Keep holding those buttons until you see an Android laying down,");
            Console.WriteLine("And white text on the bottom left of your phone");
            Console.WriteLine("");
            Console.WriteLine("Once your phone is in bootloader mode, press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Process blstat = new Process();
            blstat.StartInfo.FileName = "cmd.exe";
            blstat.StartInfo.RedirectStandardInput = true;
            blstat.StartInfo.RedirectStandardOutput = true;
            blstat.StartInfo.RedirectStandardError = true;
            blstat.StartInfo.CreateNoWindow = false;
            blstat.StartInfo.UseShellExecute = false;
            blstat.Start();
            Console.WriteLine("If this freezes at <waiting for device>,");
            Console.WriteLine("Either you do not have the drivers installed,");
            Console.WriteLine("Your phone is not in bootloader mode");
            Console.WriteLine("Your phone is not conected to the computer,");
            Console.WriteLine("Or your USB cable is broken");
            blstat.StandardInput.WriteLine("fastboot flashing get_unlock_ability");
            blstat.StandardInput.Flush();
            blstat.StandardInput.Close();
            Console.Clear();
            Console.WriteLine(blstat.StandardOutput.ReadToEnd());
            Console.WriteLine(blstat.StandardError.ReadToEnd());
            Console.WriteLine("What was the output?");
            Console.WriteLine("");
            Console.WriteLine("If the output was '(bootloader) 1', press y");
            Console.WriteLine("If the output was '(bootloader) 0', press any other key");
            string unlk = Console.ReadLine();
            if (unlk == "y")
            {
                goto flash;
            }
            else
            {
                Disclaimer:
                Console.Clear();
                Console.WriteLine("Your bootloader needs to be unlocked before we can continue");
                Console.WriteLine("DISCLAIMER: unlocking your bootloader MAY ERASE ALL DATA!!");
                Console.WriteLine("By typing 'YES', you are agreeing to the fact that your data may be wiped, and you are OK with this.");
                Console.WriteLine("If you do not want to risk losing your data, do not type 'YES'");
                string agreement = Console.ReadLine();
                if (agreement == "YES")
                {
                    startunlk:
                    Console.Clear();
                    Console.WriteLine("Now reboot your phone into bootloader");
                    Console.WriteLine("To do this, hold the power and volume buttons at the same time");
                    Console.WriteLine("Keep holding those buttons until you see an Android laying down,");
                    Console.WriteLine("And white text on the bottom left of your phone");
                    Console.WriteLine("");
                    Console.WriteLine("Once your phone is in bootloader mode, press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Unlocking your bootloader now...");
                    Console.WriteLine("");
                    Console.WriteLine("If this freezes at <waiting for device>,");
                    Console.WriteLine("Either you do not have the drivers installed,");
                    Console.WriteLine("Your phone is not in bootloader mode");
                    Console.WriteLine("Your phone is not conected to the computer,");
                    Console.WriteLine("Or your USB cable is broken");
                    Process unlkbl = new Process();
                    unlkbl.StartInfo.FileName = "cmd.exe";
                    unlkbl.StartInfo.RedirectStandardInput = true;
                    unlkbl.StartInfo.RedirectStandardOutput = true;
                    unlkbl.StartInfo.RedirectStandardError = true;
                    unlkbl.StartInfo.CreateNoWindow = false;
                    unlkbl.StartInfo.UseShellExecute = false;
                    unlkbl.Start();
                    unlkbl.StandardInput.WriteLine("fastboot flashing unlock");
                    unlkbl.StandardInput.Flush();
                    unlkbl.StandardInput.Close();
                    Console.Clear();
                    Console.WriteLine(unlkbl.StandardOutput.ReadToEnd());
                    Console.WriteLine(unlkbl.StandardError.ReadToEnd());
                    Console.WriteLine("What was the output?");
                    Console.WriteLine("Pick a number...");
                    Console.WriteLine("1. 'Device already unlocked!'");
                    Console.WriteLine("2. 'Command not Allowed'");
                    Console.WriteLine("3. 'Success!'");
                    Console.WriteLine("4. None of the above");
                    string unlkstat = Console.ReadLine();
                    if (unlkstat == "1")
                    {
                        goto flash;
                    }
                    if (unlkstat == "2")
                    {
                        Console.WriteLine("You must enable OEM unlocking in developer options");
                        Console.WriteLine("If your device is in a bootloop,");
                        Console.WriteLine("Hold a heat gun or blow dryer to the back of it,");
                        Console.WriteLine("Until it boots succesfully, then quickly enable OEM unlocking");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    if (unlkstat == "3")
                    {
                        goto flash;
                    }
                    if (unlkstat == "4")
                    {
                        Console.WriteLine("Leave a reply on the 6p fix post,");
                        Console.WriteLine("Or PM the developer @XCnathan32");
                        Console.WriteLine("Please provide a screenshot of the output");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid option");
                        Console.WriteLine("Press any key to go back...");
                        Console.ReadKey();
                        Console.Clear();
                        goto startunlk;
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Response!");
                    Console.WriteLine("You must accept the disclaimer");
                    Console.WriteLine("To accept it, type 'YES' in all caps");
                    Console.WriteLine("Press any key to go back and accept it...");
                    Console.ReadKey();
                    goto Disclaimer;
                }
            }
            flash:
            {
                Console.Clear();
                Console.WriteLine("Yay it made it this far!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}

