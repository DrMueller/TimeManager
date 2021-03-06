﻿using System.IO.Abstractions;
using StructureMap;

namespace Mmu.TimeManager.WpfUI.Infrastructure.DependencyInjection
{
    public class WpfUiRegistry : Registry
    {
        public WpfUiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WpfUiRegistry>();
                    scanner.WithDefaultConventions();
                });

            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}