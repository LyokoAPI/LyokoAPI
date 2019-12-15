using System;
using System.Collections.Generic;
using System.Linq;

namespace LyokoAPI.Commands
{
    public class CommandListener
    {
        private List<Command> Commands = new List<Command>();

        public void AddCommand(Command command)
        {
            Commands.Add(command);
        }

        public CommandListener()
        {
            //Commands = new List<Command>(){new Xana(), new Aelita(), new Devirtualize(), new Hurt(), new Kill(), new Virtualize(), new Heal(), new Frontier(),new Xanafy(), new Translate()};

        }

        public List<Command> GetCommands()
        {
            return Commands;
        }

        public void OnCommand(string arg)
        {
            string[] commandargs = arg.Split('.');
            var commandname = commandargs[0];
            if (commandargs.Length > 1)
            {
                commandargs = commandargs.ToList().GetRange(1, commandargs.Length - 1).ToArray();
            }
            else
            {
                commandargs = new string[] { };
            }
            var command = Commands.Find(commandd => commandd.Name.Equals(commandname));
            if (command != null)
            {
                command?.Run(commandargs);
            }
            else
            {
                //CommandOutputEvent.Call("Error",$"The command \"{commandname}\" does not exist."); remember: this will be called for commands that aren't part of minilyoko as well
            }
        }
    }
}
