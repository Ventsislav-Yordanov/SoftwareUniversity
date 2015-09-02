namespace StringEditor
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
                        {
                            string[] parameters = commandInfo.Split(' ');
                            string value = parameters[0];
                            int insertIndex = int.Parse(parameters[1]);

                            try
                            {
                                this.editor.Insert(value, insertIndex);
                                commandResult = "OK";
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                commandResult = "ERROR";
                            }

                            break;
                        }

                    case "APPEND":
                        {
                            this.editor.Append(commandInfo);
                            commandResult = "OK";
                            break;
                        }

                    case "DELETE":
                        {
                            string[] parameters = commandInfo.Split(' ');
                            int deleteIndex = int.Parse(parameters[0]);
                            int count = int.Parse(parameters[1]);

                            try
                            {
                                this.editor.Delete(deleteIndex, count);
                                commandResult = "OK";
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                commandResult = "ERROR";
                            }

                            break;
                        }

                    case "REPLACE":
                        {
                            string[] parameters = commandInfo.Split(' ');
                            int replaceIndex = int.Parse(parameters[0]);
                            int count = int.Parse(parameters[1]);
                            string value = parameters[2];
                            try
                            {
                                this.editor.Replace(replaceIndex, count, value);
                                commandResult = "OK";
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                commandResult = "ERROR";
                            }

                            break;
                        }

                    case "PRINT":
                        {
                            commandResult = this.editor.Print();
                            break;
                        }

                    default:
                        {
                            throw new InvalidOperationException("Invalid command.");
                        }
                }

                Console.WriteLine(commandResult);
            }
        }
    }
}
