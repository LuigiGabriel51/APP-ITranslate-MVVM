using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMVVM.Models
{
    public class TranslationData
    {
        public string Word { get; set; }
        public string Translation { get; set; }
    }

    public class TranslationFileManager
    {
        private string filePath;

        public TranslationFileManager()
        {
            string modelFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Models");

            // Certifica-se de que o diretório exista
            Directory.CreateDirectory(modelFolderPath);

            filePath = Path.Combine(modelFolderPath, "translations.json");
        }

        public void AddTranslation(string word, string translation)
        {
            var translationData = new TranslationData
            {
                Word = word,
                Translation = translation
            };

            List<TranslationData> translationList;
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                translationList = JsonConvert.DeserializeObject<List<TranslationData>>(fileContent);
            }
            else
            {
                translationList = new List<TranslationData>();
            }

            translationList.Add(translationData);

            string updatedContent = JsonConvert.SerializeObject(translationList, Formatting.Indented);
            File.WriteAllText(filePath, updatedContent);
        }

        public List<TranslationData> GetAllTranslations()
        {
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<TranslationData>>(fileContent);
            }

            return new List<TranslationData>();
        }

        public void RemoveTranslation(string word)
        {
            List<TranslationData> translationList;
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                translationList = JsonConvert.DeserializeObject<List<TranslationData>>(fileContent);
            }
            else
            {
                translationList = new List<TranslationData>();
            }

            // Procurar a tradução com base na palavra
            var translationToRemove = translationList.FirstOrDefault(t => t.Word == word);

            if (translationToRemove != null)
            {
                translationList.Remove(translationToRemove);

                // Atualizar o conteúdo do arquivo
                string updatedContent = JsonConvert.SerializeObject(translationList, Formatting.Indented);
                File.WriteAllText(filePath, updatedContent);
            }
        }
    }
}

