//Copyright (c) Microsoft Corporation. Alle Rechte vorbehalten.

// cmdline1.cs
// Argumente: A B C


using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;



namespace main
{
    public class main
    {
        public static int Main(string[] args)
        {
            catchExceptions clExceptions = new catchExceptions(); 
            int iReturnCode = -1; // error handling

            iReturnCode = (int)clExceptions.catchGenericExceptions(args);
                                                                                // argument formating (kind of bubblesort-way to check validity of arguments in logic context [arguments gain/order])
            switch (iReturnCode)
            { 
                    case 0:
                        tcpchk clTcpCheck = new tcpchk(args);                       // main-instance initialized via overloaded constructor
                        clTcpCheck.PortCheck(args);
                    break;  
          
                    default:
                    Console.WriteLine("\ngenException_No:'{0}'", iReturnCode);
                    break;
            
            }   // anything greater than 0 must be considered a failure
            return 0;
        }      
    }           // class main
}               // namespaces