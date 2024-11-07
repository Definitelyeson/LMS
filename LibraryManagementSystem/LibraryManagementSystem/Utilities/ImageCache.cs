using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Utilities
{
    public static class ImageCache
    {
        // Dictionary to hold the cached images
        private static readonly Dictionary<string, Image> _cache = new Dictionary<string, Image>();

        // Method to retrieve an image from cache
        public static Image GetImage(string path)
        {
            if (_cache.ContainsKey(path))
            {
                return _cache[path];
            }
            return null;
        }

        // Method to store an image in cache
        public static void StoreImage(string path, Image image)
        {
            if (!_cache.ContainsKey(path))
            {
                _cache.Add(path, image);
            }
        }

        // Optional: Method to clear the cache (useful for memory management)
        public static void ClearCache()
        {
            foreach (var image in _cache.Values)
            {
                image.Dispose();
            }
            _cache.Clear();
        }
    }
}
