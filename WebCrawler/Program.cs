﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Graph;

namespace WebCrawler
{
    /// <summary>
    /// Программа
    /// </summary>
    class Program
    {
        /// <summary>
        /// Первая ссылка сайта
        /// </summary>
        private static Link initialLink;

        /// <summary>
        /// Хранилище ссылок
        /// </summary>
        private static LinkStorage storage;

        /// <summary>
        /// Содержит и строит граф
        /// </summary>
        private static GraphMaker maker = new GraphMaker();

        /// <summary>
        /// Контейнер для посещаемой
        /// в данный момент ссылки
        /// </summary>
        private static Link link = new Link("");

        /// <summary>
        /// Контейнер для результата парсинга
        /// посещаемой в данный момент ссылки
        /// </summary>
        private static List<Link> parseResult = new List<Link>();

        /// <summary>
        /// Ввод с клавиатуры
        /// первой ссылки сайта
        /// </summary>
        /// <returns>Первую ссылку сайта</returns>
        public static Link GetInitialLink()
        {
            Console.WriteLine("Enter url:");
            String line = Console.ReadLine();
            Link link = new Link(line);
            return link;
        }

        /// <summary>
        /// Точка входа в программу
        /// из операционной системы
        /// </summary>
        /// <param name="args">Аргументы,
        /// передаваемые операционной системой</param>
        public static void Main(string[] args)
        {
            initialLink = GetInitialLink();
            storage = new LinkStorage(initialLink);
            while (storage.IsNeedVisit())
            {
                parseResult = storage.Visit(out link);
                if (parseResult.Count > 0)
                {
                    maker.Make(link, parseResult);
                }
            }
            Console.WriteLine(maker.Graph.ToString());
            Console.ReadKey();
        }
    }
}