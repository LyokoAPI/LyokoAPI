using System;

namespace LyokoAPI.Events.EventArgs
{
    public class StringEventArg : System.EventArgs
    {
        private string _message;

        public string Message
        {
            get => string.Copy(_message);
            private set => _message = value;
        }

        public StringEventArg(string message)
        {
            Message = String.Copy(message);
        }
        
        public static implicit operator StringEventArg(string message)
        {
            return new StringEventArg(message);
        }

        public static implicit operator string(StringEventArg arg)
        {
            return arg.Message;
        }
    }
}