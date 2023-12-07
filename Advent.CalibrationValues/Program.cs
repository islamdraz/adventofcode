// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

using (var fileStream = File.OpenRead(".//input.txt"))
{

    using (var streamReader = new StreamReader(fileStream))
    {
        string line ="";
        List<int> numbers= new List<int>();
        Dictionary<string, string> wordToDigitMap = new Dictionary<string, string>()
        {
            { "zero", "0" },
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
            { "0", "o" },
            { "1", "1" },
            { "2", "2" },
            { "3", "3" },
            { "4", "4" },
            { "5", "5" },
            { "6", "6" },
            { "7", "7" },
            { "8", "8" },
            { "9", "9" },
        };

    while(( line = streamReader.ReadLine()) != null)
        {
            int startIndex = 1000;
            int endIndex = -1;
            string tempStartNum  = "";
            string tempEndNum = "";
            foreach (var w in wordToDigitMap) {
                var tempIndex =line.IndexOf(w.Key);
                var lastTempIndex =line.LastIndexOf(w.Key);

                if( tempIndex != -1 && tempIndex < startIndex)
                {
                    startIndex = tempIndex;
                    tempStartNum = w.Value;
                }
                if(lastTempIndex > endIndex )
                {
                    endIndex = lastTempIndex;
                    tempEndNum = w.Value;
                }

            }

            numbers.Add(int.Parse(tempStartNum+""+tempEndNum));
    }

    Console.WriteLine(numbers.Sum());
    Console.WriteLine(string.Join(",",numbers));

        #region  old implementation 
        // one, two, three, four, five, six, seven, eight, and nine
        // while(( line = streamReader.ReadLine()) != null)
        // {
        //     Console.WriteLine(line);


        //         int start = 0;
        //         int end = line.Length;
        //         bool startSuccess = false;
        //         bool endSuccess = false;
               
                
        //         while(line.Contains("one") || line.Contains("two") || line.Contains("three") || line.Contains("four") 
        //                 ||line.Contains("five") ||line.Contains("six")||line.Contains("seven") ||line.Contains("eight")
        //                 ||line.Contains("nine") )
        //         {
                    
        //             if (startSuccess == false && start + 3 <= line.Length)
        //             {                        
        //                 string nWord = line.Substring(start, 3);
        //                 if( wordToDigitMap.ContainsKey(nWord))
        //                 {
        //                    line = ReplaceAt(line, start,nWord.Length, wordToDigitMap[nWord]);
        //                    end = line.Length;
        //                     startSuccess = true;

        //                 }
                   
        //             }
        //             if (endSuccess == false && end - 3 >=  0)
        //             {                        
        //                 string nWord = line.Substring(end - 3, 3);
        //                 if(wordToDigitMap.ContainsKey(nWord))
        //                 {
        //                     line = ReplaceAt(line, end - 3,3, wordToDigitMap[nWord]);
        //                     endSuccess = true;
                           

        //                 }
                   
        //             }
        //             if (startSuccess == false && start + 4 <= line.Length)
        //             {                        
        //                 string nWord = line.Substring(start, 4);
        //                 if(wordToDigitMap.ContainsKey(nWord)){
        //                      line = ReplaceAt(line, start,nWord.Length, wordToDigitMap[nWord]);
        //                     startSuccess = true;
        //                     end = line.Length;                           
        //                 }                        
                      
        //             }

        //             if ( endSuccess == false && end - 4 >= 0)
        //             {                        
        //                 string nWord = line.Substring(end - 4, 4);
        //                 if(wordToDigitMap.ContainsKey(nWord)){
        //                     line = ReplaceAt(line, end - 4,nWord.Length, wordToDigitMap[nWord]);
        //                     endSuccess = true;                           
        //                 }                        
        //             }

        //             if ( startSuccess == false && start + 5 <= line.Length)
        //             {                        
        //                 string nWord = line.Substring(start, 5);
        //                 if(wordToDigitMap.ContainsKey(nWord)){
        //                     line = ReplaceAt(line, start,nWord.Length, wordToDigitMap[nWord]);
        //                     startSuccess = true;
        //                     end = line.Length;
        //                 }                        
        //             }

        //             if ( endSuccess == false && end - 5 >= 0)
        //             {                        
        //                 string nWord = line.Substring(end - 5, 5);
        //                 if(wordToDigitMap.ContainsKey(nWord)){
        //                     line = ReplaceAt(line, end - 5,nWord.Length, wordToDigitMap[nWord]);
        //                     endSuccess = true;

        //                 }                        
        //             }
                 
        //             start ++;
        //             end --;
        //             if (startSuccess && endSuccess)
        //                 break;

        //         }

        //        string nline = string.Join("", line.Where(x=> char.IsDigit(x)).ToArray());
        //         if(nline.Length>2)
        //         {
        //             numbers.Add( int.Parse(nline[0]+""+nline[nline.Length-1]));
        //         }
        //         else if (nline.Length == 2)
        //         {
        //             numbers.Add(int.Parse(nline) );
        //         }
        //         else {
        //              numbers.Add(int.Parse(nline+""+nline) );
        //         }

            

        // }
        // Console.WriteLine(string.Join(",", numbers) );
        // Console.WriteLine(numbers.Sum());
        #endregion
    }

     static string ReplaceAt(string str, int index, int length, string replace)
    {
        return str.Remove(index, Math.Min(length, str.Length - index))
                .Insert(index, replace);
    }

    
}

