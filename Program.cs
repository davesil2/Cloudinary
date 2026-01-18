using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddCommandLine(args); // 'args' is the array from the Main method

IConfiguration configuration = builder.Build();

String file = configuration["file"];
String uploadpreset = configuration["uploadpreset"];
String folder = configuration["folder"];
String cloudname = configuration["cloudname"];
String apikey = configuration["apikey"];
String apisecret = configuration["apisecret"];
String metadata = configuration["metadata"];

string[] keyValuePairs = metadata.Split('|', StringSplitOptions.RemoveEmptyEntries);

// Use LINQ to process each pair and convert to a StringDictionary
StringDictionary resultDictionary = keyValuePairs
    .Select(item => item.Split('=')) // Split each pair into an array of [key, value]
    .Where(parts => parts.Length == 2) // Ensure we have exactly two parts (key and value)
    .ToDictionary(parts => parts[0], parts => parts[1]) // Convert the results to a standard Dictionary<string, string>
    .Aggregate(new StringDictionary(), (dict, kvp) => { // Aggregate into a StringDictionary
        dict.Add(kvp.Key, kvp.Value);
        return dict;
    });


if (file == null || uploadpreset == null || folder == null || cloudname == null || apikey == null || apisecret == null || metadata == null)
{
    Console.WriteLine("Parameters must be used to upload:");
    Console.WriteLine("");
    Console.WriteLine("\t/file=\"<path to file>\"");
    Console.WriteLine("\t/uploadpreset=\"<upload preset>\"");
    Console.WriteLine("\t/folder=\"<cloudinary folder>\"");
    Console.WriteLine("\t/cloudname=\"<cloudinary cloud name>\"");
    Console.WriteLine("\t/apikey=\"<apikey>\"");
    Console.WriteLine("\t/apisecret=\"<api secret>\"");
    Console.WriteLine("");
    Console.WriteLine("NO CHANGES PERFORMED: provide all values in the command line!");
    Console.WriteLine("");
    Console.WriteLine("EXAMPLE: cloudinary.exe /file=\"c:\\temp\\upload.png\" /uploadpreset=\"Cloudinary Preset\" /folder=\"CloudinaryFolder\" /cloudname=\"cloudinary\" /apikey=\"1234567789\" /apisecret=\"sadkqwekdslkjjksdkfjjksdf\"");
} 
else
{
    Account account = new Account(cloudname,apikey,apisecret);
    Cloudinary cloudinary = new Cloudinary(account);
    cloudinary.Api.SignatureAlgorithm = SignatureAlgorithm.SHA256;

    var uploadParams = new ImageUploadParams()
    {
        File = new FileDescription(file),
        UploadPreset = uploadpreset,
        Folder = folder,
        MetadataFields = resultDictionary
    };

    var uploadResult = cloudinary.Upload(uploadParams);
    Console.WriteLine(uploadResult.JsonObj);
}