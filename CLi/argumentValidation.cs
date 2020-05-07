using System;
using System.Collections.Generic;
using System.Text;

namespace main
{
    public class argumentValidation
    {

        protected LiteralConsts clConsts;
        protected String[] strOptions;
        public int iReturnCode;

        //protected configInstance clRunTimeConfig;

         

        public argumentValidation(String[] args, configInstance clRTConfig)     // anything greater than '0' is a failcase
        {
            this.strOptions = new String[11];
            this.clConsts = new LiteralConsts();
            this.iReturnCode = -1;
     
           
            for (int iArgs = 0; iArgs < args.Length; iArgs++)
            {
                for (int iCount = 0; iCount < 7; iCount++)
                {  //   this.strOptions[iCount] = "String(" + Convert.ToString(1 + iCount) + "):NULL";


                   // Console.WriteLine("checking ARG:'{0}' against ARL:{1}", args[iArgs], this.clConsts.strArguments[iCount]);
                    if (args[iArgs].CompareTo(this.clConsts.strArguments[iCount]) == 0)
                    {
                        switch(iCount)
                        {
                            case (int)LiteralConsts.Arguments.ARG_HostLong:
                                if (args[iArgs + 1].Length < 3)
                                {
                                    Console.WriteLine("\nerr: Hostname must be at least three chars long");
                                    this.iReturnCode = (int)LiteralConsts.genExceptions.ArgErr_InvalidIP;
                                }
                                else
                                    clRTConfig.Set_HostAsString(args[iArgs + 1]);
                            break;


                            case (int)LiteralConsts.Arguments.ARG_HostShort:
                                if(args[iArgs+1].Length<3)
                                {
                                    Console.WriteLine("\nerr: Hostname must be at least three chars long");
                                    this.iReturnCode = (int)LiteralConsts.genExceptions.ArgErr_InvalidIP;
                                }
                                else
                                    clRTConfig.Set_HostAsString(args[iArgs+1]);
                                break;


                            case (int)LiteralConsts.Arguments.ARG_PortLong:
                                if
                                clRTConfig.Set_PortAsString(args[iArgs+1]);
                            break;


                            case (int)LiteralConsts.Arguments.ARG_PortShort:
                                clRTConfig.Set_PortAsString(args[iArgs+1]);
                            break;


                            case (int)LiteralConsts.Arguments.ARG_HelpLong:
                                Console.WriteLine("{0}", clConsts.strHelpTXT);
                                this.iReturnCode = (int)LiteralConsts.genExceptions.genErr_HelpTxt;
                            break;


                            case (int)LiteralConsts.Arguments.ARG_HelpShort_Char:
                                Console.WriteLine("{0}", clConsts.strHelpTXT);
                                this.iReturnCode = (int)LiteralConsts.genExceptions.genErr_HelpTxt;
                            break;


                            case (int)LiteralConsts.Arguments.ARG_HelpShort_QM:
                                Console.WriteLine("{0}", clConsts.strHelpTXT);
                                this.iReturnCode = (int)LiteralConsts.genExceptions.genErr_HelpTxt;
                            break;


                            default:
                                Console.WriteLine("{0}", clConsts.strHelpNotice);
                                this.iReturnCode = (int)LiteralConsts.genExceptions.ArgErr_InsufficientArguments;
                            break;
                        }
                    }
                    else
                        ;;


                 }
            }
            Console.Write("\ntesting '{0}:{1}'\n", clRTConfig.Get_HostAsString(), clRTConfig.Get_PortAsString());  // for testing purposes
           /* 
            * Console.WriteLine("\n\npress key, pls");
            System.Console.ReadKey(true); 
            Console.WriteLine("\nwilco! one second, pls ...\n"); 
            *
            */
        }

        public bool ArgumentValidation(String[] args)
        {  
            // toBe done
            return true;
        }
    }
}
