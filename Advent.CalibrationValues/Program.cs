// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

using (var fileStream = File.OpenRead(".//input-day2.txt"))
{

    Day2.Day2Fix(fileStream);

    
}

