using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;


namespace main
{
    class catchExceptions
    {

        public uint catchGenericExceptions(String[] args)
        {
            LiteralConsts clConsts = new LiteralConsts();
            bool bTestArgs = false;

            if (args.Length < 1)
                return (int)LiteralConsts.genExceptions.ArgErr_InsufficientArguments;
            else
                ;;
            

            if (args.Length < 2)
                if (System.String.Compare(args[0], "--help") == 0 || System.String.Compare(args[0], "-h") == 0)
                {
                    Console.WriteLine("{0}\n", clConsts.strHelpTXT);
                    return (int)LiteralConsts.genExceptions.genErr_HelpTxt;
                }
                else
                {
                    Console.WriteLine("{0}ambigous argument(s) ... bye\n", clConsts.strHelpNotice);
                    return (int)LiteralConsts.genExceptions.ArgErr_UnknownArgument;
                }
                 

            return 0; 
        }
            

        public int catchSocketExceptions(SocketException hndlError, bool bStealthModeInEffect)
        {

                switch (hndlError.ErrorCode)                                 // check returned exceptionm
                {
                    case (int)SocketError.NetworkDown:                       // return VALs are ints but recasting is imperative since they are type delegated in Sockets.SocketExceptions 
                    if (!(bStealthModeInEffect))
                    {
                        Console.WriteLine("SYN_NACK ... :(");
                        Console.WriteLine("SckErr: 'NetworkDown'\n");
                    }
                    return (int)LiteralConsts.genExceptions.SckErr_NetworkDown;
                    break;


                    case (int)SocketError.NetworkUnreachable:
                    if (!(bStealthModeInEffect))
                    {
                        Console.WriteLine("SYN_NACK ... :(");
                        Console.WriteLine("SckErr: 'NetworkUnreachable'\n");
                    }
                    return (int)LiteralConsts.genExceptions.SckErr_NetworkUnreachable;
                    break;


                    case (int)SocketError.ConnectionRefused:
                    if (!(bStealthModeInEffect))
                    {
                        Console.WriteLine("SYN_NACK ... :(");
                        Console.WriteLine("SckErr: 'Connection refused'\n");
                    }
                    return (int)LiteralConsts.genExceptions.SckErr_ConnectionRefused;
                    break;


                    case (int)SocketError.HostNotFound:
                    if(!(bStealthModeInEffect))
                    {
                        Console.WriteLine("SYN_NACK ... :(");
                        Console.WriteLine("SckErr: 'Host not found'\n");
                    }
                    return (int)LiteralConsts.genExceptions.SckErr_HostNotFount;
                    break;


                    case (int)SocketError.TimedOut:
                    if (!(bStealthModeInEffect))
                    {
                        Console.WriteLine("SYN_NACK ... :(");
                        Console.WriteLine("SckErr: 'Connection timeout'\n");
                    }
                    return (int)LiteralConsts.genExceptions.SckErr_ConnectionTimeout;
                    break;

                }
                return 0;
         }
         

    }                   // class
}                       // namespace
