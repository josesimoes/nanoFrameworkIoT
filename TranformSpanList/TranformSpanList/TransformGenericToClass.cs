using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace TranformSpanList
{
    public class TransformGenericToClass
    {
        public static void TransformTofile(string templatePath, string typeToTransform, string outputFilePath)
        {
            string contentTemplate = string.Empty;
            using (StreamReader fileTemplate = new StreamReader(templatePath))
            {
                contentTemplate = fileTemplate.ReadToEnd();
            }            

            // Replace generic interfaces by their normal ones
            contentTemplate = contentTemplate.Replace("IEnumerable<T>", "IEnumerable");
            contentTemplate = contentTemplate.Replace("IEnumerator<T>", "IEnumerator");
            // First find all the <T> and replace them with the type
            string capitalTypeToTransform = $"{typeToTransform[0]}".ToUpper() + typeToTransform.Substring(1);
            // Find first <T> then find the constructor and replace the constructor by the new name
            int idxFirstT = contentTemplate.IndexOf("<T>");
            if(idxFirstT<=0)
            {
                throw new Exception($"No <T> in the template");
            }

            int idxLastSpace = contentTemplate.Substring(0, idxFirstT).LastIndexOf(' ');
            string mainType = contentTemplate.Substring(idxLastSpace +1, idxFirstT - idxLastSpace - 1);
            // Find constructor, always public typetosearch( as it's a function
            contentTemplate = contentTemplate.Replace($"public {mainType}(", $"public {mainType}{capitalTypeToTransform}(");

            contentTemplate = contentTemplate.Replace("<T>", capitalTypeToTransform);
            // then arrays
            contentTemplate = contentTemplate.Replace("T[]", $"{typeToTransform}[]");
            // Then simple T but check few combinations
            contentTemplate = contentTemplate.Replace(" T ", $" {typeToTransform} ");
            contentTemplate = contentTemplate.Replace(" T>", $" {typeToTransform}>");
            contentTemplate = contentTemplate.Replace("(T)", $"({typeToTransform})");
            contentTemplate = contentTemplate.Replace("(T ", $"({typeToTransform} ");
            contentTemplate = contentTemplate.Replace(" T)", $" {typeToTransform})");
            contentTemplate = contentTemplate.Replace(" T[", $" {typeToTransform}[");

            using (StreamWriter fileOutput = new StreamWriter(outputFilePath))
            {
                fileOutput.Write(contentTemplate);
            }
        }

    }
}
