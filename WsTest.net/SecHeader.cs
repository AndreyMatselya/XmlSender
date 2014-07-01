using System;
using CommonWsItf;
namespace SecHeader
{
    public class UsernameToken: TRemotable
    {
        public string Username
        {
          get {
            return FUsername;
          }
          set {
            FUsername = value;
          }
        }
        public string Password
        {
          get {
            return FPassword;
          }
          set {
            FPassword = value;
          }
        }
        private string FUsername = String.Empty;
        private string FPassword = String.Empty;
    } // end UsernameToken

    public class UsernameTokenT: TSOAPHeader
    {
        public string Username
        {
          get {
            return FUsername;
          }
          set {
            FUsername = value;
          }
        }
        public string Password
        {
          get {
            return FPassword;
          }
          set {
            FPassword = value;
          }
        }
        private string FUsername = String.Empty;
        private string FPassword = String.Empty;
    } // end UsernameTokenT

    public class Security: TSOAPHeader
    {
        public UsernameToken UsernameToken
        {
          get {
            return FUsernameToken;
          }
          set {
            FUsernameToken = value;
          }
        }
        private UsernameToken FUsernameToken = null;
        //@ Destructor  Destroy()
        ~Security()
        {
            FUsernameToken = null;
            base.Destroy();
        }
    } // end Security

}

namespace SecHeader.Units
{
    public class SecHeader
    {
        public static TSOAPHeader createHeader(string Username, string Password)
        {
            TSOAPHeader result;
            Security Security_;
            UsernameToken UsernameToken_;
            UsernameToken_ = new UsernameToken();
            UsernameToken_.Username = Username;
            UsernameToken_.Password = Password;
            Security_ = new Security();
            //@ Unsupported property or method(C): 'UsernameToken'
            Security_.UsernameToken = UsernameToken_;
            result = Security_;
            return result;
        }

        public void initialization()
        {
            //@ Unsupported function or procedure: 'TypeInfo'
            //@ Undeclared identifier(3): 'InvRegistry'
            //@ Unsupported property or method(B): 'RegisterHeaderClass'
            InvRegistry.RegisterHeaderClass(TypeInfo(GisunCommonWsImpl), Security, "Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            //@ Undeclared identifier(3): 'RemClassRegistry'
            //@ Unsupported property or method(B): 'RegisterXSClass'
            RemClassRegistry.RegisterXSClass(UsernameToken, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", "UsernameToken");
            //@ Undeclared identifier(3): 'RemClassRegistry'
            //@ Unsupported property or method(B): 'RegisterXSClass'
            RemClassRegistry.RegisterXSClass(Security, "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", "Security");
        }

    } // end SecHeader

}

