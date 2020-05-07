using System;
using System.Collections.Generic;
using System.Text;


namespace main
{
    public class LiteralConsts
    {

        // num. return msgs SocketExceptions

        public enum genExceptions 
        { 
            SckErr_HostNotFount = 1,
            SckErr_NetworkUnreachable = 2,
            SckErr_ConnectionRefused = 3,
            SckErr_ConnectionTimeout = 4,
            SckErr_NetworkDown = 5,
            ArgErr_InvalidIP = 6,
            ArgErr_NonValidPort = 7,
            ArgErr_UnknownArgument = 8,   
            ArgErr_InsufficientArguments = 9,
            genErr_HelpTxt = 10
        }


        // available arguments

        public enum Arguments
        {
              ARG_HostLong = 0,
              ARG_HostShort = 1,
              ARG_PortLong = 2,
              ARG_PortShort = 3,
              ARG_HelpLong = 4,
              ARG_HelpShort_QM = 5,
              ARG_HelpShort_Char = 6,
        }

        // returned strings to overwrite exceptions

        /*
         
            protected String strARG_HostLong = null,
            protected String strARG_HostShort = null,
            protected String strARG_PortLong = null,
            protected String strARG_PortShort = null,
            protected String strARG_HelpLong = null,
            protected String strARG_HelpShort_QM = null,
            protected String strARG_HelpShort_Char = null,
        }
         */

        public String[] strArguments = null;
        public String[] strErrMsg = null;
        public String strHelpNotice = null;
        public String strHelpTXT = null;

        /*
        public String strErrMsg_HostNotFound = null;
        public String strErrMsg_ConnectionRefused = null;
        public String strErrMsg_NetworkDown = null;
        public String strErrMsg_NetworkUnreachable = null;
        public String strErrMsg_ConnectionTimeout = null;
        public String strHelpTXT = null;
        public String strHelpNotice = null;
        */
   
        public LiteralConsts()
        {
            // errMsg


            this.strHelpNotice = "USAGE: 'tcpchk -h <host> -p <port>'\n\npls, check one of these:\n\n'tcpchk " +
                           "--help'\n'tcpchk -h'\n'tcpchk /?' ... bye\n\n";

            this.strHelpTXT = "USAGE: 'tcpchk -H <host> -p <port>'\n" +
                               "\n\n--host,-H\t\t : hostname / ipaddress" +
                               "\n--port,-p\t\t : (tcp)port" +
                               "\n--help,-h,/?\t\t : will show this text" +
                               "\n\nsend bug reports in english, pls to 'christoph.mallau@sensw.berlin.de\n" +
                               "Senatsverwaltung fuer Stadtentwicklung und Wohnen.\n\n";


            this.strErrMsg = new String[10];
            this.strErrMsg[(int)genExceptions.SckErr_HostNotFount] = "err: host not found\n";
            this.strErrMsg[(int)genExceptions.SckErr_ConnectionRefused] = "err: connection refused\n";
            this.strErrMsg[(int)genExceptions.SckErr_NetworkDown] = "err: network down\n";
            this.strErrMsg[(int)genExceptions.SckErr_NetworkUnreachable] = "err: network unreachable\n";
            this.strErrMsg[(int)genExceptions.SckErr_ConnectionTimeout] = "err: connection timed out\n";
            this.strErrMsg[(int)genExceptions.ArgErr_InsufficientArguments] = "err: insufficient arguments\n";
            this.strErrMsg[(int)genExceptions.ArgErr_InvalidIP] = "err: malformed hostname/ip-address (pls use four-octet notation OR FQDN)\n";
            this.strErrMsg[(int)genExceptions.ArgErr_NonValidPort] = "err: port must be a numeric expression between 1-65535\n";
            this.strErrMsg[(int)genExceptions.ArgErr_UnknownArgument] = "err: ambigous/unknown arguments present\n\n" +
                                                                        this.strHelpNotice;
         
           




            // arguments

            this.strArguments = new String[7];
            this.strArguments[(int)Arguments.ARG_HelpLong] = "--help";
            this.strArguments[(int)Arguments.ARG_HelpShort_Char] = "-h";
            this.strArguments[(int)Arguments.ARG_HelpShort_QM] = "/?";
            this.strArguments[(int)Arguments.ARG_HostLong] = "--host";
            this.strArguments[(int)Arguments.ARG_HostShort] = "-H";
            this.strArguments[(int)Arguments.ARG_PortLong] = "--port";
            this.strArguments[(int)Arguments.ARG_PortShort] = "-p";
            

        }
    }
}