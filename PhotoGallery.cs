using System.Collections.Generic;

namespace n_json_schema_getting_started
{
    public class PhotoGallery: Entity
    {
        public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();        
    }
}
