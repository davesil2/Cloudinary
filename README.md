# Cloudinary .Net SDK Console Application

### How to use

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
            "/file=/Users/david/Downloads/IMG_2019.jpeg",
            "/cloudname=bp-dev",
            "/apikey=162965161671763",
            "/apisecret=1ZJB3fpHF39oxC3wt5hatRMoM0o",
            "/uploadpreset=CoC File Uploads",
            "/folder=Peoplesoft/Certificate of Conformance",
            "/metadata=category=certificates_of_conformance|function=testing"
        ]
    },
    {
        "name": "C#: Launch Startup Project",
        "type": "dotnet",
        "request": "launch"
    }
]
```
### build executable

* Create Independent Single File for execution (no .net dependency)
  * This will be a large file
> dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=True

* Create executable - destination will require .Net framework version

> dotnet publish -c Release -r win-x64 /p:PublishSingleFile=True
