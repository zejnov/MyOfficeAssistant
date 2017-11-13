namespace OfficeAssistant.Commands.Impl
{
    internal class CommandHelp : ICommand
    {
        public string Name => "Help";
        public string HelpInfo => "Printing help informatiosn";
        public void Execute()
        {
            //WriteHelper.PrintAvaibleCommandsHelp();
        }
    }
}
