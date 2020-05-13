using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace main
{

   public class configInstance
    {

       private IPEndPoint hndlIPEndpoint;
       private IPHostEntry hndlServer;
       private Socket hndlSck;
       private IPAddress hndlTargetAddr;
       private String strHost;
       private String strPort;
       private String strPortRangeBEGIN;
       private String strPortRangeEND;
       private bool bVerbose;
       private bool bDebugMode;
       private bool bStealthMode;
    

       public configInstance()
       {

           this.bDebugMode = false;
           this.bVerbose = false;
           this.bStealthMode = false;
       }


       // seties

       public void Set_IPEndPoint(IPEndPoint hndlIPEndpoint)    { this.hndlIPEndpoint = hndlIPEndpoint; }
       public void Set_IPHosteEntry(IPHostEntry hndlHostEntry)  { this.hndlServer = hndlHostEntry; }
       public void Set_IPAddress(IPAddress hndlIPAdr)           { this.hndlTargetAddr = hndlIPAdr; }
       public void Set_Socket(Socket hndlSocket)                { this.hndlSck = hndlSocket; }
       public void Set_HostAsString(String strHost)             { this.strHost = strHost; }
       public void Set_PortAsString(String strPort)             { this.strPort = strPort; }
       public void Set_PortAsStringRangeBEGIN(String strPortRangeBEGIN) { this.strPortRangeBEGIN = strPortRangeBEGIN; }
       public void Set_PortAsStringRangeEND(String strPortRangeEND) { this.strPortRangeEND = strPortRangeEND; }
       public void Set_StealthMode(bool bStealthMode) { this.bStealthMode = bStealthMode; }

        // geties

       public IPEndPoint Get_IPEndPoint()       {   return this.hndlIPEndpoint;  }
       public IPHostEntry Get_IPHosteEntry()    {   return this.hndlServer;    }
       public IPAddress Get_IPAddress()         {   return this.hndlTargetAddr;   }
       public Socket Get_Socket()               {   return this.hndlSck;   }
       public String Get_HostAsString()         {   return this.strHost; }
       public String Get_PortAsString()         {   return this.strPort; }
       public String Get_PortAsStringRangeBEGIN() { return this.strPortRangeBEGIN; }
       public String Get_PortAsStringRangeEND() { return this.strPortRangeEND; }
       public bool Get_StealthMode() { return this.bStealthMode; }




    }
}
