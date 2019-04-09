using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTDemoService.Services;
using StructureMap;

namespace LTDemoConsole
{
    class Program
    {
        private static readonly Container _container = ConfigureIoC();

        static async Task Main(string[] args)
        {
            var albumService = _container.GetInstance<IAlbumService>();
            var photoService = _container.GetInstance<IPhotoService>();

            var albumId = await AlbumSelection(albumService);

            if (albumId != -1)
                await DisplayPhotoOptions(photoService, albumId);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static Container ConfigureIoC() =>
            new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    x.WithDefaultConventions();
                });
            });

        private async static Task<int> AlbumSelection(IAlbumService albumService)
        {
            var albums = await albumService.GetAlbumOptions();
            var albumId = -1;

            if (albums.Any())
            {
                Console.Clear();
                Console.WriteLine("ALBUMS\n");

                var albumOptions = albums.ToDictionary(o => o.Id, o => o.Title);

                DisplayOptions(albumOptions);

                Console.WriteLine("Enter Album Option (e.g. [4] Album Title - enter 4):");

                while (!int.TryParse(Console.ReadLine(), out albumId) || !albumOptions.Select(s => s.Key).Contains(albumId))
                {
                    Console.WriteLine("Invalid option.");
                    Console.WriteLine("Enter Album Option (e.g. [4] Album Title - enter 4):");
                }
            }
            else
            {
                Console.WriteLine("No albums found.");
            }

            return albumId;
        }

        private async static Task DisplayPhotoOptions(IPhotoService photoService, int albumId)
        {
            var photos = await photoService.GetPhotoOptions(albumId);

            if (photos.Any())
            {
                Console.Clear();
                Console.WriteLine("PHOTOS\n");

                var albumOptions = photos.ToDictionary(o => o.Id, o => o.Title);

                DisplayOptions(albumOptions);
            }
            else
            {
                Console.WriteLine("No photos found.");
            }
        }

        private static void DisplayOptions(IDictionary<int, string> options)
        {
            foreach (var option in options)
            {
                Console.WriteLine($"[{option.Key}] {option.Value}");
            }
        }
    }
}
