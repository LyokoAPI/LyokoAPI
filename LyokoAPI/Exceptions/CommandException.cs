using LyokoAPI.Events;
using LyokoAPI.Commands;

namespace LyokoAPI.Exceptions
{
    public class CommandException : MiniLyokoException
    {
        public string ErrorMessage { get; }
        public string Command { get; }
        public CommandException(Command command, string messagge)
        {
            ErrorMessage = messagge;
            Command = command.DisplayName;
        }


        public override void Resolve(string parameter = "")
        {
            CommandOutputEvent.Call(Command, ErrorMessage);
        }
    }
}
