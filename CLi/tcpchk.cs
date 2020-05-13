using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;





namespace main
{
    public class tcpchk
    {

            
        private argumentValidation clArgsCheck;
        private configInstance clRTConfig; 
        private catchExceptions clCatchSckEcpt;
        private bool bSckConn;

        public tcpchk(String[] args)
        {
            this.clRTConfig = new configInstance();
            this.clCatchSckEcpt = new catchExceptions();
            this.bSckConn = false;                          // dirty construct used to check synchronous socket operations against failure (the connected-property will stay '0'/'false')
            this.clArgsCheck = new argumentValidation(args, clRTConfig);    // instead of checking the sheer amount and quality of input value format, we will check logical consistency of arguments
                                                            // i.e., to check if <host> is either specified as FQDN or IP-address in compilance to IEEE802.3 or not specifying ports > 65535 or <= 0


            try
            {

                if (this.clArgsCheck.ArgumentValidation(args))                                                      // returns false if arguments are malformed
                {
                    this.clRTConfig.Set_IPHosteEntry(Dns.GetHostEntry(this.clRTConfig.Get_HostAsString()));                                                    // parse Hostentry about target
                    this.clRTConfig.Set_IPAddress(this.clRTConfig.Get_IPHosteEntry().AddressList[0]);                                           // parse targets address
                    this.clRTConfig.Set_IPEndPoint(new IPEndPoint(this.clRTConfig.Get_IPAddress(), Convert.ToInt32(this.clRTConfig.Get_PortAsString())));              // endpoint config imperative for Sockets-class
                    this.clRTConfig.Set_Socket(new Socket(this.clRTConfig.Get_IPEndPoint().AddressFamily, SocketType.Stream, ProtocolType.Tcp));     // our Send Socket
                }
                else
                    ;
            }

            catch (SocketException SckError)                                    // catch socketExceptions
            {
                
                    this.clCatchSckEcpt.catchSocketExceptions(SckError, clRTConfig.Get_StealthMode());

            }   // catch()
        }     // overloaded constructor             


        public int PortCheck(String[] args)                             // this is where the magic happens :D
        {
             

            try                                                         // in order to catch Socket.Exceptions
            {

                byte[] byMsg = new byte[3];                             // Msg for Socket.Send();
                byMsg = Encoding.UTF8.GetBytes("\n\n\0");               // one newline for Term.Init(); on server side, one additional to send 
                                                                        // at least one byte to the remote listening process one termination char

                
                if(this.clRTConfig.Get_IPEndPoint()!=null && this.clRTConfig.Get_Socket()!=null)       // this is silly but VS is complaining about nullReferenceExceptions, and unlike its precessor,
                    this.clRTConfig.Get_Socket().Connect(this.clRTConfig.Get_IPEndPoint());            // it is no more possible to exclude error handling for this specific exception in the build process


                if(this.clRTConfig.Get_Socket()!=null)                                  
                {
                    this.clRTConfig.Get_Socket().Send(byMsg, SocketFlags.None);              // shout to server 
                        if (this.clRTConfig.Get_Socket().Connected)                         // to be ready to receive, one crittical impact is that once this member was called, the socket state is gone
                        {                                                   // to cope with that, socket state is beeing saved in private class property
                            this.bSckConn = true;
                            if(!(clRTConfig.Get_StealthMode()))
                                Console.WriteLine("SYN_ACK ... remote port is listening.'", args[0], args[1]);
                        }
                        else
                            ;
                }
            
            } // try{}


               
            catch (SocketException SckError) {  return(int)clCatchSckEcpt.catchSocketExceptions(SckError,clRTConfig.Get_StealthMode());   }
            return clArgsCheck.iReturnCode;
        }   // member method


    }       // class
}           // namespace tcpchkl
