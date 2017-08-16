// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Extensions.CommandLineUtils;
using System.IO;
using System.Reflection;

namespace KoreBuild.Console.Commands
{
    internal class RootCommand : CommandBase
    {
        public override void Configure(CommandLineApplication application)
        {
            // TODO: ToolsSource DotnetHome, Path, ConfigureFile
            application.FullName = "korebuild";

            application.Command("docker-build", new DockerBuildCommand().Configure, throwOnUnexpectedArg:false);
            application.Command("install-tools", new InstallToolsCommand().Configure);
            application.Command("msbuild", new MSBuildCommand().Configure, throwOnUnexpectedArg:false);
            //application.Command("push-nuget", new PushToNugetCommand().Configure);

            application.VersionOption("--version", GetVersion);
            base.Configure(application);
        }

        private static string GetVersion()
                => typeof(RootCommand).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                    .InformationalVersion;
    }

}
