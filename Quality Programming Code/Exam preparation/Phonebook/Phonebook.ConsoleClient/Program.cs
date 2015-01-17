namespace Phonebook.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Odbc;
    using System.Data.Sql;
    using System.Data.SqlTypes;
    using System.Linq;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Net.Sockets;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ConsoleClient
    {
        private const string PhoneCodeDefault = "+359";
        // Program shoul use the fast implementation of phonebook repository
        private static IPhonebookRepository phonebookEntriesData = new PhonebookRepository();
        private static StringBuilder output = new StringBuilder();
        // TODO: output can be moved in methods


        public static void Main()
        {
            while (true)
            {
                string currentCommand = Console.ReadLine();
                if (currentCommand == "End" || currentCommand == null)
                {
                    break;
                }

                int indexOfFirstOpeningBracket = currentCommand.IndexOf('(');
                if (indexOfFirstOpeningBracket == -1)
                {
                    throw new ArgumentException(String.Format("Invalid command: {0}. It shoud have \"(\" for parameters", currentCommand));
                }

                string commandName = currentCommand.Substring(0, indexOfFirstOpeningBracket);
                if (!currentCommand.EndsWith(")"))
                {
                    throw new ArgumentException(String.Format("Invalid command: {0}. It shoud have \")\" for parameters", currentCommand));
                }

                string parametersAsString = currentCommand.Substring(indexOfFirstOpeningBracket + 1, currentCommand.Length - indexOfFirstOpeningBracket - 2);
                var parameters = parametersAsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();

                if (commandName.StartsWith("AddPhone") && parameters.Count >= 2)
                {
                    ExecuteCommand("AddPhone", parameters);
                }
                else if ((commandName == "ChangePhone") && (parameters.Count == 2))
                {
                    ExecuteCommand("ChangeРhone", parameters);
                }
                else if ((commandName == "List") && (parameters.Count == 2))
                {
                    ExecuteCommand("List", parameters);
                }
                else
                {
                    throw new InvalidOperationException(String.Format("Invalid command name: {0}.", commandName));
                }
            }

            Console.Write(output);
        }

        private static void ExecuteCommand(string commandName, List<string> parameters)
        {
            if (commandName == "AddPhone")
            {
                string entryName = parameters[0];
                //ToList() is slow operation. Better start from index 1 on the parameters
                var phoneNumbersOnly = new List<string>();

                for (int i = 1; i < parameters.Count; i++)
                {
                    phoneNumbersOnly.Add(Convert(parameters[i]));
                }

                bool isNew = phonebookEntriesData.AddPhone(entryName, phoneNumbersOnly);
                if (isNew)
                {
                    AppendOutput("Phone entry created");
                }
                else
                {
                    AppendOutput("Phone entry merged");
                }
            }
            else if (commandName == "ChangeРhone")
            {
                var numbersChangedCount = phonebookEntriesData.ChangePhone(Convert(parameters[0]), Convert(parameters[1]));
                AppendOutput(numbersChangedCount + " numbers changed");
            }
            else
            {
                try
                {
                    IEnumerable<PhonebookEntry> entries = phonebookEntriesData.ListEntries(int.Parse(parameters[0]), int.Parse(parameters[1]));
                    foreach (var entry in entries)
                    {
                        AppendOutput(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    AppendOutput("Invalid range");
                }
            }
        }

        private static string Convert(string number)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i <= output.Length; i++)
            {
                // Bottleneck 3 repeats blocks of code
                result.Clear();
                foreach (char symbol in number)
                {
                    if (char.IsDigit(symbol) || (symbol == '+'))
                    {
                        result.Append(symbol);
                    }
                }

                if (result.Length >= 2 && result[0] == '0' && result[1] == '0')
                {
                    result.Remove(0, 1);
                    result[0] = '+';
                }

                while (result.Length > 0 && result[0] == '0')
                {
                    result.Remove(0, 1);
                }

                if (result.Length > 0 && result[0] != '+')
                {
                    result.Insert(0, PhoneCodeDefault);
                }
            }

            return result.ToString();
        }

        private static void AppendOutput(string text)
        {
            output.AppendLine(text);
        }
    }
}
