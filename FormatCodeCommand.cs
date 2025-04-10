using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace CodePolishFormatter
{
    internal sealed class FormatCodeCommand
    {
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("f78e9b26-2f8a-4ac9-bc01-ff562f7b784b"); // GUID do comando
        private readonly AsyncPackage _package;
        private OleMenuCommand _menuCommand;

        private FormatCodeCommand(AsyncPackage package, IMenuCommandService commandService)
        {
            _package = package ?? throw new ArgumentNullException(nameof(package));

            // Criando o comando e registrando no menu
            var menuCommandID = new CommandID(CommandSet, CommandId);
            _menuCommand = new OleMenuCommand(Execute, menuCommandID);
            commandService.AddCommand(_menuCommand);
        }

        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Obtendo o serviço de comando de forma assíncrona
            var commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as IMenuCommandService;

            if (commandService != null)
            {
                // Inicializando o comando de formatação
                new FormatCodeCommand(package, commandService);
            }
            else
            {
                throw new InvalidOperationException("Não foi possível obter o IMenuCommandService.");
            }
        }

        private void Execute(object sender, EventArgs e)
        {
            // Aqui você pode adicionar a lógica de formatação de código
            VsShellUtilities.ShowMessageBox(
                _package,
                "Code formatted (simulated)!",
                "AutoCodeFormatter",
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
    }
}
