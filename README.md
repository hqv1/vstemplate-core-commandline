# vstemplate-core-commandline
Visual Studio template to create .net core applications

## Usage
Go into __Output\Hqv.Core.CommandLine.Application directory

Zip up all the files into Hqv.Core.CommandLine.Application.zip. Make sure you don't zip up the Hqv.Core.CommandLine.Application directory.

Copy the zip file into your Template\ProjectTemplates directory. On my machine this is under C:\Users\...\Documents\Visual Studio 2017\Templates\ProjectTemplates.

Execute the command ```devenv /installvstemplates``` to reset templates. You may need to do this under the Developer Command Prompt.

Open up Visual Studio.

Create a new project. If you search for Hqv, the template should show up. Provide a name hit enter and multiople projects should be created for you.