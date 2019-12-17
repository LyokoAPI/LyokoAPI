using System;
using System.Collections.Generic;
using System.Linq;
using LyokoAPI.API;
using LyokoAPI.Events;

namespace LyokoAPI.Commands
{
    public abstract class CommandListener : LAPIListener
    {
        private List<ICommand> Commands = new List<ICommand>();
        protected abstract string Prefix { get; }
        public CommandListener AddCommand(ICommand command)
        {
            Commands.Add(command);
            return this;
        }

        protected CommandListener()
        {
            //Commands = new List<Command>(){new Xana(), new Aelita(), new Devirtualize(), new Hurt(), new Kill(), new Virtualize(), new Heal(), new Frontier(),new Xanafy(), new Translate()};
        }
        
        

        public List<ICommand> GetCommands()
        {
            return Commands;
        }

        public override void onCommandInput(string arg)
        {
            if (!Commands.Any())
            {
                return;
            }
            if (!arg.StartsWith(Prefix))
            {
                return;
            }

            string[] commandargs = arg.Split('.');
            var commandname = commandargs[1]; //The 0th element is the prefix, so the first is the command
            if (commandargs.Length > 2)
            {
                commandargs = commandargs.ToList().GetRange(2, commandargs.Length - 1).ToArray();
            }
            else if (commandargs.Length == 1)
            {
                List<string> CommandNames = new List<string>();
                if (Commands != null)
                {
                    Commands.ForEach(c => { CommandNames.Add(c.Name); });
                    CommandOutputEvent.Call(Prefix, $"Commands: {String.Join(",", CommandNames)}");
                }
            }
            else
            {
                commandargs = new string[] { };
            }
            var command = Commands?.Find(commandd => commandd.Name.Equals(commandname));
            if (command != null)
            {
                command.Run(commandargs);
            }
            else
            {
                CommandOutputEvent.Call(Prefix,$"Unknown command: \"{commandname}\""); 
            }
        }
    }
}
