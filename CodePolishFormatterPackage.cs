using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace CodePolishFormatter
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(CodePolishFormatterPackage.PackageGuidString)]
    public sealed class CodePolishFormatterPackage : AsyncPackage
    {
        public const string PackageGuidString = "246f71ab-51d0-4b7d-b04a-c364b0702930";

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await base.InitializeAsync(cancellationToken, progress);

            // Register the Format Code command
            await FormatCodeCommand.InitializeAsync(this);
        }
    }
}
