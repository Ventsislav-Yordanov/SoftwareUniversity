namespace RopeForEfficientStringEditing
{
    using System;
    using System.Collections.Generic;

    public class StringEditorEngine
    {
        private IStringEditor editor;

        public StringEditorEngine(IStringEditor editor)
        {
            this.editor = editor;
        }

        public StringEditorEngine()
            : this(new StringEditor())
        {
        }

        public void Run()
        {
            string line;
            var lines = new List<string>();
            while (true)
            {
                line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                lines.Add(line);
            }

            foreach (var lineString in lines)
            {
                int commandEndIndex = lineString.IndexOf(' ');
                string commandName = lineString;
                string commandInfo = string.Empty;
                if (commandEndIndex != -1)
                {
                    commandName = lineString.Substring(0, commandEndIndex);
                    commandInfo = lineString.Substring(commandEndIndex + 1);
                }

                string commandResult = string.Empty;
                switch (commandName)
                {
                    case "INSERT":
                        this.editor.Insert(commandInfo);
                        commandResult = "OK";
                        break;
                    case "APPEND":
                        this.editor.Append(commandInfo);
                        commandResult = "OK";
                        break;
                    case "DELETE":
                        try
                        {
                            string[] parameters = commandInfo.Split(' ');
                            int startIndex = int.Parse(parameters[0]);
                            int count = int.Parse(parameters[1]);
                            this.editor.Delete(startIndex, count);
                            commandResult = "OK";
                        }
                        catch (Exception)
                        {

                            commandResult = "ERROR";
                        }
                        break;
                    case "PRINT":
                        commandResult = this.editor.Print();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid command.");
                }

                Console.WriteLine(commandResult);
            }
        }
    }
}
