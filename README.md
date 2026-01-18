# Cloudinary .Net SDK Console Application

### How to Use

  Create launch.json file for Debugging
    .vscode/launch.json

```json
"version": "0.2.0",
"configurations": [
    {
        "name": "C#: cloudinary Debug",
        "type": "coreclr",
        "request": "launch",
        "program": "${workspaceFolder}/bin/Debug/net9.0/cloudinary.dll",
        "args": [
            "/file=<file path>",
            "/cloudname=<cloudinary cloud name>",
            "/apikey=<apikey>",
            "/apisecret=<apisecret>",
            "/uploadpreset=<upload preset>",
            "/folder=<folder path>",
            "/metadata=<metadata key=value pair>|<metadata key=value pair"
        ]
    },
    {
        "name": "C#: Launch Startup Project",
        "type": "dotnet",
        "request": "launch"
    }
]
```
### Build Executable

* Create Independent Single File for execution (no .net dependency)
  * This will be a large file
> dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=True

* Create executable - destination will require .Net framework version

> dotnet publish -c Release -r win-x64 /p:PublishSingleFile=True


### Application Usage

> cloudinary.exe /file=<file path> /cloudname=<cloudinary cloud name> /apikey=<api key> /apisecret=<api secret> /uploadpreset=<upload preset> /folder=<cloudinary folder> /metadata=<metadate key=value pair>|metadata key=value pair>
