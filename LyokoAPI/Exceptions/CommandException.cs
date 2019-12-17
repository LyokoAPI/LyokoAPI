using LyokoAPI.Events;
using LyokoAPI.Commands;

namespace LyokoAPI.Exceptions
{
    public class CommandException : MiniLyokoException
    {
        public string ErrorMessage { get; }
        public string Command { get; }
        public CommandException(ICommand command, string messagge)
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
