// File:    CSVStream.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:43:31
// Purpose: Definition of Class CSVStream

using Repository.Csv.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.Csv.Stream
{
    public class CSVStream<E> : ICSVStream<E> where E : class
    {
        private string path;
        private ICSVConverter<E> converter;

        public CSVStream(string path, ICSVConverter<E> converter)
        {
            this.path = path;
            this.converter = converter;
        }

        public void AppendToFile(E entity)
        {
            File.AppendAllText(path, converter.ConvertEntityToCSVFormat(entity) + Environment.NewLine);
        }

        public IEnumerable<E> ReadAll()
        {
            return File.ReadAllLines(path).Select(converter.ConvertCSVFormatToEntity).ToList();
        }

        public void SaveAll(IEnumerable<E> entities)
        {
            WriteAllLinesToFile(entities.Select(converter.ConvertEntityToCSVFormat).ToList());
        }

        public void WriteAllLinesToFile(IEnumerable<string> content)    // Poziva se u okviru SaveAll
            => File.WriteAllLines(path, content.ToArray());
    }
}