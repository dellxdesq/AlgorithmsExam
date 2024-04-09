using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ExternalMergeSort
    {
        private const int BufferSize = 4096; // Размер буфера для чтения/записи файлов
        private string InputFilePath; // Путь к исходному файлу
        private string TempDirectoryPath; // Путь к временной директории для промежуточных файлов

        // Конструктор для инициализации путей к файлам
        public ExternalMergeSort(string inputFilePath, string tempDirectoryPath)
        {
            InputFilePath = inputFilePath;
            TempDirectoryPath = tempDirectoryPath;
        }

        // Основной метод для сортировки
        public void Sort()
        {
            // Разбиваем исходный файл на отсортированные части
            SplitFile(InputFilePath, TempDirectoryPath);
            // Сливаем отсортированные части обратно в исходный файл
            MergeSortedParts(TempDirectoryPath);
        }

        // Метод для разделения файла на отсортированные части
        private void SplitFile(string filePath, string tempDir)
        {
            // Используем StreamReader для чтения файла
            using (var reader = new StreamReader(filePath))
            {
                int partNum = 0; // Номер части файла
                while (!reader.EndOfStream)
                {
                    var buffer = new List<string>(); // Буфер для хранения строк части файла
                    int bufferSize = 0; // Размер буфера

                    // Читаем строки из файла, пока не достигнем конца файла или буфер не заполнится
                    while (!reader.EndOfStream && bufferSize < BufferSize)
                    {
                        buffer.Add(reader.ReadLine()); // Добавляем строку в буфер
                                                       // Увеличиваем размер буфера на размер добавленной строки
                        bufferSize += buffer[buffer.Count - 1].Length * sizeof(char);
                    }

                    buffer.Sort(); // Сортируем часть файла
                    string tempFilePath = Path.Combine(tempDir, $"part_{partNum}.txt"); // Путь к временному файлу
                    DeleteIfExists(tempFilePath); // Удаляем временный файл, если он уже существует
                    WriteBufferToFile(buffer, tempFilePath); // Записываем отсортированный буфер во временный файл
                    partNum++; // Увеличиваем номер части для следующей итерации
                }
            }
        }

        // Метод для удаления файла, если он существует
        private void DeleteIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        // Метод для записи буфера в файл
        private void WriteBufferToFile(List<string> buffer, string filePath)
        {
            // Используем StreamWriter для записи в файл
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var line in buffer)
                {
                    writer.WriteLine(line); // Записываем строку из буфера в файл
                }
            }
        }

        // Метод для слияния отсортированных частей обратно в исходный файл
        private void MergeSortedParts(string tempDir)
        {
            string[] partFiles = Directory.GetFiles(tempDir, "part_*.txt"); // Получаем список временных файлов
            int numFiles = partFiles.Length; // Количество временных файлов

            // Пока есть более одного файла для слияния
            while (numFiles > 1)
            {
                int mergedNum = 0; // Номер сливаемого файла

                // Обходим пары файлов для слияния
                for (int i = 0; i < numFiles; i += 2)
                {
                    if (i + 1 < numFiles) // Если есть следующий файл для слияния
                    {
                        // Сливаем текущий файл и следующий файл в новый временный файл
                        MergeFiles(partFiles[i], partFiles[i + 1], Path.Combine(tempDir, $"merged_{mergedNum++}.txt"));
                    }
                    else // Если текущий файл остался без пары
                    {
                        // Переименовываем текущий файл в новое имя, без изменения содержимого
                        File.Move(partFiles[i], Path.Combine(tempDir, $"merged_{mergedNum++}.txt"));
                    }
                }

                // Обновляем список временных файлов и их количество после слияния
                partFiles = Directory.GetFiles(tempDir, "merged_*.txt");
                numFiles = partFiles.Length;
            }

            // Переименовываем последний сливаемый файл в исходное имя
            File.Move(partFiles[0], InputFilePath);
        }

        // Метод для слияния двух файлов в третий файл
        private void MergeFiles(string filePath1, string filePath2, string outputFile)
        {
            // Используем StreamReader для чтения файлов, и StreamWriter для записи в третий файл
            using (var reader1 = new StreamReader(filePath1))
            using (var reader2 = new StreamReader(filePath2))
            using (var writer = new StreamWriter(outputFile))
            {
                string line1 = reader1.ReadLine(); // Читаем первую строку из первого файла
                string line2 = reader2.ReadLine(); // Читаем первую строку из второго файла

                // Пока есть строки для сравнения из обоих файлов
                while (line1 != null && line2 != null)
                {
                    // Сравниваем строки и записываем меньшую в третий файл
                    if (line1.CompareTo(line2) <= 0)
                    {
                        writer.WriteLine(line1);
                        line1 = reader1.ReadLine(); // Читаем следующую строку из первого файла
                    }
                    else
                    {
                        writer.WriteLine(line2);
                        line2 = reader2.ReadLine(); // Читаем следующую строку из второго файла
                    }
                }

                // Записываем оставшиеся строки из первого файла, если они есть
                while (line1 != null)
                {
                    writer.WriteLine(line1);
                    line1 = reader1.ReadLine();
                }

                // Записываем оставшиеся строки из второго файла, если они есть
                while (line2 != null)
                {
                    writer.WriteLine(line2);
                    line2 = reader2.ReadLine();
                }
            }

            // Удаляем исходные файлы после слияния
            File.Delete(filePath1);
            File.Delete(filePath2);
        }
    }
}